using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace MatIDE.Converters
{
	/// <summary>
	/// </summary>
	public class ZeroToVisibilityConverter : MarkupExtension, IValueConverter
	{
		private static ZeroToVisibilityConverter _converter;
		
		/// <summary>
		/// constructor
		/// </summary>
		public ZeroToVisibilityConverter()
		{
		}
		
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if ( _converter == null )
				_converter = new ZeroToVisibilityConverter();
			return _converter;
		}
		
		#region IValueConverter implementation
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ( value == null )
				return System.Windows.Visibility.Collapsed;
			
			if ( value is int ){
				if ( (int)value == 0 )
					return System.Windows.Visibility.Collapsed;
			}
			return System.Windows.Visibility.Visible;	
		}
		
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
