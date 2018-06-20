using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseLogg.Models
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "FKNR")]
        public int ArticleId { get; set; }
        [Display(Name = "Artikkelnavn")]
        public string Name { get; set; }
        public double Density { get; set; }

    }
}
