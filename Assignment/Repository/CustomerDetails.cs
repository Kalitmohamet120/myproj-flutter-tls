using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace Assignment.Repository
{
    [Authorize]
    public class CustomerDetails
    {
        SqlConnection con;
        SqlCommand cmd;
        public CustomerDetails()
        {
            con = new SqlConnection("server=ENGKALIT;database=Bookshop; integrated security=true; TrustServerCertificate=True;");
        }

        public List<Data> getAll()
        {
            List<Data> data = new List<Data>();
            using (con)
            {
                con.Open();
                string _query = "select * from Customers order by FullName asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new Data() { Id = Convert.ToInt32(dr["id"]),  Full_Name = dr["FullName"].ToString(), Email = dr["Email"].ToString(), Phone = dr["Phone"].ToString(), });
                    }

                }
            }
            return data;

        }


        public Data get_by_id(int id)
        {
            Data data = new Data();
            using (con)
            {
                con.Open();
                string _query = $"select * from Customers where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new Data() { Id = Convert.ToInt32(dr["id"]), Full_Name = dr["FullName"].ToString(), Email = dr["Email"].ToString(), Phone = dr["Phone"].ToString() };
                }
            }
            return data;
        }
           public bool Register(string FullName, string Email, string Phone)    {
            using (con)
            {
                con.Open();
                string _query = $"insert into Customers values({{'{FullName}','{Email}','{Phone}')";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool update(int id, string FullName, string Email,string Phone)
        {
            using (con)                                       
            {
                con.Open();
                string _query = $"update Customers set Full_Name='{FullName}',Email= '{Email}',Phone= '{Phone}' where id= {id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool delete(int id)
        {

            using (con)
            {
                con.Open();
                string _query = $"delete from Customers where id={id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}


