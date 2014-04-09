package onlineBook.filter;

import java.io.IOException;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

/**
 * 统一字符集filter
 * @author yueguoyan
 *
 */
public class CharsetEncodingFilter implements Filter {

	private String encoding;
	
	public void destroy() {
	}

	public void doFilter(ServletRequest request, ServletResponse response,
			FilterChain chain) throws IOException, ServletException {
		
		//设置字符集
		request.setCharacterEncoding(encoding);
		response.setCharacterEncoding(encoding);
		
		//继续执行
		chain.doFilter(request, response);
	}

	public void init(FilterConfig filterConfig) throws ServletException {
		
		//从配置中读取encoding
		encoding = filterConfig.getInitParameter("encoding");
		
	}

}
