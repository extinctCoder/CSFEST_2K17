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
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace SmartHomeAutomation.CustomControls
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public static StatusBar _statusBar = null;
        private StatusBar()
        {
            InitializeComponent();
        }

        public static StatusBar statusBar
        {
            get
            {
                if (StatusBar._statusBar == null)
                {
                    StatusBar._statusBar=new StatusBar();
                }
                return StatusBar._statusBar;
            }
            private set { }
        }

        public static void setConsoleTxt(String text)
        {
            if (StatusBar._statusBar == null)
            {
                StatusBar._statusBar = new StatusBar();
            }
            StatusBar._statusBar.primary_console.Content = text;
        }
    }
}
