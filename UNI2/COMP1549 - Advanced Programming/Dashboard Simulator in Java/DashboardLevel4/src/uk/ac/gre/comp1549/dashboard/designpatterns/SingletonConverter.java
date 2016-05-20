package uk.ac.gre.comp1549.dashboard.designpatterns;

import java.io.File;

/**
 *
 * @author Gyokay
 */
//Class for SINGLETON DESIGN PATTERN
public class SingletonConverter {

    //initialize the instance
    private static SingletonConverter instance = null;

    //not accesible (private) prevents creating new objects
    private SingletonConverter() {
    }

    //validation
    public static synchronized SingletonConverter getInstance() {
        if (instance == null) {
            instance = new SingletonConverter();
        }
        return instance;
    }

    /**
     * convertToFileURL() is a utility method just used if DashboardDemoMain is
     * run in standalone mode to test the class
     *
     * @param filename - name of the xml file
     * @return filename in URL format e.g "file:///c:/files/file.xml"
     */
    public String convertToFileURL(String filename) {
        String path = new File(filename).getAbsolutePath();
        if (File.separatorChar != '/') {
            path = path.replace(File.separatorChar, '/');
        }

        if (!path.startsWith("/")) {
            path = "/" + path;
        }
        return "file:" + path;
    }
}
