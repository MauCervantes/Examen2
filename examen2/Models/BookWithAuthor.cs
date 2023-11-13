using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2.Models
{
    public class BookWithAuthor
    {
        public string titleBook { get; set; } = null;
        public string author { get; set; } = null;
        public int chaptersBook { get; set; }
        public int pagesBook { get; set; }
        public double priceBook { get; set; }
    }
}
