package onlineBook.servlet;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import onlineBook.domain.User;
import onlineBook.domain.UserOrder;
import onlineBook.manager.UserOrderManager;
import onlineBook.util.BeanFactory;

/**
 * 显示用户以往的订单有关servlet
 * @author yueguoyan
 *
 */
public class ShowUserOrderServlet extends HttpServlet {

	private UserOrderManager userOrderManager;
	
	@Override
	public void init() throws ServletException {
		userOrderManager = (UserOrderManager)BeanFactory.getInstance().getManagerObject(UserOrderManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		User user = (User)request.getSession().getAttribute("user");
		
		List<UserOrder> orderList =  userOrderManager.findUserOrderByUserName(user.getUserName());
		request.setAttribute("orderList", orderList);
		
		request.getRequestDispatcher("/private/show_order.jsp").forward(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request,response);
	}

}
