package onlineBook.servlet;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.OrderItem;
import onlineBook.domain.UserOrder;

/**
 * 从购物车中删除书籍
 * @author 冯珺
 *
 */
public class DeleteBookServlet extends HttpServlet {

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		String isbn = request.getParameter("isbn");
		
		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");
		List<OrderItem> orderItemList = userOrder.getOrderItemList();
		
		//记录订单项在list中存在的下标
		int index = -1;
		
		for(OrderItem orderItem : orderItemList) {
			index ++;
			if(orderItem.getBook().getIsbn().equals(isbn)) {
				break;
			}
		}
		
		//从用户订单中删除此订单项
		orderItemList.remove(index);
		response.sendRedirect(request.getContextPath() + "/servlet/ShowCartServlet");
	}

}
