package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.UserOrder;

/**
 * 显示购物车
 * @author 冯珺
 *
 */
public class ShowCartServlet extends HttpServlet {

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");
		
		//如果用户没有购物车，分配一个
		if (userOrder == null){
			userOrder = new UserOrder();
			session.setAttribute("userOrder", userOrder);
		}
		
		request.getRequestDispatcher("/shopping_cart.jsp").forward(request, response);
	}

}
