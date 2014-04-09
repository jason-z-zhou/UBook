package onlineBook.servlet;

import java.io.IOException;

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
 * 用户注册有关servlet
 * 
 * @author 冯珺
 * 
 */
public class RegisterServlet extends HttpServlet {

	private UserManager userManager;

	@Override
	public void init() throws ServletException {
		userManager = (UserManager) BeanFactory.getInstance().getManagerObject(
				UserManager.class);
	}

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		String userName = request.getParameter("username");
		String password = request.getParameter("password");
		String email = request.getParameter("email");
		String realName = request.getParameter("realname");
		String address = request.getParameter("address");
		String zipCode = request.getParameter("zipCode");
		String phone = request.getParameter("phone");
		String authCode = request.getParameter("authCode");

		// 使用MD5加密
		String passmd5 = Md5.getInstance().getMD5ofStr(password);

		User user = new User();
		user.setUserName(userName);
		user.setPassword(passmd5);
		user.setEmail(email);
		user.setRealName(realName);
		user.setAddress(address);
		user.setZipCode(zipCode);
		user.setPhone(phone);

		HttpSession session = request.getSession();
		String rand = (String) session.getAttribute("rand");

		// 如果验证码信息不对
		if (!rand.equalsIgnoreCase(authCode)) {

			// 错误信息设到request中，并转发
			request.setAttribute("authMessage", "验证码输入有误！");
			request.setAttribute("user", user);
			request.getRequestDispatcher("/register.jsp").forward(request,
					response);
			return;
		}

		if (userManager.findUserByUserName(userName) != null) {

			// 把错误信息和用户输入的信息放入request并转发
			request.setAttribute("message", "用户名已经被注册，请重新注册");
			request.setAttribute("user", user);
			request.getRequestDispatcher("/register.jsp").forward(request,
					response);
		} else {
			userManager.addUser(user);

			// 把用户信息存到session中
			session.setAttribute("user", user);

			// 把用户信息设到购物车中
			UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");

			if (userOrder == null) {
				userOrder = new UserOrder();
			}
			userOrder.setUser(user);
			session.setAttribute("userOrder", userOrder);
			response.sendRedirect(request.getContextPath()
					+ "/private/register_success.jsp");
		}
	}

}
