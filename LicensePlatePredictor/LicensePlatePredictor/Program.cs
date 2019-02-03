using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensePlatePredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu screenMenu = new Menu();
            int selection;

            do
            {
                screenMenu.Display();

                if (screenMenu.GetInput(out selection))
                {
                    if (selection == (int)Menu.MenuAction.exit)
                    {
                        break;
                    }

                    screenMenu.HandleMenuAction((Menu.MenuAction)selection);
                }

            } while (true);
        }
    }
}
