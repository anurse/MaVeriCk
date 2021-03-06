// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="VersionConverter.cs" company="Andrew Nurse">
//   Copyright (c) 2009 Andrew Nurse.  Licensed under the Ms-PL license: http://opensource.org/licenses/ms-pl.html
// </copyright>
// <summary>
//   Defines the VersionConverter type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;

namespace Maverick.ComponentModel {
    public class VersionConverter : TypeConverter {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            Arg.NotNull("value", value);

            string stringValue = value as string;
            if(stringValue == null) {
                throw GetConvertFromException(value);
            }
            return new Version(stringValue.Trim());
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            Arg.NotNull("value", value);
            
            if(destinationType != typeof(string)) {
                throw GetConvertToException(value, destinationType);
            }
            return value.ToString();
        }
    }
}