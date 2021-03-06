package uk.ac.gre.comp1549.dashboard.controls;

import java.awt.*;
import java.awt.geom.Rectangle2D;
import javax.swing.*;

/**
 * DigitalDisplayBarDrawPanel. Draw a horizontal bar indicator and show its
 * current value
 *
 * @author Gyokay Ali
 * @version 2.0
 *
 * CURRENTLY NOT IN USE, BECAUSE OF THE NEWLY IMPLEMENTED JAVA BEAN AS A DIGITAL
 * DISPLAY
 */
public class DigitalDisplayBarDrawPanel extends JPanel implements InterfacePanels {

    private int value; // current value - will be indicated on the bar

    private int barLength; // length/width of the bar
    private int barHeight; // height of the bar

    private int padding; // padding around the bar
    private float barMaxValue; // bar runs from 0 to barMaxValue
    private JLabel lblTitle;

    /**
     * Default constructor - sets default values
     */
    public DigitalDisplayBarDrawPanel() {
        this(100, 20, 8, 100, 0);
    }

    /**
     *
     * @param length - length of the horizontal bar
     * @param height - height of the bar
     * @param padding - padding around the bar
     * @param barMaxValue - bar runs from 0 to barMaxValue
     * @param value - current value that will be indicated on the bar
     */
    public DigitalDisplayBarDrawPanel(int length, int height, int padding, int barMaxValue, int value) {
        // set size of the JPanel to be big enough to hold the bar plus padding
        setPreferredSize(new Dimension(length + (2 * padding), height + (2 * padding)));

        this.barLength = length;
        this.barHeight = height;
        this.padding = padding;
        this.barMaxValue = barMaxValue;
        this.value = value;
    }

    /**
     * This method is called every time the Bar needs drawing for instance when
     * the value has changed. It draws the bar itself and the indicator in the
     * correct position to indicate the current value
     *
     * @param g - graphics object used to draw on the JPanel
     */
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g; // get a Graphics2D object to draw with
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        // Draw the bar itself. 
        Rectangle2D barx = new Rectangle2D.Double(padding, padding, barLength, barHeight);
        g2.setPaint(Color.BLACK);
        g2.fill(barx);

        Font myFont = new Font("Goudy Stout", Font.BOLD, 20); //create custom font
        // draw labels of the value        
        g2.setPaint(Color.GREEN);
        g2.drawString("  ft.", 92, 25);
        g2.setFont(myFont); //set font
        //draw the value
        g2.drawString(String.valueOf(value * 100), 9, 25);
    }

    /**
     * Set the value to be displayed on the bar
     *
     * @param value value
     */
    @Override
    public void setValue(int value) {
        // don't let the value go over the maximum for the bar or under the minimum
        this.value = value > barMaxValue ? (int) barMaxValue : value < 0 ? 0 : value;
        repaint(); // causes paintComponent() to be called
    }

    //get the current value
    @Override
    public int getValue() {
        return value;
    }

    //set label
    @Override
    public void setLabel(String label) {
        lblTitle.setText(label);
    }

}
