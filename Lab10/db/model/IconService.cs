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
    class IconService: IDAO<Icon>
    {
        public int Add(Icon icon)
        {
            if (icon != null)
            {
                using (SqlConnection connection = 
                    new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    connection.Open();
                    string sqlExpression = @"insert into Icons (ProductId, Photo)
                                            values(@productId, @photo);
                                            SET @id=SCOPE_IDENTITY();";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    sqlCommand.Parameters.Add(new SqlParameter("@productId", icon.ProductId));
                    sqlCommand.Parameters.Add(new SqlParameter("@photo", icon.Photo));
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

        public List<Icon> FindAll()
        {
            List<Icon> icons = new List<Icon>();

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "select * from Icons;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Icon icon = new Icon()
                        {
                            Id = result.GetInt32(0),
                            ProductId = result.GetInt32(1),
                            Photo = (byte[]) result.GetValue(2)
                        };
                        icons.Add(icon);
                    }
                }
            }

            return icons;
        }

        public Icon FindById(long id)
        {

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();
                string sqlExpression = "select * from Icons where Id=@id;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    Icon icon = new Icon()
                    {
                        Id = result.GetInt32(0),
                        ProductId = result.GetInt32(1),
                        Photo = DBNull.Value.Equals(result.GetValue(6))?null: (byte[])result.GetValue(2)
                    };
                    return icon;
                }
            }

            return null;
        }

        public bool Update(long id, Icon newValue)
        {
            if (newValue != null)
            {
                using (SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    connection.Open();
                    string sqlExpression = "update Icons set ProductId=@productId, Photo=@photo" +
                                           " where id=@id";
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    sqlCommand.Parameters.Add(new SqlParameter("@id", newValue.Id));
                    sqlCommand.Parameters.Add(new SqlParameter("@productId", newValue.ProductId));
                    sqlCommand.Parameters.Add(new SqlParameter("@photo", newValue.Photo));
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
                string sqlExpression = "delete from Icons;";
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
                SqlTransaction transaction = connection.BeginTransaction();

                string sqlExpression = "delete from Icons where id=@id;";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                sqlCommand.Transaction = transaction;

                try
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                    sqlCommand.ExecuteNonQuery();

/*
                    sqlCommand.CommandText = "delete from Products where id=@id;";
                    sqlCommand.ExecuteNonQuery();
*/

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
