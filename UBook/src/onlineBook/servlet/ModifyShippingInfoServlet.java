package onlineBook.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.ShippingInfo;
import onlineBook.domain.UserOrder;

public class ModifyShippingInfoServlet extends HttpServlet {


	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

	
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");
		
		String method = request.getParameter("method");
		String recipientName = request.getParameter("recipientName");
		String address = request.getParameter("address");
		String zipCode = request.getParameter("zipCode");
		String phone = request.getParameter("phone");
		
		ShippingInfo shippingInfo = new ShippingInfo();
		shippingInfo.setAddress(address);
		shippingInfo.setPhone(phone);
		shippingInfo.setRecipientName(recipientName);
		shippingInfo.setZipCode(zipCode);
		shippingInfo.setMethod(method);
		userOrder.setShippingInfo(shippingInfo);
		
		session.removeAttribute("userOrder");
		session.setAttribute("userOrder", userOrder);
		
		response.sendRedirect(request.getContextPath()+"/private/order_confirm.jsp");
	}

	
}
