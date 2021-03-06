﻿#pragma warning disable CS1591

using System;
using System.Globalization;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Support for validation with behaviors in XAML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BoolToObjectConverter<T> : IValueConverter
    {
        public T FalseObject { set; get; }

        public T TrueObject { set; get; }

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            return (bool)value ? this.TrueObject : this.FalseObject;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(this.TrueObject);
        }
    }
}
