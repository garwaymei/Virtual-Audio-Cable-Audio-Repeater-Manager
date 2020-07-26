using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VACARM;

namespace VACARM
{
    /// <summary>
    /// Interaction logic for RepeaterMenu.xaml
    /// </summary>
    public partial class RepeaterMenu : Window
    {
        private RepeaterInfo info;

        public RepeaterInfo Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                info.OnPropertyChanged("SamplingRate");
                info.OnPropertyChanged("BitsPerSample");
                info.OnPropertyChanged("ChannelConfig");
                info.OnPropertyChanged("ChannelMask");
                info.OnPropertyChanged("BufferMs");
                info.OnPropertyChanged("Buffers");
                info.OnPropertyChanged("Prefill");
                info.OnPropertyChanged("ResyncAt");
            }
        }

        public RepeaterMenu(RepeaterInfo info)
        {
            InitializeComponent();

            List<Channel> channelList = Enum.GetValues(typeof(Channel)).Cast<Channel>().ToList();

            for (int i = 0; i < channelList.Count; i++)
            {
                Channel c = channelList[i];

                TextBlock text = new TextBlock();
                text.Text = c.ToString();
                Grid.SetRow(text, 0);
                Grid.SetColumn(text, i);

                CheckBox checkBox = new CheckBox();
                checkBox.Tag = c;
                Grid.SetRow(checkBox, 1);
                Grid.SetColumn(checkBox, i);
                Binding bindChannel = new Binding("ChannelMask");
                bindChannel.Converter = new ChannelConverter(info);
                bindChannel.ConverterParameter = (int)c;
                bindChannel.Source = info;
                checkBox.SetBinding(CheckBox.IsCheckedProperty, bindChannel);

                channels.Children.Add(text);
                channels.Children.Add(checkBox);
            }

            Info = info;
            DataContext = Info;
        }

        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
[ValueConversion(typeof(int), typeof(bool))]
public class ChannelConverter : IValueConverter
{
    RepeaterInfo info;

    public ChannelConverter(RepeaterInfo info)
    {
        this.info = info;
    }

    //channelmask to channel bool
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int bit = (int)parameter;
        int val = (int)value;
        return (val & bit) != 0;
    }

    //bool to channelmask
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int mask = info.ChannelMask;
        int bit = (int)parameter;
        bool check = (bool)value;

        if (check) return mask | bit;
        else return mask & ~bit;
    }
}