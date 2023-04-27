using AutoHouse.Model;
using System;
using System.Globalization;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator(new Alarm(), new Calendar(DayOfWeek.Sunday), new CoffeePot(), new Sprinkler());
            mediator.Start();
        }
    }
}
