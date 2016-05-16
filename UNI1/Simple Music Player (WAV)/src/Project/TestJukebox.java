package Project;

// Import all the necessary libraries
import java.awt.event.*;
import java.io.*;
import java.sql.*;
import java.util.*;
import javax.swing.*;
import net.proteanit.sql.DbUtils;
import sun.audio.*;

public class TestJukebox extends javax.swing.JFrame {

    int countSearch;
    Connection conn = null;
    ResultSet rs = null;
    PreparedStatement pst = null;

    public TestJukebox() {
        initComponents();
        conn = JavaConnect.ConnectDB(); 

    }
// this method clears the content of the playlist
    private void EmptyPlaylist() {
        try {
            Vector data = new Vector();
            data.add("");
            myList.setListData(data);
        } catch (Exception e) {
            System.out.println(e);
        }
    }
    // this method gets the song from table Playlist in SQL
    // and imports them in the playlist
    private void FillPlaylist() {

        try {

            String sql = "SELECT * FROM Playlist";
            pst = conn.prepareStatement(sql);
            rs = pst.executeQuery();
            Vector data = new Vector();
            while (rs.next()) {
                data.add(rs.getString(1) + " " + rs.getString(2) + " - "
                        + rs.getString(3) + "\n");
            }
            myList.setListData(data);

        } catch (Exception e) {
            System.out.println(e + " Connection failed");

        }

    }
// this method lists all the songs from the database
    private void UpdateTable() {

        try {
            String sql = "SELECT * FROM Catalogue";
            pst = conn.prepareStatement(sql);
            rs = pst.executeQuery();
            myTable.setModel(DbUtils.resultSetToTableModel(rs));

        } catch (Exception e) {
            System.out.println(e + " Connection failed");
        }

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jMenuBar2 = new javax.swing.JMenuBar();
        jMenu3 = new javax.swing.JMenu();
        jMenu4 = new javax.swing.JMenu();
        jPanel1 = new javax.swing.JPanel();
        jScrollPane1 = new javax.swing.JScrollPane();
        myTable = new javax.swing.JTable();
        trackProgress = new javax.swing.JProgressBar();
        prevBut = new javax.swing.JButton();
        pauseBut = new javax.swing.JButton();
        playBut = new javax.swing.JButton();
        nextBut = new javax.swing.JButton();
        volumeSlider = new javax.swing.JSlider();
        checkBut = new javax.swing.JButton();
        importBut = new javax.swing.JButton();
        searchField = new javax.swing.JTextField();
        searchLabel = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        myList = new javax.swing.JList();
        clearBut = new javax.swing.JButton();
        stopBut = new javax.swing.JButton();
        imageLabel = new javax.swing.JLabel();
        jLabel1 = new javax.swing.JLabel();
        rateBut = new javax.swing.JButton();
        playlistBut = new javax.swing.JButton();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        openMenu = new javax.swing.JMenuItem();
        saveMenu = new javax.swing.JMenuItem();
        exitMenu = new javax.swing.JMenuItem();
        jMenu2 = new javax.swing.JMenu();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenu5 = new javax.swing.JMenu();
        jMenu6 = new javax.swing.JMenu();
        jMenu7 = new javax.swing.JMenu();

        jMenu3.setText("File");
        jMenuBar2.add(jMenu3);

        jMenu4.setText("Edit");
        jMenuBar2.add(jMenu4);

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setTitle("JUKEBOX  ★═══════════════════════♫♪♫♪♫♪♫♪♫♪♫♪══════════════════════★ ");
        setResizable(false);

        jPanel1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jPanel1MouseClicked(evt);
            }
        });

        myTable.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        myTable.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4", "Title 5"
            }
        ));
        myTable.setToolTipText("Current tracks in library");
        myTable.setColumnSelectionAllowed(true);
        myTable.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        myTable.setSelectionForeground(new java.awt.Color(102, 204, 255));
        myTable.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        myTable.setShowVerticalLines(false);
        myTable.getTableHeader().setReorderingAllowed(false);
        myTable.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                myTableMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(myTable);
        myTable.getColumnModel().getSelectionModel().setSelectionMode(javax.swing.ListSelectionModel.MULTIPLE_INTERVAL_SELECTION);

        trackProgress.setToolTipText("Progress of playing track");
        trackProgress.setValue(100);
        trackProgress.setStringPainted(true);

        prevBut.setText("|◄");
        prevBut.setToolTipText("Previous");
        prevBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                prevButActionPerformed(evt);
            }
        });

        pauseBut.setText("▌▐");
        pauseBut.setToolTipText("Pause");

        playBut.setText("►");
        playBut.setToolTipText("Play");
        playBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                playButActionPerformed(evt);
            }
        });

        nextBut.setText("►|");
        nextBut.setToolTipText("Next");

        volumeSlider.setMajorTickSpacing(50);
        volumeSlider.setMinorTickSpacing(5);
        volumeSlider.setPaintTicks(true);
        volumeSlider.setSnapToTicks(true);
        volumeSlider.setToolTipText("Adjust volume");
        volumeSlider.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        volumeSlider.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                volumeSliderStateChanged(evt);
            }
        });

        checkBut.setText("Check library ۩");
        checkBut.setToolTipText("Import tracks from library");
        checkBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                checkButActionPerformed(evt);
            }
        });

        importBut.setText("Import ♫");
        importBut.setToolTipText("Import playlist from database");
        importBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                importButActionPerformed(evt);
            }
        });

        searchField.setToolTipText("Search ..");
        searchField.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                searchFieldMouseClicked(evt);
            }
        });
        searchField.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                searchFieldActionPerformed(evt);
            }
        });
        searchField.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                searchFieldKeyPressed(evt);
            }
        });

        searchLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        searchLabel.setText("Search:");

        myList.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        myList.setToolTipText("Playlist");
        jScrollPane2.setViewportView(myList);

        clearBut.setText("Clear ♫");
        clearBut.setToolTipText("Remove tracks from list");
        clearBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                clearButActionPerformed(evt);
            }
        });

        stopBut.setText("■");
        stopBut.setToolTipText("Stop");
        stopBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                stopButActionPerformed(evt);
            }
        });

        imageLabel.setIcon(new javax.swing.ImageIcon(getClass().getResource("/images/00.jpg"))); // NOI18N
        imageLabel.setToolTipText("Artist photo");
        imageLabel.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));

        jLabel1.setText("Volume: _ ▁ ▂ ▃ ▄ ▅ ▆ █ ");

        rateBut.setText("Rate Track ♫");
        rateBut.setToolTipText("Rate chosen track");
        rateBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                rateButActionPerformed(evt);
            }
        });

        playlistBut.setText("Add to playlist ♫");
        playlistBut.setToolTipText("Add selected song to playlist");
        playlistBut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                playlistButActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(trackProgress, javax.swing.GroupLayout.PREFERRED_SIZE, 824, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(checkBut)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(rateBut)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(playlistBut))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 481, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(imageLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 160, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(searchLabel)
                                        .addGap(432, 432, 432)
                                        .addComponent(volumeSlider, javax.swing.GroupLayout.PREFERRED_SIZE, 164, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                .addGap(0, 0, Short.MAX_VALUE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(searchField, javax.swing.GroupLayout.PREFERRED_SIZE, 175, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(16, 16, 16)
                                .addComponent(prevBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(pauseBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(playBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(stopBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(nextBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(jLabel1)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)))
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(0, 0, Short.MAX_VALUE)
                                .addComponent(importBut)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(clearBut)
                                .addGap(24, 24, 24))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 179, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGap(11, 11, 11)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(importBut)
                    .addComponent(checkBut)
                    .addComponent(clearBut, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(rateBut)
                    .addComponent(playlistBut))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 286, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(imageLabel, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 228, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(3, 3, 3)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(volumeSlider, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(searchLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 33, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                .addComponent(searchField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addComponent(prevBut)
                                .addComponent(pauseBut)
                                .addComponent(playBut)
                                .addComponent(nextBut)
                                .addComponent(stopBut)))))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(trackProgress, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
        );

        jMenu1.setText("File");

        jMenuItem1.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_N, java.awt.event.InputEvent.CTRL_MASK));
        jMenuItem1.setText("New playlist");
        jMenuItem1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem1ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem1);

        openMenu.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_O, java.awt.event.InputEvent.CTRL_MASK));
        openMenu.setText("Open");
        openMenu.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                openMenuActionPerformed(evt);
            }
        });
        jMenu1.add(openMenu);

        saveMenu.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_S, java.awt.event.InputEvent.CTRL_MASK));
        saveMenu.setText("Save playlist");
        saveMenu.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                saveMenuActionPerformed(evt);
            }
        });
        jMenu1.add(saveMenu);

        exitMenu.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_E, java.awt.event.InputEvent.CTRL_MASK));
        exitMenu.setText("Exit");
        exitMenu.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exitMenuActionPerformed(evt);
            }
        });
        jMenu1.add(exitMenu);

        jMenuBar1.add(jMenu1);

        jMenu2.setText("Edit");

        jMenuItem3.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_S, java.awt.event.InputEvent.SHIFT_MASK));
        jMenuItem3.setText("Change Skin");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem3);

        jMenuBar1.add(jMenu2);

        jMenu5.setText("Options");
        jMenuBar1.add(jMenu5);

        jMenu6.setText("Tools");
        jMenuBar1.add(jMenu6);

        jMenu7.setText("Help");
        jMenuBar1.add(jMenu7);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, 834, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );

        setSize(new java.awt.Dimension(860, 415));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void prevButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_prevButActionPerformed
    }//GEN-LAST:event_prevButActionPerformed
    // method to get the selected song
    // and play it
    private void playButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_playButActionPerformed
        int row = myTable.getSelectedRow();
        String key = (myTable.getModel().getValueAt(row, 0).toString());

        try {

            InputStream in = new FileInputStream(new File("\\\\storage-stud\\user-area\\3\\ag306\\Desktop\\Fix Jukebox\\Jukebox\\Test\\src\\wav\\" + key + ".wav"));
            AudioStream au = new AudioStream(in);
            AudioPlayer.player.start(au);
            LibraryData.incrementPlayCount(key);
            
        } catch (Exception e) {
            System.out.println(e);
        }

    }//GEN-LAST:event_playButActionPerformed
    private void searchFieldActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_searchFieldActionPerformed
    }//GEN-LAST:event_searchFieldActionPerformed
    // gets the method to fill the table when button is pressed
    private void checkButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_checkButActionPerformed
        UpdateTable();

    }//GEN-LAST:event_checkButActionPerformed
    // method to create a new playlist
    // just removes the content of Playlist from database
    // and makes it ready to be used
    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem1ActionPerformed
        try {
            String sql = "DELETE FROM Playlist";
            pst = conn.prepareStatement(sql);
            pst.execute();

            JOptionPane.showMessageDialog(null, "New playlist created");

        } catch (Exception e) {
            System.out.println(e);
        }


    }//GEN-LAST:event_jMenuItem1ActionPerformed
// method to check if the user wants to clear the playlist
    // if YES then gets the EmptyPlaylist() method
    private void clearButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_clearButActionPerformed
        int confirm = JOptionPane.showConfirmDialog(null, "Do you really want to clear the playlist?",
                "Clear all", JOptionPane.YES_NO_OPTION);
        if (confirm == 0) {
            EmptyPlaylist();
            JOptionPane.showMessageDialog(null, "Playlist cleared");
        } else {
        }
    }//GEN-LAST:event_clearButActionPerformed
// method that gets FillPlaylist() when Import button is pressed
    private void importButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_importButActionPerformed
        FillPlaylist();        // TODO add your handling code here:
    }//GEN-LAST:event_importButActionPerformed
    // method that gets the selected row
    // and displays the image that corresponds to that song
    private void myTableMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_myTableMouseClicked

        int row = myTable.getSelectedRow();
        String tableClick = (myTable.getModel().getValueAt(row, 0).toString());

        try {
            // Import ImageIcon     
            ImageIcon iconLogo = new ImageIcon("\\\\storage-stud\\user-area\\3\\ag306\\Desktop\\Fix Jukebox\\Jukebox\\Test\\src\\images\\" + tableClick + ".jpg");
            // Display the image in JLabel
            imageLabel.setIcon(iconLogo);

        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, e);
        }


    }//GEN-LAST:event_myTableMouseClicked
// checks where the mouse was clicked
    private void searchFieldMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_searchFieldMouseClicked
        if (countSearch == 0) {

            searchField.setEnabled(true);
            searchField.setText("Artist..");

            countSearch = 1;
        } else {
        }

    }//GEN-LAST:event_searchFieldMouseClicked
// checks again where the mouse was clicked
    private void jPanel1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jPanel1MouseClicked
        if (countSearch == 1) {
            searchField.setEnabled(false);
            searchField.setText("");

            countSearch = 0;
        }
    }//GEN-LAST:event_jPanel1MouseClicked
// method that searches matching artist from the database
    // Key code ENTER !
    private void searchFieldKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_searchFieldKeyPressed
        String word = searchField.getText();

        if (evt.getKeyCode() == KeyEvent.VK_ENTER) {
            try {
                String sql = "SELECT * FROM Catalogue WHERE Artist = '" + word + "'";
                pst = conn.prepareStatement(sql);
                rs = pst.executeQuery();
            } catch (Exception e) {
                System.out.println(e + " Connection failed");
            }
        }
        myTable.setModel(DbUtils.resultSetToTableModel(rs));
    }//GEN-LAST:event_searchFieldKeyPressed

    private void stopButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_stopButActionPerformed
    }//GEN-LAST:event_stopButActionPerformed

    private void volumeSliderStateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_volumeSliderStateChanged
    }//GEN-LAST:event_volumeSliderStateChanged
// opens the auxillary class UpdateLibrary()
    // which is used to rate the songs
    private void rateButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_rateButActionPerformed
        new UpdateLibrary();
    }//GEN-LAST:event_rateButActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_jMenuItem3ActionPerformed
// adds selected songs from the table into the Playlist in database
    // Playlist table to be used from Import button
    private void playlistButActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_playlistButActionPerformed
        int row = myTable.getSelectedRow();
        String id = (myTable.getModel().getValueAt(row, 0).toString());;
        String artist = (myTable.getModel().getValueAt(row, 1).toString());;
        String song = (myTable.getModel().getValueAt(row, 2).toString());

        try {
            String sql = "INSERT INTO Playlist (ID, Artist, Song) VALUES ('" + id + "','" + artist + "', '" + song + "');";
            pst = conn.prepareStatement(sql);
            pst.execute();
            System.out.println("\n Track has been inserted in the playlist");

        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Track already in playlist!");
            System.out.println(e);
        }
    }//GEN-LAST:event_playlistButActionPerformed
// opens a file chooser to open file
    // doesn't do anything
    private void openMenuActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_openMenuActionPerformed
        JFileChooser chooser = new JFileChooser();
        int response = chooser.showOpenDialog(null);

        try {

            if (response == JFileChooser.APPROVE_OPTION) {
                System.out.println("The file open operation was successful.");
            } else {
                System.out.println("The file open operation was canceled.");
            }
        } catch (Exception e) {
            System.out.println(e);
        }

    }//GEN-LAST:event_openMenuActionPerformed
// opens a file chooser to save file
    // doesn't do anything too
    private void saveMenuActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_saveMenuActionPerformed
        JFileChooser chooser = new JFileChooser();
        int response = chooser.showSaveDialog(null);

        try {
            if (response == JFileChooser.APPROVE_OPTION) {
                System.out.println("Saving playlist was successful.");
            } else {
                System.out.println("Saving playlist was canceled.");
            }
        } catch (Exception e) {
            System.out.println(e);
        }

    }//GEN-LAST:event_saveMenuActionPerformed
// used to close the program
    // X button is disabled
    private void exitMenuActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_exitMenuActionPerformed
        try {
            conn.close();
            LibraryData.close();
            System.exit(0);
        } catch (SQLException ex) {
            System.out.println(ex);
        }

    }//GEN-LAST:event_exitMenuActionPerformed

    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                /*if ("Nimbus".equals(info.getName())) {
                 javax.swing.UIManager.setLookAndFeel(info.getClassName());
                 break;
                 }*/
                //UIManager.setLookAndFeel("com.jtattoo.plaf.smart.SmartLookAndFeel");
                UIManager.setLookAndFeel("com.jtattoo.plaf.hifi.HiFiLookAndFeel");

            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(TestJukebox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(TestJukebox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(TestJukebox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(TestJukebox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    Thread.sleep(3500);
                } catch (Exception e) {
                    System.out.println(e + "\n Splash screen error!");
                }

                new TestJukebox().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton checkBut;
    private javax.swing.JButton clearBut;
    private javax.swing.JMenuItem exitMenu;
    private javax.swing.JLabel imageLabel;
    private javax.swing.JButton importBut;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenu jMenu3;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenu jMenu5;
    private javax.swing.JMenu jMenu6;
    private javax.swing.JMenu jMenu7;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuBar jMenuBar2;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JList myList;
    private static javax.swing.JTable myTable;
    private javax.swing.JButton nextBut;
    private javax.swing.JMenuItem openMenu;
    private javax.swing.JButton pauseBut;
    private javax.swing.JButton playBut;
    private javax.swing.JButton playlistBut;
    private javax.swing.JButton prevBut;
    public javax.swing.JButton rateBut;
    private javax.swing.JMenuItem saveMenu;
    private javax.swing.JTextField searchField;
    private javax.swing.JLabel searchLabel;
    private javax.swing.JButton stopBut;
    private javax.swing.JProgressBar trackProgress;
    private javax.swing.JSlider volumeSlider;
    // End of variables declaration//GEN-END:variables
}
