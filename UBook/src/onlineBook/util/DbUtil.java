package onlineBook.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


/**
 * 封装数据常用操作
 * @author yueguoyan
 *
 */
public class DbUtil {

	/**
	 * 取得Connection
	 * @return
	 */
	public static Connection getConnection() {
		Connection conn = null;
		try {
			JdbcConfig jdbcConfig = XmlConfigReader.getInstance().getJdbcConfig();
			Class.forName(jdbcConfig.getDriverName());
			conn = DriverManager.getConnection(jdbcConfig.getUrl(), jdbcConfig.getUserName(), jdbcConfig.getPassword());
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return conn;
	}
	
	/**
	 * 关闭Connection
	 * @param conn
	 */
	public static void close(Connection conn) {
		if (conn != null) {
			try {
				conn.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}
	
	/**
	 * 关闭Statement
	 * @param pstmt
	 */
	public static void close(Statement pstmt) {
		if (pstmt != null) {
			try {
				pstmt.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}
	
	/**
	 * 关闭ResultSet
	 * @param rs
	 */
	public static void close(ResultSet rs ) {
		if (rs != null) {
			try {
				rs.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}
	
	/**
	 * 如若想手动提交事务，显式开启事务
	 * @param conn
	 */
	public static void beginTransaction(Connection conn) {
		try {
			if (conn != null) {
				if (conn.getAutoCommit()) {
					conn.setAutoCommit(false); //手动提交
				}
			}
		}catch(SQLException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 手动提交事务
	 * @param conn
	 */
	public static void commitTransaction(Connection conn) {
		try {
			if (conn != null) {
				if (!conn.getAutoCommit()) {
					conn.commit();
				}
			}
		}catch(SQLException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 手动提交发生异常，回滚
	 * @param conn
	 */
	public static void rollbackTransaction(Connection conn) {
		try {
			if (conn != null) {
				if (!conn.getAutoCommit()) {
					conn.rollback();
				}
			}
		}catch(SQLException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 手动提交事务后，恢复以前的事务状态
	 * @param conn
	 */
	public static void resetConnection(Connection conn) {
		try {
			if (conn != null) {
				if (conn.getAutoCommit()) {
					conn.setAutoCommit(false);
				}else {
					conn.setAutoCommit(true);
				}
			}
		}catch(SQLException e) {
			e.printStackTrace();
		}
	}
	
}
