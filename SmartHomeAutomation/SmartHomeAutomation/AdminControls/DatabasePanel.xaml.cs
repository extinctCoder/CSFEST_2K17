using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using SmartHomeAutomation.db;

namespace SmartHomeAutomation.AdminControls
{
    /// <summary>
    /// Interaction logic for DatabasePanel.xaml
    /// </summary>
    public partial class DatabasePanel : UserControl
    {
        public DatabasePanel()
        {
            InitializeComponent();
            using (var db = new HomeAutomationCentralDatabaseEntities())
            {
                this.DataGrid.ItemsSource = db.Users.ToList();
            }
        }
    }
}
