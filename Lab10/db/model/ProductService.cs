using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.db.model
{
    class ProductService: IDAO<Product>
    {
        public int Add(Product product)
        {
            if (product != null)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    connection.Open();
                    string sqlExpression = @"insert into Products (Name, Weight, Qty)
                                            values(@name, @weight, @qty);
                                            SET @id=SCOPE_IDENTITY()";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    sqlCommand.Parameters.Add(new SqlParameter("@name", product.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@weight", product.Weight));
                    sqlCommand.Parameters.Add(new SqlParameter("@qty", product.Qty));
                    SqlParameter sqlParameter = new SqlParameter()
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.ExecuteNonQuery();
                    return (int)sqlParameter.Value;
                }
            }
            return -1;
        }

        public List<Product> FindAll()
        {
            List<Product> products =  new List<Product>();

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "select * from Products";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Product product = new Product()
                        {
                            Id = result.GetInt32(0),
                            Name = result.GetString(1),
                            Weight = result.GetInt32(2),
                            Qty = result.GetInt32(3),
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public Product FindById(long id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "select * from Products where Id=@id;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    Product product = new Product()
                    {
                        Id = result.GetInt32(0),
                        Name = result.GetString(1),
                        Weight = result.GetInt32(2),
                        Qty = result.GetInt32(3),
                    };

                    return product;
                }
            }

            return null;
        }

        public bool Update(long id, Product newValue)
        {
            if (newValue != null)
            {
                using (SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    connection.Open();
                    string sqlExpression = "update Products set Name=@name,Weight=@weight,Qty=@qty " +
                                           "where Id=@id";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    sqlCommand.Parameters.Add(new SqlParameter("@id", newValue.Id));
                    sqlCommand.Parameters.Add(new SqlParameter("@name", newValue.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@weight", newValue.Weight));
                    sqlCommand.Parameters.Add(new SqlParameter("@qty", newValue.Qty));
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void RemoveAll()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "delete from Products;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void RemoveById(long id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "delete from Products where Id=@id;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
