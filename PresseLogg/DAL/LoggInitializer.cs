using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresseLogg.Models;

namespace PresseLogg.DAL
{
    public class LoggInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LoggContext>
    {
        protected override void Seed(LoggContext context)
        {

            var artikler = new List<Article>
            {
                new Article{ ArticleId= 11001, Name = "Kromat Fjør Egg", Density = 0.7},
                new Article{ ArticleId= 10547, Name = "Format Vekst 110", Density = 0.7},
                new Article{ ArticleId=10862,Name = "Format Purke", Density = 0.75}

            };
            artikler.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();

            var logger = new List<PressLog>
            {
                new PressLog{AmpExpander = 230, AmpMixer1 = 23, AmpMixer2 = 24, AmpPresse =234, ArticleId = 10547, Damptrykk=2, 
                    KgDampPrTime = 234, KonTrykk= 23, Oppholdstid = 0, Presse= Presse.PL01, Kommentar ="Gikk lett", 
                    TempExpander = 123, TempKjøle = 15, TempMixer1=75, TempMixer2=72, TonnPrTime=7.5, VinkelOAP = 0},
                new PressLog{AmpExpander = 0, AmpMixer1 = 23, AmpMixer2 = 24, AmpPresse =234, ArticleId = 10547, Damptrykk=4, 
                    KgDampPrTime = 234, KonTrykk= 0, Oppholdstid = 0, Presse= Presse.PL03, Kommentar ="Gikk tungt", 
                    TempExpander = 123, TempKjøle = 15, TempMixer1=75, TempMixer2=72, TonnPrTime=7.5, VinkelOAP = -21},
                new PressLog{AmpExpander = 0, AmpMixer1 = 23, AmpMixer2 = 24, AmpPresse =234, ArticleId = 10547, Damptrykk=2, 
                    KgDampPrTime = 234, KonTrykk= 0, Oppholdstid = 60, Presse= Presse.PL02, Kommentar ="-", 
                    TempExpander = 123, TempKjøle = 15, TempMixer1=75, TempMixer2=72, TonnPrTime=7.5, VinkelOAP = -21},
                new PressLog{AmpExpander = 230, AmpMixer1 = 23, AmpMixer2 = 24, AmpPresse =234, ArticleId = 10862, Damptrykk=3.5, 
                    KgDampPrTime = 234, KonTrykk= 23, Oppholdstid = 60, Presse= Presse.PL01, Kommentar ="ok", 
                    TempExpander = 123, TempKjøle = 15, TempMixer1=75, TempMixer2=72, TonnPrTime=7.5, VinkelOAP = 0},
                new PressLog{AmpExpander = 230, AmpMixer1 = 23, AmpMixer2 = 24, AmpPresse =234, ArticleId = 10862, Damptrykk=2, 
                    KgDampPrTime = 234, KonTrykk= 23, Oppholdstid = 60, Presse= Presse.PL01, Kommentar ="Gikk lett", 
                    TempExpander = 123, TempKjøle = 15, TempMixer1=75, TempMixer2=72, TonnPrTime=7.5, VinkelOAP = 0},
            };
            logger.ForEach(s => context.PressLogs.Add(s));
            context.SaveChanges();

            var shifttasks = new List<ShiftTask>
            {
                new ShiftTask{ Task = "Tømme steinkasse", Status = 1},
                new ShiftTask{ Task = "Rengjøre mikrovekter", Status = 1},
                new ShiftTask{ Task = "Tømme magnet kværner", Status = 1},
              
            };
            shifttasks.ForEach(s => context.ShiftTasks.Add(s));
            context.SaveChanges();

            var shifttaskgroups = new List<ShiftTaskGroup>
            {
                new ShiftTaskGroup{  ShiftTaskGroupName = "Formiddag"},
                new ShiftTaskGroup{  ShiftTaskGroupName = "Ettermiddag"},
                new ShiftTaskGroup{  ShiftTaskGroupName = "Natt 1"},
                
              
            };
            shifttaskgroups.ForEach(s => context.ShiftTaskGroups.Add(s));
            context.SaveChanges();

            var shiftlogs = new List<ShiftLog>
            {
                new ShiftLog{ Date = DateTime.Today, Shift = Shift.Ettermiddag,  Text= "Ok", ShiftTaskGroupId= 1},
                new ShiftLog{ Date = DateTime.Today, Shift = Shift.Formiddag,  Text= "Formiddag Ok", ShiftTaskGroupId= 2},
                new ShiftLog{ Date = DateTime.Today, Shift = Shift.Natt1,  Text= "Natt 1 Ok", ShiftTaskGroupId= 3},
               
                
              
            };
            shiftlogs.ForEach(s => context.ShiftLogs.Add(s));
            context.SaveChanges();
        }
    }
}
