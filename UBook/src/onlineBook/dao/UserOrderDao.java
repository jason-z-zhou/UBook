package onlineBook.dao;

import java.util.List;

import onlineBook.domain.Book;
import onlineBook.domain.CreditCard;
import onlineBook.domain.ShippingInfo;
import onlineBook.domain.UserOrder;

/**
 * 和订单有关的访问数据库接口
 * @author yueguoyan
 *
 */
public interface UserOrderDao {

	/**
	 * 添加邮寄信息
	 * @param shippingInfo
	 */
	public void addShippingInfo(ShippingInfo shippingInfo);
	
	/**
	 * 添加信用卡信息
	 * @param creditCard
	 */
	public void addCreditCard(CreditCard creditCard);
	
	/**
	 * 添加用户订单
	 * @param userOrder
	 */
	public void addUserOrder(UserOrder userOrder);
	
	/**
	 * 根据用户名查找信用卡集
	 * @param userName
	 * @return
	 */
	public List<CreditCard> findCreditCardByUserName(String userName);
	
	/**
	 * 根据用户名查找订单集
	 * @param userName
	 * @return
	 */
	public List<UserOrder> findUserOrderByUserName(String userName);
	
	
	/**
	 * 查找上个月销售量最高的十本书
	 * @return
	 */
	public List<Book> findTopTenBooks();
	
	/**
	 * 根据信用卡号查找信用卡
	 * @param cardNum
	 * @return
	 */
	public CreditCard findCreditCardByCardNum(String cardNum);
	
	/**
	 * 修改信用卡信息
	 * @param creditCard
	 */
	public void modifyCreditCard(CreditCard creditCard);
	
}
