package Project;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class CreatePlaylist extends JFrame
        implements ActionListener {

    JLabel trackLabel = new JLabel("Enter track number:");
    JTextField trackNo = new JTextField(2);
    TextArea showTxt = new TextArea(2, 26);
    TextArea playlistTxt = new TextArea(6, 27);
    JButton showBtn = new JButton(" Show Selected Track ");
    JButton resetBtn = new JButton("         Reset   Playlist        ");
    JButton stopBtn = new JButton(" ■ ");
    JButton playBtn = new JButton(" ► ");
    JButton pauseBtn = new JButton("║║");
    JButton addBtn = new JButton(" Add to Playlist ");

    public CreatePlaylist() {
        setLayout(new BorderLayout());
        setBounds(100, 100, 400, 270);
        setTitle("Create PLaylist");
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        JPanel top = new JPanel();
        top.add(trackLabel);
        top.add(trackNo);
        top.add(showBtn);
        top.add(showTxt);
        add("North", top);

        JPanel middle = new JPanel();
        middle.add(showTxt);
        middle.add(stopBtn);
        middle.add(playBtn);
        middle.add(pauseBtn);
        middle.add(resetBtn);
        middle.add(addBtn);
        add("Center", middle);

        JPanel bottom = new JPanel();
        bottom.add(playlistTxt);
        bottom.add(resetBtn);
        add("South", bottom);

        showBtn.addActionListener(this);
        resetBtn.addActionListener(this);
        stopBtn.addActionListener(this);
        playBtn.addActionListener(this);
        pauseBtn.addActionListener(this);
        addBtn.addActionListener(this);

        playlistTxt.setEditable(false);
        showTxt.setEditable(false);
        setResizable(false);
        setVisible(true);
    }

    public void actionPerformed(ActionEvent e) {
        String key = trackNo.getText(); // the string gets the song number entered by the user
        String name = LibraryData.getName(key); // gets the song name linked with the key number
        if (e.getSource() == showBtn) {

            // if wrong key number is entered displays error message
            if (name == null) {
                showTxt.setText("No such track number"); // sets error message in text area
            } else {
                //if the key number entered is correct the text area is filled with song name
                showTxt.setText(name + " - " + LibraryData.getArtist(key));
            }
        } else if (e.getSource() == addBtn) {
            playlistTxt.append(showTxt.getText() + "\n");
        } else if (e.getSource() == resetBtn) {
            playlistTxt.setText("");
            showTxt.setText("");
        } else if (e.getSource() == playBtn) {
            LibraryData.incrementPlayCount(key);
        }

    }
}
