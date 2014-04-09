<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" onload="check_pageNum()">
	<head>
		<base href="<%=basePath%>">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>我亲爱的网上书店啦啦啦</title>
		<meta name="keywords" content="" />
		<meta name="description" content="" />
		<link href="templatemo_style.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" src="script/login.js"></script>
		<script src="script/prototype.lite.js" type="text/javascript"></script> 
		<script src="script/moo.fx.js" type="text/javascript"></script> 
		<script src="script/moo.fx.pack.js" type="text/javascript"></script> 
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

 
 	function topPage() {
		window.self.location = "${pageContext.request.contextPath}/servlet/SearchBookServlet?pageNo=${pageModel.topPageNo}&searchText=${searchText }&searchMethod=${searchMethod }";
	}
	
	function previousPage() {
		window.self.location = "${pageContext.request.contextPath}/servlet/ShowByCategoryServlet?pageNo=${pageModel.previousPageNo}&category=${category }";
	}	
	
	function nextPage() {
		window.self.location = "${pageContext.request.contextPath}/servlet/ShowByCategoryServlet?pageNo=${pageModel.nextPageNo}&category=${category }";
	}
	
	function bottomPage() {
		window.self.location = "${pageContext.request.contextPath}/servlet/ShowByCategoryServlet?pageNo=${pageModel.bottomPageNo}&category=${category }";
	}
	
	function check_pageNum(){
		if(${pageModel.pageNo}==${pageModel.totalPages}){
			document.getElementById("btnBottomPage").disabled = true;
			document.getElementById("btnNextPage").disabled = true;
		}else{
			document.getElementById("btnBottomPage").disabled = false;
			document.getElementById("btnNextPage").disabled = false;
		}
		
		if(${pageModel.pageNo}==1){
			document.getElementById("btnTopPage").disabled = true;
			document.getElementById("btnPreviousPage").disabled = true;
		}else{
			document.getElementById("btnTopPage").disabled = false;
			document.getElementById("btnPreviousPage").disabled = false;
		}
		
	}
 </script>




	</head>
	<body onload = "check_pageNum()">
		<body>
		<div class="sample_popup" id="popup"
			style="visibility: hidden; display: none;">
			<div class="menu_form_header" id="popup_drag">
				<img class="menu_form_exit" id="popup_exit" src="images/close.jpg" />

			</div>
			<div class="menu_form_body">
				<form method="post" action="servlet/LoginServlet">

				用户名:
					<input type="text" name="username"/>
					<font color="red"><label id="loginErrorMessage">
							${loginErrorMessage }
						</label> </font>
					<br>
					<br>
					密　码:
					<input type="password" name="password"/>
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

			<div id="templatemo_content_area">

				<div id="templatemo_left">
					<div class="templatemo_section_1">
						<div class="top">
							<h1>
								分类搜索
							</h1>
						</div>
						<div class="item" align=left >    
              			<ul>
               				<li><A class = "title" href="javascript:void(0)">人文社科</a></li>
                			<div class="content"> 
								<p>人文科学关注的中心、研究的对象主要是关于人的精神、文化、价值、观念的问题。</p> 
								<p><a href="servlet/ShowByCategoryServlet?category=人文社科">查看详情</a></p>
							</div> 
                			<li><A class = "title" href="javascript:void(0)">管理技术</a></li>
                			<div class="content"> 
								<p>用于计划、开发和实现技术能力，完成组织战略和运营目标。</p> 
								<p><a href="servlet/ShowByCategoryServlet?category=管理技术">查看详情</a></p>
							</div> 
                			<li><A class = "title" href="javascript:void(0)">科技前沿</a></li>
                			<div class="content"> 
		  						<p>帮助您掌握最新的技术。</p> 
		  						<p><a href="servlet/ShowByCategoryServlet?category=科技前沿">查看详情</a></p>
							</div> 
               				<li><A class = "title" href="javascript:void(0)">少儿读物</a></li>
               				<div class="content"> 
		  						<p>适合小朋友的书。</p> 
		  						<p><a href="servlet/ShowByCategoryServlet?category=少儿读物">查看详情</a></p>
							</div> 
                			<li><A class = "title" href="javascript:void(0)">艺术体育</a></li>	
                			<div class="content"> 
		  						<p>锻炼身体，陶冶情操。</p> 
		  						<p><a href="servlet/ShowByCategoryServlet?category=艺术体育">查看详情</a></p>
							</div> 				
							<script type="text/javascript"> 
								var contents = document.getElementsByClassName('content');
								var toggles = document.getElementsByClassName('title');
	
								var myAccordion = new fx.Accordion(
									toggles, contents, {opacity: true, duration: 400}
								);
								myAccordion.showThisHideOpen(contents[0]);
							</script>     
               			</ul>
             		</div>
			</div>

			<div class="templaemo_h_line"></div>

			<div class="templatemo_section_2">
				<h1>
					畅销排行
				</h1>
				<c:choose>
					<c:when test="${empty topBookList}">
						<h3>
							无数据
						</h3>
					</c:when>
					<c:otherwise>
						<c:forEach items="${topBookList}" var="book">
							<div>
								<h3>
									<a href="servlet/ShowBookDetailServlet?isbn=${book.isbn }"><font
										color="blue">${book.name }</font>
									</a>
								</h3>
								<p>
									价格：￥${book.price }
								</p>
							</div>
						</c:forEach>
					</c:otherwise>
				</c:choose>
			</div>
			<div class="templaemo_h_line"></div>

		</div>
		<!-- End of left -->

		<div id="templatemo_right">
			<div class="templatemo_section_3">
				<br>
				<h1>
					搜索结果：
				</h1>
				<br>
				<br>

				<div class="templatemo_section_3">
					<c:choose>
						<c:when test="${empty pageModel.list}">对不起，没有您要求的结果！</c:when>
						<c:otherwise>
							<c:forEach items="${pageModel.list }" var="book">

								<div>
									<img src="book_images/${book.pictureName }" alt="image" align=left border=0>
									<a href="servlet/ShowBookDetailServlet?isbn=${book.isbn }">${book.name
										}</a>
									<br />
									--------------------------------------------------------------------------------
									<br />
									作者：${book.author }
									<br />
									ISBN：${book.isbn}
									<br />
									出版日期：${book.dateOfPublication }
									<br />
									简介：${book.description }
									<br />
									<br />
									<br />
									价格：${book.price }
								</div>
								<div class="cleaner"></div>
								<hr />
							</c:forEach>
						</c:otherwise>
					</c:choose>
					<div>
						共&nbsp;${pageModel.totalPages
						}&nbsp;页&nbsp;&nbsp;&nbsp;&nbsp;当前第&nbsp;${pageModel.pageNo
						}&nbsp;页

						<input name="btnTopPage" class="button1" type="button"
							id="btnTopPage" value="|&lt;&lt; " title="首页" onclick="topPage()" />
						<input name="btnPreviousPage" class="button1" type="button"
							id="btnPreviousPage" value=" &lt;  " title="上页"
							onclick="previousPage()" />
						<input name="btnNextPage" class="button1" type="button"
							id="btnNextPage" value="  &gt; " title="下页" onclick="nextPage()" />
						<input name="btnBottomPage" class="button1" type="button"
							id="btnBottomPage" value=" &gt;&gt;|" title="尾页"
							onclick="bottomPage();check_pageNum()" />
					</div>
				</div>

				<div class="templatemo_two_col right">

				</div>
				<div class="cleaner"></div>

			</div>

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
