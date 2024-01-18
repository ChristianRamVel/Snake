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
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Lógica de interacción para UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public User user;
        Label lb_username;
        TextBox tb_username;
        Label lb_password;
        PasswordBox tb_password;
        Button bt_loggin;
        public UserLogin()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Height = 500;
            this.Width = 500;

            sp_ventana_login.VerticalAlignment = VerticalAlignment.Center;
            sp_ventana_login.HorizontalAlignment = HorizontalAlignment.Center;

            lb_username = new Label();
            lb_username.Content = "Usuario: ";
            sp_ventana_login.Children.Add(lb_username);

            tb_username = new TextBox();
            tb_username.Height = 18;
            tb_username.Width = 200;
            tb_username.Margin = new Thickness(0, 0, 0, 20);
            sp_ventana_login.Children.Add(tb_username);

            lb_password = new Label();
            lb_username.Content = "Contraseña: ";
            sp_ventana_login.Children.Add(lb_password);


            tb_password = new PasswordBox();
            tb_password.Width = 200;
            tb_password.Margin = new Thickness(0, 0, 0, 20);
            sp_ventana_login.Children.Add(tb_password);

            bt_loggin = new Button();
            bt_loggin.Height = 50;
            bt_loggin.Content = "Aceptar";
            bt_loggin.Width = 70;
            bt_loggin.Click += Button_Click;
            bt_loggin.Margin = new Thickness(0, 0, 0, 20);
            sp_ventana_login.Children.Add(bt_loggin);


        }

        private void Button_Click(Object sender, RoutedEventArgs e)
        {

            String username = tb_username.Text;
            String password = tb_password.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.Name == username && user.Password == password);

                if (userfound)
                {
                    user = context.Users.Single<User>(user => user.Name == username && user.Password == password);

                    Close();

                }
                else
                {
                    MessageBox.Show("usuario no encontrado");
                }
            }
        }
    }
}
