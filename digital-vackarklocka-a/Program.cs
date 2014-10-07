using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digital_vackarklocka_a
{
    class Program
    {
        static void Main(string[] args)
        {
            string HorizontalLine = "----------------------------------------------";
            AlarmClock ac = new AlarmClock();

            //1. Test av standardkonstruktor
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.\n");
            Console.WriteLine(ac.ToString());
            Console.WriteLine(HorizontalLine);

            //2. Test av konstruktorn med två parametrar
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, <9, 42>.\n");
            ac = new AlarmClock(9, 42);
            Console.WriteLine(ac.ToString());
            Console.WriteLine(HorizontalLine);

            //3. Test av konstruktorn med fyra parametrar
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar.\n");
            ac = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac.ToString());
            Console.WriteLine(HorizontalLine);

            //4. Test av TickTock()
            ViewTestHeader("Test 4.\nTest av TickTock().\n");
            ac = new AlarmClock(23, 58, 7, 35);
            Run(ac, 13);
            Console.WriteLine(HorizontalLine);

            //5. Ställ tiden till 6:12 och alarm 6:15. Indikera när alarmet går.
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter. Testkoden ska på lämpligt sätt indikera när ett alarm går.\n");
            ac = new AlarmClock(6, 12, 6, 15);
            Run(ac, 6);
            Console.WriteLine(HorizontalLine);

            //6. Test av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.
            ViewTestHeader("Test 6.\nTest av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.\n");
            try
            {
                ac.Hour = 24;
            }
            catch
            {
                ViewErrorMessage("Timmen är inte i intervallet 0-23");
            }
            try
            {
                ac.Minute = 60;
            }
            catch
            {
                ViewErrorMessage("Minuten är inte i intervallet 0-59");
            }
            try
            {
                ac.AlarmHour = 24;
            }
            catch
            {
                ViewErrorMessage("Alarmtimmen är inte i intervallet 0-23");
            }
            try
            {
                ac.AlarmMinute = 60;
            }
            catch
            {
                ViewErrorMessage("Alarmminuten är inte i intervallet 0-59");
            }
            Console.WriteLine(HorizontalLine);

            //7. Test av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.
            ViewTestHeader("Test 7.\nTest av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.\n");
            try
            {
                ac = new AlarmClock(24, 0, 0, 0);
            }
            catch
            {
                ViewErrorMessage("Timmen är inte i intervallet 0-23");
            }
            try
            {
                ac = new AlarmClock(0, 0, 24, 0);
            }
            catch
            {
                ViewErrorMessage("Alarmtimmen är inte i intervallet 0-23");
            }
            try
            {
                ac = new AlarmClock(0, 60, 0, 0);
            }
            catch
            {
                ViewErrorMessage("Minuten är inte i intervallet 0-60");
            }
            try
            {
                ac = new AlarmClock(0, 0, 0, 60);
            }
            catch
            {
                ViewErrorMessage("Alarmminuten är inte i intervallet 0-60");
            }

        }

        //Metod med parametrar som refererar till AlarmClock-objekt 
        //och anropar TickTock()).
        private static void Run(AlarmClock ac, int minutes)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║       Väckarklockan URLED <TM>       ║ ");
            Console.Write(" ║           ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Modellnr: 1DV402");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("           ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();

            for (int i = 0; i < minutes; i++)
            {
                if (ac.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(String.Format(" ♫ " + ac.ToString() + " BEEP! BEEP! BEEP! BEEP!"));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("   " + ac.ToString());
                }
            }
        }

        //Privat statisk metoden som tar ett felmeddelande som argument 
        //och presenterar det.
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine(message);
            Console.ResetColor();
        }

        //Metod som tar en sträng som argument och presenterar strängen.
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(header);
        }
    }
}