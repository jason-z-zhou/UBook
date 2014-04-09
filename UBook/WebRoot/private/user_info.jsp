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
				<span><font size="5" color="#123487"> 您的个人信息</font>
				</span>
			</p>
			<br>

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
								<p><label>${user.userName }</label></p>
							</td>
							
						</tr>
						<tr>
							<td>
								<p>
									<label>
										密码：
									</label>
							</td>
							<td>
								<p><label>XXX</label></p>
							</td>
						</tr>
						<tr>
							<td>
								<p>
									<label>
										邮箱：
									</label>
									</p>
							</td>
							<td>
								<p><label>${user.email }</label></p>
							</td>
						</tr>
						<tr>
							<td>
								<p>
									<label>
										地址：
									</label>
									</p>
							</td>
							<td>
								<p><label>${user.address }</label></p>
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
								<p><label>${user.realName }</label></p>
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
								<p><label>${user.zipCode }</label></p>
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
								<p><label>${user.phone}</label></p>
							</td>
						</tr>
					<tr><td></td><td><br/>
						
						<form action="private/user_modify.jsp" method="post">
						<input type="button" value=" 返回 " name="btn_register" onclick="javascript:history.go(-1);">
							<input type="submit" value=" 修改 "/>
						</form>
					</td></tr></table>
					<br>
						<br>


     </div><!-- End of right -->
        
        </div> <!-- End of content_area -->
        
    </div><!-- End Of Container --><br/><br/><br/><br/><br/><br/>

				<div class="cleaner"></div>
				<div id="templatemo_footer">
					Copyright 漏 2024
					<a href="#">我们的网站</a> | Designed by
					<a href="" target="_parent"></a>
				</div>
	</body>
</html>


