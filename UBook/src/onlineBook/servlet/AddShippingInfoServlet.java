package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.ShippingInfo;
import onlineBook.domain.User;
import onlineBook.domain.UserOrder;

public class AddShippingInfoServlet extends HttpServlet {

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		String useMyAddress = request.getParameter("useMyAddress");
		String method = request.getParameter("method");
		String recipientName = request.getParameter("recipientName");
		String address = request.getParameter("address");
		String zipCode = request.getParameter("zipCode");
		String phone = request.getParameter("phone");
		
		ShippingInfo shippingInfo = new ShippingInfo();
		HttpSession session = request.getSession();
		//判断是否使用自己的地址进行邮寄
		if("true".equals(useMyAddress)) {
			User user = (User)session.getAttribute("user");
			address = user.getAddress();
			phone = user.getPhone();
			recipientName = user.getRealName();
			zipCode = user.getZipCode();
		} 
		
		shippingInfo.setAddress(address);
		shippingInfo.setPhone(phone);
		shippingInfo.setRecipientName(recipientName);
		shippingInfo.setZipCode(zipCode);
		shippingInfo.setMethod(method);
	
		UserOrder userOrder = (UserOrder)session.getAttribute("userOrder");
		userOrder.setShippingInfo(shippingInfo);
		
		//更新session中的订单信息
		session.removeAttribute("userOrder");
		session.setAttribute("userOrder", userOrder);
		
		response.sendRedirect(request.getContextPath()+"/private/servlet/ShowCreditCardServlet");
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request, response);
	}

}
