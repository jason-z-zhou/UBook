package onlineBook.manager;

import onlineBook.dao.BookDao;
import onlineBook.domain.Book;
import onlineBook.util.BeanFactory;
import onlineBook.util.PageModel;

/**
 * 书籍业务层接口实现
 * @author yueguoyan
 *
 */
public class BookManagerImpl implements BookManager {

	private BookDao bookDao;
	
	public BookManagerImpl() {
		bookDao = (BookDao)BeanFactory.getInstance().getDaoObject(BookDao.class);
	}
	
	public Book findBookByIsbn(String isbn) {
		return bookDao.findBookByIsbn(isbn);
	}

	public PageModel<Book> findBooksByAuthor(String author, int pageNo,
			int pageSize) {
		return bookDao.findBooksByAuthor(author, pageNo, pageSize);
	}

	public PageModel<Book> findBooksByName(String name, int pageNo, int pageSize) {
		return bookDao.findBooksByName(name, pageNo, pageSize);
	}

	public PageModel<Book> findBooksByCategory(String category, int pageNo,
			int pageSize) {
		return bookDao.findBooksByCategory(category, pageNo, pageSize);
	}

}
