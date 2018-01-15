package serpis.ad;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class PruebaHibernate {

	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = 
				Persistence.createEntityManagerFactory("serpis.ad.ghibernate");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.find(Categoria.class, 9L);
		System.out.println(categoria);
		categoria.setNombre("modificado " + new Date());
		entityManager.getTransaction().commit();
		entityManagerFactory.close();
		
		showAll();
	}
	
	public static void newCategoria() {
		
	}
	
	private static void showAll() {
		EntityManagerFactory entityManagerFactory = 
				Persistence.createEntityManagerFactory("serpis.ad.ghibernate");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.find(Categoria.class, 9L);
		System.out.println(categoria);
		categoria.setNombre("modificado " + new Date());
		entityManager.getTransaction().commit();
		entityManagerFactory.close();
	}
	
	private static void modify(long id) {
		System.out.println("modificado categoría " + id);
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = new Categoria();
		categoria.setId(id);
		categoria.setNombre("modificado" + new Date());
		entityManager.persist(categoria);
		entityManager.getTransaction().commit();
	}
	
	private static void remove(long id) {
		System.out.println("eliminando categoría " + id);
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.getReference(Categoria.class, id);
		categoria.setId(id);
		categoria.setNombre("modificado" + new Date());
		entityManager.persist(categoria);
		entityManager.getTransaction().commit();
	}
}