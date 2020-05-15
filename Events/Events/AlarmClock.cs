using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class AlarmEventArgs : EventArgs
    {
        public DateTime Time;
        public string EventDescription;
    }

    delegate void AlarmEvenHandler(object sender, AlarmEventArgs e);
    class AlarmClock
    {
        public string Name;
        public event AlarmEvenHandler Ring;

        protected virtual void OnRing(AlarmEventArgs e)
        {
            Console.WriteLine($"{e.EventDescription}!!! Уже {e.Time.ToShortTimeString()}");

            if (Ring != null)
                Ring(this, e);
        }

        public void WakeUp(string description)
        {
            OnRing(new AlarmEventArgs() { 
                Time = DateTime.Now, 
                EventDescription = description 
            });
        }
    }
}
