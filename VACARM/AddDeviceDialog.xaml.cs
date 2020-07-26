using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace VACARM
{
    /// <summary>
    /// Interaction logic for AddDeviceDialog.xaml
    /// </summary>
    public partial class AddDeviceDialog : Window
    {
        public MMDevice Device;

        public AddDeviceDialog()
        {
            InitializeComponent();
            DataContext = new DeviceList();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectDeviceType.SelectedIndex == -1 || selectDevice.SelectedIndex == -1) return;

            List<MMDevice> devices = (selectDeviceType.SelectedIndex == 0) ? (DataContext as DeviceList).WaveIn : (DataContext as DeviceList).WaveOut;
            Device = devices[selectDevice.SelectedIndex];

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void selectDeviceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectDevice.SelectedIndex = -1;
            if (selectDeviceType.SelectedIndex == 0) selectDevice.ItemsSource = (DataContext as DeviceList).WaveInName;
            else selectDevice.ItemsSource = (DataContext as DeviceList).WaveOutName;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
