package uk.ac.gre.comp1549.dashboard.designpatterns;
import uk.ac.gre.comp1549.dashboard.controls.*;
/**
 *
 * @author Gyokay Ali
 */
//Class for the FACTORY DESIGN PATTERN
public class FactoryIndicator {
    
    //use getIndicator method to get object of type indicator 
   public static InterfacePanels getIndicator(String indicatorType){
      if(indicatorType == null){
         return null;
      }		
      if(indicatorType.equalsIgnoreCase("SPEED")){
         return new DialPanel();
         
      } else if(indicatorType.equalsIgnoreCase("FUEL") || indicatorType.equalsIgnoreCase("TEMPERATURE")){
         return new HalfDialPanel();
      } 
      else if(indicatorType.equalsIgnoreCase("OIL")){
         return new BarPanel();
      }      
      return null;
   }
}
