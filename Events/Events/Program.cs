using System;
using System.Collections.Generic;

namespace Events
{
    class Program
    {
        static void Main()
        {
            var alarmClock = new AlarmClock() { Name = "будильник" };

            var boy = new Person
            {
                Name = "Петя",
                Message = "Дай поспать!"
            };

            alarmClock.Ring += boy.Reply;

            var girl = new Person
            {
                Name = "Таня",
                Message = "Уже встаю..."
            };

            alarmClock.Ring += girl.Reply;

            var dog = new Dog() { NickName = "Мухтар" };

            alarmClock.Ring += dog.Bark;

            alarmClock.WakeUp("Пора вставать");

            alarmClock.Ring -= boy.Reply;

            alarmClock.WakeUp("Пора вставать");

            Console.ReadKey();
        }
    }
}
