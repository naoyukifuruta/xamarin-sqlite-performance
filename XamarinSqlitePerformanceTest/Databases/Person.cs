using System;
using SQLite;

namespace XamarinSqlitePerformanceTest.Databases
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
