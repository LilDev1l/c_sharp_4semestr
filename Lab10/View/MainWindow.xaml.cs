using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;


namespace lab10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True";
        private string databaseName = "lab10_OOP";

        private int iterator = 0;

        public MainWindow()
        {
            CreateDatabase();
            InitializeComponent();
        }

        public void CreateDatabase()
        {
            bool IsExits = CheckDatabaseExists();
            if (!IsExits)
            {

                    string createDatabase = "CREATE DATABASE " + databaseName + ";";

                    string createTables = @"CREATE TABLE Products
                                               (Id INT PRIMARY KEY IDENTITY,
                                               Name NVARCHAR(50),
                                               Weight INT,
                                               Qty INT)

                                           CREATE TABLE Icons
                                               (Id INT PRIMARY KEY IDENTITY,
                                               ProductId INT foreign key references Products(Id),
                                               Photo varbinary(MAX))";

                    string createProcGetProductInfo = @"CREATE PROCEDURE sp_GetProductsInfo
                                                        AS
                                                            SELECT p.Id, p.Name, p.Weight, p.Qty, i.ProductId, i.Photo 
                                                            FROM Products p join Icons i on p.Id = i.ProductId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(createDatabase, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(createTables, connection);
                    connection.Open();
                    command.ExecuteNonQuery();

                    command.CommandText = createProcGetProductInfo;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckDatabaseExists()
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                    SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, connection);

                    connection.Open();
                    var resultObj = sqlCmd.ExecuteScalar();
                    int? resultInt = resultObj as int?;

                    result = (resultInt > 0);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private void Prev_OnClick(object sender, RoutedEventArgs e)
        {
            if (iterator <= 0)
            {
                iterator = DataTable.Items.Count - 1;
            }

            iterator--;
            DataTable.SelectedItem = DataTable.Items.GetItemAt(iterator);
        }
        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            if (iterator >= DataTable.Items.Count)
            {
                iterator = 0;
            }

            DataTable.SelectedItem = DataTable.Items.GetItemAt(iterator);
            iterator++;
        }
    }
}
