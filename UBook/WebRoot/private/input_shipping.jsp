<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
	String basePath = request.getScheme() + "://"
			+ request.getServerName() + ":" + request.getServerPort()
			+ path + "/";
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<base href="<%=basePath%>" />
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>我亲爱的网上书店啦啦啦</title>
		<meta name="keywords" content="" />
		<meta name="description" content="" />
		<link href="templatemo_style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
	function changeInfo(){
		var box = document.getElementById("useMyAddress").checked;
		if( box){
			document.getElementById("recipientName").value="";
			document.getElementById("address").value="";
			document.getElementById("phone").value="";
			document.getElementById("zipCode").value="";
			document.getElementById("labelAddress").innerHTML="";
			document.getElementById("labelRecipentName").innerHTML="";
			document.getElementById("labelZipCode").innerHTML="";
			document.getElementById("labelPhone").innerHTML="";
			document.getElementById("recipientName").disabled=true;
			document.getElementById("address").disabled=true;
			document.getElementById("phone").disabled=true;
			document.getElementById("zipCode").disabled=true;
			return true;
		}else{
			document.getElementById("recipientName").disabled=false;
			document.getElementById("address").disabled=false;
			document.getElementById("phone").disabled=false;
			document.getElementById("zipCode").disabled=false;
			return false;
		}		
	}
	
	function RecipientName_check(){
		if(!changeInfo()){
			var name = document.getElementById("recipientName").value.replace(/(^\s*)|(\s*$)/g, "");
			if(name==""||name==null){
				document.getElementById("labelRecipentName").innerHTML=" 请输入收件人";
				return false;
			}else{
				document.getElementById("labelRecipentName").innerHTML="";
				return true;
				}
		}
	}
		
	function Address_check(){
		var box = document.getElementById("useMyAddress").checked;
		if(!box){
			var address = document.getElementById("address").value.replace(/(^\s*)|(\s*$)/g, "");
			if(address==""||address==null){
				document.getElementById("labelAddress").innerHTML=" 请输入收件人地址";
				return false;
			}else{
				document.getElementById("labelAddress").innerHTML="";
				return true;
				}
		}
	}
	
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
	
	function submit_check() {
		if(!changeInfo()){
			if (!RecipientName_check()||!Address_check()) {
			alert("收件人信息有误,请重新输入");
			return false;
		}
		
	}
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
								<li class="current">
									<a href="#" onclick="popup_show();return false;">登陆</a>，
									<a href="register.jsp">立即注册</a>
								</li>
								<li class="current">
									<a href="private/user_info.jsp">${user.userName }</a>，你好！
									<a href="private/servlet/LogoutServlet">注销</a>
								</li>
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
					&nbsp;&nbsp;
					<input type="radio" name="searchMethod" value="author" />
					按作者
					<input type="radio" name="searchMethod" value="name"
						checked="checked" />
					按书名
					<form action="#" method="post">
						<input type="text" name="searchText" id="searchText" class="field" />
						<input type="button" name="search" value="" alt="Search"
							class="button" title="搜索" onclick="searchBooks()" />
					</form>

				</div>

				<div id="templatemo_menu">
					<ul>
						<li>
							<a href="servlet/IndexServlet" class="current">首页</a>
						</li>
						<li>
									<a href="servlet/ShowByCategoryServlet?category=人文社科">人文社科</a>
								</li>
								<li>
									<a href="servlet/ShowByCategoryServlet?category=管理技术">管理技术</a>
								</li>
								<li>
									<a href="servlet/ShowByCategoryServlet?category=科技前沿">科技前沿</a>
								</li>
								<li>
									<a href="servlet/ShowByCategoryServlet?category=少儿读物">少儿读物</a>
								</li>
								<li>
									<a href="servlet/ShowByCategoryServlet?category=艺术体育">艺术体育</a>
								</li>
					</ul>
				</div>
				<!-- end of menu -->

			</div>




			<br>
			<p>
				<span><font size="5" color="#121887">填写邮寄信息：</font></span>
			</p>
			<br>


			<form  method="post" action="private/servlet/AddShippingInfoServlet" id="register_form" onsubmit="return submit_check()">
				
					<p><label>
						<input type="checkbox" name="useMyAddress" id="useMyAddress" value="true" onclick="changeInfo()"/>
						邮到我的地址</label>
					</p>

					<table><tr>
					<p id="input_email"><td>
						<label>
							收&nbsp;&nbsp;件&nbsp;&nbsp;人 ：
						</label></td><td>
						<span><input id ="recipientName" name="recipientName" type="text"
								maxlength="40" onblur="RecipientName_check()" /> </span></td>
								<td><font color="red"><label id="labelRecipentName">*</label></font></td>
					</p></tr><tr>
					<p><td>
						<label>
							收件人地址&nbsp;：
						</label></td><td>
						<span><input name="address" id="address" type="text" maxlength="40" onblur="Address_check()"/>
						</span></td>
						<td><font color="red"><label id="labelAddress">*</label></font></td>
					</p></tr><tr>

					<p><td>
						<label>
							邮&nbsp;&nbsp;&nbsp; 编&nbsp;：
						</label></td><td>
						<span><input name="zipCode" id="zipCode"  type="text" maxlength="40" onblur="ZipCode_check()" />
						</span></td>
						
					<td><font color="red"><label id="labelZipCode"></label></font></td></p></tr><tr>
					<p><td>
						<label>
							电 话：
						</label></td><td>
						<span><input name="phone" id="phone" type="text" maxlength="40" onblur="Phone_check()"
								 /> </span></td>
					<td><font color="red"><label id="labelPhone"></label></font></td></p></tr>
					<tr>
					<p><td>
						<label>
							邮寄方式&nbsp;：&nbsp;</td>
<td>
							<select name="method">
								<option value="圆通">
									圆通
								</option>
								<option value="申通">
									申通
								</option>
								<option selected="selected" value="EMS">
									EMS
								</option>
								<option value="中通">
									中通
								</option>
							</select></td>
						</label>
					</p></tr><tr><td>
					
							<p>
								<br/>
								<input type="submit" value=" 继续 " onclick="" />
							</p></td></td><td></tr>
							
				</table>
				<br>
					<br>
						<br>
			</form>


  </div><!-- End of right -->
        
        </div> <!-- End of content_area -->
<br/><br/><br/><br/><br/><br/><br/>
			<div class="cleaner"></div>
			<div id="templatemo_footer">
				Copyright 漏 2024
				<a href="#">我们的网站</a> | Designed by
				<a href="" target="_parent"></a>
			</div>
	</body>
</html>



