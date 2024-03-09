using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace Assignment.Models
{
    public class Data
    {
        public int Id { get; set; }
     
        public string Full_Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
    public class info
    {
        public int P_id { get; set; }

        public string P_Name { get; set; }

        public float price { get; set; }


    }
}