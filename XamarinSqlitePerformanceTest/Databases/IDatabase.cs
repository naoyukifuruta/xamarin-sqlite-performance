using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace XamarinSqlitePerformanceTest.Databases
{
    public interface IDatabase
    {
        void Dispose();

        void BeginTransaction();

        void RollBack();

        void Commit();

        void CreateTable<T>();

        void DropTable<T>();

        void Insert<T>(T insertData);

        void Insert<T>(IEnumerable<T> insertData);

        IEnumerable<T> Select<T>() where T : new();

        IEnumerable<T> Select<T>(Expression<Func<T, bool>> filter) where T : new();

        IEnumerable<T> Select<T>(List<Expression<Func<T, bool>>> filter) where T : new();

        int Update<T>(T updateData);

        int Update<T>(IEnumerable<T> updateData);

        int Delete<T>(T deleteData);

        int DeleteAll<T>();

        int Delete<T>(Expression<Func<T, bool>> filter) where T : new();
    }
}
