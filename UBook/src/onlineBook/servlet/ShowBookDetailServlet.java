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
import onlineBook.util.BeanFactory;

/**
 * 显示书籍详细信息
 * @author 冯珺
 *
 */
public class ShowBookDetailServlet extends HttpServlet {

	private BookManager bookManager;
	
	private UserOrderManager userOrderManager;
	
	@Override
	public void init() throws ServletException {
		bookManager = (BookManager)BeanFactory.getInstance().getManagerObject(BookManager.class);
		userOrderManager = (UserOrderManager)BeanFactory.getInstance().getManagerObject(UserOrderManager.class);
	}
	
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		String isbn = request.getParameter("isbn");
		
		Book book = bookManager.findBookByIsbn(isbn);
		
		//查找同类书籍的前四本
		int pageNo = 1;
		int pageSize = 4;
		List<Book> bookList = bookManager.findBooksByCategory(book.getCategory().getName(), pageNo, pageSize).getList();
		
		request.setAttribute("bookList", bookList);
		request.setAttribute("book", book);
		request.getRequestDispatcher("/book_detail.jsp").forward(request, response);
	}


}
