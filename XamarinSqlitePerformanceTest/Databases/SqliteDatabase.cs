using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class SqliteDatabase
    {
        private readonly SQLiteConnection _sqlite;

        public SqliteDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.db3");

            _sqlite = new SQLiteConnection(dbPath);

            _sqlite.CreateTable<Person>();
        }

        public List<Person> GetPersons()
        {
            return _sqlite.Table<Person>().ToList();
        }

        public Person GetPerson(int id)
        {
            return _sqlite.Table<Person>().Where(i => i.ID == id).FirstOrDefault();
        }

        public int SavePerson(Person person)
        {
            if (person.ID != 0)
            {
                return _sqlite.Update(person);
            }
            else
            {
                return _sqlite.Insert(person);
            }
        }

        public void SavePersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (person.ID != 0)
                {
                    _sqlite.Update(person);
                }
                else
                {
                    _sqlite.Insert(person);
                }
            }
        }

        public int DeletePerson(Person person)
        {
            return _sqlite.Delete(person);
        }


        //private readonly SQLiteAsyncConnection _database;

        //public SqliteDatabase(string dbPath)
        //{
        //    _database = new SQLiteAsyncConnection(dbPath);

        //    _database.CreateTableAsync<Person>().Wait();
        //}

        //public Task<List<Person>> GetPersonsAsync()
        //{
        //    return _database.Table<Person>().ToListAsync();
        //}

        //public Task<Person> GetPersonAsync(int id)
        //{
        //    return _database.Table<Person>().Where(i => i.ID == id).FirstOrDefaultAsync();
        //}

        //public Task<int> SavePersonAsync(Person person)
        //{
        //    if (person.ID != 0)
        //    {
        //        return _database.UpdateAsync(person);
        //    }
        //    else
        //    {
        //        return _database.InsertAsync(person);
        //    }
        //}

        //public Task<int> DeletePersonAsync(Person person)
        //{
        //    return _database.DeleteAsync(person);
        //}
    }
}
