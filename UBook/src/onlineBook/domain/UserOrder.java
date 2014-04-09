package onlineBook.domain;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * 用户订单实体类
 * @author yueguoyan
 *
 */
public class UserOrder {

	//在数据库中的主键，值为1970年至今的毫秒数
	private String id = Calendar.getInstance().getTimeInMillis()+"";
	
	private CreditCard creditCard;
	
	private ShippingInfo shippingInfo;
	
	//下订单的日期
	private Date date = new Date();
	
	//所属的用户
	private User user;
	
	//订单中的订单项
	private List<OrderItem> orderItemList = new ArrayList<OrderItem>();

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public CreditCard getCreditCard() {
		return creditCard;
	}

	public void setCreditCard(CreditCard creditCard) {
		this.creditCard = creditCard;
	}

	public ShippingInfo getShippingInfo() {
		return shippingInfo;
	}

	public void setShippingInfo(ShippingInfo shippingInfo) {
		this.shippingInfo = shippingInfo;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public List<OrderItem> getOrderItemList() {
		return orderItemList;
	}

	public void setOrderItemList(List<OrderItem> orderItemList) {
		this.orderItemList = orderItemList;
	}
}
