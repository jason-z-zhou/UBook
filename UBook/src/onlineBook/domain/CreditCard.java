package onlineBook.domain;

import java.util.Date;

/**
 * 信用卡实体类
 * @author yueguoyan
 *
 */
public class CreditCard {

	private String cardNum;
	
	private String nameOnCard;
	
	//信用卡类型
	private String type;
	
	//到期日期
	private Date expirationDate;
	
	//所属的用户
	private User user;

	public String getCardNum() {
		return cardNum;
	}

	public void setCardNum(String cardNum) {
		this.cardNum = cardNum;
	}

	public String getNameOnCard() {
		return nameOnCard;
	}

	public void setNameOnCard(String nameOnCard) {
		this.nameOnCard = nameOnCard;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public Date getExpirationDate() {
		return expirationDate;
	}

	public void setExpirationDate(Date expirationDate) {
		this.expirationDate = expirationDate;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
}
