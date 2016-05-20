package uk.ac.gre.comp1549.dashboard.controls;
import java.awt.Graphics2D;
/**
 * Interface implemented by classes for drawing the hand for Dials and Half Dials
 * @author Gyokay Ali
 */
public interface InterfaceDrawHands {
    public void drawHand(Graphics2D g2, double angle, double handLength, int radius, int padding);
}
