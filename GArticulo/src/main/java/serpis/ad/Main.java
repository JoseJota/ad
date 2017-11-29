package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) throws SQLException, ClassNotFoundException {
//		String DB_URL = "jdbc:mysql://localhost/dbprueba";
//		String USER = "root";
//		String PASS = "sistemas";
//		String sql;
//		   
//		Connection connection = DriverManager.getConnection(DB_URL,USER,PASS);
//		Statement stmt = connection.createStatement();

		System.out.println("Menu:");
		Scanner sc = new Scanner(System.in);
		int opcion = sc.nextInt();
		
		switch (opcion+1) {
		case 1:
			System.out.println("0 Salir");
			break;
		case 2:
			System.out.println("1: Nuevo");
			break;
		case 3:
			System.out.println("2 Salir");
			break;
		case 4:
			System.out.println("3: Nuevo");
			break;
		case 5:
			System.out.println("4 Salir");
			break;
		case 6:
			System.out.println("5: Nuevo");
			break;
			
		}
		
//	    sql = "SELECT * FROM categoria";
//	    ResultSet rs = stmt.executeQuery(sql);
//	    
//	    while(rs.next()){
//	         int id  = rs.getInt("id");
//	         String nombre = rs.getString("nombre");
//
//	         System.out.println("ID: " + id + " nombre: " + nombre);
//	      }
//	    
//	      rs.close();
//	      stmt.close();
//	      connection.close();
	}
}