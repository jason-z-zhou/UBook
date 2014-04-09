package onlineBook.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import onlineBook.domain.Book;
import onlineBook.domain.Category;
import onlineBook.domain.Publisher;
import onlineBook.util.DbUtil;
import onlineBook.util.PageModel;

import org.apache.log4j.Logger;

/**
 * 书籍访问数据库接口实现
 * @author zhou ziying
 *
 */
public class BookDaoImpl implements BookDao {
	
	private static Logger logger = Logger.getLogger(BookDaoImpl.class.getName());

	/**
	 * @param isbn
	 * @return Book
	 */
	public Book findBookByIsbn(String isbn) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select  b.isbn, b.cid as category_id , b.pname as publisher_name,")
			.append("b.author, b.name, b.edition, b.dateofpublication, b.price, ")
			.append("b.description, b.picturename, p.address as publisher_addr, c.name as category_name ")
			.append("from Book b, Publisher p, Category c ")
			.append("where(b.pname = p.name AND b.cid = c.id AND b.isbn = ?)");
		
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		Book book = null ;
			
			try {
				conn = DbUtil.getConnection();
				pstmt = conn.prepareStatement(sbSql.toString());
				pstmt.setString(1, isbn);
				rs = pstmt.executeQuery();
				if(rs.next()){
					
					book = new Book();
					
					book.setIsbn(rs.getString("isbn"));
					book.setAuthor(rs.getString("author"));
					book.setName(rs.getString("name"));
					book.setEdition(rs.getString("edition"));
					book.setDateOfPublication(rs.getDate("dateofpublication"));
					book.setPrice(rs.getDouble("price"));
					book.setDescription(rs.getString("description"));
					book.setPictureName(rs.getString("picturename"));
					//category
					Category category = new Category();
					category.setId(rs.getInt("category_id"));
					category.setName(rs.getString("category_name"));
					book.setCategory(category);
					//publisher
					Publisher publisher = new Publisher();
					publisher.setName(rs.getString("publisher_name"));
					publisher.setAddress(rs.getString("publisher_addr"));
					book.setPublisher(publisher);
				}
			} catch (SQLException e) {
				logger.error("根据isbn查找书籍出错：" , e);
			}finally {
				DbUtil.close(rs);
				DbUtil.close(pstmt);
				DbUtil.close(conn);
			}
		return book;
	}

	/**
	 * @param author
	 * @param pageNo
	 * @param pageSize
	 * @return PageModel
	 */
	//如果author为空，输出全部书
	public PageModel<Book> findBooksByAuthor(String author, int pageNo,
			int pageSize) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select  b.isbn, b.cid as category_id , b.pname as publisher_name, ")
			.append("b.author, b.name, b.edition, b.dateofpublication, b.price, ")
			.append("b.description, b.picturename, p.address as publisher_addr, c.name as category_name ")
			.append("from Book b, Publisher p, Category c ");
			if(author==null||author.equals("")){
				sbSql.append("where(b.pname = p.name AND b.cid = c.id ) ");
			}
			else{
				sbSql.append("where(b.pname = p.name AND b.cid = c.id AND b.author = ?) ");
			}
			sbSql.append("limit ?, ?");
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		PageModel<Book> pageModel = null ;
		List<Book> bookList = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sbSql.toString());
			if(author==null||author.equals("")){
				pstmt.setInt(1, (pageNo - 1) * pageSize);
				pstmt.setInt(2, pageSize);
			}else{
				pstmt.setString(1, author);
				pstmt.setInt(2, (pageNo - 1) * pageSize);
				pstmt.setInt(3, pageSize);
			}
			
			rs = pstmt.executeQuery();
			bookList = new ArrayList<Book>();
			while(rs.next()){
				Book book = new Book();
				book.setIsbn(rs.getString("isbn"));
				book.setAuthor(rs.getString("author"));
				book.setName(rs.getString("name"));
				book.setEdition(rs.getString("edition"));
				book.setDateOfPublication(rs.getDate("dateofpublication"));
				book.setPrice(rs.getDouble("price"));
				book.setDescription(rs.getString("description"));
				book.setPictureName(rs.getString("picturename"));
				//Category
				Category category = new Category();
				category.setId(rs.getInt("category_id"));
				category.setName(rs.getString("category_name"));
				book.setCategory(category);
				//Publisher
				Publisher publisher = new Publisher();
				publisher.setName(rs.getString("publisher_name"));
				publisher.setAddress(rs.getString("publisher_addr"));
				book.setPublisher(publisher);
				//将书放入BookList
				bookList.add(book);
			}
			pageModel = new PageModel<Book>();
			pageModel.setPageNo(pageNo);
			pageModel.setPageSize(pageSize);
			//通过作者名得到总的记录数
			int totalRecords = getTotalRecordsByAuthor(conn, author);
			pageModel.setTotalRecords(totalRecords);
			pageModel.setList(bookList);
		} catch (SQLException e) {
			logger.error("根据作者查找书籍出错：" , e);
		}finally {
			DbUtil.close(rs);
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
		return pageModel;
	}

	//1.如果name为空,返回输出全部书名. 2.支持模糊查询
	public PageModel<Book> findBooksByName(String name, int pageNo, int pageSize) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select  b.isbn, b.cid as category_id , b.pname as publisher_name,")
			.append("b.author, b.name, b.edition, b.dateofpublication, b.price, ")
			.append("b.description, b.picturename, p.address as publisher_addr, c.name as category_name ")
			.append("from (Book b, Publisher p, Category c )");
		if(name==null||name.equals("")){
			sbSql.append("where b.pname = p.name AND b.cid = c.id ");
		}else{
			sbSql.append("where b.pname = p.name AND b.cid = c.id AND b.name LIKE ? ");
		}
			sbSql.append("limit ?, ?");
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		PageModel<Book> pageModel = null ;
		List<Book> bookList = null;
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sbSql.toString());
			if(name==null||name.equals("")){
				pstmt.setInt(1, (pageNo - 1) * pageSize);
				pstmt.setInt(2, pageSize);
			}else{
				pstmt.setString(1, "%"+name+"%");
				pstmt.setInt(2, (pageNo - 1) * pageSize);
				pstmt.setInt(3, pageSize);
			}
			rs = pstmt.executeQuery();
			bookList = new ArrayList<Book>();
			while(rs.next()){
				Book book = new Book();
				book.setIsbn(rs.getString("isbn"));
				book.setAuthor(rs.getString("author"));
				book.setName(rs.getString("name"));
				book.setEdition(rs.getString("edition"));
				book.setDateOfPublication(rs.getDate("dateofpublication"));
				book.setPrice(rs.getDouble("price"));
				book.setDescription(rs.getString("description"));
				book.setPictureName(rs.getString("picturename"));
				
				Category category = new Category();
				category.setId(rs.getInt("category_id"));
				category.setName(rs.getString("category_name"));
				book.setCategory(category);
				
				Publisher publisher = new Publisher();
				publisher.setName(rs.getString("publisher_name"));
				publisher.setAddress(rs.getString("publisher_addr"));
				book.setPublisher(publisher);
				
				bookList.add(book);
			}
			pageModel = new PageModel<Book>();
			pageModel.setPageNo(pageNo);
			pageModel.setPageSize(pageSize);
			int totalRecords = getTotalRecordsByName(conn, name);
			pageModel.setTotalRecords(totalRecords);
			pageModel.setList(bookList);
		} catch (SQLException e) {
			
			logger.error("根据书名查找书籍出错：" , e);
		} finally {
			DbUtil.close(rs);
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
		return pageModel;
	}

	public PageModel<Book> findBooksByCategory(String category, int pageNo,
			int pageSize) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select  b.isbn, b.cid as category_id , b.pname as publisher_name, ")
			.append("b.author, b.name, b.edition, b.dateofpublication, b.price, ")
			.append("b.description, b.picturename, p.address as publisher_addr, c.name as category_name ")
			.append("from Book b, Publisher p, Category c ")
			.append(" where(b.pname = p.name AND b.cid = c.id AND c.name = ?) ")
			.append("limit ?, ?");
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		PageModel<Book> pageModel = null ;
		List<Book> bookList = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sbSql.toString());
			pstmt.setString(1, category);
			pstmt.setInt(2, (pageNo - 1) * pageSize);
			pstmt.setInt(3, pageSize);
			rs = pstmt.executeQuery();
			bookList = new ArrayList<Book>();
			while(rs.next()){
				Book book = new Book();
				book.setIsbn(rs.getString("isbn"));
				book.setAuthor(rs.getString("author"));
				book.setName(rs.getString("name"));
				book.setEdition(rs.getString("edition"));
				book.setDateOfPublication(rs.getDate("dateofpublication"));
				book.setPrice(rs.getDouble("price"));
				book.setDescription(rs.getString("description"));
				book.setPictureName(rs.getString("picturename"));
				
				Category category1 = new Category();
				category1.setId(rs.getInt("category_id"));
				category1.setName(rs.getString("category_name"));
				book.setCategory(category1);
				
				Publisher publisher = new Publisher();
				publisher.setName(rs.getString("publisher_name"));
				publisher.setAddress(rs.getString("publisher_addr"));
				book.setPublisher(publisher);
				
				bookList.add(book);
				
				pageModel = new PageModel<Book>();
				pageModel.setPageNo(pageNo);
				pageModel.setPageSize(pageSize);
				int totalRecords = getTotalRecordsByCategory(conn, category);
				pageModel.setTotalRecords(totalRecords);
				pageModel.setList(bookList);
			}
		} catch (SQLException e) {
			
			logger.error("根据类别查找书籍出错：" , e);
		}finally {
			DbUtil.close(rs);
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
		return pageModel;
	}
	
	/**
	 * 根据作者取得总记录数
	 * @param conn Connection
	 * @param author String
	 * @return int
	 */
	private int getTotalRecordsByAuthor(Connection conn, String author) {
		String sql = "select author, count(isbn) as total_record from book ";
		if(author != null && !author.equals("")){
			sql += "where author = ? " ;
		}
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		int totalRecord = 0;
		
		try {
			pstmt = conn.prepareStatement(sql);
			if(author != null && !author.equals("")){
				pstmt.setString(1, author);
			}
			rs = pstmt.executeQuery();
			if(rs.next()){
				totalRecord = rs.getInt("total_record");
			}
		} catch (SQLException e) {
			logger.error("根据作者取得总记录数：" , e);
		}finally {
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}
		return totalRecord;
	}

	/**
	 * 根据书名取得总记录数
	 * @param conn Connection
	 * @param name String
	 * @return int
	 */
	private int getTotalRecordsByName(Connection conn, String name) {
		String sql = "select name, count(isbn) as total_record from book ";
		if(name != null && !name.equals("")){
			sql += "where name LIKE ? " ;
		}
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		int totalRecord = 0;
		
		try {
			pstmt = conn.prepareStatement(sql);
			if(name != null && !name.equals("")){
				pstmt.setString(1, "%"+name+"%");			
			}
			rs = pstmt.executeQuery();
			if(rs.next()){
				totalRecord = rs.getInt("total_record");
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return totalRecord;
	}
	
	/**
	 * 根据区域取得总记录数
	 * @param conn
	 * @param category
	 * @return int
	 */
	private int getTotalRecordsByCategory(Connection conn, String category) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select c.name as category_name, count(b.isbn) as total_record ").
			append("from book b , category c ")
			.append("where b.cid = c.id AND c.name = ? ");
		
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		int totalRecord = 0;
		
		try {
			pstmt = conn.prepareStatement(sbSql.toString());
			pstmt.setString(1, category);
			rs = pstmt.executeQuery();
			if(rs.next()){
				totalRecord = rs.getInt("total_record");
			}
		} catch (SQLException e) {
			logger.error("根据区域取得总记录数：" , e);
		}
		return totalRecord;
	}
}

















