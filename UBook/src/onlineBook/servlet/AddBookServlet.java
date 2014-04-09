package onlineBook.servlet;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import onlineBook.domain.Book;
import onlineBook.domain.OrderItem;
import onlineBook.domain.UserOrder;
import onlineBook.manager.BookManager;
import onlineBook.util.BeanFactory;

/**
 * 使用Ajax往购物车中加入书籍
 * @author 冯珺
 *
 */
public class AddBookServlet extends HttpServlet {

	private BookManager bookManager;
	
	@Override
	public void init() throws ServletException {
		bookManager = (BookManager)BeanFactory.getInstance().getManagerObject(BookManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		String isbn = request.getParameter("isbn");
		int  qty = Integer.parseInt(request.getParameter("qty"));
		
		HttpSession session = request.getSession();
		UserOrder userOrder = (UserOrder) session.getAttribute("userOrder");
		
		//如果session中没有购物车相关信息
		if (userOrder == null){
			userOrder = new UserOrder();
		}
		
		List<OrderItem> orderItemList = userOrder.getOrderItemList();
		
		//用来记录orderItem在orderItemList中第几个
		int index = -1;
		
		//用来标记购物篮中是否存在同样的书籍
		Boolean inOrNot = false;
		
		for(OrderItem orderItem : orderItemList) {
			
			index++;
			//如果购物车中存在相同的书籍，只更改数量即可
			if(orderItem.getBook().getIsbn().equals(isbn)) {
				inOrNot = true;
				break;
			}
		}
		
		//改变购物车中书籍的数量
		if(inOrNot) {
			OrderItem orderItem = orderItemList.get(index);
			orderItem.setQty(qty + orderItem.getQty());
			orderItemList.set(index, orderItem);
			userOrder.setOrderItemList(orderItemList);
			
		//不存在相同的书籍，把书籍加入购物车中
		} else {
			Book book = bookManager.findBookByIsbn(isbn);
			OrderItem orderItem = new OrderItem();
			orderItem.setBook(book);
			orderItem.setUserOrder(userOrder);
			orderItem.setQty(qty);
			orderItemList.add(orderItem);
			userOrder.setOrderItemList(orderItemList);
		}
		session.setAttribute("userOrder", userOrder);
		
	}	


}
