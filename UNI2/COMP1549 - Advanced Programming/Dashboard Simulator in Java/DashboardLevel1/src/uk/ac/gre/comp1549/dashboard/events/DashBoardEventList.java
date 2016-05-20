package uk.ac.gre.comp1549.dashboard.events;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Holds a Map the keys of which are types of DashBoardEvents (e.g type "speed)
 * the values are the list of Listeners registered for that type of event.
 *
 * @author Gill
 */
public class DashBoardEventList {

    // key is event type, value is list of listeners for that type
    HashMap<String, List<DashBoardEventListener>> eventListeners;

    /**
     * default constructor
     */
    public DashBoardEventList() {
        eventListeners = new HashMap<>();
    }

    /**
     * Add a DashBoardEventListener
     *
     * @param type - the type of event listened for (e.g "speed")
     * @param listener - reference to the listener object
     */
    public void addListener(String type, DashBoardEventListener listener) {
        List<DashBoardEventListener> dbl = eventListeners.get(type);
        if (dbl == null) { // if no listeners for this type already registered
            dbl = new ArrayList<>(); // create a new list
        }
        dbl.add(listener); // add the listener to the list
        eventListeners.put(type, dbl); // update the map
    }

    /**
     * Remove a DashBoardEventListener
     *
     * @param type - the type of event listened for (e.g "speed")
     * @param listener - reference to the listener object
     */
    public void removeListener(String type, DashBoardEventListener listener) {
        List<DashBoardEventListener> dbl = eventListeners.get(type);
        if (dbl != null) { // if there are any listeners for the specified event type
            while (dbl.remove(listener)); // remove listener looping in case more than one
        }
    }

    /**
     * Return a list of DashBoardEventListeners for a specified type of event
     * @param type - the type of event for which listeners are required (e.g. "speed")
     * @return - the list of listeners of the specified type
     */
    public List<DashBoardEventListener> getListeners(String type) {
        return eventListeners.get(type);
    }
}
