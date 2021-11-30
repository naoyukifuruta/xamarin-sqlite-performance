using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class DatabaseAccessor : IDatabase
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

        public void CreateTable<T>()
        {
            throw new NotImplementedException();
        }

        public void DropTable<T>()
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T insertData)
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(IEnumerable<T> insertData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select<T>() where T : new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select<T>(List<Expression<Func<T, bool>>> filter) where T : new()
        {
            throw new NotImplementedException();
        }

        public int Update<T>(T updateData)
        {
            throw new NotImplementedException();
        }

        public int Update<T>(IEnumerable<T> updateData)
        {
            throw new NotImplementedException();
        }

        public int Delete<T>(T deleteData)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll<T>()
        {
            throw new NotImplementedException();
        }

        public int Delete<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            throw new NotImplementedException();
        }
    }
}
