using GuidPKTest.Models;
using System;

namespace GuidPKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Server=localhost;Database=POC;User Id=user;Password=<password>;";

            TestTable<int>.CreateTableWithGuidPK(connString);
            TestTable<int>.CreateTableWithIntIdentityPK(connString);
            TestTable_ClusterId.CreateTableWithGuidPKAndClusterId(connString);
            TestTable_ExtraGuid.CreateTableWithIntIdentityPkAndExtraGuidField(connString);

            Console.WriteLine("Created tables");

            var metrics = new Metrics(connString);

            metrics.TestTables_intPK(); // base line. Int identity PK
            metrics.TestTables_ExtraGuid(); // int identity PK, expecting to be as fast as int_PK. Actual - a bit slower
            metrics.TestTables_GuidPK(); // GUID PK, expecting to be somewhat slower. Actual - ~60 times slower.
            metrics.TestTables_GuidPK_ClusterId(); // GUID non-clustered PK and clusterd identity column. Expecting to be faster than clustered guid PK. Actual - a bit faster than GUID PK.


            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
