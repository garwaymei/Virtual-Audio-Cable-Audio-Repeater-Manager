using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VACARM
{
    /// <summary>
    /// Interaction logic for DeviceControl.xaml
    /// </summary>
    public partial class DeviceControl : UserControl
    {
        private MMDevice device;

        public DeviceControl(MMDevice device)
        {
            InitializeComponent();

            this.device = device;

            deviceName.Text = device.DeviceFriendlyName;

            if (device.State != DeviceState.Active) deviceColor.Color = Colors.Purple;
            else if (device.DataFlow == DataFlow.Capture) deviceColor.Color = Colors.Red;
            else deviceColor.Color = Colors.Green;
        }
    }
}
