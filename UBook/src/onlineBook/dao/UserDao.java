package onlineBook.dao;

import java.sql.Connection;

import onlineBook.domain.User;

/**
 * 用户数据访问接口
 * @author yueguoyan
 *
 */
public interface UserDao {

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
	public void modifyUser( User user);
}
