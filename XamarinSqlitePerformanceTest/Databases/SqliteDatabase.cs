using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using SQLite;
using XamarinSqlitePerformanceTest.Databases.Entities;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class SqliteDatabase : IDatabase
    {
        private SQLiteConnection _sqlite;

        private bool _isInTransaction
        {
            get { return _sqlite.IsInTransaction; }
        }

        public SqliteDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");

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

        // ===================================================================

        public void Dispose()
        {
            _sqlite.Dispose();
            _sqlite = null;
        }

        public void BeginTransaction()
        {
            while (_sqlite.IsInTransaction)
            {
                //他のトランザクションが終了するまで待機する
            }

            _sqlite.BeginTransaction();
        }

        public void RollBack()
        {
            if (_isInTransaction)
            {
                _sqlite.Rollback();
            }
        }

        public void Commit()
        {
            _sqlite.Commit();
        }

        public void CreateTable<T>()
        {
            var result = _sqlite.CreateTable<T>();
        }

        public void DropTable<T>()
        {
            var result = _sqlite.DropTable<T>();
        }

        public void Insert<T>(T insertData)
        {
            _sqlite.Insert(insertData);
        }

        public void Insert<T>(IEnumerable<T> insertData)
        {
            _sqlite.InsertAll(insertData);
        }

        public IEnumerable<T> Select<T>() where T : new()
        {
            var result = _sqlite.Table<T>();
            return result;
        }

        public IEnumerable<T> Select<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            var result = _sqlite.Table<T>().Where(filter);
            return result;
        }

        public IEnumerable<T> Select<T>(List<Expression<Func<T, bool>>> filters) where T : new()
        {
            if (!filters.Any())
            {
                return _sqlite.Table<T>();
            }

            var tempFilters = new List<Expression<Func<T, bool>>>(filters);
            var first = tempFilters.First();
            TableQuery<T> result = _sqlite.Table<T>().Where(first);
            tempFilters.Remove(first);
            foreach (var filter in tempFilters)
            {
                result = result.Where(filter);
            }

            return result;
        }

        public int Update<T>(T updateData)
        {
            return _sqlite.Update(updateData);
        }

        public int Update<T>(IEnumerable<T> updateData)
        {
            return _sqlite.UpdateAll(updateData);
        }

        public int Delete<T>(T deleteData)
        {
            return _sqlite.Delete(deleteData);
        }

        public int DeleteAll<T>()
        {
            return _sqlite.DeleteAll<T>();
        }

        public int Delete<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            int result = 0;
            var targets = Select(filter);
            foreach (var target in targets)
            {
                result += Delete<T>(target);
            }
            return result;
        }
    }
}
