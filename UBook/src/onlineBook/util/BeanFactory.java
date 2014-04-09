package onlineBook.util;

import java.util.HashMap;
import java.util.Map;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;


/**
 * 抽象工厂,主要创建两个系列的产品：
 *   1、Manager系列
 *   2、Dao系列产品
 * @author yueguoyan
 *
 */
public class BeanFactory {

	private static BeanFactory instance = new BeanFactory();
	
	private final String beansConfigFile = "beans-config.xml";
	
	//保存manager相关对象
	private Map managerMap = new HashMap();
	
	//保存Dao相关对象
	private Map daoMap = new HashMap();
	
	private Document doc;
	
	private BeanFactory() {
		try {
			doc = new SAXReader().read(Thread.currentThread().getContextClassLoader().getResourceAsStream(beansConfigFile));
		} catch (DocumentException e) {
			e.printStackTrace();
			throw new RuntimeException();
		}
	}
	
	public static BeanFactory getInstance() {
		return instance;
	}
	
	/**
	 * 根据产品编号取得manager系列产品
	 * @param beanId
	 * @return
	 */
	public synchronized Object getManagerObject(Class c){
		//如果存在相关对象实例，返回
		if (managerMap.containsKey(c.getName())) {
			return managerMap.get(c.getName());
		}
		Element beanElt = (Element)doc.selectSingleNode("//manager[@id=\"" + c.getName() + "\"]");
		String className = beanElt.attributeValue("class");
		Object manager = null;
		try {
			manager = Class.forName(className).newInstance();
			
			//将创建好的对象放到Map中
			managerMap.put(c.getName(), manager);
		} catch (Exception e) {
			throw new RuntimeException();
		}
		return manager;
	}
	
	/**
	 * 根据产品编号取得dao系列产品
	 * @param beanId
	 * @return
	 */
	public synchronized Object getDaoObject(Class c){
		//如果存在相关对象实例，返回
		if (daoMap.containsKey(c.getName())) {
			return daoMap.get(c.getName());
		}
		Element beanElt = (Element)doc.selectSingleNode("//dao[@id=\"" + c.getName() + "\"]");
		String className = beanElt.attributeValue("class");
		Object dao = null;
		try {
			dao = Class.forName(className).newInstance();
			
			//将创建好的对象放到Map中
			daoMap.put(c.getName(), dao);
		} catch (Exception e) {
			throw new RuntimeException();
		}
		return dao;
	}
	
}
