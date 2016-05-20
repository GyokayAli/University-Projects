package uk.ac.gre.comp1549.dashboard.controls;

import java.awt.BorderLayout;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.border.BevelBorder;

/**
 * DialPanel.  Container for DialDrawPanel to hold dial and label.
 * If a label is not needed DialDrawPanel an be used on its own
 *
 * @author Gill Windall
 * @version 2.0
 */
public class DialPanel extends JPanel {

    private DialDrawPanel dial;  // the dial itself
    private JLabel lblTitle; // the label which always appears above the dial

    /**
     * Default constructor
     */
    public DialPanel() {
        setLayout(new BorderLayout());
        
        // set the style of the border
        setBorder(new BevelBorder(BevelBorder.LOWERED));

        // position the label above the dial
        lblTitle = new JLabel();
        lblTitle.setHorizontalAlignment(JLabel.CENTER);
        add(lblTitle, BorderLayout.NORTH);
        dial = new DialDrawPanel();
        add(dial, BorderLayout.CENTER);

    }

    /**
     * Set the value for the dial
     * @param value - value for the dial
     */
    public void setValue(int value) {
        dial.setValue(value);
    }

    /**
     *
     * @param label - label to appear above the dial
     */
    public void setLabel(String label) {
        lblTitle.setText(label);
    }
}
