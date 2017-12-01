﻿using System;
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
using MahApps.Metro.Controls;
using SmartHomeAutomation.ComponentModel;
using SmartHomeAutomation.CustomControls;
using SmartHomeAutomation.db;
using SmartHomeAutomation.DAL;

namespace SmartHomeAutomation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private user _currentUser = null;
        public MainWindow()
        {
            InitializeComponent();
            LoginPanel.LoginEventHandler += LoginEventHandler;
            this.statusbar_grid.Children.Add(StatusBar.statusBar);
            if (dbHandler.DB == null)
            {
                Label _label = new Label();
                _label.HorizontalContentAlignment = HorizontalAlignment.Center;
                _label.VerticalContentAlignment = VerticalAlignment.Center;
                _label.Content = "no database is available.";
                this.container.Children.Add(_label);
            }
            else
            {
                this.container.Children.Add(new LoginPanel());
            }
            this._currentUser= new user();
        }

        private void LoginEventHandler(object sender, EventArgs eventArgs)
        {
            this.container.Children.Clear();
            this.container.Children.Add(new ControlPanel(LoginPanel.LogedUser.control_panel.First()));
            this._currentUser = LoginPanel.LogedUser;
        }

    }
}