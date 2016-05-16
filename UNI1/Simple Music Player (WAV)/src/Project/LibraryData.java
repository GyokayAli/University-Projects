package Project;

// Skeleton version of public class LibraryData.java that links to a database.
import java.sql.*; // DB handling package
public class LibraryData {

    // Declare the JDBC objects.
    private static Connection con = null;
    private static Statement stmt = null;

    static {
        // standard code to open a connection and statement to SQL Server database
        try {
            // Create a variable for the connection string.
            String connectionUrl = "jdbc:sqlserver://SQL-SERVER;"
                    + "databaseName=" + System.getProperty("user.name") + ";"
                    + "integratedSecurity=true;";

            // Establish the connection.
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            con = DriverManager.getConnection(connectionUrl);

        } // Handle any errors that may have occurred.
        catch (SQLException sqle) {
            System.out.println("Sql Exception :" + sqle.getMessage());
        } catch (ClassNotFoundException e) {
            System.out.println("Class Not Found Exception :" + e.getMessage());
        }
    }

    public static String listAll() {
        String output = "";
        try {
            stmt = con.createStatement();
            ResultSet res = stmt.executeQuery("SELECT * FROM Catalogue");
            while (res.next()) { // there is a result
                // the name field is the thrid one in the ResultSet
                // Note that with  ResultSet we count the fields starting from 1
                output += res.getString(1) + " " + res.getString(2) + " - "
                        + res.getString(3) + "\n";
            }
        } catch (Exception e) {
            System.out.println(e);
            return null;
        }
        return output;
    }

    public static String getName(String key) {
        try {

            stmt = con.createStatement();
            ResultSet res = stmt.executeQuery("SELECT * FROM Catalogue WHERE ID = '" + key + "'");
            if (res.next()) { // there is a result
                // the name field is the second one in the ResultSet
                // Note that with  ResultSet we count the fields starting from 1
                return res.getString(2);
            } else {
                return null;
            }
        } catch (Exception e) {
            System.out.println(e);
            return null;
        }
    }

    public static String getArtist(String key) {
        try {

            stmt = con.createStatement();
            ResultSet res = stmt.executeQuery("SELECT * FROM Catalogue WHERE ID = '" + key + "'");
            if (res.next()) { // there is a result
                // the name field is the second one in the ResultSet
                // Note that with  ResultSet we count the fields starting from 1
                return res.getString(3);
            } else {
                return null;
            }
        } catch (Exception e) {
            System.out.println(e);
            return null;
        }
    }

    public static int getRating(String key) {
        try {

            stmt = con.createStatement();
            ResultSet res = stmt.executeQuery("SELECT * FROM Catalogue WHERE ID = '" + key + "'");
            if (res.next()) { // there is a result
                // the name field is the second one in the ResultSet
                // Note that with  ResultSet we count the fields starting from 1
                return res.getInt(5);
            } else {
                return -1;
            }
        } catch (Exception e) {
            System.out.println(e);
            return -1;
        }
    }

    public static int getPlayCount(String key) {
        try {

            stmt = con.createStatement();
            ResultSet res = stmt.executeQuery("SELECT * FROM Catalogue WHERE ID = '" + key + "'");
            if (res.next()) { // there is a result
                // the name field is the second one in the ResultSet
                // Note that with  ResultSet we count the fields starting from 1
                return res.getInt(4);
            } else {
                return -1;
            }
        } catch (Exception e) {
            System.out.println(e);
            return -1;
        }
    }

    public static void setRating(String key, int rating) {
        /* SQL UPDATE statement required. For instance if rating is 5 and key is "04" then updateStr is
         UPDATE Libary SET rating = 5 WHERE ID = '04'*/
        String updateStr = "UPDATE Catalogue SET rating = " + rating + " WHERE ID = '" + key + "'";
        System.out.println(updateStr);
        try {
            stmt.executeUpdate(updateStr);
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public static void incrementPlayCount(String key) {
        // Similar to setRating - but must getPlayCount first and increment by 1
        int counter = LibraryData.getPlayCount(key);
        counter = counter + 1;
        String updateStr = "UPDATE Catalogue SET Play_Count = " + counter + " WHERE ID = '" + key + "'";
        System.out.println(updateStr);
        try {
            stmt.executeUpdate(updateStr);
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    // close the database
    public static void close() {
        try {
            con.close();
        } catch (Exception e) {
            // this shouldn't happen
            System.out.println(e);
        }
    }
}
