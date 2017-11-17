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

namespace SmartHomeAutomation.CustomControls
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void Login_btn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.database_cbox.SelectedIndex != -1)
                {
                    
                    if (this.database_cbox.SelectedIndex == 0)
                    {
                        using (var db = new HomeAutomationCentralDatabaseEntities())
                        {
                            foreach (var dbUser in db.Users)
                            {
                                if (dbUser.idUser == Convert.ToInt32(this.userid_txt.Text) &&
                                    dbUser.passwordUser == this.password_txt.Password)
                                {
                                    Debug.WriteLine("Login successful FROM HomeAutomationCentralDatabaseEntities");
                                    break;
                                }
                            }
                        }
                    }
                    else if (this.database_cbox.SelectedIndex == 1)
                    {
                        using (var db = new HomeAutomationModel_1_DatabaseEntities())
                        {
                            foreach (var dbUser in db.Users)
                            {
                                if (dbUser.idUser == Convert.ToInt32(this.userid_txt.Text) &&
                                    dbUser.passwordUser == this.password_txt.Password)
                                {
                                    Debug.WriteLine("Login successful FROM HomeAutomationModel_1_DatabaseEntities");
                                    break;
                                }
                            }
                        }
                    }
                    else if (this.database_cbox.SelectedIndex == 2)
                    {
                        using (var db = new HomeAutomationModel_2_DatabaseEntities())
                        {
                            foreach (var dbUser in db.Users)
                            {
                                if (dbUser.idUser == Convert.ToInt32(this.userid_txt.Text) &&
                                    dbUser.passwordUser == this.password_txt.Password)
                                {
                                    Debug.WriteLine("Login successful FROM HomeAutomationModel_2_DatabaseEntities");
                                    break;
                                }
                            }
                        }
                    }
                    else if (this.database_cbox.SelectedIndex == 3)
                    {
                        using (var db = new HomeAutomationModel_3_DatabaseEntities())
                        {
                            foreach (var dbUser in db.Users)
                            {
                                if (dbUser.idUser == Convert.ToInt32(this.userid_txt.Text) &&
                                    dbUser.passwordUser == this.password_txt.Password)
                                {
                                    Debug.WriteLine("Login successful FROM HomeAutomationModel_3_DatabaseEntities");
                                    break;
                                }
                            }
                        }
                    }
                    else if (this.database_cbox.SelectedIndex == 4)
                    {
                        using (var db = new HomeAutomationModel_4_DatabaseEntities())
                        {
                            foreach (var dbUser in db.Users)
                            {
                                if (dbUser.idUser == Convert.ToInt32(this.userid_txt.Text) &&
                                    dbUser.passwordUser == this.password_txt.Password)
                                {
                                    Debug.WriteLine("Login successful FROM HomeAutomationModel_4_DatabaseEntities");
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}
