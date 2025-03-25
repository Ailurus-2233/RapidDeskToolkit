using System.Collections;
using System.Globalization;
using Avalonia.Data.Converters;

namespace RapidDeskToolkit.UIPackage.Converters;

/// <summary>
///     将可用的数据转换为可见性，可用的数据类型有
///         1. 非空对象
///         2. 非空字符串
///         3. 非空集合
///     转换器参数： Reverse 反转可见性
/// </summary>
public class AvailableToBooleanConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var isReverse = parameter is "Reverse";
        var isNull = value == null || (value is string str && string.IsNullOrWhiteSpace(str));
        var isFalse = value is false;
        var enumerable = value as IEnumerable;
        var next = enumerable?.GetEnumerator();
        using var next1 = next as IDisposable;
        var isEmpty = next != null && !next.MoveNext();
        var isAvailable = !(isNull || isFalse || isEmpty);

        // 执行异或操作，如果可用和反转可见性不一致，则返回可见，否则返回隐藏
        return isAvailable ^ isReverse;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}