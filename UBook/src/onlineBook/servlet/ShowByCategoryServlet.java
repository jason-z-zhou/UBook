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
 * 根据类别分页查找书籍
 * @author 冯珺
 *
 */
public class ShowByCategoryServlet extends HttpServlet {

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

		String category = new String(request.getParameter("category").getBytes("iso-8859-1"),"UTF-8");
		
		String tmp = request.getParameter("pageNo");
		
		//从web.xml中取得配置数据
		int pageSize = Integer.parseInt(getServletContext().getInitParameter("page-size"));
		
		int pageNo;
		if (tmp == null){
			pageNo = 1;
		} else {
			pageNo = new Integer(tmp);
		}

		PageModel<Book> pageModel = bookManager.findBooksByCategory(category, pageNo, pageSize);

		request.setAttribute("pageModel", pageModel);
		request.setAttribute("category", category);
		request.getRequestDispatcher("/show_category_book.jsp").forward(request, response);
	}

}
