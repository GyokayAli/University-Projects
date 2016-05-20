package uk.ac.gre.comp1549.dashboard.designpatterns;

import javax.swing.JLabel;
import uk.ac.gre.comp1549.dashboard.controls.HalfDialPanel;
import uk.ac.gre.comp1549.dashboard.controls.InterfacePanels;

/**
 * 
 * @author Gyokay Ali
 */
// CLASS FOR THE FACADE DESIGN PATTERN
public class FacadeIndicator implements InterfacePanels{

    private InterfacePanels fuelDial;
    private int value;
    private JLabel lblTitle;

    public FacadeIndicator() {      
        fuelDial = new HalfDialPanel();
    }
    
    //used in main. gets the drawing for Fuel Indicator
    public InterfacePanels getFuelDial() {
        return fuelDial;
    }
    //sets the label for Fuel Indicator
    public void setFuelLabel(String label) {
        fuelDial.setLabel(label);
    }
    //sets the value of the Fuel Indicator
    public void setFuelValue(int value) {
        fuelDial.setValue(value);
    }
  
    //sets label used in setFuelLabel
    @Override
    public void setLabel(String label) {
        lblTitle.setText(label);
    }
    //gets label
    public String getLabel() {
        return lblTitle.getText();
    }
    //sets value in setFuelValue
    @Override
    public void setValue(int value) {
        this.value = value;
        fuelDial.setValue(value);
    }
    //gets the current value
    @Override
    public int getValue() {
         return fuelDial.getValue();
    }
}
