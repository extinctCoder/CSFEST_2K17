using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            ArduinoDriver arduino = new ArduinoDriver();
            Console.Write("input the model number : ");
            try
            {
                try_again:
                int _choice = Convert.ToInt32(Console.ReadKey().KeyChar);
                if (_choice == 49)
                {
                    arduino.pinConfig(Model.Model_1);
                    dbHandler db = new dbHandler(Model.Model_1);
                    while (true)
                    {
                        arduino.updateData(db.getData());
                    }
                }
                else if (_choice == 50)
                {
                    arduino.pinConfig(Model.Model_2);
                    dbHandler db = new dbHandler(Model.Model_2);
                    while (true)
                    {
                        arduino.updateData(db.getData());
                    }
                }
                else if (_choice == 51)
                {
                    arduino.pinConfig(Model.Model_3);
                    dbHandler db = new dbHandler(Model.Model_3);
                    while (true)
                    {
                        arduino.updateData(db.getData());
                    }
                }
                else if (_choice == 52)
                {
                    arduino.pinConfig(Model.Model_4);
                    dbHandler db = new dbHandler(Model.Model_4);
                    while (true)
                    {
                        arduino.updateData(db.getData());
                    }
                }
                else
                {
                    Console.WriteLine("\nwrong input ... \nplease try again choice is 1 to 4");
                    goto try_again;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
