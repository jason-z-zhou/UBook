package onlineBook.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.OrderItem;
import onlineBook.domain.UserOrder;

/**
 * 更改购物车中的书本数量
 * @author 冯珺
 *
 */
public class ChangeQtyServlet extends HttpServlet {


	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");		
		List<OrderItem> orderItemList = userOrder.getOrderItemList();
		
		//如果购物车中没有书籍
		if(orderItemList == null) {
			response.sendRedirect(request.getContextPath()+"/shopping_cart.jsp");
			return;
		}
		
		String[] strQty = request.getParameter("qty").split(",");
		
		for(int i=0;i<orderItemList.size();i++) {
			int qty = Integer.parseInt(strQty[i]);
			
			//如果用户输入的数量低于1时
			if(qty <= 0){
				orderItemList.remove(i);
			} else {
				orderItemList.get(i).setQty(qty);
			}
		}
		
		userOrder.setOrderItemList(orderItemList);
		session.setAttribute("userOrder", userOrder);
		
		response.sendRedirect(request.getContextPath()+"/shopping_cart.jsp");
	}


}
