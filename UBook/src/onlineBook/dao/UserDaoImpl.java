package onlineBook.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

import onlineBook.domain.User;
import onlineBook.util.DbUtil;

/**
 * 对用户dao接口进行实现
 * @author yueguoyan
 *
 */
public class UserDaoImpl implements UserDao {

	private static Logger logger = Logger.getLogger(UserDaoImpl.class.getName());
	
	@Override
	public void addUser(User user) {
		String sql = "insert into User (username, password, email, realname, address, zipCode, phone) ";
		sql += " values (?, ?, ?, ?, ?, ?, ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, user.getUserName());
			pstmt.setString(2, user.getPassword());
			pstmt.setString(3, user.getEmail());
			pstmt.setString(4, user.getRealName());
			pstmt.setString(5, user.getAddress());
			pstmt.setString(6, user.getZipCode());
			pstmt.setString(7, user.getPhone());
			pstmt.executeUpdate();
		} catch (SQLException e) {
			logger.error("用户注册出错：" , e);
		} finally {
			DbUtil.close(conn);
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
	}

	@Override
	public User findUserByUserName(String userName) {
		String sql = "select * from User where (userName =  ?)";
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		User user = null;
		
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, userName);
			rs = pstmt.executeQuery();
			
			if (rs.next()){
				user = new User();
				user.setUserName(rs.getString("username"));
				user.setPassword(rs.getString("password"));
				user.setEmail(rs.getString("email"));
				user.setRealName(rs.getString("realname"));
				user.setAddress(rs.getString("address"));
				user.setZipCode(rs.getString("zipcode"));
				user.setPhone(rs.getString("phone"));
			}
		} catch (SQLException e) {
			logger.error("根据用户名查找用户：" , e);
		}finally {
			DbUtil.close(rs);
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
		return user;
	}

	@Override
	public void modifyUser( User user) {
		String sql = "update User set password=?, email=?, realName=?, address=?, zipCode=?, phone=? "
					+" where userName=?";
		Connection conn = null ;
		PreparedStatement pstmt = null;
	
		try {
			conn = DbUtil.getConnection();
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(7, user.getUserName());
			pstmt.setString(1, user.getPassword());
			pstmt.setString(2, user.getEmail());
			pstmt.setString(3, user.getRealName());
			pstmt.setString(4, user.getAddress());
			pstmt.setString(5, user.getZipCode());
			pstmt.setString(6, user.getPhone());
			pstmt.executeUpdate();
		} catch (SQLException e) {
			logger.error("用户修改个人信息：" , e);
		}finally{
			DbUtil.close(pstmt);
			DbUtil.close(conn);
		}
	}
}

















