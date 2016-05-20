/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uk.ac.gre.comp1549.dashboard.controls;

import java.awt.BorderLayout;
import java.awt.Component;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.border.BevelBorder;

/**
 *
 * @author Gyokay Ali
 */
public class SuperPanel extends JPanel {
    private JLabel lblTitle;
    private InterfaceGetSetMethods drawing;
    private int value;
    public SuperPanel(InterfaceGetSetMethods drawing){
        setLayout(new BorderLayout());
        setBorder(new BevelBorder(BevelBorder.LOWERED));
    
        lblTitle = new JLabel();
        lblTitle.setHorizontalAlignment(JLabel.CENTER);
        add(lblTitle, BorderLayout.NORTH);

        this.drawing = drawing;
        add((Component) drawing, BorderLayout.CENTER);
    }
    
    public void setLabel(String label) {
        lblTitle.setText(label);   
    }
    
    public void setValue(int value) {
        this.value = value;
        drawing.setValue(value);
    }
    
    public int getValue(){
        return drawing.getValue();
    }
}
