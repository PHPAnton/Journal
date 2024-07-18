using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Journal.Models;

namespace Journal.ViewModels.Converters
{
    public class StudentsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var students = value as List<Student>;
            if (students != null)
            {
                return string.Join(", ", students.Select(s => $"{s.FirstName} {s.LastName}"));
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
