using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Boutique.Models
{
    public class DetailsImple
    {
        static string connection = @"Data Source=DESKTOP-7CJJVUO;Initial Catalog=shop;User ID=sa;Password=sa123";
        public List<BoutiqueDetails> GetBoutique()
        {
            var list = new List<BoutiqueDetails>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM Boutique";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var obj = new BoutiqueDetails();
                        obj.Id = Convert.ToInt32(reader[0]);
                        obj.Name = reader[1].ToString();
                        obj.Styles = reader[2].ToString();
                        obj.Price = Convert.ToInt32(reader[3]);
                        list.Add(obj);
                    }
                }
                catch(SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }
        public void Delete(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                var query = $"drop from Boutique where Id={Id}";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("No Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void Update(BoutiqueDetails Bout)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                var query = $"UPDATE Boutique set Name = '{ Bout.Name }', Styles = '{Bout.Styles}', Price = {Bout.Price} WHERE Id = {Bout.Id}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("No Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void Add(BoutiqueDetails obj)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                var query = "Insert into Boutique values(@Id,@Name, @Styles, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Styles", obj.Styles);
                cmd.Parameters.AddWithValue("@Price", obj.Price);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("No Details were added");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
