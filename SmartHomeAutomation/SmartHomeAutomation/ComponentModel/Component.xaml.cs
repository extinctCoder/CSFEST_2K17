using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;
using SmartHomeAutomation.CustomControls;
using SmartHomeAutomation.db;
using SmartHomeAutomation.DAL;

namespace SmartHomeAutomation.ComponentModel
{
    /// <summary>
    /// Interaction logic for Component.xaml
    /// </summary>
    public partial class Component : UserControl
    {
        private component _component;
        public Component()
        {
            InitializeComponent();
            this._component = new component();
        }

        public Component(component _component)
        {
            InitializeComponent();
            this._component = _component;
            this.name_text.Content = this._component.name.ToUpper();
            this.description_text.Content = this._component.description;
            this.id_text.Content = this._component.id.ToString();
            this.type_text.Content = this._component.type;
            this.mode_value_button.IsChecked = this._component.mode == 1 ? true : false;
            this.value_slider.Value = Convert.ToDouble(this._component.value);
            this.value_slider_text.Text = this._component.value.ToString();
            this.name_edit_text.Text = this._component.name;
            this.type_edit_text.Text = this._component.type;
            this.description_edit_text.Text = this._component.description;
        }

        private void Mode_value_button_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.mode_value_button.IsChecked == true)
            {
                this.value_slider.Value = 100;
                this.value_slider.IsEnabled = true;
                StatusBar.setConsoleTxt(this._component.name + " is set to High.");
            }
            else
            {
                this.value_slider.Value = 0;
                this.value_slider.IsEnabled = false;
                StatusBar.setConsoleTxt(this._component.name + " is set to Low.");
            }
            this._component.mode = this.mode_value_button.IsChecked == true ? 1 : 0;
            this._component.value = Convert.ToInt32(this.value_slider.Value);
            dbHandler.DB.SaveChanges();
        }

        private void Value_slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this._component.value = Convert.ToInt32(this.value_slider.Value);
                dbHandler.DB.SaveChanges();
                this.value_slider_text.Text= Convert.ToString(this.value_slider.Value);
                StatusBar.setConsoleTxt(
                    this._component.name + "'s value changed to " + this._component.value.ToString());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this._component.name = this.name_edit_text.Text.ToUpper();
            this._component.type = this.type_edit_text.Text;
            this._component.description = this.description_edit_text.Text;
            dbHandler.DB.SaveChanges();
            this.name_text.Content = this._component.name;
            this.type_text.Content = this._component.type;
            this.description_text.Content = this._component.description;
        }
    }
}
