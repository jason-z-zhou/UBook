package onlineBook.filter;

import java.io.IOException;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.User;
import onlineBook.domain.UserOrder;

/**
 * 验证用户权限有关filter
 * @author yueguoyan
 *
 */
public class AuthFilter implements Filter {

	
	
	public void destroy() {

	}

	public void doFilter(ServletRequest request, ServletResponse response,
			FilterChain chain) throws IOException, ServletException {
		
		
		
		
		HttpServletRequest req = (HttpServletRequest)request;
		HttpServletResponse res = (HttpServletResponse)response;
		
		HttpSession session = req.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");
		User user = (User)session.getAttribute("user");

		
		//如果用户没有购物车，分配一个
		if (userOrder == null){
			userOrder = new UserOrder();
			session.setAttribute("userOrder", userOrder);
		}
		
		//如果用户没有登录，重定向到登录页面
		if(session == null ||  user== null) {
			res.sendRedirect(req.getContextPath() + "/servlet/ShowLoginServlet");
			return;
		}
		
		chain.doFilter(req, res);
	}

	public void init(FilterConfig arg0) throws ServletException {
	}

}
