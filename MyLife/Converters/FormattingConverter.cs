// <copyright file="FormattingConverter.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class FormattingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var format = parameter == null ? null : parameter.ToString();

            if (string.IsNullOrEmpty(format))
            {
                return value.ToString();
            }

            return string.Format(culture, format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
