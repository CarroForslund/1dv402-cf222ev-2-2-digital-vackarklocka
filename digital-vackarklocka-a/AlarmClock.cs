using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digital_vackarklocka_a
{
    class AlarmClock
    {
        //Deklarera fält
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        //Egenskapen AlarmHour ska kapsla in det privata fältet _alarmHour.
        //Set-metoden måste validera att värdet som ska tilldelas _alarmHour är 
        //i det slutna intervallet mellan 0 och 23. Är värdet inte i intervallet 
        //ska ett undantag av typen ArgumentException kastas.
        public int AlarmHour
        {
            get { return _alarmHour; }
            set {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                _alarmHour = value;
            }
        }

        //Egenskapen AlarmMinute kapslar in det privata fältet _alarmMinute.
        //Set-metoden måste validera att värdet som ska tilldelas _alarmMinute 
        //är i det slutna intervallet mellan 0 och 59. Är värdet inte i 
        //intervallet ska ett undantag av typen ArgumentException kastas.
        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }
                _alarmMinute = value;
            }
        }

        //Egenskapen Hour kapslar in det privata fältet _hour.
        //Set-metoden måste validera att värdet som ska tilldelas _hour 
        //är i det slutna intervallet mellan 0 och 23. Är värdet inte i 
        //intervallet ska ett undantag av typen ArgumentException kastas.
        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                _hour = value;
            }
        }

        //Egenskapen Minute kapslar in det privata fältet _minute.
        //Set-metoden måste validera att värdet som ska tilldelas _minute 
        //är i det slutna intervallet mellan 0 och 59. Är värdet inte i 
        //intervallet ska ett undantag av typen ArgumentException kastas.
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }
                _minute = value;
            }
        }

        //Standardkonstruktorn AlarmClock() initierar fälten till deras 
        //standardvärden och anropar den konstruktor i klassen som har två parametrar.
        public AlarmClock() : this (0, 0)
        {
        }

        //Initierar ett objekt så att alarmklockan ställs på den tid som parametrarna 
        //för timme respektive minut anger. Denna konstruktor anropar konstruktorn 
        //som har fyra parametrar.
        public AlarmClock(int hour, int minute) : this (hour, minute, 0, 0)
        {
        }

        //Initierar ett obkjekt så att alarmklockan ställs på den tid 
        //och alarmtid som parametrarna anger.
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
            Hour = hour;
            Minute = minute;
        }

        //Metoden TickTock anropas för att få klockan att gå en minut. 
        //Om den nya tiden överensstämmer med alarmtiden ska metoden returnera true, 
        //annars false. Inga utskrifter till konsolfönstret får göras av metoden.
        public bool TickTock()
        {
            if (Minute < 59)
            {
                ++Minute;
            }
            else
            {
                Minute = 0;
                if (Hour < 23)
                {
                    Hour += 1;
                }
                else
                {
                    Hour = 0;
                }
            }
            
            return Hour == AlarmHour && Minute == AlarmMinute;
        }

        //Publik metod som har som uppgift att returnera en sträng 
        //representerande värdet av en instans av klassen AlarmClock.
        public override string ToString()
        {
            return String.Format("{0,2:0}:{1:00} <{2}:{3:00}>", 
                Hour, Minute, AlarmHour, AlarmMinute);
        }
    }
}
