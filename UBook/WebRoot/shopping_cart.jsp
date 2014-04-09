<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt"%>
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
		<title>我亲爱的网上书店</title>
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
		
	function updateQty() {
		var qty = document.getElementsByName("qty");
		var qtyArray = new Array(qty.length);

		for(var i=0;i<qty.length;i++) {
			qtyArray[i] = qty[i].value;
		}
		window.self.location = "${pageContext.request.contextPath}/servlet/ChangeQtyServlet?qty="+qtyArray;
	}


	//检查购物车中是否为空
	function check_order() {
		if(${empty userOrder.orderItemList}) {
			alert("购物车为空，请购买！");
			return;
		}
		window.self.location="${pageContext.request.contextPath}/private/input_shipping.jsp";
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
					<input type="text" name="username" onfocus="select();" />
					<font color="red"><label id="loginErrorMessage">
							${loginErrorMessage }
						</label> </font>
					<br>
					<br>
					密　码:
					<input type="password" name="password" onfocus="select();" />
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
						<c:choose>
							<c:when test="${empty user }">
								<li class="current">
									<a href="#" onclick="popup_show();return false;">登陆</a>，
									<a href="register.jsp">立即注册</a>
								</li>
							</c:when>
							<c:otherwise>
								<li class="current">
									<a href="private/user_info.jsp">${user.userName }</a>，你好！
									<a href="private/servlet/LogoutServlet">注销</a>
								</li>
							</c:otherwise>
						</c:choose>
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

			<h1>
				我的购物车
			</h1>


			<br>
			<br>
			<table>

				<tr bgcolor=#CCCCCC height="40">
					<th style="font-family: 楷体; font-size: 14pt;">
						<b>书本isbn</b>
					</th>
					<th style="font-family: 楷体; font-size: 14pt;">
						<b>书名</b>
					</th>
					<th style="font-family: 楷体; font-size: 14pt;">
						<b>购买数量</b>
					</th>
					<th style="font-family: 楷体; font-size: 14pt;">
						<b>图书单价</b>
					</th>
					<th style="font-family: 楷体; font-size: 14pt;" colspan="2">
						<b>总价</b>
					</th>
				</tr>
				<c:set value="0" var="totalPrice" scope="page" />
				<c:forEach items="${userOrder.orderItemList}" var="orderItem">
					<tr bgcolor=#CCCCCC height="40">
						<td style="font-family: 楷体; font-size: 14pt;">
							${orderItem.book.isbn}
						</td>
						<td style="font-family: 楷体; font-size: 14pt;">
							${orderItem.book.name}
						</td>
						<td style="font-family: 楷体; font-size: 14pt;">
							<INPUT type="text" name="qty" value="${orderItem.qty}" size="10">
						</td>
						<td style="font-family: 楷体; font-size: 14pt;" align="right">
							￥${orderItem.book.price }
						</td>
						<td style="font-family: 楷体; font-size: 14pt;">
							<fmt:formatNumber var="booksPrice"
								value="${orderItem.book.price * orderItem.qty}" pattern="￥.00" />
							${booksPrice }
						</td>
						<td style="font-family: 楷体; font-size: 14pt;" align="center">
							<FORM METHOD="post"
								ACTION="servlet/DeleteBookServlet?isbn=${orderItem.book.isbn }">
								<INPUT type="submit" value="移除" NAME="移除">
							</FORM>
						</td>
					</tr>
					<c:set
						value="${totalPrice + orderItem.book.price * orderItem.qty }"
						var="totalPrice" scope="page" />
				</c:forEach>

				<tr bgcolor=#CCCCCC height="40">
					<td colspan="4" align="right">
						<b>应付:</b>
					</td>
					<fmt:formatNumber var="totalPrice" value="${totalPrice }"
						pattern="￥.00" />
					<td style="font-family: 楷体; font-size: 14pt;">
						${totalPrice }
					</td>
					<td style="font-family: 楷体; font-size: 14pt;" align="center">
						<INPUT type="button" value="更新" onclick="updateQty()">
					</td>
				</tr>

				<tr bgcolor=#CCCCCC height="60">
					<td colspan="6" style="font-family: 楷体; font-size: 14pt;"
						align="right">
						<align= "bottom">
						<INPUT type="button" value="核算" NAME="核算" onclick="check_order()">
					</td>
				</tr>
			</table>

		</div>
		<!-- End of right -->

		</div>
		<!-- End of content_area -->

		</div>
		<!-- End Of Container -->
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<div class="cleaner"></div>
		<div id="templatemo_footer">
			Copyright 漏 2024
			<a href="#">我们的网站</a> | Designed by
			<a href="" target="_parent"></a>
		</div>

	</body>
</html>

