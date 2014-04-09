<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<base href="<%=basePath%>">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我亲爱的网上书店啦啦啦</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="templatemo_style.css" rel="stylesheet" type="text/css" /> 

<script type="text/javascript">
function searchBooks() {
	var searchMethod = "name";

	for(var i=0;i<document.getElementsByName("searchMethod").length-1;i++) {
		if(document.getElementsByName("searchMethod")[i].checked) {
			searchMethod = document.getElementsByName("searchMethod")[i].value;
		}
	}

	var searchText = document.getElementById("searchText").value
	location.href = "${pageContext.request.contextPath}/servlet/SearchBookServlet?searchMethod="+searchMethod+"&searchText="+searchText;
}
</script>
 
</head>
<body>
	<div id="templatemo_container"> 
    	<div id="templatemo_header">
        	<div id="templatemo_logo_area">
          </div>
         
   <div id="templatemo_about_jump">
               <ul>
				<li class="current"><a href="private/user_info.jsp">${user.userName }</a>，你好！　<a href="private/servlet/LogoutServlet">注销</a></li>
         				
				<li class="current">
					<a href="servlet/ShowCartServlet">购物车</a>
				</li>
				<li class="current">
					<a href="private/servlet/ShowUserOrderServlet">我的以往订单</a>
				</li>
				<li class="current">
					<a href="help.jsp">帮助</a>
				</li>
			</ul>  
       </div> 
 
            <div id="templatemo_social">
              <form action="#" method="post">
                	  <input type="text" value="" name="q" class="field"  title="email" onfocus="clearText(this)" onblur="clearText(this)" />
                	  <input type="submit" name="search" value = "" alt="Search" class="button" title="Subscribe" />
            	</form>
                
            </div>
            
            <div id="templatemo_menu">
                <ul>
                    <li><a href="servlet/IndexServlet" class="current">首页</a></li>
                    <li><a href="#">分类搜索</a></li>
                    <li><a href="#">畅销排行</a></li>
                    <li><a href="#">某A</a></li>
                    <li><a href="#">某B</a></li>
                    <li><a href="#" class="last">某C</a></li>
                </ul>    	
    		</div> <!-- end of menu -->
            
        </div>
        
        <div id="templatemo_content_area">
        
        	<div id="templatemo_left">
            	<div class="templatemo_section_1">
                	<div class="top">
                    	<h1>分类搜索</h1>
                    </div>
               <div class="item">    
              <ul>
                <li><a href="">人文社科</a></li>
                <li><a href="">管理技术</a></li>
                <li><a href="">科技前沿</a></li>
                <li><a href="">少儿读物</a></li>
                <li><a href="">艺术体育</a></li>					    </ul>
             </div>
                        </div>
                   
                <div class="templaemo_h_line"></div>
                
                <div class="templatemo_section_2">
                	<h1>畅销排行</h1>
                	<c:choose>
	                	<c:when test="${empty topBookList}">
	                		<h3>无数据</h3>
	                	</c:when>
	                	<c:otherwise>
		                	<c:forEach items="${topBookList}" var="book">
		                    <div>
		                    	<h3><a href="servlet/ShowBookDetailServlet?isbn=${book.isbn }"><font color="blue">${book.name }</font></a></h3 >
		                        <p>价格：￥${book.price }</p>
		                    </div>
	                    	</c:forEach>
	                    </c:otherwise>
                    </c:choose>
                </div>
                
                <div class="templaemo_h_line"></div>
                
               </div><!-- End of left -->
            
            <div id="templatemo_right">
                    
                    
                	
                </div>
            
            </div><!-- End of right -->
        
        </div> <!-- End of content_area -->
        
    </div><!-- End Of Container -->
    <div class="cleaner"></div>
     <div id="templatemo_footer">
        	Copyright 漏 2024 <a href="#">我们的网站</a> | Designed by <a href="" target="_parent"></a>    
        </div>
 
</body>
</html>
 
 

