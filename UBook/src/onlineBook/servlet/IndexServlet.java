package onlineBook.servlet;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import onlineBook.domain.Book;
import onlineBook.manager.BookManager;
import onlineBook.manager.UserOrderManager;
import onlineBook.manager.UserOrderManagerImpl;
import onlineBook.util.BeanFactory;

/**
 * 首页显示有关servlet
 * @author yueguoyan
 *
 */
public class IndexServlet extends HttpServlet {
	
	private BookManager bookManager;
	
	@Override
	public void init() throws ServletException {
		bookManager = (BookManager)BeanFactory.getInstance().getManagerObject(BookManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		UserOrderManager userOrderManager = new UserOrderManagerImpl();
		List<Book> bookList = userOrderManager.findTopTenBooks();
		
		int pageNo = 6;
		int pageSize = 4;
		String category1 = "人文社科";
		String category2 = "管理技术";
		String category3 = "科技前沿";
		List<Book> categoryList1 = bookManager.findBooksByCategory(category1, pageNo, pageSize).getList();
		List<Book> categoryList2 = bookManager.findBooksByCategory(category2, pageNo, pageSize).getList();
		List<Book> categoryList3 = bookManager.findBooksByCategory(category3, pageNo, pageSize).getList();
		
		request.setAttribute("categoryList1", categoryList1);
		request.setAttribute("categoryList2", categoryList2);
		request.setAttribute("categoryList3", categoryList3);
		request.getSession().setAttribute("topBookList", bookList);
		request.getRequestDispatcher("/index.jsp").forward(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doGet(request, response);
	}

}
