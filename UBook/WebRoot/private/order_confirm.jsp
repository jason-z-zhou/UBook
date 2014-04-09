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
		<base href="<%=basePath%>" />
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>我亲爱的网上书店啦啦啦</title>
		<meta name="keywords" content="" />
		<meta name="description" content="" />
		<link href="templatemo_style.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript">
function recipientName_check() {
	var name = document.getElementById("recipientName").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (name == "" | name == null) {
		document.getElementById("labelRecipientName").innerHTML = "请输入有效的收件人姓名";
		document.getElementById("sub").innerHTML = "         ";
	} else {
		document.getElementById("labelRecipientName").innerHTML = "";
	}
}

function address_check() {
	var add = document.getElementById("address").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (add == "" | add == null) {
		document.getElementById("labelAddress").innerHTML = "请输入有效的收件人地址";
		document.getElementById("sub").innerHTML = "         ";
	} else {
		document.getElementById("labelAddress").innerHTML = "";
	}
}

function zipCode_check() {
	var zc = document.getElementById("zipCode").value.replace(/(^\s*)|(\s*$)/g,
			"");
	if (zc == "" | zc == null) {
		document.getElementById("labelZipCode").innerHTML = "请输入有效的收件人邮编";
		document.getElementById("sub").innerHTML = "         ";
	} else {
		document.getElementById("labelZipCode").innerHTML = "";
	}
}

function phone_check() {
	var phone = document.getElementById("phone").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (phone == "" | phone == null) {
		document.getElementById("labelPhone").innerHTML = "请输入有效的收件人电话";
		document.getElementById("sub").innerHTML = "         ";
	} else {
		document.getElementById("labelPhone").innerHTML = "";
	}
}

function submit_check() {
	var name = document.getElementById("recipientName").value.replace(
			/(^\s*)|(\s*$)/g, "");
	var add = document.getElementById("address").value.replace(
			/(^\s*)|(\s*$)/g, "");
	var zc = document.getElementById("zipCode").value.replace(/(^\s*)|(\s*$)/g,
			"");
	var phone = document.getElementById("phone").value.replace(
			/(^\s*)|(\s*$)/g, "");
	if (name == "" || name == null || add == "" || add == null || zc == ""
			|| zc == "" || phone == "" || phone == null) {
		alert("收件人信息有误,请重新输入");
		return false;
	}
}

function nameOnCard_check() {
	var noc = document.getElementById("nameOnCard").value.replace(/(^\s*)|(\s*$)/g, "");
	if (noc == "" || noc == null) {
		document.getElementById("labelNameOnCard").innerHTML = "请输入持卡人姓名";
	} else {
		document.getElementById("labelNameOnCard").innerHTML = "";
	}
}

function cardNum_check() {
	var cn= document.getElementById("cardNum").value.replace(/(^\s*)|(\s*$)/g, "");
	if (cn == "" || cn == null) {
		document.getElementById("labelCardName").innerHTML = "请输入卡号";
	} else {
		document.getElementById("labelCardName").innerHTML = "";
	}
}

function expirationDate_check() {
	var ed = document.getElementById("year").value.replace(/(^\s*)|(\s*$)/g, "");
	if (ed == "" || ed == null) {
		document.getElementById("labelExpirationDate").innerHTML = "请输入此卡到期日期";
	} else {
		document.getElementById("labelExpirationDate").innerHTML = "";
	}
}

function type_check() {
	var type = document.getElementById("type").value.replace(/(^\s*)|(\s*$)/g,"");
	if (type == "" || type == null) {
		document.getElementById("labelType").innerHTML = "请输入此卡所属银行";
	} else {
		document.getElementById("labelType").innerHTML = "";
	}
}

function submit_checkcard(){
	var noc = document.getElementById("nameOnCard").value.replace(/(^\s*)|(\s*$)/g, "");
	var cn = document.getElementById("cardNum").value.replace(/(^\s*)|(\s*$)/g, "");
	var ed = document.getElementById("year").value.replace(/(^\s*)|(\s*$)/g, "");
	var type = document.getElementById("type").value.replace(/(^\s*)|(\s*$)/g,"");
	if(noc == "" || noc == null||cn == "" || cn == null||ed == "" || ed == null||type == "" || type == null){
		alert("请输入有效的银行卡信息");
		return false;
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
				<font size="5" color="#123389"><span>确认订单信息：</span>
				</font>
			</p>
			<br>

				<form name="register_form" method="post"
					action="private/servlet/ModifyShippingInfoServlet" class="login_form"
					onsubmit="return submit_check()">
					<p>
						邮寄信息：
					</p>
					<table>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								收件人：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="recipientName" id="recipientName" type="text"
									maxlength="40" value="${userOrder.shippingInfo.recipientName }"
									onblur="recipientName_check()" />
							</td>
							<td bgcolor="ffffff">
								<font color="red"><lable id="labelRecipientName"></lable>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								地址：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="address" id="address" type="text" maxlength="40"
									value="${userOrder.shippingInfo.address }"
									onblur="address_check()" />
							</td>
							<td bgcolor="ffffff">
								<font color="red"><lable id="labelAddress"></lable>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								邮编：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="zipCode" id="zipCode" type="text" maxlength="40"
									value="${userOrder.shippingInfo.zipCode }"
									onblur="zipCode_check()" />
							</td>
							<td bgcolor="ffffff">
								<font color="red"><lable id="labelZipCode"></lable>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								邮寄方式：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<select name="method">
									<option value="圆通" selected="${userOrder.shippingInfo.method == 圆通 }">
										圆通
									</option>
									<option value="申通" selected="${userOrder.shippingInfo.method == 申通 }">
										申通
									</option>
									<option value="中通" selected="${userOrder.shippingInfo.method == 中通 }">
										中通
									</option>
									<option value="EMS" selected="${userOrder.shippingInfo.method == EMS }">
										EMS
									</option>
								</select>
							</td>
							<td bgcolor="ffffff">
								<font color="red"><lable id="labelShippingMethod"></lable>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								电话：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="phone" id="phone" type="text" maxlength="40"
									value="${userOrder.shippingInfo.phone }" onblur="phone_check()" />
							</td>
							<td bgcolor="ffffff">
								<font color="red"><lable id="labelPhone"></lable>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="60">
							<td colspan="2" style="font-family: 楷体; font-size: 10pt;"
								align="middle">

								<FORM METHOD="GET" ACTION="">
									<INPUT type="submit" value="更改 " NAME="核算">
								</FORM>
							</td>
						</tr>
					</table>
				</form>
				<br />
				<br />
				<script type="text/javascript">

</script>
				<form name="register_form" method="post"
					action="private/servlet/ModifyCreditCartServlet" class="login_form"
					onsubmit="return submit_checkcard()">
					<p>
						信用卡信息：
					</p>
					<table>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								开户人：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="nameOnCard" id="nameOnCard" type="text"
									maxlength="40" value="${userOrder.creditCard.nameOnCard }"
									onblur="nameOnCard_check()" />
							</td>
							<td bgcolor="#ffffff">
								<font color="red"><label id="labelNameOnCard"></label>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								银行卡号：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="cardNum" id="cardNum" type="text" maxlength="40"
									value="${userOrder.creditCard.cardNum }"
									onblur="cardNum_check()" />
							</td>
							<td bgcolor="#ffffff">
								<font color="red"><label id="labelCardName"></label>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								到期日期：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<fmt:formatDate value="${userOrder.creditCard.expirationDate}"
									var="year" pattern="yyyy" />
								<input name="year" id="year" type="text"
									value="${year }" onblur="expirationDate_check()" />年
									<fmt:formatDate value="${userOrder.creditCard.expirationDate}"
									var="month" pattern="MM" />
								<input name="month" id="year" type="text"
									value="${month }" onblur="expirationDate_check()" />月
							</td>
							<td bgcolor="#ffffff">
								<font color="red"><label id="labelExpirationDate"></label>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								所属银行：
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<input name="type" id="type" type="text" maxlength="40"
									value="${userOrder.creditCard.type }" onblur="type_check()" />
							</td>
							<td bgcolor="#ffffff">
								<font color="red"><label id="labelType"></label>
								</font>
							</td>
						</tr>
						<tr bgcolor=#CCCCCC height="60">
							<td colspan="2" style="font-family: 楷体; font-size: 10pt;"
								align="middle">
								<align= "bottom">
								<FORM METHOD="GET" ACTION="">
									<INPUT type="submit" value=" 更改 ">
								</FORM>
							</td>
						</tr>
					</table>
				</form>
				<br />
				<br />

				<p>
					所订的书：
				</p>
				<table>
					<tr bgcolor=#CCCCCC height="40">
						<th style="font-family: 楷体; font-size: 10pt;">
							<b>书本isbn</b>
						</th>
						<th style="font-family: 楷体; font-size: 10pt;">
							<b>书名</b>
						</th>
						<th style="font-family: 楷体; font-size: 10pt;">
							<b>购买数量</b>
						</th>
						<th style="font-family: 楷体; font-size: 10pt;">
							<b>图书单价</b>
						</th>
						<th style="font-family: 楷体; font-size: 10pt;">
							<b>总价</b>
						</th>
					</tr>
					<c:set value="0" var="totalPrice" scope="page"/>
					<c:forEach items="${userOrder.orderItemList}" var="orderItem">
						<tr bgcolor=#CCCCCC height="40">
							<td style="font-family: 楷体; font-size: 10pt;">
								${orderItem.book.isbn}
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								${orderItem.book.name}
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								${orderItem.qty}
							</td>
							<td style="font-family: 楷体; font-size: 10pt;" align="right">
								￥${orderItem.book.price }
							</td>
							<td style="font-family: 楷体; font-size: 10pt;">
								<fmt:formatNumber var="booksPrice" value="${orderItem.book.price * orderItem.qty}" pattern="￥.00" />${booksPrice }
							</td>
						</tr>
						<c:set value="${totalPrice + orderItem.book.price * orderItem.qty }" var="totalPrice" scope="page"/>
					</c:forEach>

					<tr bgcolor=#CCCCCC height="40">
						<td colspan="4" align="right">
							<b>应付:</b>
						</td>
						<td style="font-family: 楷体; font-size: 14pt;">
							<fmt:formatNumber var="totalPrice" value="${totalPrice }" pattern="￥.00" />${totalPrice }
						</td>
					</tr>

					<tr bgcolor=#CCCCCC height="60">
						<td colspan="6" style="font-family: 楷体; font-size: 10pt;"
							align="right">
							<align= "bottom">
							<FORM METHOD="post"
								ACTION="private/servlet/ConfirmUserOrderServlet">
								<INPUT type="submit" value="核算">
							</FORM>
						</td>
					</tr>
				</table>
				</form>
				<br />
				<br />


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



