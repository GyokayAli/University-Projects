package uk.ac.gre.comp1549.dashboard.controls;

import java.awt.*;
import javax.swing.*;
import javax.swing.border.BevelBorder;

/**
 *
 * @author Gyokay Ali
 */

//All Indicator Panels inherit from the Super Panel
public class SuperPanel extends JPanel implements InterfacePanels {

    private JLabel lblTitle;
    private InterfacePanels drawing;
    private int value;

    public SuperPanel(InterfacePanels drawing) {
        setLayout(new BorderLayout());
        setBorder(new BevelBorder(BevelBorder.LOWERED));

        lblTitle = new JLabel();
        lblTitle.setHorizontalAlignment(JLabel.CENTER);
        add(lblTitle, BorderLayout.NORTH);

        this.drawing = drawing;
        add((Component) drawing, BorderLayout.SOUTH);
    }
    //sets the label
    @Override
    public void setLabel(String label) {
        lblTitle.setText(label);
    }
    //sets the value
    @Override
    public void setValue(int value) {
        this.value = value;
        drawing.setValue(value);
    }
    //gets the current value
    @Override
    public int getValue() {
        return drawing.getValue();
    }
}
