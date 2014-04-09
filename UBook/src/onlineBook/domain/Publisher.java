package onlineBook.domain;

/**
 * 出版商实体类
 * @author yueguoyan
 *
 */
public class Publisher {

	@Override
	public String toString() {
		return "Publisher [" + '\n'
				+"address=" + address + '\n'
				+ "name=" + name + '\n'
				+ "]"+ '\n';
	}

	private String name;
	
	private String address;

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}
}
