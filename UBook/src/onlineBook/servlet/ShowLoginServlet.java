package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * 该servlet会记录用户在登陆前的页面
 * @author yueguoyan
 *
 */
public class ShowLoginServlet extends HttpServlet {

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		//取得登录前的url
		String previouseURL = request.getHeader("referer");
		
		//记录登录前的页面
		request.getSession().setAttribute("previouseURL", previouseURL);
		
		//重定向到login.jsp
		response.sendRedirect(request.getContextPath() + "/login.jsp");
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request, response);
	}

}
