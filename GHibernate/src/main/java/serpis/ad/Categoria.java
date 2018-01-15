package serpis.ad;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class Categoria {
	@Id
	private long id;
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}


	private String nombre;
	
	public String getNombre() {
		return nombre;
	}
	
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	
	
	@Override
	public String toString() {
		return String.format("[%s] %s", id, nombre);
		
	}
}
