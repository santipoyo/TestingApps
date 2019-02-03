using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensePlatePredictor
{
    public class Menu
    {
        public enum MenuAction : int
        {
            invalid = 0,
            validate = 1,
            exit = 2,
        }

        private static readonly string menuText =
            "Welcome to Licence Plate Validator\n\n" +
            "What do you want to do?\n" +
            "1. Validate a License Plate.\n" +
            "2. Exit.\n\n";

        public LicensePlate license;

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(menuText);
        }

        public bool GetInput(out int input)
        {
            return int.TryParse(Console.ReadLine(), out input);
        }

        public void HandleMenuAction(MenuAction action)
        {
            switch (action)
            {
                case MenuAction.validate:
                    license = new LicensePlate();
                    break;
                case MenuAction.invalid:
                    break;
                default:
                    break;
            }
        }
    }
}
