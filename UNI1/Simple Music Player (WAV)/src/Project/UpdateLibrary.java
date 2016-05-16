package Project;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class UpdateLibrary extends JFrame
        implements ActionListener {

    JTextField trackNo = new JTextField(2);
    JSlider slider = new JSlider(1, 6);
    JButton rateBtn = new JButton("Rate");

    public UpdateLibrary() {
        setLayout(new BorderLayout());
        setBounds(100, 75, 250, 125);
        setTitle("Update Library");
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);


        slider.setSnapToTicks(true); // should be activated for custom tick space
        slider.setMajorTickSpacing(1);
        slider.setPaintTicks(true);
        slider.setPaintLabels(true);

        JPanel top = new JPanel();
        top.add(new JLabel("Enter track number:"));
        top.add(trackNo);
        top.add(rateBtn);
        rateBtn.addActionListener(this);
        add("North", top);

        JPanel middle = new JPanel();

        middle.add(slider);
        add("Center", middle);


        setResizable(false);
        setVisible(true);
    }

    public void actionPerformed(ActionEvent e) {

        String key = trackNo.getText(); // the string gets the song number entered by the user
        String name = LibraryData.getName(key); // gets the song name linked with the key number
        try {
            if (name == null) {
                JOptionPane.showMessageDialog(null, " No such track found! \n Please enter a number between 01-30"); // sets error message in text area
            } else {
                int rating = slider.getValue();
                LibraryData.setRating(key, rating);
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }


    }

    private String stars(int rating) {
        String stars = "";
        for (int i = 0; i < rating; ++i) {
            stars += "*";
        }
        return stars; // returns the counted stars
    } // end private

   
}
