package uk.ac.gre.comp1549.dashboard.scriptreader;

import javax.xml.parsers.*;
import org.xml.sax.*;
import org.xml.sax.helpers.*;

import java.util.*;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import uk.ac.gre.comp1549.dashboard.events.*;

/**
 * DashboardEventGeneratorFromXML reads and parses an XML file which holds a
 * script of dashboard events (i.e. events that may cause a change in the value
 * of a dashboard indicator). It generates DashBoardEvents which listeners can
 * register to receive.
 *
 * @author Gill Windall
 * @version 3.0
 */
public class DashboardEventGeneratorFromXML extends DefaultHandler {

    // constants used to control processing of the XML file
    /**
     * XML tag used to indicate a dashboard event
     */
    public final static String EVENT_TAG = "dashboard_event";

    /**
     * XML tag used to indicate the type of event
     */
    public final static String TYPE_TAG = "type";

    /**
     * XML tag used to indicate the value of event
     */
    public final static String VALUE_TAG = "value";

    /**
     * XML tag used to indicate the a time delay in the script
     */
    public final static String DELAY_TAG = "delay";

    /**
     * How many milliseconds each unit in a delay element is to cause the script
     * to pause for. To speed up the script processing, decrease the number. To
     * slow the script processing, increase the number.
     */
    public final static int delayUnits = 100; // 1000 = 1 second

    // current event being processed
    private DashBoardEvent currentEvent = null;
    private String currentTag = ""; // current tag being processed

    // list of listeners registered to receive dashboard events
    private final DashBoardEventList dashBoardListeners;

    // the xml parser object
    private final XMLReader xmlReader;

    /**
     *
     * @throws Exception - problem creating the parser
     */
    public DashboardEventGeneratorFromXML() throws Exception {
        dashBoardListeners = new DashBoardEventList();

        // The following code configures and creates an object known as a SAXParser which is capable of
        // reading and interpreting an XML file.
        SAXParserFactory spf = SAXParserFactory.newInstance();
        spf.setNamespaceAware(true);
        SAXParser saxParser = spf.newSAXParser();
        xmlReader = saxParser.getXMLReader();
    }

    /**
     *
     * @param filename - filename of the XML file to be processed
     * @throws IOException - problem reading the file
     * @throws SAXException - problem parsing the file
     */
    public void processScriptFile(String filename) throws IOException, SAXException {
        // register the current object to receive callbacks when elements are encountered in the XML file
        xmlReader.setContentHandler(this);
        // Start the parsing process.  As the file is processed methods in the startElement(), endElement() and
        // characters() methods in the current object will be called to handle the content of the XML file.
        xmlReader.parse(convertToFileURL(filename));
    }

    /**
     * startElement() is called by the parser whenever a start tag (tag =
     * element) is encountered in the XML file. Store the tag's name and if it
 is an EVENT_tag create a new DashBoardEvent object that will be
 populated with data by the character() method
     *
     * @param namespaceURI
     * @param localName - the name of the tag e.g. "dashboard_event"
     * @param atts
     * @throws SAXException - problem parsing the file
     */
    @Override
    public void startElement(String namespaceURI,
            String localName,
            String qName,
            Attributes atts)
            throws SAXException {

        currentTag = localName;

        if (currentTag.equals(EVENT_TAG)) {
            currentEvent = new DashBoardEvent();
        }
    }

    /**
     * characters() is called by the parser when character content is to be
     * processed. Note that we need to check what type of tag is currently being
     * processed in order to know what to do with the characters. For instance
     * if we are processing a delay tag we want to pause processing for the
     * specified amount of time.
     *
     * @param ch - array holding the characters to be processed
     * @param start - start position of current characters within the array
     * @param length - number of characters to process
     * @throws SAXException
     */
    @Override
    public void characters(char ch[], int start, int length)
            throws SAXException {
        // get the characters into a String and lose any unwanted whitespace
        String val = new String(ch, start, length).trim();

        if (val.length() < 1) {  // is no characters to process (was all whitespace) just return
            return;
        }

        // process the characters based on what type of tag we are currently dealing with.
        switch (currentTag) {
            case TYPE_TAG:
                currentEvent.setType(val);
                break;
            case VALUE_TAG:
                currentEvent.setValue(val);
                break;
            case DELAY_TAG:
                pause(Integer.parseInt(val));
                break;
        }
    }

    /**
     * endElement() is called by the parser when the end tag of an element is
     * encountered. At that point know that we have finished processing that
     * tag. The only situation we are interested in is when the end
     * "dashboard_event" tag is found. At that [point we know that we have all
     * the data for the event and can fire the event by creating the event
     * object and passing it to all the listeners
     *
     * @param uri
     * @param localName - the name of the tag e.g. "dashboard_event"
     * @param qName
     * @throws SAXException
     */
    @Override
    public void endElement(String uri, String localName, String qName)
            throws SAXException {

        if (localName.equals(EVENT_TAG)) {
            // get all listeners
            List<DashBoardEventListener> listeners = dashBoardListeners.getListeners(currentEvent.getType());
            if (listeners != null) {
                // loop through the listeners passing the event object to them - this is "firing" the event
                for (DashBoardEventListener dbel : listeners) {
                    dbel.processDashBoardEvent(this, currentEvent);
                }
            }
            currentEvent = null;
        }
        currentTag = "";
    }

    /**
     *
     * @param delay - the length of the delay
     */
    private void pause(int delay) {
        try {
            Thread.sleep(delay * delayUnits);
        } catch (InterruptedException ex) {
            Logger.getLogger(DashboardEventGeneratorFromXML.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * registerDashBoardEventListener() is called by objects that want to be
     * notified when a dashboard event occurs,
     *
     * @param type - type of the event listener is interested in (e.g. "speed")
     * @param dbel - reference to the listener object
     */
    public void registerDashBoardEventListener(String type, DashBoardEventListener dbel) {
        dashBoardListeners.addListener(type, dbel);
    }

    /**
     * removeDashBoardEventListener() is called by objects that not longer want
     * to be notified when a dashboard event occurs,
     *
     * @param type - type of the event listener wishes to deregister for (e.g.
     * "speed")
     * @param dbel - reference to the listener object
     */
    public void removeDashBoardEventListener(String type, DashBoardEventListener dbel) {
        dashBoardListeners.removeListener(type, dbel);
    }

    /**
     * convertToFileURL() is a utility method just used if DashboardDemoMain is
     * run in standalone mode to test the class
     *
     * @param filename - name of the xml file
     * @return filename in URL format e.g "file:///c:/files/file.xml"
     */
    private static String convertToFileURL(String filename) {
        String path = new File(filename).getAbsolutePath();
        if (File.separatorChar != '/') {
            path = path.replace(File.separatorChar, '/');
        }

        if (!path.startsWith("/")) {
            path = "/" + path;
        }
        return "file:" + path;
    }

    /**
     * Output a help message to the user
     */
    private static void usage() {
        System.err.println("Usage:  DashboardEventGeneratorFromXML <file.xml>");
        System.err.println("       -usage or -help = this message");
        System.exit(1);
    }

    /**
     * main() method is only used if the class is run in standalone mode for testing purposes.
     * @param args - last argument (args[length-1]) is the name of the xml file to process
     * @throws Exception
     */
    public static void main(String[] args) throws Exception {
        String filename = null;

        // get the filename if persent
        for (int i = 0; i < args.length; i++) {
            filename = args[i];
            if (i != args.length - 1) {
                usage();
            }
        }

        if (filename == null) {
            usage();
        }
        
        // Create an instance of DashboardEventGeneratorFromXML and test it
        DashboardEventGeneratorFromXML me = new DashboardEventGeneratorFromXML();
        DashBoardEventListener dbel = new DashBoardEventListener() {
            @Override
            public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                System.out.println("***** " + dbe);
            }
        };
        me.registerDashBoardEventListener("speed", dbel);
        me.processScriptFile(filename);
        me.removeDashBoardEventListener("speed", dbel);
        me.processScriptFile(filename);
    }
}
