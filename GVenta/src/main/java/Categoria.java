
public class Categoria {

	
	private long id;
	private String nombre;
	
	public void setId(long id) {
		this.id = id;
	}
	
	public String getNombre( ) {
		return nombre;
	}
	
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	
	public String toString() {
		return String.format("[%s] %s",  id, nombre);
	}
}