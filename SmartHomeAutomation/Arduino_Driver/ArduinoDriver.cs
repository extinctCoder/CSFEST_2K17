using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Solid.Arduino;
using Solid.Arduino.Firmata;

namespace Arduino_Driver
{
    class ArduinoDriver
    {
        private ISerialConnection _connection = null;
        private IFirmataProtocol _session = null;
        private Firmware _firmware;
        private ProtocolVersion _protocal;
        private BoardCapability _compatibility;

        private int room_1_led,
            room_2_led,
            outdoor_led,
            garadge_led,
            room_1_door,
            room_2_door,
            model_1_light,
            model_2_light;
        public ArduinoDriver()
        {
            connection_handler:
            try
            {
                this._connection = getArduinoConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Message : " + e.Message);
                this._session = null;
            }
            
            if (this._connection != null)
            {
                this._session = new ArduinoSession(this._connection);
                Console.WriteLine("New arduino session started successfully ... !!!");
                Console.WriteLine("Performing board compatibility tests ...");
                this.compatibilityTest();
                Console.WriteLine("arduino is ready to receive commands ...");
            }
            else
            {
                Console.WriteLine("No connection found...");
                Console.WriteLine("Press any to try again.");
                Console.ReadKey(true);
                goto connection_handler;
            }
        }

        private void compatibilityTest()
        {
            if (this._session != null)
            {
                this._firmware = this._session.GetFirmware();
                Console.WriteLine(
                    $"Firmware: {this._firmware.Name}, version : {this._firmware.MajorVersion}.{this._firmware.MinorVersion}");
                this._protocal = this._session.GetProtocolVersion();
                Console.WriteLine($"Firmata protocol version : {this._protocal.Major}.{this._protocal.Minor}");
                this._compatibility = this._session.GetBoardCapability();
                Console.WriteLine("Board Capability List,");
                foreach (var pin in this._compatibility.Pins)
                {
                    Console.WriteLine(
                        "Pin {0}\t: Input: {1}, Output: {2}, Analog: {3}, Analog-Res: {4}, PWM: {5}, PWM-Res: {6}, " +
                        "Servo: {7}, Servo-Res: {8}, Serial: {9}, Encoder: {10}, Input-pullup: {11}",
                        pin.PinNumber, pin.DigitalInput, pin.DigitalOutput, pin.Analog, pin.AnalogResolution, pin.Pwm,
                        pin.PwmResolution, pin.Servo, pin.ServoResolution, pin.Serial, pin.Encoder, pin.InputPullup);
                }
                Console.WriteLine("Press any key to proceed ...");
                Console.ReadKey(true);
            }
        }

        private ISerialConnection getArduinoConnection()
        {
            Console.WriteLine("Searching for arduino ...");
            ISerialConnection _connection = EnhancedSerialConnection.Find();
            if (_connection == null)
            {
                Console.WriteLine("Arduino not found .... :(");
                return null;
            }
            Console.WriteLine($"Arduino found in : {_connection.PortName} at {_connection.BaudRate} baud rate.");
            return _connection;
        }

        public void pinConfig(Model _model)
        {
            Console.WriteLine("configuring the pins to control components.");
            if (_model == Model.Model_1)
            {
                this.PinCongigarator(3, 4, 5, 6, 8, 7);
            }
            else if (_model == Model.Model_2)
            {
                this.PinCongigarator(2, 3, 4, 5, 6, 7);
            }
            else if(_model==Model.Model_3)
            {
                this.PinCongigarator(2, 3, 4, 5, 6, 7);
            }
            else if (_model == Model.Model_4)
            {
                this.model_1_light = 2;
                this.model_2_light = 3;
                this._session.SetDigitalPinMode(this.model_1_light, PinMode.DigitalOutput);
                this._session.SetDigitalPinMode(this.model_2_light, PinMode.DigitalOutput);
            }

        }

        private void PinCongigarator(int room_1_led, int room_2_led, int outdoor_led, int garadge_led, int room_1_door,
            int room_2_door)
        {
            this.room_1_led = room_1_led;
            this.room_2_led = room_2_led;
            this.outdoor_led = outdoor_led;
            this.garadge_led = garadge_led;
            this.room_1_door = room_1_door;
            this.room_2_door = room_2_door;
            this._session.SetDigitalPinMode(this.room_1_led, PinMode.DigitalOutput);
            this._session.SetDigitalPinMode(this.room_2_led, PinMode.DigitalOutput);
            this._session.SetDigitalPinMode(this.outdoor_led, PinMode.DigitalOutput);
            this._session.SetDigitalPinMode(this.garadge_led, PinMode.DigitalOutput);
            this._session.SetDigitalPinMode(this.room_1_door, PinMode.ServoControl);
            this._session.SetDigitalPinMode(this.room_2_door, PinMode.ServoControl);

        }

        public void updateData(string data)
        {
            string[] coomand = Regex.Split(data, ",");
            try
            {
                this._session.SetDigitalPin(this.room_1_led, Convert.ToInt32(coomand[0]) == 0 ? false : true);

                this._session.SetDigitalPin(this.room_2_led, Convert.ToInt32(coomand[1]) == 0 ? false : true);
                this._session.SetDigitalPin(this.room_2_led, Convert.ToInt32(coomand[2]) == 0 ? false : true);

                this._session.SetDigitalPin(this.room_2_led, Convert.ToInt32(coomand[3]) == 0 ? false : true);
                this._session.SetDigitalPin(this.garadge_led, Convert.ToInt32(coomand[4]) == 0 ? false : true);
                this._session.SetDigitalPin(this.outdoor_led, Convert.ToInt32(coomand[5]) == 0 ? false : true);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
