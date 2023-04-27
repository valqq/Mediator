using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    public class CoffeePot
    {
        private const int BREW_TIME_MINUTES = 30;

        private FatherTime _fatherTime;
        private bool _isBrewing;
        public bool IsBrewing { get { return CheckIfBrewing(); } }
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public bool IsAM { get; private set; }
        public CoffeePot()
        {
            Set(4, 30, true);
        }
        public void SyncTime(FatherTime fatherTime)
        {
            _fatherTime = fatherTime;
        }
        private bool CheckIfBrewing()
        {
            if (_fatherTime.IsAM == IsAM &&
                _fatherTime.Hour >= Hour &&
                _fatherTime.Minute >= Minute &&
                (_fatherTime.Minute <= (Minute + BREW_TIME_MINUTES)))
            {
                if (!_isBrewing)
                {
                    _isBrewing = true;
                    OnCoffeePotBrew(new EventArgs());
                }
                return true;
            }
            else
            {
                _isBrewing = false;
                return false;
            }

        }
        public void Set(int hour, int minute, bool isAm)
        {
            Hour = hour;
            Minute = minute;
            IsAM = isAm;

            string am;
            if (IsAM)
            {
                am = "A.M.";
            }

            else
            {
                am = "р.м";
            }
            
            string currentMin = Minute.ToString().PadLeft(2, '0');
            string currentHr = Hour.ToString().PadLeft(2);
            Console.WriteLine("Setting {0} to {1}:{2} {3}", GetType().Name, currentHr, currentMin, am);
        }
        public void On()
        {
            Console.WriteLine("Turning {0} on ...", GetType().Name);
        }
        public void Off()
        {
            Console.WriteLine("Turning {0} off ...", GetType().Name);
        }
        public void Reset()
        {
            Console.WriteLine("Resetting {0} ...", GetType().Name);
        }

        public void StartCoffeeBrew()
        {

        }

        public event EventHandler CoffeePotBrew;
        protected virtual void OnCoffeePotBrew(EventArgs e)
        {
            Console.WriteLine("CoffeePot is Brewing");
            CoffeePotBrew?.Invoke(this, e);
        }
        
    }
}