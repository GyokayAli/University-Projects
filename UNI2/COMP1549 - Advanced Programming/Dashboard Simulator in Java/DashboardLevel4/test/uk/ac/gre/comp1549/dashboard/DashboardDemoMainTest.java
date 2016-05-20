/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uk.ac.gre.comp1549.dashboard;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Gyoki
 */
public class DashboardDemoMainTest {

    private DashboardDemoMain dashboard;

    public DashboardDemoMainTest() {
    }

    @Before
    public void setUp() {
        dashboard = new DashboardDemoMain(); // new instance of main 
        dashboard.setVisible(true);
    }

    /**
     * Test 1 of setSpeed method, of class DashboardDemoMain.
     */
    @Test
    public void testSetSpeed1() {
        System.out.println("Test - setSpeed1");
        dashboard.txtSpeedValueInput.setText("20");
        pause();
        assertEquals(dashboard.indicatorSpeed.getValue(), 20);
    }

    /**
     * Test 2 of setSpeed method, of class DashboardDemoMain.
     */
    @Test
    public void testSetSpeed2() {
        System.out.println("Test - setSpeed2");
        dashboard.txtSpeedValueInput.setText("hello");
        pause();
        assertEquals(dashboard.indicatorSpeed.getValue(), 0);
    }

    /**
     * Test 3 of setSpeed method, of class DashboardDemoMain.
     */
    @Test
    public void testSetSpeed3() {
        System.out.println("Test - setSpeed3");
        dashboard.txtSpeedValueInput.setText("-100");
        pause();
        assertEquals(dashboard.indicatorSpeed.getValue(), 0);
    }

    /**
     * Test 4 of setSpeed method, of class DashboardDemoMain.
     */
    @Test
    public void testSetSpeed4() {
        System.out.println("Test - setSpeed4");
        dashboard.txtSpeedValueInput.setText("0.521");
        pause();
        assertEquals(dashboard.indicatorSpeed.getValue(), 0);
    }

    /**
     * Test 5 of setSpeed method, of class DashboardDemoMain.
     */
    @Test
    public void testSetSpeed5() {
        System.out.println("Test - setSpeed5");
        dashboard.txtSpeedValueInput.setText("101");
        pause();
        assertEquals(dashboard.indicatorSpeed.getValue(), 100);
    }

    /**
     * Test 1 of setTemp method, of class DashboardDemoMain.
     */
    @Test
    public void testSetTemp1() {
        System.out.println("Test - setTemp1");
        dashboard.txtTempValueInput.setText("55");
        pause();
        assertEquals(dashboard.indicatorTemp.getValue(), 55);
    }

    /**
     * Test 2 of setTemp method, of class DashboardDemoMain.
     */
    @Test
    public void testSetTemp2() {
        System.out.println("Test - setTemp2");
        dashboard.txtTempValueInput.setText("A");
        pause();
        assertEquals(dashboard.indicatorTemp.getValue(), 0);
    }

    /**
     * Test 3 of setTemp method, of class DashboardDemoMain.
     */
    @Test
    public void testSetTemp3() {
        System.out.println("Test - setTemp3");
        dashboard.txtTempValueInput.setText("-1");
        pause();
        assertEquals(dashboard.indicatorTemp.getValue(), 0);
    }

    /**
     * Test 4 of setTemp method, of class DashboardDemoMain.
     */
    @Test
    public void testSetTemp4() {
        System.out.println("Test - setTemp4");
        dashboard.txtTempValueInput.setText("25.55");
        pause();
        assertEquals(dashboard.indicatorTemp.getValue(), 0);
    }

    /**
     * Test 5 of setTemp method, of class DashboardDemoMain.
     */
    @Test
    public void testSetTemp5() {
        System.out.println("Test - setTemp5");
        dashboard.txtTempValueInput.setText("1000");
        pause();
        assertEquals(dashboard.indicatorTemp.getValue(), 100);
    }

    /**
     * Test 1 of setOil method, of class DashboardDemoMain.
     */
    @Test
    public void testSetOil1() {
        System.out.println("Test - setOil1");
        dashboard.txtOilValueInput.setText("80");
        pause();
        assertEquals(dashboard.indicatorOil.getValue(), 80);
    }

    /**
     * Test 2 of setOil method, of class DashboardDemoMain.
     */
    @Test
    public void testSetOil2() {
        System.out.println("Test - setOil2");
        dashboard.txtOilValueInput.setText("-80");
        pause();
        assertEquals(dashboard.indicatorOil.getValue(), 0);
    }

    /**
     * Test 3 of setOil method, of class DashboardDemoMain.
     */
    @Test
    public void testSetOil3() {
        System.out.println("Test - setOil3");
        dashboard.txtOilValueInput.setText("No");
        pause();
        assertEquals(dashboard.indicatorOil.getValue(), 100);
    }

    /**
     * Test 4 of setOil method, of class DashboardDemoMain.
     */
    @Test
    public void testSetOil4() {
        System.out.println("Test - setOil4");
        dashboard.txtOilValueInput.setText("17.8");
        pause();
        assertEquals(dashboard.indicatorOil.getValue(), 100);
    }

    /**
     * Test 5 of setOil method, of class DashboardDemoMain.
     */
    @Test
    public void testSetOil5() {
        System.out.println("Test - setOil5");
        dashboard.txtOilValueInput.setText("200");
        pause();
        assertEquals(dashboard.indicatorOil.getValue(), 100);
    }

    /**
     * Test 1 of setPetrol method, of class DashboardDemoMain.
     */
    @Test
    public void testSetPetrol1() {
        System.out.println("Test - setPetrol1");
        dashboard.txtPetrolValueInput.setText("200");
        pause();
        assertEquals(dashboard.facadeFuel.getValue(), 100);
    }

    /**
     * Test 2 of setPetrol method, of class DashboardDemoMain.
     */
    @Test
    public void testSetPetrol2() {
        System.out.println("Test - setPetrol2");
        dashboard.txtPetrolValueInput.setText("0");
        pause();
        assertEquals(dashboard.facadeFuel.getValue(), 0);
    }

    /**
     * Test 3 of setPetrol method, of class DashboardDemoMain.
     */
    @Test
    public void testSetPetrol3() {
        System.out.println("Test - setPetrol3");
        dashboard.txtPetrolValueInput.setText("letter");
        pause();
        assertEquals(dashboard.facadeFuel.getValue(), 100);
    }

    /**
     * Test 4 of setPetrol method, of class DashboardDemoMain.
     */
    @Test
    public void testSetPetrol4() {
        System.out.println("Test - setPetrol4");
        dashboard.txtPetrolValueInput.setText("-5");
        pause();
        assertEquals(dashboard.facadeFuel.getValue(), 0);
    }

    /**
     * Test 5 of setPetrol method, of class DashboardDemoMain.
     */
    @Test
    public void testSetPetrol5() {
        System.out.println("Test - setPetrol5");
        dashboard.txtPetrolValueInput.setText("33.33");
        pause();
        assertEquals(dashboard.facadeFuel.getValue(), 100);
    }

    /**
     * Test 1 of setAltitude method, of class DashboardDemoMain.
     */
    @Test
    public void testSetAltitude1() {
        System.out.println("Test - setAltitude1");
        dashboard.txtAltitudeValueInput.setText("99");
        pause();
        assertEquals(dashboard.beanAltitude.getValue(), 99);
    }

    /**
     * Test 2 of setAltitude method, of class DashboardDemoMain.
     */
    @Test
    public void testSetAltitude2() {
        System.out.println("Test - setAltitude2");
        dashboard.txtAltitudeValueInput.setText("1000");
        pause();
        assertEquals(dashboard.beanAltitude.getValue(), 100);
    }

    /**
     * Test 3 of setAltitude method, of class DashboardDemoMain.
     */
    @Test
    public void testSetAltitude3() {
        System.out.println("Test - setAltitude3");
        dashboard.txtAltitudeValueInput.setText("no");
        pause();
        assertEquals(dashboard.beanAltitude.getValue(), 0);
    }

    /**
     * Test 4 of setAltitude method, of class DashboardDemoMain.
     */
    @Test
    public void testSetAltitude4() {
        System.out.println("Test - setAltitude4");
        dashboard.txtAltitudeValueInput.setText("-0.5");
        pause();
        assertEquals(dashboard.beanAltitude.getValue(), 0);
    }

    /**
     * Test 5 of setAltitude method, of class DashboardDemoMain.
     */
    @Test
    public void testSetAltitude5() {
        System.out.println("Test - setAltitude5");
        dashboard.txtAltitudeValueInput.setText("25.5");
        pause();
        assertEquals(dashboard.beanAltitude.getValue(), 0);
    }

    //this is very good between the tests, so we can see the inputs while being tested with the result
    private void pause() {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException ex) {
            Logger.getLogger(DashboardDemoMain.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
