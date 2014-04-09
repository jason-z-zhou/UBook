package onlineBook.manager;

import onlineBook.domain.User;

/**
 * 用户逻辑层接口
 * @author yueguoyan
 *
 */
public interface UserManager {

	/**
	 * 添加用户
	 * @param user
	 */
	public void addUser(User user);
	
	/**
	 * 根据用户名查找用户
	 * @param userName
	 * @return
	 */
	public User findUserByUserName(String userName);
	
	/**
	 * 修改用户信息
	 * @param user
	 */
	public void modifyUser(User user);
}
