using System;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class DatabaseAccessorFactory
    {
        public static DatabaseAccessor Create()
        {
            var sqlite = new SqliteDatabase();

            return new DatabaseAccessor(sqlite);
        }
    }
}
