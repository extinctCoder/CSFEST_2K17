using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BLL.Rules;
using Backend.DAL;
using Peasy;

namespace Backend.BLL.Services
{
    public class LoginService :ServiceBase<user,int>
    {
        public LoginService(IDataProxy<user, int> dataProxy) : base(dataProxy)
        {
        }

        protected override IEnumerable<IRule> GetBusinessRulesForInsert(user entity, ExecutionContext<user> context)
        {
            yield return new LoginRule(entity.ID.ToString(),entity.password);
        }
    }
}
