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
		<script type="text/javascript" src="script/login.js"></script>
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
		
var namemsg = "";
var pswmsg = "";
function username_check() {
	var v = document.getElementById("txtname").value.replace(/(^\s*)|(\s*$)/g,
			"");
	if (v == "" || v == null){
		document.getElementById("labelName").innerHTML = "请输入用户名";
		return false;
	}else{
		document.getElementById("labelName").innerHTML ="";
	}
	return true;
}

function realname_check() {
	var v = document.getElementById("txtrealname").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (v == "" || v == null){
		document.getElementById("labelRealName").innerHTML = "请输入您的真实姓名";
		return false;
	}else{
		document.getElementById("labelRealName").innerHTML ="";
	}
	return true;
}
function address_check() {
	var v = document.getElementById("txtaddress").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (v == "" || v == null){
		document.getElementById("labelAddress").innerHTML = "请输入您的地址";
		return false;
	}else{
	document.getElementById("labelAddress").innerHTML ="";
	}
	return true;
}

function psw1check(){//检查密码输入是否为空
	var psw1=document.registe.password1.value;
	if(psw1==""||psw1==null){
		document.getElementById("labelPsw1").innerHTML="请输入密码";
		return false;
	}else{
		document.getElementById("labelPsw1").innerHTML="";
	}
	return true;
}

function psw_check(){//确认密码两次输入是否相同
	var psw1=document.registe.password1.value;
	var psw= document.getElementById("password2").value;
	if(psw1==""||psw1==null){
		document.getElementById("labelPsw1").innerHTML="请输入密码";
		return false;
	}else if(psw!=psw1){
		document.getElementById("labelPsw2").innerHTML="两次输入密码不同！";
		return false;
	}else{
		document.getElementById("labelPsw1").innerHTML="";
		document.getElementById("labelPsw2").innerHTML="";
	}
	return true;
}

function submit_check() {//检查所有的输入信息的有效性
	
	if (!psw_check()||!psw1check()||!username_check()||!address_check()||!realname_check()){
		alert("请输入有效的注册信息");
		return false;
	}
	return true;
}

function repeatSend(node) {
	node.src="servlet/AuthImageServlet?a=" + new Date();
}
</script>
	</head>
	<body>
		<div class="sample_popup" id="popup"
			style="visibility: hidden; display: none;">
			<div class="menu_form_header" id="popup_drag">
				<img class="menu_form_exit" id="popup_exit" src="images/close.jpg" />

			</div>
			<div class="menu_form_body">
				<form method="post" action="servlet/LoginServlet">

				用户名:
					<input type="text" name="username" />
					<font color="red"><label id="loginErrorMessage">
							${loginErrorMessage }
						</label> </font>
					<br>
					<br>
					密　码:
					<input type="password" name="password" />
					<br>
					<br>
					　　　　　　<input type="submit" value=" 登录 " />
				</form>
			</div>
		</div>
		</div>
		<div id="templatemo_container">
			<div id="templatemo_header">
				<div id="templatemo_logo_area">
				</div>

				<div id="templatemo_about_jump">
					<ul>
					
								<li class="current">
									<a href="#" onclick="popup_show();return false;">登陆</a>
									<a href="register.jsp">立即注册</a>
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

			<form name="registe" method="post" action="servlet/RegisterServlet"
				onsubmit="return submit_check()">

				<br>
				<p>
					<span><font size="5" color="#123989">请填写注册信息</font> </span>
				</p>
				<br>
				<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="" />
				<table>
					<tr>
						<td>
							<p>
								<label>
									用户名 ：
								</label>
							</p>
						</td>
						<td>
							<p>
								<span><input name="username" type="text" maxlength="40"
										id="txtname" onblur="username_check()" /> </span>

							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelName">
										<font color="red" size="3">*${message }</font>
									</label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									登录密码：
								</label>
							</p>
						</td>
						<td>
							<p>
								<input name="password1" type="password" maxlength="30"
									id="txtpwd1" onblur="psw1check()" />
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelPsw1">
										<font color="red" size="3">*</font>
									</label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									确认密码：
								</label>
							</p>
						</td>
						<td>
							<p>
								<input name="password" id="password2" type="password"
									maxlength="30" id="txtpsw2" onblur="psw_check()" />
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelPsw2">
										<font color="red" size="3">*</font>
									</label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									真实姓名：
								</label>
							</p>
						</td>
						<td>
							<p>
								<input name="realname" type="text" id="txtrealname"
									value="${user.realName }" maxlength="20"
									onblur="realname_check()" />
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelRealName">
										<font color="red" size="3">*</font>
									</label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									固定邮箱：
								</label>
							</p>
						</td>
						<td>
							<p>
								<span><input name="email" type="text" maxlength="40"
										value="${user.email }" id="txtemail"
										onfocus="realname_check()" /> </span>
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelEmail"></label>
								</font>
							</p>
						</td>

					</tr>
					<tr>
						<td>
							<p>
								<label>
									电话：
								</label>
							</p>
						</td>
						<td>
							<p>
								<input name="phone" type="text" maxlength="20" id="txtphone"
									value="${user.phone }" />
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelPhone"></label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									固定地址：
								</label>
							</p>
						</td>
						<td>
							<p>
								<span><input name="address" type="text" maxlength="400"
										value="${user.address }" id="txtaddress"
										onblur="address_check()" /> </span>
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelAddress">
										<font color="red" size="3">*</font>
									</label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									邮编：
								</label>
							</p>
						</td>
						<td>
							<p>
								<input name="zipCode" type="text" maxlength="20"
									value="${user.zipCode }" id="txtzipcode" />
							</p>
						</td>
						<td>
							<p>
								<font color="red"> <label id="labelZipCode"></label>
								</font>
							</p>
						</td>
					</tr>
					<tr>
						<td>
							<p>
								<label>
									验证码：
								</label>
							</p>
						</td>
						<td>
							<p>
								<span><input name="authCode" type="text" maxlength="40" />
								</span>
							</p>
						</td>
						<td>
							<p>
								&nbsp;&nbsp;
								<img height="30" width="80" src="servlet/AuthImageServlet"
									onclick="repeatSend(this)" />
								&nbsp;&nbsp;
								<font color="red">${authMessage }</font>
							</p>
						</td>
					</tr>
					<tr>
						<td></td>
						<td>
							<br>
							<button type="submit" name="btn_register">
								提交注册
							</button>
						</td>
					</tr>
				</table>
			</form>
			<br>
			<br>
			<br>


		</div>
		<!-- End of right -->

		</div>
		<!-- End of content_area -->

		</div>
		<!-- End Of Container -->

		<div class="cleaner"></div>
		<div id="templatemo_footer">
			Copyright 漏 2024
			<a href="#">我们的网站</a> | Designed by
			<a href="" target="_parent"></a>
		</div>
	</body>
</html>
