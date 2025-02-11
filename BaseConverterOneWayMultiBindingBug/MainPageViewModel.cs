using System.Globalization;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BaseConverterOneWayMultiBindingBug;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] 
    private int _count = 0;

    [ObservableProperty] 
    private string _countText = "# times clicked: ";
    
    [RelayCommand]
    private void CounterClick()
    {
        Count++;
    }
}


[AcceptEmptyServiceProvider]
// This doesn't work with MultiBinding
public class IntToStringConverter : BaseConverterOneWay<int, string>
{
    public override string ConvertFrom(int value, CultureInfo? culture)
    {
        return value.ToString(culture);
    }

    public override string DefaultConvertReturnValue { get; set; } = "NULL";
}


[AcceptEmptyServiceProvider]
// This works with MultiBinding
public class IntToObjectConverter : BaseConverterOneWay<int, object>
{
    public override string ConvertFrom(int value, CultureInfo? culture)
    {
        return value.ToString(culture);
    }

    public override object DefaultConvertReturnValue { get; set; } = "NULL";
}