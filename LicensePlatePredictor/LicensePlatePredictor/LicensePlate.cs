using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Globalization;

namespace LicensePlatePredictor
{
    public class LicensePlate
    {
        #region Enumerators

        public enum Action : int
        {
            invalid = 0,
            validate = 1,
            back = 2,
        }

        #endregion Enumerators

        private static readonly string optionsText =
            "1. Validate a License Plate?\n" +
            "2. Go back.\n\n";

        private static readonly TimeSpan MorningHourStart = TimeSpan.FromHours(7);
        private static readonly TimeSpan MorningHourEnd = TimeSpan.FromHours(9.5);
        private static readonly TimeSpan AfternoonHourStart = TimeSpan.FromHours(16);
        private static readonly TimeSpan AfternoonHourEnd = TimeSpan.FromHours(19.5);


        #region Properties

        private string _letterSection;
        private int _numberSection;
        private DateTime _date;
        private TimeSpan _time;

        public string LetterSection
        {
            get { return this._letterSection; }
            set { this._letterSection = value; }
        }

        public int NumberSection
        {
            get { return this._numberSection; }
            set { this._numberSection = value; }
        }

        public DateTime Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public TimeSpan Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        #endregion Properties
        
        public LicensePlate()
        {
            this.DisplayOptions();
        }

        public void DisplayOptions()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(optionsText);
                int option;

                if (this.GetInput(out option))
                {
                    if (option == (int)Action.back)
                    {
                        break;
                    }

                    this.HandleAction((Action)option);
                }

            } while (true);
        }

        public void AskForValues()
        {
            string LicensePlate;
            string DateToVerify;
            string TimeToVerify;
            int n;
            DateTime dt;
            DateTime tv;

            Console.Clear();

            do
            {
                Console.WriteLine("Please write the License Plate Number (XXX####) to Verify:");
                LicensePlate = Console.ReadLine();

                if ((Regex.IsMatch(LicensePlate.Substring(0, 3), @"^[a-zA-Z]+$"))
                    && int.TryParse(LicensePlate.Substring(3, 4), out n)
                    && !LicensePlate.Contains("-"))
                {
                    this._letterSection = LicensePlate.Substring(0, 3);
                    this._numberSection = Convert.ToInt32(LicensePlate.Substring(3, 4));
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid License Plate Number Format.");
                }
            } while (true);

            do
            {
                Console.WriteLine("Please write the Date (dd-mm-yyyy) to Verify:");
                DateToVerify = Console.ReadLine();

                if (DateTime.TryParseExact(DateToVerify, "dd-MM-yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt))
                {
                    this._date = Convert.ToDateTime(DateToVerify);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Date Format.");
                }
            } while (true);

            do
            {
                Console.WriteLine("Please write the Time (hh:mm) to Verify:");
                TimeToVerify = Console.ReadLine();

                if (DateTime.TryParseExact(TimeToVerify, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out tv))
                {
                    this._time = TimeSpan.Parse(TimeToVerify);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Time Format.");
                }
            } while (true);
        }

        public bool GetInput(out int input)
        {
            return int.TryParse(Console.ReadLine(), out input);
        }

        public void HandleAction(Action action)
        {
            this.AskForValues();

            switch (action)
            {
                case Action.validate:
                    if (this.ValidateDateTimeToCirculate(this._date, this._time))
                    {
                        Console.WriteLine("The Vehicule is authorized to circulate at that day and time.");
                    }
                    else
                    {
                        Console.WriteLine("The Vehicule is not authorized to circulate at that day and time.");
                    }
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadKey();
                    break;
                case Action.invalid:
                    break;
                default:
                    break;
            }
        }

        public bool ValidateDateTimeToCirculate(DateTime date, TimeSpan time)
        {
            bool result = false;
            int weekDay = (int)date.DayOfWeek;
            string licensePlateNumbers = this._numberSection.ToString();
            int lastDigit = Convert.ToInt32(licensePlateNumbers.Substring(licensePlateNumbers.Length - 1));

            switch (weekDay)
            {
                case (int)DayOfWeek.Monday:
                    if (lastDigit == 1 || lastDigit == 2)
                    {
                        if ((time >= MorningHourStart && time <= MorningHourEnd)
                            ||
                            (time >= AfternoonHourStart && time <= AfternoonHourEnd))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                case (int)DayOfWeek.Tuesday:
                    if (lastDigit == 3 || lastDigit == 4)
                    {
                        if ((time >= MorningHourStart && time <= MorningHourEnd)
                            ||
                            (time >= AfternoonHourStart && time <= AfternoonHourEnd))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                case (int)DayOfWeek.Wednesday:
                    if (lastDigit == 5 || lastDigit == 6)
                    {
                        if ((time >= MorningHourStart && time <= MorningHourEnd)
                            ||
                            (time >= AfternoonHourStart && time <= AfternoonHourEnd))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                case (int)DayOfWeek.Thursday:
                    if (lastDigit == 7 || lastDigit == 8)
                    {
                        if ((time >= MorningHourStart && time <= MorningHourEnd)
                            ||
                            (time >= AfternoonHourStart && time <= AfternoonHourEnd))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                case (int)DayOfWeek.Friday:
                    if (lastDigit == 9 || lastDigit == 0)
                    {
                        if ((time >= MorningHourStart && time <= MorningHourEnd)
                            ||
                            (time >= AfternoonHourStart && time <= AfternoonHourEnd))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
