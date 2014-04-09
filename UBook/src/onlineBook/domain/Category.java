package onlineBook.domain;

/**
 * 书类别实体类
 * @author yueguoyan
 *
 */
public class Category {
	
	@Override
	public String toString() {
		return "Category " + '\n'
				+"[id=" + id + '\n'
				+ "name=" + name  + '\n'
				+"]";
	}

	private int id;
	
	private String name;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
}
