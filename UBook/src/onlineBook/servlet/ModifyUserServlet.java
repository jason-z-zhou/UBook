package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import onlineBook.domain.User;
import onlineBook.manager.UserManager;
import onlineBook.util.BeanFactory;
import onlineBook.util.Md5;

/**
 * 修改用户信息有关servlet
 * @author 冯珺
 *
 */
public class ModifyUserServlet extends HttpServlet {

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
		
		String password = request.getParameter("password");
		String prePassword = request.getParameter("prePassword");
		String email = request.getParameter("email");
		String realName = request.getParameter("realName");
		String address = request.getParameter("address");
		String zipCode = request.getParameter("zipCode");
		String phone = request.getParameter("phone");
		
		//使用MD5加密
		String passmd5 = Md5.getInstance().getMD5ofStr(prePassword);
		
		User user1 = (User)request.getSession().getAttribute("user");
		String currentPassword = user1.getPassword();
		//如果输入的原密码和不对
		if(!currentPassword.equals(passmd5)) {
			request.setAttribute("message", "原密码输入的不对，请重新输入！");
			request.getRequestDispatcher("/private/user_modify.jsp").forward(request, response);
			return;
		}
		
		User user = new User();
		user.setUserName(user1.getUserName());
		user.setPassword(Md5.getInstance().getMD5ofStr(password));
		user.setEmail(email);
		user.setRealName(realName);
		user.setAddress(address);
		user.setZipCode(zipCode);
		user.setPhone(phone);
		
		userManager.modifyUser(user);
		response.sendRedirect(request.getContextPath() + "/private/user_info.jsp");
	}

}
