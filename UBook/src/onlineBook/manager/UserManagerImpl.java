package onlineBook.manager;


import onlineBook.dao.UserDao;
import onlineBook.domain.User;
import onlineBook.util.BeanFactory;

/**
 * 用户业务层接口实现
 * @author yueguoyan
 *
 */
public class UserManagerImpl implements UserManager {

	private UserDao userDao;
	
	public UserManagerImpl() {
		userDao = (UserDao)BeanFactory.getInstance().getDaoObject(UserDao.class);
	}
	
	public void addUser(User user) {
		userDao.addUser(user);
	}

	public User findUserByUserName(String userName) {
		return userDao.findUserByUserName(userName);
	}

	public void modifyUser(User user) {
		userDao.modifyUser(user);
	}

}
