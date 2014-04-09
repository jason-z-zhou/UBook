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

function radio_check() {
	var b = true;
	var container = document.getElementById("existCard");
	for ( var i = 0; i < container.getElementsByTagName("existCard").length; i++) {
		b = b || container.getElementsByTagName("existCard")[i].checked;
	}
	if (b) {
		document.getElementById("nameOnCard").value = "";
		document.getElementById("cardNum").value = "";
		document.getElementById("type").value = "";

		document.getElementById("txtNameOnCard").textContent = "";
		document.getElementById("txtCardNum").textContent = "";
		document.getElementById("txtType").textContent = "";

		document.getElementById("nameOnCard").disabled = true;
		document.getElementById("cardNum").disabled = true;
		document.getElementById("type").disabled = true;
		return true;
	} else {
		document.getElementById("nameOnCard").disabled = false;
		document.getElementById("cardNum").disabled = false;
		document.getElementById("type").disabled = false;
		return false;
	}
}

function nameOnCard_check() {
	//if (document.getElementById("existCard").checked == false) {
	if(document.getElementById("existCard").checked == false){
		var noc =document.getElementById("nameOnCard").value.replace(/(^\s*)|(\s*$)/g, "");
		if ( noc== null
				|| noc == "") {
			document.getElementById("txtNameOnCard").textContent = "请输入开户人";
			return false;
		} else {
			document.getElementById("txtNameOnCard").textContent = "";
			return true;
		}
	}
}

function cardNum_check() {
	var flag = false;
	var radio = document.getElementsByName("existCard");

	for(var i=0;i<radio.length;i++) {
		if(radio[i].checked == true) {
			flag = true;
		}
	}
	
	if (flag == false) {
		var cn = document.getElementById("cardNum").value.replace(/(^\s*)|(\s*$)/g, "");
		if ( cn== null || cn == "") {
			document.getElementById("txtCardNum").textContent = "请输入银行卡号";
			return false;
		} else {
			document.getElementById("txtCardNum").textContent = "";
			return true;
		}
	}
}

function type_check() {
	if (document.getElementById("existCard").checked == false) {
		var type =document.getElementById("type").value.replace(/(^\s*)|(\s*$)/g, "");
		if ( type== null||type == "") {
			document.getElementById("txtType").textContent = "请输入银行卡号";
			return false;
		} else {
			document.getElementById("txtType").textContent = "";
			return true;
		}
	}
}

function reset_check() {
	document.getElementById("nameOnCard").disabled = false;
	document.getElementById("cardNum").disabled = false;
	document.getElementById("type").disabled = false;
}

function submit_check() {

	var flag = false;
	var radio = document.getElementsByName("existCard");

	for(var i=0;i<radio.length;i++) {
		if(radio[i].checked==true) {
			flag = true;
		}
	}
	if(flag == false){
		if(!nameOnCard_check()||!cardNum_check()||!type_check()){
			alert("请输入有效的银行卡信息");
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

			</div>
			<br>
			<p>
				<span>填写信用卡信息：</span>
			</p>
			<br>
				

				<form name="register_form" method="post"
					action="private/servlet/AddCreditCardServlet" onsubmit="return submit_check()">
					<c:choose>
						<c:when test="${empty cardList }"></c:when>
						<c:otherwise>
							<c:forEach items="${cardList }" var="card">
								<label>
									<input type="radio" value="${card.cardNum }" tag="existCard"
										name="existCard" id="existCard" onclick="radio_check()" />
									信用卡号：${card.cardNum }
								</label>
								<br />
							</c:forEach>
						</c:otherwise>
					</c:choose>
					<table>
						<tr>
							<p>
								<td>
									<label>
										开&nbsp;户&nbsp;人 ：
									</label>
								</td>
								<td>
									<span><input name="nameOnCard" id="nameOnCard"
											type="text" maxlength="40" onblur="nameOnCard_check()" /> </span>
								</td>
								<td>
									<font color="red"><label id="txtNameOnCard"></label> </font>
								</td>
							</p>
						</tr>
						<tr>
							<td>
								<br />
							</td>
						</tr>
						<tr>
							<p>
								<td>
									<label>
										银行卡号&nbsp;：
									</label>
								</td>
								<td>
									<span><input name="cardNum" id="cardNum" type="text"
											maxlength="40" onblur="cardNum_check()" /> </span>
								</td>
								<td>
									<font color="red"><label id="txtCardNum"></label> </font>
								</td>
							</p>
						</tr>
						<tr>
							<td>
								<br />
							</td>
						</tr>
						<tr>


							<p>
								<td>
									<label>
										开户银行&nbsp;：
									</label>
								</td>
								<td>
									<span><input name="type" id="type" type="text"
											maxlength="40" onblur="type_check()" /> </span>
								</td>
								<td>
									<font color="red"><label id="txtType"></label> </font>
								</td>
							</p>
						</tr>
						<tr>
							<td>
								<br />
							</td>
						</tr>
						<tr>
							<p>
								<td>
									<label>
										到期日期：
									</label>
								</td>
								<td>
									<select name="year" >
										<option value="2011" selected="selected">
											2011
										</option>
										<option value="2012">
											2012
										</option>
										<option value="2013">
											2013
										</option>
										<option value="2014">
											2014
										</option>
										<option value="2015">
											2015
										</option>
										<option value="2016">
											2016
										</option>
										<option value="2017">
											2017
										</option>
										<option value="2018">
											2018
										</option>
										<option value="2019">
											2018
										</option>
										<option value="2020">
											2018
										</option>
									</select>
									年
									<select name="month">
										<option value="1">
											1
										</option>
										<option value="2">
											2
										</option>
										<option value="3">
											3
										</option>
										<option value="4">
											4
										</option>
										<option value="5">
											5
										</option>
										<option value="6" selected="selected">
											6
										</option>
										<option value="7">
											7
										</option>
										<option value="8">
											8
										</option>
										<option value="9">
											9
										</option>
										<option value="10">
											10
										</option>
										<option value="11">
											11
										</option>
										<option value="12">
											12
										</option>
									</select>
									月
									</span>
								</td>
								<td>
									<font color="red"><label id="txtType"></label> </font>
								</td>
							</p>
						</tr>
						<br>
							<tr>
								<td>
									<br />
									<br />
								</td>
							</tr>
							<tr>
								<br>
									<td>
										<p>
											<input type="reset" value="重置" onclick="reset_check()"/>
										</p>
									</td>
									<td>
										<p>
											<input type="submit" value=" 继续 "/>
										</p>
									</td>
							</tr>
					</table>
					<br/>
						<br/>
							<br/>
				</form>

</div><!-- End of right -->
        
        </div> <!-- End of content_area -->
<br/><br/>


				<div class="cleaner"> </div>
				<div id="templatemo_footer">
					Copyright 漏 2024
					<a href="#">我们的网站</a> | Designed by
					<a href="" target="_parent"></a>
				</div>
	</body>
</html>



