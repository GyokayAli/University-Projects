package Project;
// Commented by Gyokay Ali, 27 Nov 2013
// This is the CheckLibrary class that will be used in the main application.
// Will be assigned to the Check Library button and used to pop up when pressed by the user.
/**/

// import the classes of the abstract windows toolkit and swing to enable us to use 
// components like buttons, text fields, lists, text areas, radio buttons, e.g
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

// creates the main class CheckLibrary
// implements the event handler ActionListener in JFrame
public class CheckLibrary extends JFrame
        implements ActionListener {

    //creates all the GUI objects
    JTextField trackNo = new JTextField(2); // constructs text fied with 2 columns
    TextArea information = new TextArea(6, 50); // constucts text area with set size
    //constructs buttons
    JButton list = new JButton("List All Tracks");
    JButton check = new JButton("Check Track");

    //the constructor for the class
    public CheckLibrary() {
        //the size and set up of the content pane
        setLayout(new BorderLayout());
        // first two parameters 100x100 sets the location of the frame
        // last two parameters 400X200 sets the size of the frame
        setBounds(100, 100, 400, 200);
        setTitle("Check Library"); // sets the title of the frame
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE); // closed when X pressed 

        //adding all the buttons to top panel
        JPanel top = new JPanel(); // creates a new panel called "top"
        top.add(new JLabel("Enter Track Number:"));
        top.add(trackNo); // adds empty field to enter song number
        top.add(check); // adds the Check Track button
        top.add(list); // adds the List All Tracks button
        add("North", top); // lets the panel to be placed in North/top

        //setting up the listener to take in the "List All Tracks" button click
        list.addActionListener(this);
        //setting up the listener to take in the "Check Track button" click
        check.addActionListener(this);

        //adding all the buttons to middle panel
        JPanel middle = new JPanel(); // creates a new panel called "middle"
        // fills the TextArea information with content from the song library
        information.setText(LibraryData.listAll());
        middle.add(information); // adds the text area showing the song library
        add("Center", middle); //lets the panel to be placed in Center/middle

        // sets the application to be not resizable by the user or its components (false/not)
        setResizable(false);
        setVisible(true); // sets the application to be visible (true/yes)
    } //  end of constructor

    // handle and respond click event of two buttons
    public void actionPerformed(ActionEvent e) {
        // determines which button has been clicked by if/else
        String key = trackNo.getText(); // the string gets the song number entered by the user
        String name = LibraryData.getName(key); // gets the song name linked with the key number
        // when "List All Tracks" selected
        // song library imported from LibraryData class to text area
        if (e.getSource() == check) {
            information.setText(name + " - " + LibraryData.getArtist(key));
            information.append("\nRating: " + stars(LibraryData.getRating(key)));
            information.append("\nPlay count: " + LibraryData.getPlayCount(key));
        } else {
            information.setText(LibraryData.listAll());
        }
    }
    // used to count the stars of rated songs
    // for - loop is used in this case

    private String stars(int rating) {
        String stars = "";
        for (int i = 0; i < rating; ++i) {
            stars += "*";
        }
        return stars; // returns the counted stars
    } // end private String stars
} //end main class CheckLibrary
