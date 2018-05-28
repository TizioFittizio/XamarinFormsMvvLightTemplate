using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateMvvmLight.Converters
{
    // https://stackoverflow.com/questions/46315807/xamarin-forms-negate-bool-binding-values?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
    public class NegateBoolCoverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
