package onlineBook.servlet;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import onlineBook.domain.CreditCard;
import onlineBook.domain.User;
import onlineBook.manager.UserOrderManager;
import onlineBook.util.BeanFactory;

/**
 * 查找用户所有的信用卡有关servlet
 * @author yueguoyan
 *
 */
public class ShowCreditCardServlet extends HttpServlet {

	private UserOrderManager userOrderManager;
	
	@Override
	public void init() throws ServletException {
		userOrderManager = (UserOrderManager)BeanFactory.getInstance().getManagerObject(UserOrderManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		User user = (User)request.getSession().getAttribute("user");
		List<CreditCard> cardList = userOrderManager.findCreditCardByUserName(user.getUserName());
		
		request.setAttribute("cardList", cardList);
		request.getRequestDispatcher("/private/input_card.jsp").forward(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request,response);
	}

}
