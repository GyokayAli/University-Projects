package uk.ac.gre.comp1549.dashboard.controls;
/**
 * Interface implemented by Indicator Panel classes for setting and getting values
 * @author Gyokay Ali
 */
public interface InterfacePanels {
    public void setValue(int value);
    public int getValue();
    public void setLabel(String label);
}
