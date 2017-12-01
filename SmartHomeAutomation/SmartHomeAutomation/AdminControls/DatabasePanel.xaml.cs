using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using SmartHomeAutomation.db;

namespace SmartHomeAutomation.AdminControls
{
    /// <summary>
    /// Interaction logic for DatabasePanel.xaml
    /// </summary>
    public partial class DatabasePanel : UserControl
    {
        private HomeAutomationDbEntities _db = new HomeAutomationDbEntities();
        public DatabasePanel()
        {
            InitializeComponent();
        }
        private void Action_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.action.ItemsSource = this._db.actions.ToList();
        }

        private void Component_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.component.ItemsSource = this._db.components.ToList();
        }

        private void Control_panel_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.control_panel.ItemsSource = this._db.control_panel.ToList();
        }

        private void Data_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.data.ItemsSource = this._db.data.ToList();
        }

        private void Permission_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.permission.ItemsSource = this._db.permissions.ToList();
        }

        private void Room_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.room.ItemsSource = this._db.rooms.ToList();
        }
        private void Scheduler_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.scheduler.ItemsSource = this._db.schedulers.ToList();
        }

        private void Switch_condition_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.switch_condition.ItemsSource = this._db.switch_condition.ToList();
        }

        private void User_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.user.ItemsSource = this._db.users.ToList();
        }

        private void User_group_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.user_group.ItemsSource = this._db.user_group.ToList();
        }

        private void Reload_btn_OnClick(object sender, RoutedEventArgs e)
        {
            this._db.SaveChanges();
            this.action.ItemsSource = this._db.actions.ToList();
            this.component.ItemsSource = this._db.components.ToList();
            this.control_panel.ItemsSource = this._db.control_panel.ToList();
            this.data.ItemsSource = this._db.data.ToList();
            this.permission.ItemsSource = this._db.permissions.ToList();
            this.room.ItemsSource = this._db.rooms.ToList();
            this.scheduler.ItemsSource = this._db.schedulers.ToList();
            this.switch_condition.ItemsSource = this._db.switch_condition.ToList();
            this.user.ItemsSource = this._db.users.ToList();
            this.user_group.ItemsSource = this._db.user_group.ToList();
        }

        private void OnCurrentCellChanged(object sender, EventArgs e)
        {
            this._db.SaveChanges();
            this.action.ItemsSource = this._db.actions.ToList();
            this.component.ItemsSource = this._db.components.ToList();
            this.control_panel.ItemsSource = this._db.control_panel.ToList();
            this.data.ItemsSource = this._db.data.ToList();
            this.permission.ItemsSource = this._db.permissions.ToList();
            this.room.ItemsSource = this._db.rooms.ToList();
            this.scheduler.ItemsSource = this._db.schedulers.ToList();
            this.switch_condition.ItemsSource = this._db.switch_condition.ToList();
            this.user.ItemsSource = this._db.users.ToList();
            this.user_group.ItemsSource = this._db.user_group.ToList();
        }

        private void Action_OnAddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            this._db.SaveChanges();
            this.action.ItemsSource = this._db.actions.ToList();
            this.component.ItemsSource = this._db.components.ToList();
            this.control_panel.ItemsSource = this._db.control_panel.ToList();
            this.data.ItemsSource = this._db.data.ToList();
            this.permission.ItemsSource = this._db.permissions.ToList();
            this.room.ItemsSource = this._db.rooms.ToList();
            this.scheduler.ItemsSource = this._db.schedulers.ToList();
            this.switch_condition.ItemsSource = this._db.switch_condition.ToList();
            this.user.ItemsSource = this._db.users.ToList();
            this.user_group.ItemsSource = this._db.user_group.ToList();
        }
        
    }
}
