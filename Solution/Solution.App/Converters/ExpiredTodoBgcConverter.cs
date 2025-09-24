using System.Globalization;

namespace Solution.App.Converters;

public class ExpiredTodoBgcConverter: IMultiValueConverter
{
    object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is bool isReady && values[1] is DateTime deadline)
        {
            return !isReady && deadline < DateTime.Now.AddDays(-1)  ? Colors.LightPink : Colors.White;
        }
        return Colors.White;
    }

    object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
