package Project;

// Imports the SQL Library
import java.sql.*;

/*
 * 
 * 
 */
/**
 *
 * @author ag306
 */

// The purpose of this class is to establish
// a connection between SQL Server and the main program
// It uses static object
public class JavaConnect {

    Connection conn = null;

    public static Connection ConnectDB() {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            Connection conn = DriverManager.getConnection("jdbc:sqlserver://SQL-SERVER;"
                    + "databaseName=" + System.getProperty("user.name") + ";"
                    + "integratedSecurity=true;");
            return conn;
        } catch (SQLException sqle) {
            System.out.println("Sql Exception :" + sqle.getMessage());
        } catch (ClassNotFoundException e) {
            System.out.println("Class Not Found Exception :" + e.getMessage());

        }
        return null;
    }
}
