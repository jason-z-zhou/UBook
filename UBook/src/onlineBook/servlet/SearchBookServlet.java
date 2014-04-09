package onlineBook.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import onlineBook.domain.Book;
import onlineBook.manager.BookManager;
import onlineBook.util.BeanFactory;
import onlineBook.util.PageModel;

/**
 * 分页查找书籍
 * @author 冯珺
 *
 */
public class SearchBookServlet extends HttpServlet {

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
		
		String searchText = new String(request.getParameter("searchText").getBytes("iso-8859-1"),"UTF-8");
		String searchMethod = request.getParameter("searchMethod");
		String tmp = request.getParameter("pageNo");
		int pageNo;
		if (tmp == null){
			pageNo = 1;
		} 
		else {
			pageNo = new Integer(tmp);
		}
		
		//从web.xml中取得配置数据
		int pageSize = Integer.parseInt(getServletContext().getInitParameter("page-size"));
	
		PageModel<Book> pageModel;
		if (searchMethod.equals("author")) {
			pageModel =  bookManager.findBooksByAuthor(searchText,pageNo, pageSize);
		} else {
			pageModel = bookManager.findBooksByName(searchText, pageNo, pageSize);
		}
		
		request.setAttribute("pageModel", pageModel);
		request.setAttribute("searchMethod", searchMethod);
		request.setAttribute("searchText", searchText);
		request.getRequestDispatcher("/show_search_book.jsp").forward(request, response);
	}

}
