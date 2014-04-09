package onlineBook.dao;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import org.apache.log4j.Logger;

import onlineBook.domain.Book;
import onlineBook.domain.CreditCard;
import onlineBook.domain.OrderItem;
import onlineBook.domain.ShippingInfo;
import onlineBook.domain.User;
import onlineBook.domain.UserOrder;
import onlineBook.util.DbUtil;

public class UserOrderDaoImpl implements UserOrderDao {

	private static Logger logger = Logger.getLogger(UserDaoImpl.class.getName());
	
	public void addCreditCard(CreditCard creditCard) {
		String sql = "insert into Creditcard(cardNum, username, nameOnCard, type, expirationDate)"
					+"values(?, ?, ?, ?, ?)" ;
		Connection conn = null;
		PreparedStatement pstmt = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1,creditCard.getCardNum());
			pstmt.setString(2, creditCard.getUser().getUserName());
			pstmt.setString(3, creditCard.getNameOnCard());
			pstmt.setString(4, creditCard.getType());
			//!java.mysql.Date 与  java.util.Date 这将后者转换成前者
			pstmt.setDate(5, new java.sql.Date(creditCard.getExpirationDate().getTime()));
			pstmt.executeUpdate();
		} catch (SQLException e) {
			logger.error("增加信用卡信息出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(pstmt);
		}
	}

	/**
	 * 添加订单项
	 * @param orderItemList
	 *
	 */
	private void addOrderItems(List<OrderItem> orderItemList) {
		String sql = "insert into Orderitem(isbn, oid, qty)"
					+"values(?, ?, ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			for(OrderItem item : orderItemList){
				pstmt.setString(1, item.getBook().getIsbn());
				pstmt.setString(2, item.getUserOrder().getId());
				pstmt.setInt(3, item.getQty());
				pstmt.executeUpdate();
			}
		} catch (SQLException e) {
			logger.error("添加订单项：" , e);
		}finally{
			DbUtil.close(conn);
			DbUtil.close(pstmt);
		}
	}

	public void addShippingInfo(ShippingInfo shippingInfo) {
		String sql = "insert into shippinginfo values(?, ?, ?, ?, ?, ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, shippingInfo.getId());
			pstmt.setString(2, shippingInfo.getAddress());
			pstmt.setString(3, shippingInfo.getPhone());
			pstmt.setString(4, shippingInfo.getZipCode());
			pstmt.setString(5, shippingInfo.getMethod());
			pstmt.setString(6, shippingInfo.getRecipientName());
			pstmt.executeUpdate();

		} catch (SQLException e) {
			logger.error("添加邮寄信息出错：" , e);
		}finally{
			DbUtil.close(conn);
			DbUtil.close(pstmt);
		}
	}

	public void addUserOrder(UserOrder userOrder) {
		String sql = "insert into userorder values(?, ?, ?, ?, ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, userOrder.getId());
			pstmt.setString(2, userOrder.getUser().getUserName());
			pstmt.setString(3, userOrder.getCreditCard().getCardNum());
			pstmt.setString(4, userOrder.getShippingInfo().getId());
			pstmt.setDate(5,  new Date(userOrder.getDate().getTime()));
			pstmt.executeUpdate();
			addOrderItems(userOrder.getOrderItemList());
		} catch (SQLException e) {
			logger.error("增加用户订单出错：" , e);
		}finally{
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
	}
	

	public CreditCard findCreditCardByCardNum(String cardNum) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select c.cardNum, c.username as uname, c.nameOnCard, c.type, c.expirationDate, ") 
			.append(" u.password, u.email, u.realname, u.address, u.zipcode, u.phone ")
			.append("from creditcard c, user u ")
			.append("where (")
			.append(" c.userName = u.userName AND cardNum = ?")
			.append(" )");		
		Connection conn = null;
		PreparedStatement pstmt = null;
		CreditCard card = null;
		ResultSet rs = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sbSql.toString());
			pstmt.setString(1, cardNum);
			rs = pstmt.executeQuery();
			if(rs.next()){
				card = new CreditCard();
				card.setCardNum(rs.getString("cardnum"));
				card.setNameOnCard(rs.getString("nameoncard"));
				card.setType(rs.getString("type"));
				card.setExpirationDate(rs.getDate("expirationdate"));
				
				User user = new User();
				user.setUserName(rs.getString("uname"));
				user.setPassword(rs.getString("password"));
				user.setEmail(rs.getString("email"));
				user.setRealName(rs.getString("realname"));
				user.setAddress(rs.getString("address"));
				user.setZipCode(rs.getString("zipcode"));
				user.setPhone(rs.getString("phone"));
				
				card.setUser(user);
			}
		} catch (SQLException e) {
			logger.error("根据信用卡号查找信用卡出错：" , e);
		}finally{
			DbUtil.close(conn);
			DbUtil.close(pstmt);
		}
		return card;
	}

	public List<CreditCard> findCreditCardByUserName(String userName) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select c.cardNum, c.username as uname, c.nameOnCard, c.type, c.expirationDate, ") 
			.append("u.password, u.email, u.realname, u.address, u.zipcode, u.phone ")
			.append("from creditcard c, user u ")
			.append("where (")
			.append(" c.userName = u.userName AND c.userName = ?")
			.append(" )");		
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		List<CreditCard> cardList = null;
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sbSql.toString());
			pstmt.setString(1, userName);
			rs = pstmt.executeQuery();
			cardList = new ArrayList<CreditCard>();
			while(rs.next()){
				CreditCard card = new CreditCard();
				card.setCardNum(rs.getString("cardnum"));
				card.setNameOnCard(rs.getString("nameoncard"));
				card.setType(rs.getString("type"));
				card.setExpirationDate(rs.getDate("expirationdate"));
				
				User user = new User();
				user.setUserName(rs.getString("uname"));
				user.setPassword(rs.getString("password"));
				user.setEmail(rs.getString("email"));
				user.setRealName(rs.getString("realname"));
				user.setAddress(rs.getString("address"));
				user.setZipCode(rs.getString("zipcode"));
				user.setPhone(rs.getString("phone"));
				card.setUser(user);
				
				cardList.add(card);
			}
		} catch (SQLException e) {
			logger.error("根据用户名查找信用卡集出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}

		return cardList;
	}

	@SuppressWarnings("deprecation")
	/*
	 * List<Book> 上个月天排名前十的书
	 * */
	public List<Book> findTopTenBooks() {
		Calendar cal = Calendar.getInstance();
		int year = cal.get(Calendar.YEAR) -1900;
		int month = cal.get(Calendar.MONTH);
		java.util.Date begin = null;
		java.util.Date end = null;
		if(month == 0){
			 begin = new java.util.Date(year - 1, 12, 1);
			 end = new java.util.Date(year , 0, 1);
		}else{
			 begin = new  java.util.Date(year, month -1, 1);
			 end = new java.util.Date(year, month, 1);
		}
		return findTopBooks(begin, end, 10);
	}
	
	/*
	 * 查询某段时间内排名前几的书
	 * @param beginDate java.util.Date 起始日期
	 * @param endDate java.util.Date 终止日期
	 * @param topNum int 需要的排名数
	 * @return List<Book>
	 * */
	private List<Book> findTopBooks( java.util.Date beginDate, java.util.Date endDate, int topNum) {
		StringBuffer sbSql = new StringBuffer();
		sbSql.append("select item.isbn AS i_isbn, book.name, sum(item.qty) as total_sales " )
			.append("from Orderitem item, Book book " )
			.append("where	( " )
			.append(			"( " )
			.append(				"item.oid  in " )	
			.append(				"( " )
			.append(				"select id " )
			.append(				"from Userorder ")
			.append(				"where (date>? AND date<? ) " )
			.append(				") " )	
			.append(			") " )
			.append(			"AND ")
			.append(			"(item.isbn = book.isbn) " )
			.append(		") " )
			.append("group by (i_isbn) " )
			.append("order by (total_sales) " )																								
			.append("desc " )
			.append("limit 0,? " ) ;
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		List<Book> bookList = new ArrayList<Book>();
		BookDao bookDao = new BookDaoImpl();
		
		conn = DbUtil.getConnection();
		try {
			pstmt = conn.prepareStatement(sbSql.toString());
			pstmt.setDate(1, new java.sql.Date(beginDate.getTime()));
			pstmt.setDate(2, new java.sql.Date(endDate.getTime()));
			pstmt.setInt(3, topNum);
			rs = pstmt.executeQuery();
			while(rs.next()){
				Book book = null;
				//调用BookDao中的方法
				book = bookDao.findBookByIsbn(rs.getString("i_isbn"));
				bookList.add(book);
			}
		} catch (SQLException e) {
			logger.error("查询某段时间内排名前几的书出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}
		return bookList;
	}

	public List<UserOrder> findUserOrderByUserName(String userName) {
		String sql = "select id, username, cardNum, sid, date "
		 			+"from UserOrder "
		 			+"where username = ? ";
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		List<UserOrder> userOrderList = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, userName);
			rs = pstmt.executeQuery();
			userOrderList = new ArrayList<UserOrder>();
			while(rs.next()){
				UserOrder userOrder = new UserOrder();
				userOrder.setId(rs.getString("id"));
				//信用卡
				CreditCard creditCard = findCreditCardByCardNum(rs.getString("cardnum"));
				userOrder.setCreditCard(creditCard);
				//送货信息
				ShippingInfo shippingInfo = findShippingInfoById(rs.getString("sid"));
				userOrder.setShippingInfo(shippingInfo);
				//订单项
				List<OrderItem> orderItemList = findOrderItemsByOrderId("id");
				userOrder.setOrderItemList(orderItemList);
	
				userOrderList.add(userOrder);
				
			}
		} catch (SQLException e) {
			logger.error("根据用户名查找订单出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}
		return userOrderList;
	}
	/**
	 * 根据送货号查找送货单
	 * @param id
	 * @return
	 */
	private ShippingInfo findShippingInfoById(String id) {
		String sql =  "select id, address, phone, zipCode, method, recipientName "
 					+"from ShippingInfo "
 					+"where id = ? ";
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		ShippingInfo shippingInfo = null;	
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, id);
			rs = pstmt.executeQuery();
			if(rs.next()){
				shippingInfo = new ShippingInfo();
				shippingInfo.setId(id);
				shippingInfo.setAddress(rs.getString("address"));
				shippingInfo.setPhone(rs.getString("phone"));
				shippingInfo.setZipCode(rs.getString("zipcode"));
				shippingInfo.setMethod(rs.getString("method"));
				shippingInfo.setRecipientName(rs.getString("recipientName"));
			}
		} catch (SQLException e) {
			logger.error("根据送货号查找送货单出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}
		return shippingInfo;
	}

	/**
	 * 根据订单号查找订单项集
	 * @param id
	 * @return
	 */
	private List<OrderItem> findOrderItemsByOrderId(String id) {
		String sql = "select id, isbn, oid, qty "
					+"from orderitem "
					+"where (oid = ?) ";
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		List<OrderItem> itemList = null;
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setString(1, id);
			rs = pstmt.executeQuery();
			itemList = new ArrayList<OrderItem>();

			BookDao bookDao = new BookDaoImpl();
			while(rs.next()){
				OrderItem orderItem = new OrderItem();
				orderItem.setQty(rs.getInt("qty"));
			
				Book book = bookDao.findBookByIsbn(rs.getString("isbn"));
				orderItem.setBook(book);
				
				itemList.add(orderItem);
			}
		} catch (SQLException e) {
			logger.error("根据订单号查找订单项集出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(rs);
			DbUtil.close(pstmt);
		}	
		return itemList;
	}

	
	public void modifyCreditCard(CreditCard creditCard) {
		String sql  = "update CreditCard " 
					+"set userName = ?, nameOnCard = ?, type = ?, expirationDate = ? " 
					+"where(cardNum = ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setString(5, creditCard.getCardNum());
			pstmt.setString(1, creditCard.getUser().getUserName());
			pstmt.setString(2, creditCard.getNameOnCard());
			pstmt.setString(3, creditCard.getType());
			pstmt.setDate(4, new java.sql.Date(creditCard.getExpirationDate().getTime()));
			pstmt.executeUpdate();
		} catch (SQLException e) {
			logger.error("修改信用卡出错：" , e);
		}finally {
			DbUtil.close(conn);
			DbUtil.close(pstmt);
		}	
	}
}
