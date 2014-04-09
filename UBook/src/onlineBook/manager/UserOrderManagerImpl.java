package onlineBook.manager;

import java.util.List;

import onlineBook.dao.UserOrderDao;
import onlineBook.dao.UserOrderDaoImpl;
import onlineBook.domain.Book;
import onlineBook.domain.CreditCard;
import onlineBook.domain.ShippingInfo;
import onlineBook.domain.UserOrder;
import onlineBook.util.BeanFactory;

public class UserOrderManagerImpl implements UserOrderManager {
	
	private UserOrderDao userOrderDao = new UserOrderDaoImpl();
	
	public UserOrderManagerImpl() {
		userOrderDao = (UserOrderDao)BeanFactory.getInstance().getDaoObject(UserOrderDao.class);
	}
	
	public void addCreditCard(CreditCard creditCard) {
		userOrderDao.addCreditCard(creditCard);
	}


	public void addShippingInfo(ShippingInfo shippingInfo) {
		userOrderDao.addShippingInfo(shippingInfo);
	}

	public void addUserOrder(UserOrder userOrder) {
		userOrderDao.addUserOrder(userOrder);
	}

	public CreditCard findCreditCardByCardNum(String cardNum) {
		return userOrderDao.findCreditCardByCardNum(cardNum);
	}

	public List<CreditCard> findCreditCardByUserName(String userName) {
		return userOrderDao.findCreditCardByUserName(userName);
	}

	public List<Book> findTopTenBooks() {
		return userOrderDao.findTopTenBooks();
	}

	public List<UserOrder> findUserOrderByUserName(String userName) {
		return userOrderDao.findUserOrderByUserName(userName);
	}

	public void modifyCreditCard(CreditCard creditCard) {
		userOrderDao.modifyCreditCard(creditCard);
	}

}
