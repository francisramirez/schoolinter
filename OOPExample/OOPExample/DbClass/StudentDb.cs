using OOPExample.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExample.DbClass
{
    public class StudentDb : IStudentDb
    {
        private readonly List<Person> people;
        public StudentDb()
        {
            this.people = new List<Person>();
        }
        public bool Exits(Person person)
        {
            return this.people.Exists(cd => cd.FirstName == person.FirstName);
        }

        public void Remove(Person person)
        {
            this.people.Remove(person);
        }

        public void Save(Person person)
        {
            this.people.Add(person);
        }
    }
}
