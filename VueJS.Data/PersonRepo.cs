using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJS.Data
{
    public class PersonRepo
    {
        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PersonDataContext())
            {
                return context.Persons.ToList();
            }
        }

        public void Add(Person person)
        {
            using (var context = new PersonDataContext())
            {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public void Update(Person person)
        {
            using (var context = new PersonDataContext())
            {
                context.Persons.Attach(person);
                context.Refresh(RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PersonDataContext())
            {
                context.ExecuteCommand("DELETE FROM People WHERE Id = {0}", id);
            }
        }
    }
}
