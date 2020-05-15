using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Person
    {
        public string Name;
        public string Message;

        public void Reply (object sender, AlarmEventArgs e)
        {
            var alarmClock = sender as AlarmClock;
            if (alarmClock != null)
                Console.WriteLine($"{Name}: Эй, {alarmClock.Name}! Уже {e.Time.ToShortTimeString()}? {Message}");
        }
    }

    class Dog
    {
        public string NickName;

        public void Bark(object sender, AlarmEventArgs e)
        {
            Console.WriteLine($"{NickName}: Гав-гав!!");
        }
    }
}
