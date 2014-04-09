package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.User;
import onlineBook.domain.UserOrder;
import onlineBook.manager.UserManager;
import onlineBook.util.BeanFactory;
import onlineBook.util.Md5;

/**
 * 用户登录有关servlet
 * @author 冯珺
 *
 */
public class LoginServlet extends HttpServlet {

	private UserManager userManager;
	
	@Override
	public void init() throws ServletException {
		userManager = (UserManager)BeanFactory.getInstance().getManagerObject(UserManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		String userName = request.getParameter("username");
		String password = request.getParameter("password");
		String isLoginFrame = request.getParameter("isLoginFrame");
	
		User user = userManager.findUserByUserName(userName);
		HttpSession session = request.getSession();
		//取得登录前的url，用于重定向
		String previouseURL = request.getHeader("referer");
		
		if (user != null && password != null) {
			//使用MD5加密
			String passmd5 = Md5.getInstance().getMD5ofStr(password);
			if (user.getPassword().equals(passmd5)){
				
				//把用户信息存到session中
				session.setAttribute("user", user);
				
				//把用户信息设到购物车中
				UserOrder userOrder = (UserOrder)session.getAttribute("userOrder");
				
				if (userOrder == null){
					userOrder = new UserOrder();
				}
				userOrder.setUser(user);
				session.setAttribute("userOrder", userOrder);
				
				if("false".equals(isLoginFrame)) {
					response.sendRedirect(request.getContextPath()+ "/servlet/IndexServlet");
					return;
				}
				
				//重定向到登陆前的页面
				response.sendRedirect(previouseURL);
				
			} else {
				
				//错误信息设到request中，并转发
				session.setAttribute("loginErrorMessage", "输入有误！");
				response.sendRedirect(previouseURL);
			}
		} else {
			session.setAttribute("loginErrorMessage", "输入有误！");
			response.sendRedirect(previouseURL);
		}
		
	}

}
