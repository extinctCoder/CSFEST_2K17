using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Driver
{
    class dbHandler
    {
        private Model _model;
        private control_panel _controlPanel = null;
        public dbHandler(Model _model)
        {
            this._model = _model;
        }

        public string getData()
        {
            string data = "";
            using (var db = new HomeAutomationDbEntities())
            {
                if (this._model == Model.Model_1)
                {
                    this._controlPanel = db.control_panel.Find(1);
                    foreach (var component in this._controlPanel.components)
                    {
                        data += component.mode.ToString() + ",";
                    }
                }
                else if (this._model == Model.Model_2)
                {
                    this._controlPanel = db.control_panel.Find(2);
                    foreach (var component in this._controlPanel.components)
                    {
                        data += component.mode.ToString() + "," + component.value.ToString();
                    }
                }
                else if (this._model == Model.Model_3)
                {
                    this._controlPanel = db.control_panel.Find(3);
                    foreach (var component in this._controlPanel.components)
                    {
                        data += component.mode.ToString() + "," + component.value.ToString();
                    }
                }
                else if (this._model == Model.Model_4)
                {
                    this._controlPanel = db.control_panel.Find(4);
                    foreach (var component in this._controlPanel.components)
                    {
                        data += component.mode.ToString() + "," + component.value.ToString();
                    }
                }
            }
            data = data.Remove(data.Length - 1);
            Console.WriteLine("data from database : " + data);
            return data;
        }
    }
}
