using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comments
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Comment { get; set;}

        public int Topic_Id { get; set; }

        public int Post_Id { get; set;}
    }
}
