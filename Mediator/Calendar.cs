using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    public class Calendar
    {
        private Dictionary<DayOfWeek, List<CalendarEventTypes>> _recurringEvents = new Dictionary<DayOfWeek, List<CalendarEventTypes>>();

        private DayOfWeek _currentDay;

        private bool _isWeekend;
        private bool _isTrashDay;

        public Calendar(DayOfWeek startDay)
        {
            _currentDay = startDay;
            _recurringEvents.Add(DayOfWeek.Sunday, new List<CalendarEventTypes>() { });
            _recurringEvents.Add(DayOfWeek.Monday, new List<CalendarEventTypes>() { CalendarEventTypes.Work, CalendarEventTypes.MorningWorkout });
            _recurringEvents.Add(DayOfWeek.Tuesday, new List<CalendarEventTypes>() { CalendarEventTypes.Work });
            _recurringEvents.Add(DayOfWeek.Wednesday, new List<CalendarEventTypes>() { CalendarEventTypes.TrashPickup });
            _recurringEvents.Add(DayOfWeek.Thursday, new List<CalendarEventTypes>() { CalendarEventTypes.Work, CalendarEventTypes.MorningWorkout });
            _recurringEvents.Add(DayOfWeek.Friday, new List<CalendarEventTypes>() { CalendarEventTypes.Work, CalendarEventTypes.EveningConference });
            _recurringEvents.Add(DayOfWeek.Saturday, new List<CalendarEventTypes>() { CalendarEventTypes.DrAppt, CalendarEventTypes.HomeRepairAppt });

        }
        public void NextDay(bool isStart = false)
        {
            if (!isStart) { _currentDay = ++_currentDay; }

            SetByDay();

            CalendarEventArgs e = new CalendarEventArgs();
            e.Day = _currentDay;
            e.DayEvents = _recurringEvents[_currentDay];
            e.IsTrashDay = _isTrashDay;
            e.IsWeekend = _isWeekend;
            OnCalendarEvent(e);
        }
        private void SetByDay()
        {
            switch (_currentDay)
            {
                case DayOfWeek.Sunday:
                    break;
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    break;
                case DayOfWeek.Wednesday:
                    break;
                case DayOfWeek.Thursday:
                    break;
                case DayOfWeek.Friday:
                    break;
                case DayOfWeek.Saturday:
                    break;
            }
            SetIsTrashDay();
        }
        private void SetIsTrashDay()
        {
            List<CalendarEventTypes> dayEvents = _recurringEvents[_currentDay];
             _isTrashDay = dayEvents.Contains(CalendarEventTypes.TrashPickup);
        }

        public event EventHandler<CalendarEventArgs> CalendarEvent;
        protected virtual void OnCalendarEvent(CalendarEventArgs e)
        {
            Console.WriteLine("Day has changed. It is now (0)", _currentDay);
            CalendarEvent?.Invoke(this, e);
        }
    }
}
