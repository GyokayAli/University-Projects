package indicatorbean;

import java.awt.*;
import java.awt.geom.Rectangle2D;
import javax.swing.*;
import javax.swing.border.BevelBorder;
/**
 *
 * @author Gyokay Ali
 */
public class IndicatorBean extends JPanel {

    private int value; // current value - will be indicated on the bar

    private int barLength; // length/width of the bar
    private int barHeight; // height of the bar

    private int padding; // padding around the bar
    private float maxValue; // bar runs from 0 to barMaxValue
    private JLabel lblTitle;
    private String font = "Goudy Stout";
    private Paint color = Color.green;

    /**
     * Default constructor - sets default values
     */
    public IndicatorBean() {
        this(100, 20, 20, 100, 0);

        setLayout(new BorderLayout());
        setBorder(new BevelBorder(BevelBorder.LOWERED));
        lblTitle = new JLabel();
        lblTitle.setHorizontalAlignment(JLabel.CENTER);
        add(lblTitle, BorderLayout.NORTH);
    }
    /**
     *
     * @param length - length of the horizontal bar
     * @param height - height of the bar
     * @param padding - padding around the bar
     * @param maxValue - bar runs from 0 to barMaxValue
     * @param value - current value that will be indicated on the bar
     */
    public IndicatorBean(int length, int height, int padding, int maxValue, int value) {
        // set size of the JPanel to be big enough to hold the bar plus padding
        setPreferredSize(new Dimension(length + (2 * padding), height + (int) (1.5 * padding)));

        lblTitle = new JLabel();
        this.barLength = length;
        this.barHeight = height;
        this.padding = padding;
        this.maxValue = maxValue;
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

        //creating new custom Font
        Font myFont = new Font(font, Font.BOLD, 20); //create custom font
        // draw labels of the value        
        g2.setPaint(getColor());
        g2.drawString("  ft.", 104, 37);
        g2.setFont(myFont); //set font
        //draw the value
        g2.drawString(String.valueOf(value * 100), 21, 37);
    }
    //sets the text color
    public void setColor(Paint color) {
        this.color = color;
    }
    //gets the text color
    public Paint getColor(){
        return color;
    }
    //sets new font
    public void setTheFont(String font) {
        this.font = font;
    }
    //gets the current font
    public String getTheFont() {
        return font;
    }
    //sets the label
    public void setLabel(String label) {
        lblTitle.setText(label);
    }
    //gets the label if needed
    public String getLabel() {
        return lblTitle.getText();
    }
    //sets the indicator's value
    //if value < 0 , value = 0
    //if value > 100, value = 100
    public void setValue(int value) {
        // don't let the value go over the maximum for the bar.  But what about the minimum?
        this.value = value > maxValue ? (int) maxValue : value < 0 ? 0 : value;
        repaint(); // causes paintComponent() to be called
    }
    //gets the current value
    public int getValue() {
        return value;
    }
}
