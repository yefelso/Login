using System;
using System.Data.SqlClient;
using System.Windows;

namespace Register
{
    public partial class MainWindow : Window
    {
        // Cadena de conexión a SQL Server
        private string connectionString = "Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del usuario desde los TextBoxes
            string nombre = NameR.Text;
            string contraseña = PaswordR.Text;
            string correo = EmailR.Text;

            // Insertar datos en la base de datos SQL Server
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO nombre_tabla (nombre, contraseña, correo) VALUES (@nombre, @contraseña, @correo)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Usuario registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana de inicio de sesión
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();

            // Cierra esta ventana de registro
            this.Close();
        }
    }
}
