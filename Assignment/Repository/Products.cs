using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace Assignment.Repository
{
    [Authorize]
    public class Products
    {
        SqlConnection con;
        SqlCommand cmd;
        public Products()
        {
            con = new SqlConnection("server=ENGKALIT;database=Bookshop; integrated security=true; TrustServerCertificate=True;");
        }
      

 



        public List<info> getAll()
        {
            List<info> data = new List<info>();
            using (con)
            {
                con.Open();
                string _query = "select * from Products order by P_Name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new info() { P_id = Convert.ToInt32(dr["P_id"]), P_Name = dr["P_Name"].ToString(), price = Convert.ToInt32(dr["P_price"]) } );
                    }

                }
            }
            return data;

        }


        public info get_by_id(int P_id)
        {
            info data = new info();
            using (con)
            {
                con.Open();
                string _query = $"select * from Products where P_id={P_id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new info() {  P_id = Convert.ToInt32(dr["P_id"]), P_Name = dr["P_Name"].ToString(), price = Convert.ToInt32(dr["P_price"]) };
                }
            }
            return data;
        }

        public bool create(string P_Name , float price )
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into Products values('{P_Name}',{price})";
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

        public bool Edit(int P_id, string P_Name, float price)
        {
            using (con)
            {
                con.Open();
                string _query = $"update Products set P_Name='{P_Name}',P_price= {price} where P_id= {P_id}";
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
                string _query = $"delete from Products where P_id={id}";
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


  