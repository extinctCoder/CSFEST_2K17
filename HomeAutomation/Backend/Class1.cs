using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BLL.DataProxy;
using Backend.BLL.Services;
using Backend.DAL;
using Peasy;

namespace Backend
{
    public class Person : IDomainObject<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class PersonMockDataProxy : IDataProxy<Person, int>
    {
        public IEnumerable<Person> GetAll()
        {
            return new[]
            {
                new Person() { ID = 1, Name = "Jimi Hendrix" },
                new Person() { ID = 2, Name = "James Page" },
                new Person() { ID = 3, Name = "David Gilmour" }
            };
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return GetAll();
        }

        public Person Insert(Person entity)
        {
            return new Person() { ID = new Random(300).Next(), Name = entity.Name };
        }

        public async Task<Person> InsertAsync(Person entity)
        {
            return Insert(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Person GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
    public class PersonNameRule : RuleBase
    {
        private string _name;

        public PersonNameRule(string name)
        {
            _name = name;
        }

        protected override void OnValidate()
        {
            if (_name == "Fred Jones")
            {
                Invalidate("Name cannot be fred jones");
            }
        }
    }
    public class ValidCityRule : RuleBase
    {
        private string _city;

        public ValidCityRule(string city)
        {
            _city = city;
        }

        protected override void OnValidate()
        {
            if (_city == "Nowhere")
            {
                Invalidate("Nowhere is not a city");
            }
        }
    }
    public class PersonService : ServiceBase<Person, int>
    {
        public PersonService(IDataProxy<Person, int> dataProxy) : base(dataProxy)
        {
        }

        protected override IEnumerable<IRule> GetBusinessRulesForInsert(Person entity, ExecutionContext<Person> context)
        {
            yield return new PersonNameRule(entity.Name);
            yield return new ValidCityRule(entity.City);
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            var service = new LoginService(new userDataProxy());
            var newPerson = new user() { ID = 123, password = "123" };
            Evar insertResult = service.InsertCommand(newPerson).Execute();
            if (insertResult.Success)
            {
                Console.WriteLine(insertResult.Value.ID.ToString()); // prints the id value assigned via PersonMockDataProxy.Insert
            }
            else
            {
                foreach (var error in insertResult.Errors)
                    Console.WriteLine(error);
            }
        }
    }
}
