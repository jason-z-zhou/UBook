package onlineBook.domain;

/**
 * 订单项实体类
 * @author yueguoyan
 *
 */
public class OrderItem {

	//所属的订单
	private UserOrder userOrder;
	
	private Book book;
	
	private int qty;
	
	public UserOrder getUserOrder() {
		return userOrder;
	}

	public void setUserOrder(UserOrder userOrder) {
		this.userOrder = userOrder;
	}

	public Book getBook() {
		return book;
	}

	public void setBook(Book book) {
		this.book = book;
	}

	public int getQty() {
		return qty;
	}

	public void setQty(int qty) {
		this.qty = qty;
	}
}
