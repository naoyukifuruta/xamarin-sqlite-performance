using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class SqliteDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public SqliteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPersonsAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetPersonAsync(int id)
        {
            return _database.Table<Person>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            if (person.ID != 0)
            {
                return _database.UpdateAsync(person);
            }
            else
            {
                return _database.InsertAsync(person);
            }
        }

        public Task<int> DeletePersonAsync(Person person)
        {
            return _database.DeleteAsync(person);
        }
    }
}
