﻿#pragma warning disable CS1591

using System;
using System.IO;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Convert a byte array into an ImageSource object that can be bound to
    /// the <seealso cref="Image"/> control
    /// </summary>
    public class ByteToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                MemoryStream ms = new MemoryStream(imageAsBytes);
                retSource = ImageSource.FromStream(() => ms);
                ms.Position = 0;

                return retSource;
            }
            else
            {
                return retSource;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
