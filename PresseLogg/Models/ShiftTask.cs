using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseLogg.Models
{
    public class ShiftTask
    {
        [Key]
        public int TaskId { get; set; }
        [Display(Name = "Oppgave")]
        [Required(ErrorMessage = "Skriv inn oppgavenavn")]
        [StringLength(50, ErrorMessage = "Maks 50 tegn")]
        public string Task { get; set; }
        public int Status { get; set; }


    }
}
