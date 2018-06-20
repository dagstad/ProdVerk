using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseLogg.Models
{
    public enum Presse
    {
        PL01, PL02, PL03, PL04, PL05
    }

    public class PressLog
    {
        public int ID { get; set; }

        public int ArticleId { get; set; }
        public Presse? Presse { get; set; }

        [Display(Name = "T. pr/h.")]
        public double TonnPrTime { get; set; }

        [Display(Name = "°C Mix.1")]
        public int TempMixer1 { get; set; }

        [Display(Name = "°C Mix.2")]
        public int? TempMixer2 { get; set; }

        [Display(Name = "DT")]
        public double Damptrykk { get; set; }

        [Display(Name = "Kg. pr/h.")]
        public int? KgDampPrTime { get; set; }

        [Display(Name = "Kon")]
        public int? KonTrykk { get; set; }

        [Display(Name = "OT")]
        public int? Oppholdstid { get; set; }

        [Display(Name = "°C Exp.")]
        public int? TempExpander { get; set; }

        [Display(Name = "AMP Mix.1")]
        public int AmpMixer1 { get; set; }

        [Display(Name = "AMP Mix.2")]
        public int? AmpMixer2 { get; set; }

        [Display(Name = "AMP Exp.")]
        public int? AmpExpander { get; set; }

        [Display(Name = "Vin. OAP")]
        public double? VinkelOAP { get; set; }

        [Display(Name = "AMP Pr.")]
        public int? AmpPresse { get; set; }

        [Display(Name = "°C Kj.")]
        public int? TempKjøle { get; set; }

        [Display(Name = "Komm.")]
        public string Kommentar { get; set; }


        public virtual Article Article { get; set; }
    }
}
