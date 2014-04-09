package onlineBook.dao;

import onlineBook.domain.Book;
import onlineBook.util.PageModel;

/**
 * 书籍相关的数据库访问接口
 * @author yueguoyan
 *
 */
public interface BookDao {

	/**
	 * 根据isbn查找数据的详细信息
	 * @param isbn
	 * @return
	 */
	public Book findBookByIsbn(String isbn);
	
	/**
	 * 根据作者名分页查找书籍
	 * @param author
	 * @param pageNo	页数
	 * @param pageSize	每页的数目
	 * @return
	 */
	public PageModel<Book> findBooksByAuthor(String author,int pageNo, int pageSize);
	
	/**
	 * 根据书的部分标题来分页查找书籍
	 * @param name
	 * @param pageNo	页数
	 * @param pageSize	每页的数目
	 * @return
	 */
	public PageModel<Book> findBooksByName(String name,int pageNo, int pageSize);
	
	/**
	 * 根据书的类别来分页查找书籍
	 * @param category
	 * @param pageNo
	 * @param pageSize
	 * @return
	 */
	public PageModel<Book> findBooksByCategory(String category,int pageNo, int pageSize);
}
