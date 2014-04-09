package onlineBook.servlet;

import java.io.IOException;
import java.io.PrintWriter;
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

/**
 * 修改信用卡有关servlet
 * @author 冯珺
 *
 */
public class ModifyCreditCartServlet extends HttpServlet {


	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

		
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		HttpSession session = request.getSession();
		User user = (User)session.getAttribute("user");
		UserOrder userOrder = (UserOrder)session.getAttribute("userOrder");
		
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
		
		creditCard = new CreditCard();
		creditCard.setCardNum(cardNum);
		creditCard.setExpirationDate(expirationDate);
		creditCard.setNameOnCard(nameOnCard);
		creditCard.setType(type);
		creditCard.setUser(user);
		
		//更新session中的订单信息
		userOrder.setCreditCard(creditCard);
		session.removeAttribute("userOrder");
		session.setAttribute("userOrder", userOrder);
		
		response.sendRedirect(request.getContextPath()+"/private/order_confirm.jsp");
	}

}
