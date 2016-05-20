package uk.ac.gre.comp1549.dashboard;

import indicatorbean.IndicatorBean;
import java.awt.*;
import java.awt.event.*;
import java.util.logging.*;
import javax.swing.*;
import javax.swing.event.*;
import uk.ac.gre.comp1549.dashboard.designpatterns.*;
import uk.ac.gre.comp1549.dashboard.controls.InterfacePanels;
import uk.ac.gre.comp1549.dashboard.events.*;
import uk.ac.gre.comp1549.dashboard.scriptreader.DashboardEventGeneratorFromXML;

/**
 * DashboardDemoMain.java Contains the main method for the Dashboard demo
 * application. It: a) provides the controller screen which allows user input
 * which is passed to the display indicators, b) allows the user to run the XML
 * script which changes indicator values, c) creates the dashboard JFrame and
 * adds display indicators to it.
 *
 * @author Gyokay Ali and Gill Windall
 * @version 4.0
 */
public class DashboardDemoMain extends JFrame {

    /**
     * Name of the XML script file - change here if you want to use a different
     * filename
     */
    public static final String XML_SCRIPT = "dashboard_script.xml";

    // fields that appear on the control panel
    JTextField txtPetrolValueInput, txtTempValueInput,
            txtSpeedValueInput, txtOilValueInput, txtAltitudeValueInput;
    JButton btnScript;

    // fields that appear on the dashboard itself
    InterfacePanels indicatorSpeed, indicatorOil, indicatorTemp;
    // the facade for the Fuel half dial that appear on the dashboard itself
    FacadeIndicator facadeFuel;
    // the bean for the Altitude Bar that appear on the dashboard itself
    IndicatorBean beanAltitude;

    /**
     * Constructor. Does maybe more work than is good for a constructor.
     */
    public DashboardDemoMain() {
        // Set up the frame for the controller
        setTitle("Dashboard demonstration controller");
        setLayout(new FlowLayout());
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel panel = new JPanel();
        //add the Altitude label and Text box to the panel
        panel.add(new JLabel("Altitude Value (100s):"));
        txtAltitudeValueInput = new JTextField("0", 3);
        panel.add(txtAltitudeValueInput);
        DocumentListener altitudeListener = new AltitudeValueListener();
        txtAltitudeValueInput.getDocument().addDocumentListener(altitudeListener);

        //add the Fuel label and Text box to the panel
        panel.add(new JLabel("Fuel Value:"));
        txtPetrolValueInput = new JTextField("0", 3);
        panel.add(txtPetrolValueInput);
        DocumentListener fuelListener = new FuelValueListener();
        txtPetrolValueInput.getDocument().addDocumentListener(fuelListener);

        //add the Speed label and Text box to the panel
        panel.add(new JLabel("Speed Value:"));
        txtSpeedValueInput = new JTextField("0", 3);
        panel.add(txtSpeedValueInput);
        DocumentListener speedListener = new SpeedValueListener();
        txtSpeedValueInput.getDocument().addDocumentListener(speedListener);

        //add the Temperature label and Text box to the panel
        panel.add(new JLabel("Temperature Value:"));
        txtTempValueInput = new JTextField("0", 3);
        panel.add(txtTempValueInput);
        DocumentListener tempListener = new TempValueListener();
        txtTempValueInput.getDocument().addDocumentListener(tempListener);

        //add the Oil label and Text box to the panel
        panel.add(new JLabel("Oil Value:"));
        txtOilValueInput = new JTextField("0", 3);
        panel.add(txtOilValueInput);
        DocumentListener oilListener = new OilValueListener();
        txtOilValueInput.getDocument().addDocumentListener(oilListener);

        //new button
        btnScript = new JButton("Run XML Script");

        // When the button is read the XML script will be run
        btnScript.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                new Thread() {
                    @Override
                    public void run() {
                        runXMLScript();
                    }
                }.start();
            }
        });
        panel.add(btnScript);
        add(panel);
        pack();

        setLocationRelativeTo(null); // display in centre of screen
        this.setVisible(true);

        // Set up the dashboard screen        
        JFrame dashboard = new JFrame("Aircraft Dashboard");
        dashboard.setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
        dashboard.setLayout(new FlowLayout());

        //JAVA BEAN: adding the Altitude indicator from a bean
        beanAltitude = new IndicatorBean();
        beanAltitude.setLabel("ALTITUDE");
        // beanAltitude.setTheFont("Engravers MT"); //example usage of setTheFont()
        // beanAltitude.setValue(100); // example usage of setValue()
        //beanAltitude.setColor(Color.red); //example usage of setColor()
        dashboard.add(beanAltitude);

        //FACADE: add the Fuel indicator
        facadeFuel = new FacadeIndicator();
        facadeFuel.setFuelLabel("FUEL");
        facadeFuel.setFuelValue(100);
        dashboard.add((Component) facadeFuel.getFuelDial());

        //FACTORY: add the speed indicator
        indicatorSpeed = FactoryIndicator.getIndicator("SPEED");
        indicatorSpeed.setLabel("SPEED");
        dashboard.add((Component) indicatorSpeed);

        //FACTORY: add the temperature indicator
        indicatorTemp = FactoryIndicator.getIndicator("TEMPERATURE");
        indicatorTemp.setLabel("TEMP");
        dashboard.add((Component) indicatorTemp);

        //FACTORY: add the oil indicator
        indicatorOil = FactoryIndicator.getIndicator("OIL");
        indicatorOil.setLabel("OIL");
        indicatorOil.setValue(100);
        dashboard.add((Component) indicatorOil);

        dashboard.pack();

        // centre the dashboard frame above the control frame
        Point topLeft = this.getLocationOnScreen(); // top left of control frame (this)
        int hControl = this.getHeight(); // height of control frame (this)
        int wControl = this.getWidth(); // width of control frame (this)
        int hDash = dashboard.getHeight(); // height of dashboard frame 
        int wDash = dashboard.getWidth(); // width of dashboard frame 
        // calculate where top left of the dashboard goes to centre it over the control frame
        Point p2 = new Point((int) topLeft.getX() - (wDash - wControl) / 2, (int) topLeft.getY() - (hDash + hControl));
        dashboard.setLocation(p2);
        dashboard.setVisible(true);
    }

    /**
     * Run the XML script file which generates events for the dashboard
     * indicators
     */
    private void runXMLScript() {
        try {
            DashboardEventGeneratorFromXML dbegXML = new DashboardEventGeneratorFromXML();

            // Register for speed events from the XML script file
            DashBoardEventListener dbelSpeed = new DashBoardEventListener() {
                @Override
                public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                    indicatorSpeed.setValue(Integer.parseInt(dbe.getValue()));
                }
            };
            dbegXML.registerDashBoardEventListener("speed", dbelSpeed);

            // Register for petrol events from the XML script file
            DashBoardEventListener dbelPetrol = new DashBoardEventListener() {
                @Override
                public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                    facadeFuel.setValue(Integer.parseInt(dbe.getValue()));
                }
            };
            dbegXML.registerDashBoardEventListener("petrol", dbelPetrol);

            // Register for temperature events from the XML script file
            DashBoardEventListener dbelTemp = new DashBoardEventListener() {
                @Override
                public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                    indicatorTemp.setValue(Integer.parseInt(dbe.getValue()));
                }
            };
            dbegXML.registerDashBoardEventListener("temp", dbelTemp);
            // Register for oil events from the XML script file
            DashBoardEventListener dbelOil = new DashBoardEventListener() {
                @Override
                public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                    indicatorOil.setValue(Integer.parseInt(dbe.getValue()));
                }
            };
            dbegXML.registerDashBoardEventListener("oil", dbelOil);
            // Register for altitude events from the XML script file
            DashBoardEventListener dbelAltitude = new DashBoardEventListener() {
                @Override
                public void processDashBoardEvent(Object originator, DashBoardEvent dbe) {
                    beanAltitude.setValue(Integer.parseInt(dbe.getValue()));
                }
            };
            dbegXML.registerDashBoardEventListener("altitude", dbelAltitude);

            // Process the script file - it willgenerate events as it runs
            dbegXML.processScriptFile(XML_SCRIPT);

        } catch (Exception ex) {
            Logger.getLogger(DashboardDemoMain.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Set the speed value to the value entered in the textfield.
     */
    public void setSpeed() {
        try {
            int value = Integer.parseInt(txtSpeedValueInput.getText().trim());
            indicatorSpeed.setValue(value);
        } catch (NumberFormatException e) {
        }
        // don't set the speed if the input can't be parsed
    }

    public void setTemp() {
        try {
            int value = Integer.parseInt(txtTempValueInput.getText().trim());
            indicatorTemp.setValue(value);
        } catch (NumberFormatException e) {
        }
        // don't set the temp if the input can't be parsed
    }

    public void setOil() {
        try {
            int value = Integer.parseInt(txtOilValueInput.getText().trim());
            indicatorOil.setValue(value);
        } catch (NumberFormatException e) {
        }
        // don't set the oil if the input can't be parsed
    }

    /**
     * Set the petrol value to the value entered in the textfield.
     */
    public void setPetrol() {
        try {
            int value = Integer.parseInt(txtPetrolValueInput.getText().trim());
            facadeFuel.setValue(value);

        } catch (NumberFormatException e) {
        }
        // don't set the petrol if the input can't be parsed
    }

    public void setAltitude() {
        try {
            int value = Integer.parseInt(txtAltitudeValueInput.getText().trim());
            beanAltitude.setValue(value);

        } catch (NumberFormatException e) {
        }
        // don't set the altitude if the input can't be parsed
    }

    /**
     * Respond to user input in the Speed textfield
     */
    private class SpeedValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setSpeed();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setSpeed();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }

    /**
     * Respond to user input in the Petrol textfield
     */
    private class FuelValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setPetrol();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setPetrol();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }

    private class OilValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setOil();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setOil();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }

    private class TempValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setTemp();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setTemp();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }

    private class AltitudeValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setAltitude();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setAltitude();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }

    /**
     *
     * @param args - unused
     */
    public static void main(String[] args) {
        DashboardDemoMain dm = new DashboardDemoMain();

    }
}
