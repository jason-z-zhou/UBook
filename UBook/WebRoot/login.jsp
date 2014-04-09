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
		<base href="<%=basePath %>" />
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>我亲爱的网上书店</title>
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
					密 码:
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
							<a href="#" onclick="popup_show();return false;">登陆</a>，
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


			<div id="templatemo_content">
				<span class="top"></span>
				<div id="templatemo_innter_content">

					<div id="templatemo_content_left">
						<h1>
							Welcome to our website
						</h1>
						<img src="" />
						>
						<div style="clear: both; padding: 30px 0 20px 0;">

						</div>

						<div class="cleaner_with_height">
							&nbsp;
						</div>

					</div>
					<!-- end of content left -->

					<div id="templatemo_content_right">
						<h1>
							欢迎登录
						</h1>
						<div class="right_column_section">


							<h1>
								<a href="" name="logo"></a>
							</h1>



							<font color="red">${message }</font>
							<form action="servlet/LoginServlet" method="post">
							<input type="hidden" value="false" name="isLoginFrame"/>
								<p id="input_email">
									<label>
										用户名 ：
									</label>
									<span><input name="username" type="text" maxlength="40" />
								</p>
								<br>

								<p>
									<label>
										密&nbsp;&nbsp;码 ：
									</label>
									<span><input name="password" type="password"
											maxlength="40" /> </span>
								</p>
								<br />

								<br>
								<br>
								<br>

								<p class="">
									<input type="submit" value=" 登录 ">
								</p>
							</form>
							<br>
							<br>
							<br>
							<br>


							<div class="login_frame_bottom"></div>
						</div>
						<div class="clear"></div>
					</div>







				</div>

			</div>
			<!-- end of content right -->
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<div class="cleaner">
				&nbsp;
			</div>
		</div>
		<div class="cleaner" style="background: #fff;">
			&nbsp;
		</div>
		</div>

		<div id="templatemo_footer" top=1000000px>
			Copyright 漏 2024
			<a href="#">我们的网站</a> | Designed by
			<a href="" target="_parent"></a>
		</div>

	</body>
</html>









