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
using SmartHomeAutomation.CustomControls;
using SmartHomeAutomation.db;

namespace SmartHomeAutomation.ComponentModel
{
    /// <summary>
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        private room _room = null;
        public Room()
        {
            InitializeComponent();
            this._room = new room();
        }

        public Room(room _room)
        {
            InitializeComponent();
            this._room = _room;
            this.id_text.Text = this._room.id.ToString();
            this.name_text.Text = this._room.name;
            this.description_text.Text = this._room.description;
            this.loadComponent();
        }

        private void loadComponent()
        {
            if (this._room.components == null || this._room.components.Count == 0)
            {
                Label _label = new Label();
                _label.Content = "no component avilabel in database";
                this.container.Children.Add(_label);
            }
            else
            {
                this.container.Children.Clear();
                foreach (var component in _room.components)
                {
                    this.container.Children.Add(new Component(component));
                    StatusBar.setConsoleTxt(component.name + " is created.");
                }
            }
        }
    }
}
