package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.CreditCard;
import onlineBook.domain.UserOrder;
import onlineBook.manager.UserOrderManager;
import onlineBook.util.BeanFactory;

/**
 * 确认订单，存入数据库相关的servlet
 * @author yueguoyan
 *
 */
public class ConfirmUserOrderServlet extends HttpServlet {

	private UserOrderManager userOrderManager;
	
	@Override
	public void init() throws ServletException {
		userOrderManager = (UserOrderManager)BeanFactory.getInstance().getManagerObject(UserOrderManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder)session.getAttribute("userOrder");
		CreditCard creditCard = userOrder.getCreditCard();
		
		userOrderManager.addShippingInfo(userOrder.getShippingInfo());
		
		//如果数据库里不存在这个银行卡,加入
		if((userOrderManager.findCreditCardByCardNum(creditCard.getCardNum())) == null) {
			userOrderManager.addCreditCard(creditCard);
			
		//存在这个银行卡，修改信息
		}else {
			userOrderManager.modifyCreditCard(creditCard);
		}
		userOrderManager.addUserOrder(userOrder);
		
		//把已经存入数据库的session中的购物车的信息清空,并再给用户new一个新的购物车
		session.removeAttribute("userOrder");
		UserOrder userOrder2 = new UserOrder();
		userOrder2.setUser(userOrder.getUser());
		session.setAttribute("userOrder", userOrder2);
		
		response.sendRedirect(request.getContextPath() + "/private/order_success.jsp");
		
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request,response);
	}

}
