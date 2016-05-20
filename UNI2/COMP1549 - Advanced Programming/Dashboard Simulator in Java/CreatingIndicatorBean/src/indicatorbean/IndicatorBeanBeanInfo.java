package indicatorbean;

import java.awt.Image;
import java.beans.*;

/**
 *
 * @author Gyokay Ali
 */
public class IndicatorBeanBeanInfo extends SimpleBeanInfo {

    Class beanClass = IndicatorBean.class;

    public IndicatorBeanBeanInfo() {
    }

    /**
     * This method returns a list of properties that should appear on the
     * property sheet in the IDE. Without this all properties including all the
     * inherited ones appear.
     *
     * @return
     */
    @Override
    public PropertyDescriptor[] getPropertyDescriptors() {
        try {
            PropertyDescriptor _value = new PropertyDescriptor("Value", beanClass, "getValue", "setValue");
            PropertyDescriptor _label = new PropertyDescriptor("Label", beanClass, "getLabel", "setLabel");
            PropertyDescriptor _font = new PropertyDescriptor("Font", beanClass, "getTheFont", "setTheFont");
            PropertyDescriptor _color = new PropertyDescriptor("Color", beanClass, "getColor", "setColor");

            PropertyDescriptor[] pds = new PropertyDescriptor[]{
                _value,
                _label,
                _font,
                _color
            };
            return pds;

        } catch (IntrospectionException ex) {
            ex.printStackTrace();
            return null;
        }
    }
    // Get the image to use as an icon.  Note that the image files need to be included
// in the bean's jar file.  One way is to put them in the same folder as the .java files
// Another way is to create a folder (e.g. called icons) and in NetBeans 
// right-click the project and choose Properties->Sources to add that folder 
// to the Source Packages folders
    public Image getIcon(int iconKind) {
        switch (iconKind) {
            case BeanInfo.ICON_COLOR_16x16:
                return loadImage("binbeanicon.jpg");
            case BeanInfo.ICON_COLOR_32x32:
                return loadImage("binbeanicon_big.jpg");
            case BeanInfo.ICON_MONO_16x16:
                return loadImage("binbeanicon_greyscale.jpg");
            case BeanInfo.ICON_MONO_32x32:
                return loadImage("binbeanicon_greyscale.jpg");
        }
        return null;
    }
    
    
}
