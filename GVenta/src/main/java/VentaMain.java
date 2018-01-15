import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class VentaMain {

	public static void main(String[] args) {
		EntityManagerFactory entitymanagerFactory =
				Persistence.createEntityManagerFactory("serpis.ad.gventa");
				
		
				showAll();
		
				entityManagerFactory.close();
	}

}
