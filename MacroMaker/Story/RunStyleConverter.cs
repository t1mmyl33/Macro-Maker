using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MacroMaker
{
    public class RunStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var svm = (StoryViewModel)value;
            var selection = svm.Story.RunStyle;
            if (selection == "Loop")
                return "Visible";
            return "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //public class RunStyleConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return "Hidden";
    //        var label = ((FrameworkElement)values[1]).Name;
    //        var selection = values[0].ToString();
    //        if (label == "IterationLabel")
    //        {
    //            if (selection == "Loop")
    //                return "Visible";
    //            return "Hidden";
    //        }
    //        if (selection == "Loop")
    //            return "Hidden";
    //        return "Visible";
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
