package onlineBook.servlet;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.CreditCard;
import onlineBook.domain.User;
import onlineBook.domain.UserOrder;
import onlineBook.manager.UserOrderManager;
import onlineBook.util.BeanFactory;

/**
 * 填写信用卡信息servlet
 * @author yueguoyan
 *
 */
public class AddCreditCardServlet extends HttpServlet {

	private UserOrderManager userOrderManager;
	
	@Override
	public void init() throws ServletException {
		userOrderManager = (UserOrderManager)BeanFactory.getInstance().getManagerObject(UserOrderManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		HttpSession session = request.getSession();
		User user = (User)session.getAttribute("user");
		UserOrder userOrder = (UserOrder)session.getAttribute("userOrder");
		
		String existCard = request.getParameter("existCard");
		String nameOnCard = request.getParameter("nameOnCard");
		String cardNum = request.getParameter("cardNum");
		String type = request.getParameter("type");
		String year = request.getParameter("year");
		String month = request.getParameter("month");
		
		CreditCard creditCard = null;
		Date expirationDate = null;
		SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd"); 
        try {
        	expirationDate = format.parse(year + "-" + month + "-01") ;
		} catch (ParseException e) {
			e.printStackTrace();
		} 
		
		//判断是否使用的是已经在数据库存在的信用卡
		if(existCard == null || existCard.equals("")) {
			creditCard = new CreditCard();
			creditCard.setCardNum(cardNum);
			creditCard.setExpirationDate(expirationDate);
			creditCard.setNameOnCard(nameOnCard);
			creditCard.setType(type);
			creditCard.setUser(user);
		} else {
			creditCard = userOrderManager.findCreditCardByCardNum(existCard);
		}
		
		//更新session中的订单信息
		userOrder.setCreditCard(creditCard);
		session.removeAttribute("userOrder");
		session.setAttribute("userOrder", userOrder);
		
		response.sendRedirect(request.getContextPath() + "/private/order_confirm.jsp");
		
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request,response);
	}

}
