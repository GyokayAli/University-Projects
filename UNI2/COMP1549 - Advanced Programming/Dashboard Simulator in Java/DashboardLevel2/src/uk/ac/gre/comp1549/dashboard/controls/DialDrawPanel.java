package uk.ac.gre.comp1549.dashboard.controls;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.geom.Arc2D;
import java.awt.geom.Ellipse2D;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;

import javax.swing.JPanel;

/**
 * DialDrawPanel. Draw a dial and indicate current value.
 *
 * @author Gill Windall
 * @version 2.0
 */
public class DialDrawPanel extends JPanel implements InterfaceDrawHands, InterfaceGetSetMethods {

    private int value; // current value - where the hand will point

    private int radius; // radius of dial
    private int padding; // padding outside the dial
    private double handLength; // length of indicator hand
    private int dialMaxValue;  // dial runs from 0 to dialMaxValue

    /**
     * The extent of the dial. For a full circle this would be 360
     */
    public static final float DIAL_EXTENT_DEGREES = 270;

    /**
     * Where the dial starts being draw from. Due north is 90.
     */
    public static final float DIAL_START_OFFSET_DEGREES = -45;

    /**
     * Default constructor - sets default values
     */
    public DialDrawPanel() {
        this(50, 10, 100, 0);
    }

    /**
     * @param radius - radius of the dial
     * @param padding - padding outside the dial
     * @param dialMaxValue - dial runs from 0 to dialMaxValue
     * @param value - current value - where the hand will point
     */
    public DialDrawPanel(int radius, int padding, int dialMaxValue, int value) {
        // set size of the JPanel to be big enough to hold the dial plus padding
        setPreferredSize(new Dimension(2 * (radius + padding), 2 * (radius + padding)));
        this.radius = radius;
        this.padding = padding;
        this.dialMaxValue = dialMaxValue;
        this.value = value;
        handLength = 0.9 * radius; // hand length is fixed at 90% of radius
    }

    /**
     * This method is called every time the Dial needs drawing for instance when
     * the value has changed. It draws the dial itself and the hand in the
     * correct position to indicate the current value
     *
     * @param g - graphics object used to draw on the JPanel
     */
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g; // get a Graphics2D object to draw with
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g2.setStroke(new BasicStroke(3, BasicStroke.CAP_ROUND, 0));
        // draw numbers on dial
        g2.drawString("10", 16, 80);
        g2.drawString("20", 12, 59);
        g2.drawString("30", 21, 39);
        g2.drawString("40", 34, 25);
        g2.drawString("50", 53, 22);
        g2.drawString("60", 70, 25);
        g2.drawString("70", 87, 39);
        g2.drawString("80", 94, 60);
        g2.drawString("90", 90, 82);
        // draw centre of the dial as a small circle of fixed size
        Ellipse2D circle = new Ellipse2D.Double((radius + padding) - 5, (radius + padding) - 5, 10, 10);
        g2.fill(circle);

        // draw the dial itself
        Arc2D arc = new Arc2D.Double(padding, padding, 2 * radius, 2 * radius, DIAL_START_OFFSET_DEGREES, DIAL_EXTENT_DEGREES, Arc2D.Double.OPEN);

        g2.draw(arc);

        // draw the little lines at the start and end of the dial
        drawDialEnd(g2, Math.toRadians(DIAL_START_OFFSET_DEGREES));
        drawDialEnd(g2, Math.toRadians(DIAL_START_OFFSET_DEGREES + DIAL_EXTENT_DEGREES));

        // draw the hand to indicate the current value
        double angle = Math.toRadians(225 - (value * (DIAL_EXTENT_DEGREES / dialMaxValue)));
        g2.setColor(Color.orange);
        drawHand(g2, angle, handLength, radius, padding);
    }

    /**
     * Draw one of the little lines at the end of the dial
     *
     * @param g2 - graphics object used to draw on the JPanel
     * @param angle - the angle on the dial where the line is to be drawn
     */
    private void drawDialEnd(Graphics2D g2, double angle) {
        // calculate endpoint of line furthest from centre of dial
        Point2D outerEnd = new Point2D.Double((radius + padding) + radius * Math.cos(angle),
                (radius + padding) - radius * Math.sin(angle));
        // calculate endpoint of line closest to centre of dial
        Point2D innerEnd = new Point2D.Double((radius + padding) + ((radius + padding) * .8) * Math.cos(angle),
                (radius + padding) - ((radius + padding) * .8) * Math.sin(angle));
        // draw the line
        g2.draw(new Line2D.Double(outerEnd, innerEnd));
    }

    /**
     * Draw the hand on the dial to indicate the current value
     *
     * @param g2 - graphics object used to draw on the JPanel
     * @param angle - the angle on the dial at which the hand is to point
     * @param handLength - length of the hand
     * @param radius
     * @param padding
     */
    @Override
    public void drawHand(Graphics2D g2, double angle, double handLength, int radius, int padding) {
        // calculate the outer end of the hand
        Point2D end = new Point2D.Double((radius + padding) + handLength * Math.cos(angle),
                (radius + padding) - handLength * Math.sin(angle));
        // calculate the centre 
        Point2D center = new Point2D.Double(radius + padding, radius + padding);
        //     Draw the line
        g2.draw(new Line2D.Double(center, end));
    }

    /**
     * Set the value to be displayed on the dial
     *
     * @param value value
     */
    @Override
    public void setValue(int value) {
        // don't let the value go over the maximum for the dial.  But what about the minimum?
        this.value = value > dialMaxValue ? (int) dialMaxValue : value < 0 ? 0 : value;
        repaint(); // causes paintComponent() to be called
    }

    @Override
    public int getValue() {
        return value;
    }
}
