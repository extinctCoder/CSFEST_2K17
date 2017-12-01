using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peasy;

namespace Backend.BLL.Rules
{
    public class LoginRule : RuleBase
    {
        private String _userId;
        private String _password;
        public LoginRule(String _userId, string _password)
        {
            this._userId = _userId;
            this._password = _password;
        }

        protected override void OnValidate()
        {
            if (_userId == "1234")
            {
                Invalidate("Name cannot be fred jones");
            }
        }
    }
}
