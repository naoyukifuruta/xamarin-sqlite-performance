using System;
using System.Collections.Generic;
using System.Linq;
using XamarinSqlitePerformanceTest.Databases.Entities;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class DatabaseAccessor : IDisposable
    {
        private IDatabase _db;

        public DatabaseAccessor(IDatabase db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void BeginTransaction()
        {
            _db.BeginTransaction();
        }

        public void RollBack()
        {
            _db.RollBack();
        }

        public void Commit()
        {
            _db.Commit();
        }

        // Person

        public List<Person> GetPersons()
        {
            return _db.Select<Person>().ToList();
        }

        public Person GetPerson(int id)
        {
            return _db.Select<Person>().Where(i => i.ID == id).FirstOrDefault();
        }

        public void SavePerson(Person person)
        {
            if (person.ID != 0)
            {
                _db.Update(person);
            }
            else
            {
                _db.Insert(person);
            }
        }

        public void SavePersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (person.ID != 0)
                {
                    _db.Update(person);
                }
                else
                {
                    _db.Insert(person);
                }
            }
        }

        public int DeletePerson(Person person)
        {
            return _db.Delete(person);
        }

        public int DeletePersons()
        {
            return _db.DeleteAll<Person>();
        }
    }
}
