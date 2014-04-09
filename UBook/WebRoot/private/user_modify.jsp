<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%
	String path = request.getContextPath();
	String basePath = request.getScheme() + "://"
			+ request.getServerName() + ":" + request.getServerPort()
			+ path + "/";
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

<script type = "text/javascript" >


	function address_check() {
		var v = document.getElementById("address").value.replace(
				/(^\s*)|(\s*$)/g, "");
		if (v == "" || v == null){
			document.getElementById("labelAddress").innerHTML = "请输入您的地址";
		}else{
		document.getElementById("labelAddress").innerHTML ="";
		}
	}

	function realName_check() {
		var v = document.getElementById("realName").value.replace(
				/(^\s*)|(\s*$)/g, "");
		if (v == "" || v == null){
			document.getElementById("labelRealName").innerHTML = "请输入您的真实姓名";
			}else{
				document.getElementById("labelRealName").innerHTML ="";
		}
	}

	function password1_check() {
		var v = document.getElementById("txtpsd1").value.replace(
				/(^\s*)|(\s*$)/g, "");
		if (v == "" || v == null){
			document.getElementById("lblPassword1").innerHTML = "请输入您的密码";
			}else{
			document.getElementById("lblPassword1").innerHTML ="";
			}
	}

	function password2_check() {
		var v = document.getElementById("txtpsd2").value.replace(
				/(^\s*)|(\s*$)/g, "");
		if (v == "" || v == null){
			document.getElementById("lblPassword2").innerHTML = "请输入您的密码";
			}else{
			document.getElementById("lblPassword2").innerHTML ="";
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
				<span><font size="5" color="#123487"> 修改个人信息</font>
				</span>
			</p>
			<br>


				<form method="post" action="private/servlet/ModifyUserServlet">

					<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="" />
					<table>
						<tr>
							<td>
								<p id="input_email">
									<label>
										用户名 ：
									</label>
							</td>
							<td>
								<span><input name="username" type="text" maxlength="40"
										id="username" value="${user.userName}" disabled="disabled"/>（不能修改）</span>
							</td>
							</p>
						</tr>
						<tr>
							<td>
								<p>
									<label>
										原始密码：
									</label>
							</td>
							<td>
								<input name="prePassword" type="password" maxlength="20" id="txtpsd1"
									onblur="password1_check()" /><font color="red"><label id="lblPassword1">*${message }</label></font>
							</td>
							</p>
						</tr>
						<tr>
							<td>
								<p>
									<label>
										更改密码：
									</label>
							</td>
							<td>
								<span><input name="password" type="password" id="txtpsd2"
										maxlength="20" onblur="password2_check()"/><font color="red"><label id="lblPassword2">*</label></font>
								</span>
							</td>
							</p>
						</tr>
						
						<tr>
							<td>
								<p>
									<label>
										邮箱：
									</label>
							</td>
							<td>
								<span><input name="email" type="text" maxlength="40"
										value="${user.email }"/> </span>
								</p>
							</td>
						</tr>
						<tr>
							<td>
									<label>
										地址：
									</label>
							</td>
							<td>
								<span><input name="address" type="text" value="${user.address}" maxlength="40" id="address"
										onblur="address_check()" /> <font color="red"><label id="labelAddress">*</label></font></span>
							</td>
							</p>
							
						</tr>
							<tr>
							<td>
								<p>
									<label>
										真实姓名：
									</label>
							</td>
							<td>
								<span><input name="realName" type="text" value="${user.realName}" maxlength="40" id="realName"
										onblur="realName_check()" /> <font color="red"><label id="labelRealName">*</label></font></span>
							</td>
							</p>
							
						</tr>
						
						<tr>
							<td>
								<p>
									<label>
										邮编：
									</label>
							</td>
							<td>
								<span><input name="zipCode" type="text" value="${user.zipCode}" maxlength="40"
										/> </span>
							</td>
							</p>
						</tr>
						<tr>
							<td>
								<p>
									<label>
										电话：
									</label>
							</td>
							<td>
								<span><input name="phone" type="text" value="${user.phone}" maxlength="40"
										 /> </span>
							</td>
							</p>
						</tr>
					<tr><td></td><td><br/>
					<p>
						
						<input type="submit" value="保存修改">
					</p></td></tr></table>
					<br>
						<br>
				</form>


<br/><br/><br/><br/><br/><br/>
</div><!-- End of right -->
        
        </div> <!-- End of content_area -->
        
    </div><!-- End Of Container -->
				<div class="cleaner"></div>
				<div id="templatemo_footer">
					Copyright 漏 2024
					<a href="#">我们的网站</a> | Designed by
					<a href="" target="_parent"></a>
				</div>
	</body>
</html>


