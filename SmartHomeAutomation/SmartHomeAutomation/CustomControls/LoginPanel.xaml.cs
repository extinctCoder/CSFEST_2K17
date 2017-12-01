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
using SmartHomeAutomation.db;
using SmartHomeAutomation.DAL;

namespace SmartHomeAutomation.CustomControls
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        public static EventHandler LoginEventHandler;
        public static user _user = null;
        public LoginPanel()
        {
            InitializeComponent();
            Keyboard.Focus(this.userid_txt);
        }

        public static user LogedUser
        {
            get { return LoginPanel._user; }
            set { LoginPanel._user = value; }
        }

        private void Login_btn_OnClick(object sender, RoutedEventArgs e)
        {
            bool _flag = false;
            foreach (var user in dbHandler.DB.users)
            {
                if (this.userid_txt.Text == user.id.ToString() && this.password_txt.Password == user.password)
                {
                    LoginPanel._user = user;
                    _flag = true;
                    if (LoginPanel.LoginEventHandler != null)
                    {
                        LoginPanel.LoginEventHandler(this, new EventArgs());
                    }
                    break;
                }
            }
            if (_flag)
            {
                StatusBar.setConsoleTxt("Welcome back " + LoginPanel._user.user_name);
            }
            else
            {
                StatusBar.setConsoleTxt("User not found ... :( ");
            }
        }

        private void Userid_txt_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.Focus(this.password_txt);
            }
        }

        private void Password_txt_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Login_btn_OnClick(new object(), new AccessKeyPressedEventArgs());
            }
        }
    }
}
