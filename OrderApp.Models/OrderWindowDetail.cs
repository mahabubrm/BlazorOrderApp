using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class OrderWindowDetail
    {
        [Key]
        public int WindowDetailsId { get; set; }
        public int OrderWindowId { get; set; }
        public int ElementNo { set; get; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual OrderWindow OrderWindow { get; set; }
    }
}
