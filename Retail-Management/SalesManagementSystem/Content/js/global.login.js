/*
* Placeholder plugin for jQuery
* ---
* Copyright 2010, Daniel Stocks (http://webcloud.se)
* Released under the MIT, BSD, and GPL Licenses.
*/
(function ($) {
    function Placeholder(input) {
        this.input = input;
        if (input.attr('type') == 'password') {
            this.handlePassword();
        }
        // Prevent placeholder values from submitting
        $(input[0].form).submit(function () {
            if (input.hasClass('placeholder') && input[0].value == input.attr('placeholder')) {
                input[0].value = '';
            }
        });
    }
    Placeholder.prototype = {
        show: function (loading) {
            // FF and IE saves values when you refresh the page. If the user refreshes the page with
            // the placeholders showing they will be the default values and the input fields won't be empty.
            if (this.input[0].value === '' || (loading && this.valueIsPlaceholder())) {
                if (this.isPassword) {
                    try {
                        this.input[0].setAttribute('type', 'text');
                    } catch (e) {
                        this.input.before(this.fakePassword.show()).hide();
                    }
                }
                this.input.addClass('placeholder');
                this.input[0].value = this.input.attr('placeholder');
            }
        },
        hide: function () {
            if (this.valueIsPlaceholder() && this.input.hasClass('placeholder')) {
                this.input.removeClass('placeholder');
                this.input[0].value = '';
                if (this.isPassword) {
                    try {
                        this.input[0].setAttribute('type', 'password');
                    } catch (e) { }
                    // Restore focus for Opera and IE
                    this.input.show();
                    this.input[0].focus();
                }
            }
        },
        valueIsPlaceholder: function () {
            return this.input[0].value == this.input.attr('placeholder');
        },
        handlePassword: function () {
            var input = this.input;
            input.attr('realType', 'password');
            this.isPassword = true;
            // IE < 9 doesn't allow changing the type of password inputs
            if ($.browser.msie && input[0].outerHTML) {
                var fakeHTML = $(input[0].outerHTML.replace(/type=(['"])?password\1/gi, 'type=$1text$1'));
                this.fakePassword = fakeHTML.val(input.attr('placeholder')).addClass('placeholder').focus(function () {
                    input.trigger('focus');
                    $(this).hide();
                });
                $(input[0].form).submit(function () {
                    fakeHTML.remove();
                    input.show()
                });
            }
        }
    };
    var NATIVE_SUPPORT = !!("placeholder" in document.createElement("input"));
    $.fn.placeholder = function () {
        return NATIVE_SUPPORT ? this : this.each(function () {
            var input = $(this);
            var placeholder = new Placeholder(input);
            placeholder.show(true);
            input.focus(function () {
                placeholder.hide();
            });
            input.blur(function () {
                placeholder.show(false);
            });

            // On page refresh, IE doesn't re-populate user input
            // until the window.onload event is fired.
            if ($.browser.msie) {
                $(window).load(function () {
                    if (input.val()) {
                        input.removeClass("placeholder");
                    }
                    placeholder.show(true);
                });
                // What's even worse, the text cursor disappears
                // when tabbing between text inputs, here's a fix
                input.focus(function () {
                    if (this.value == "") {
                        var range = this.createTextRange();
                        range.collapse(true);
                        range.moveStart('character', 0);
                        range.select();
                    }
                });
            }
        });
    }
})(jQuery);

// detect if browser supports transition, currently checks for webkit, moz, opera, ms
var cssTransitionsSupported = false;
(function() {
    var div = document.createElement('div');
    div.innerHTML = '<div style="-webkit-transition:color 1s linear;-moz-transition:color 1s linear;-o-transition:color 1s linear;-ms-transition:color 1s linear;-khtml-transition:color 1s linear;transition:color 1s linear;"></div>';
    cssTransitionsSupported = (div.firstChild.style.webkitTransition !== undefined) || (div.firstChild.style.MozTransition !== undefined) || (div.firstChild.style.OTransition !== undefined) || (div.firstChild.style.MsTransition !== undefined) || (div.firstChild.style.KhtmlTransition !== undefined) || (div.firstChild.style.Transition !== undefined);
    delete div;
})();

// perform JavaScript after the document is scriptable.
$(document).ready(function() {
    $(".tabs > ul").tabs("section > section");
    $(".accordion").tabs(".accordion > section", {tabs: 'header', effect: 'slide', initialIndex: 0});

    $('input[placeholder], textarea[placeholder]').placeholder();

    $("input[type=date]").dateinput();

    $.fn.uniform && $("input:checkbox,input:radio,select,input:file").uniform();
    
    $('#wrapper > section > aside > nav > h2').click(function(e){
        $(this).toggleClass('collapsed').next().toggle(!$(this).hasClass('collapsed')); e.preventDefault();
    });
    
    $('#wrapper > section > section').scrollbar();

    // Animate sidebar if transitions is not supported
    !cssTransitionsSupported && $('#wrapper > section > aside > nav > ul li a').hover(function(){
        $(this).css('padding-right', '20px').stop().animate({paddingRight: 40});
    },function(){
        $(this).stop().animate({paddingRight: 20});
    });
    /**
     * Form Validators
     */
    // Regular Expression to test whether the value is valid
    $.tools.validator.fn("[type=time]", "Please supply a valid time", function (input, value) {
        return(/^\d\d:\d\d$/).test(value);
    });
    
    $.tools.validator.fn("[data-equals]", "Value not equal with the $1 field", function (input) {
        var name = input.attr("data-equals"), 
        field = this.getInputs().filter("[name=" + name + "]");
        return input.val() === field.val() ? true : [name];
    });
    
    $.tools.validator.fn("[minlength]", function (input, value) {
        var min = input.attr("minlength");
        
        return value.length >= min ? true : {
            en : "Please provide at least " + min + " character" + (min > 1 ? "s" : "") 
        };
    });
    
    $.tools.validator.localizeFn("[type=time]", {
        en : 'Please supply a valid time'
    });
    
    /**
     * setup the validators
     */
    $(".has-validation").validator({
        position : 'bottom left', 
        offset : [5, 0], 
        messageClass : 'form-error', 
        message : '<div><em/></div>'// em element is the arrow
    }).attr('novalidate', 'novalidate');

});

var doc, draggable;

$.fn.customdrag = function(conf) {

    // disable IE specialities
    //document.ondragstart = function () { return false; };

    conf = $.extend({x: true, y: true, drag: true}, conf);

    doc = doc || $(document).bind("mousedown mouseup", function(e) {

        var el = $(e.target);  

        // start 
        if (e.type == "mousedown" && el.data("drag")) {

            var offset = el.position(),
                 x0 = e.pageX - offset.left, 
                 y0 = e.pageY - offset.top,
                 start = true;    

            doc.bind("mousemove.drag", function(e) {  
                var x = e.pageX -x0, 
                     y = e.pageY -y0,
                     props = {};

                if (conf.x) { props.left = x; }
                if (conf.y) { props.top = y; } 

                if (start) {
                    el.trigger("dragStart");
                    start = false;
                }
                if (conf.drag) { el.css(props); }
                el.trigger("drag", [y, x]);
                draggable = el;
            }); 

            e.preventDefault();

        } else {

            try {
                if (draggable) {  
                    draggable.trigger("dragEnd");  
                }
            } finally { 
                doc.unbind("mousemove.drag");
                draggable = null; 
            }
        } 

    });

    return this.data("drag", true); 
};	

// Custom Vertical Scrollbar
// @author Bryan Briosos
// @license MIT, GPL2
(function($){
    $.fn.extend({
        scrollbar: function() {
            this.each(function(i) {
                $base = $(this);
                $base.wrapInner('<div class="viewport"/>').prepend('<div class="scrollbar-vertical"><div class="scrollbar-button-start"></div><div class="scrollbar-track-piece"><div class="scrollbar-thumb" style="top: 0"></div></div><div class="scrollbar-button-end"></div></div>');
                var $scrollbar = $('> .scrollbar-vertical', $base);
                $scrollbar[0].onselectstart = function() {return false;}
                var thumbheight = 0, trackheight = 0, barheight = 0, dragstart = false;
                
                var init = function(){
                    barheight = $scrollbar.height($base.height()).height();
                    trackheight = $('.scrollbar-track-piece', $scrollbar).height(barheight - ($('.scrollbar-button-start', $scrollbar).height() + $('.scrollbar-button-end', $scrollbar).height())).height();
                    thumbheight = $('.scrollbar-thumb', $scrollbar).height(Math.round(barheight * trackheight / $('> .viewport', $base)[0].scrollHeight)).height();
                    if (thumbheight >= trackheight) {
                        $('.scrollbar-thumb', $scrollbar).hide();
                    } else {
                        $('.scrollbar-thumb', $scrollbar).show();
                    }
                };
                init();
                
                setInterval(init, 1000);
                
                var updateDragTop = function(newpos) {
                    $('.scrollbar-thumb', $scrollbar).css('top', newpos + 'px');
                };

                $('> .viewport', $base).scroll(function(event) {
                    if (!dragstart) { // if the scroll thumb wasn't dragged
                        var newpos = Math.round($('> .viewport', $base).scrollTop() * $('.scrollbar-track-piece', $scrollbar).height() / $('> .viewport', $base)[0].scrollHeight);
                        if (newpos != parseInt($('.scrollbar-thumb', $scrollbar).css('top'))) {
                            updateDragTop(newpos);
                        }
                    }
                    
                    // fix date position
                    $("input.date").each(function(){
                        var api = $(this).data("dateinput");
                        if (api.isOpen()) {
                            api.hide().show();
                        }
                    });
                    // fix the validator position
                    $(".has-validation").each(function(){
                        $(this).data("validator").reflow();
                    });
                });
                
                $('.scrollbar-thumb', $scrollbar).customdrag({x: false}).bind("dragStart", function(){
                    dragstart = true;
                }).bind("drag", function(event, x, y) {
                    if (parseInt($(this).css('top')) < 0) {
                        $(this).css('top', '0px').trigger('dragEnd');
                        return false;
                    }
                    if (parseInt($(this).css('top')) > trackheight - thumbheight) {
                        $(this).css('top', (trackheight - thumbheight) + 'px').trigger('dragEnd');
                        return false;
                    }
                    $('> .viewport', $base).scrollTop($('> .viewport', $base)[0].scrollHeight / trackheight * parseInt($(this).css('top')));
                }).bind("dragEnd", function(){
                    $('> .viewport', $base).animate({scrollTop: $('> .viewport', $base)[0].scrollHeight / trackheight * parseInt($(this).css('top'))}, 100, 'linear', function(){
                        dragstart = false;
                    });
                }).parent().mousedown(function(e){
                    if (e.pageY > $('.scrollbar-thumb', $scrollbar).offset().top + thumbheight) {
                        $('> .viewport', $base).animate({scrollTop: '+='+$base.height()}, 'fast', 'swing');
                    }
                    if (e.pageY < $('.scrollbar-thumb', $scrollbar).offset().top) {
                        $('> .viewport', $base).animate({scrollTop: '-='+$base.height()}, 'fast', 'swing');
                    }
                });
            });
        }
    });
})(jQuery);