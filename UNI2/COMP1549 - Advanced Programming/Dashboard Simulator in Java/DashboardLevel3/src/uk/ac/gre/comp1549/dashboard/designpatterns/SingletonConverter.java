package uk.ac.gre.comp1549.dashboard.designpatterns;

import java.io.File;

/**
 *
 * @author Gyokay
 */

//Class for SINGLETON DESIGN PATTERN
public class SingletonConverter {
    private static SingletonConverter instance = null;
    private SingletonConverter() { }
 
    public static synchronized SingletonConverter getInstance() {
        if (instance == null) {
            instance = new SingletonConverter();
        }
        return instance;
    }
    
    public String convertToFileURL(String filename){
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