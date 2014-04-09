package onlineBook.domain;

import java.util.Calendar;

/**
 * 和邮寄相关的信息实体类
 * @author yueguoyan
 *
 */
public class ShippingInfo {


	//在数据库中的主键，值为1970年至今的毫秒数
	private String id = Calendar.getInstance().getTimeInMillis()+"";
	
	private String address;
	
	private String phone;
	
	private String zipCode;
	
	//邮寄方式
	private String method;
	
	//收件人姓名
	private String recipientName;

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public String getZipCode() {
		return zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	public String getMethod() {
		return method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public String getRecipientName() {
		return recipientName;
	}

	public void setRecipientName(String recipientName) {
		this.recipientName = recipientName;
	}
}
