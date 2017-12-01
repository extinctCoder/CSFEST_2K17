using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using SmartHomeAutomation.CustomControls;
using SmartHomeAutomation.db;
using SmartHomeAutomation.DAL;

namespace SmartHomeAutomation.ComponentModel
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : UserControl
    {
        private control_panel _controlPanel = null;
        public ControlPanel()
        {
            InitializeComponent();
            this._controlPanel = new control_panel();
        }

        public ControlPanel(control_panel _controlPanel)
        {
            InitializeComponent();
            this._controlPanel = _controlPanel;
            this.id_text.Text = this._controlPanel.id.ToString();
            this.name_text.Text = this._controlPanel.name;
            this.online_status_btn.IsChecked = this._controlPanel.online_status == 1 ? true : false;
            this.enabled_btn.IsChecked = this._controlPanel.enabaled_status == 1 ? true : false;
            this.description_text.Text = this._controlPanel.description;
            this.loadRooms();
            if (this._controlPanel.enabaled_status == 0)
            {
                this.tabControl.IsEnabled = false;
            }
            if (this._controlPanel.enabaled_status == 1)
            {
                this.tabControl.IsEnabled = true;
            }
        }

        private void loadRooms()
        {
            if (this._controlPanel.rooms != null)
            {
                this.label.Visibility = Visibility.Hidden;
                this.tabControl.Visibility = Visibility.Visible;
                foreach (var room in this._controlPanel.rooms)
                {
                    this.tabControl.Items.Add(new TabItem()
                    {
                        Header = room.name.ToUpper(),
                        Content = new Room(room)
                    });
                    StatusBar.setConsoleTxt(room.name + " is created.");
                }
            }
            else
            {
                this.label.Visibility = Visibility.Visible;
                this.tabControl.Visibility = Visibility.Hidden;
                this.label.Content = "no room is available in database.";
            }
        }
        

        private void Enabled_btn_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.enabled_btn.IsChecked == true)
            {
                this.tabControl.IsEnabled = true;
                this._controlPanel.enabaled_status = 1;
                StatusBar.setConsoleTxt(this._controlPanel.name + " is now enabled.");
            }
            else
            {
                this.tabControl.IsEnabled = false;
                this._controlPanel.enabaled_status = 0;
                StatusBar.setConsoleTxt(this._controlPanel.name + " is disabled.");
            }
            dbHandler.DB.SaveChanges();
        }
    }
}
