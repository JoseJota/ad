import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class PruebaMySql {

	public static void main(String[] args) throws SQLException {
		// TODO Auto-generated method stub
		Connection connection = DriverManager.getConnection("jdbc:mysql://loclhost/dbprueba","root","sistemas");
	connection.close();
	}
}