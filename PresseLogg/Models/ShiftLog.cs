using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresseLogg.Models
{
    public enum Shift
    {
        Formiddag, Ettermiddag, Natt1, Natt2, NattTilLørdag, NattTilMandag, Lørdag
    }
    public class ShiftLog
    {
        public int ShiftLogId { get; set; }
        public int ShiftTaskGroupId { get; set; }
        public Shift Shift { get; set; }

        [Required(ErrorMessage = "Legg inn dato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Skriv noe i loggen!")]
        [Display(Name = "Logg")]
        [StringLength(1000)]
        public string Text { get; set; }
        public int? PictureId { get; set; }


        public virtual ShiftTaskGroup ShiftTaskGroup { get; set; }

    }
}