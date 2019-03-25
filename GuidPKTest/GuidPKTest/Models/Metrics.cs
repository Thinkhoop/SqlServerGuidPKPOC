using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace GuidPKTest.Models
{
    internal class Metrics
    {
        private readonly string connectionString;

        public Metrics(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void TestTables_intPK()
        {
            var sw = new Stopwatch();

            var ttInt = DataGenerator.GetTestTableWithIntPK();

            var insert = @"
            INSERT INTO [dbo].[TestTable_intPk]
              ([Prop_s9],[Prop_s8],[Prop_s7],[Prop_s6],[Prop_s5],[Prop_s4],[Prop_s3]
              ,[Prop_s2],[Prop_s1],[Prop_n6],[Prop_n5],[Prop_n4],[Prop_n3],[Prop_n2]
              ,[Prop_n1],[Prop_d3],[Prop_d2],[Prop_d1],[Prop_b3],[Prop_b2],[Prop_b1])";

            var selects = ttInt.Select(x => $@"SELECT '{x.Prop_s9}','{x.Prop_s8}','{x.Prop_s7}','{x.Prop_s6}','{x.Prop_s5}','{x.Prop_s4}','{x.Prop_s3}',
                            '{x.Prop_s2}','{x.Prop_s1}',{x.Prop_n6},{x.Prop_n5},{x.Prop_n4},{x.Prop_n3},{x.Prop_n2},
                            {x.Prop_n1},'{x.Prop_d3}','{x.Prop_d2}','{x.Prop_d1}',{(x.Prop_b3.GetValueOrDefault() ? 1 : 0)},{(x.Prop_b2 ? 1 : 0)},{(x.Prop_b1.GetValueOrDefault() ? 1 : 0)}")
                             .ToArray();

            var sql = insert + Environment.NewLine + string.Join(Environment.NewLine + " UNION ALL " + Environment.NewLine, selects);

            // same query 10 times
            var sqls = Enumerable.Range(1, 10).Select(x => sql).ToArray();
            this.TimeQueryExecution(sqls);
        }

        public void TestTables_ExtraGuid()
        {
            Console.WriteLine("TestTables_ExtraGuid");
            var sw = new Stopwatch();

            var ttInt = DataGenerator.GetTestTable_ExtraGuid();

            var insert = @"
            INSERT INTO [dbo].[TestTable_extraGuid]
              ([Prop_s9],[Prop_s8],[Prop_s7],[Prop_s6],[Prop_s5],[Prop_s4],[Prop_s3]
              ,[Prop_s2],[Prop_s1],[Prop_n6],[Prop_n5],[Prop_n4],[Prop_n3],[Prop_n2]
              ,[Prop_n1],[Prop_d3],[Prop_d2],[Prop_d1],[Prop_b3],[Prop_b2],[Prop_b1], ExtraGuid)";

            var selects = ttInt.Select(x => $@"SELECT '{x.Prop_s9}','{x.Prop_s8}','{x.Prop_s7}','{x.Prop_s6}','{x.Prop_s5}','{x.Prop_s4}','{x.Prop_s3}',
                            '{x.Prop_s2}','{x.Prop_s1}',{x.Prop_n6},{x.Prop_n5},{x.Prop_n4},{x.Prop_n3},{x.Prop_n2},
                            {x.Prop_n1},'{x.Prop_d3}','{x.Prop_d2}','{x.Prop_d1}',{(x.Prop_b3.GetValueOrDefault() ? 1 : 0)},{(x.Prop_b2 ? 1 : 0)},
                            {(x.Prop_b1.GetValueOrDefault() ? 1 : 0)},'{x.ExtraGuid}'")
                             .ToArray();

            var sql = insert + Environment.NewLine + string.Join(Environment.NewLine + " UNION ALL " + Environment.NewLine, selects);

            // same query 10 times
            var sqls = Enumerable.Range(1, 10).Select(x => sql).ToArray();
            this.TimeQueryExecution(sqls);
        }

        public void TestTables_GuidPK()
        {
            Console.WriteLine("TestTables_GuidPK");
            var sw = new Stopwatch();

            var sqls = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var ttInt = DataGenerator.GetTestTableWithGuidPK();

                var insert = @"
            INSERT INTO [dbo].[TestTable_guidPk]
              (Id,[Prop_s9],[Prop_s8],[Prop_s7],[Prop_s6],[Prop_s5],[Prop_s4],[Prop_s3]
              ,[Prop_s2],[Prop_s1],[Prop_n6],[Prop_n5],[Prop_n4],[Prop_n3],[Prop_n2]
              ,[Prop_n1],[Prop_d3],[Prop_d2],[Prop_d1],[Prop_b3],[Prop_b2],[Prop_b1])";


                var selects = ttInt.Select(x => $@"SELECT '{x.Id}', '{x.Prop_s9}','{x.Prop_s8}','{x.Prop_s7}','{x.Prop_s6}','{x.Prop_s5}','{x.Prop_s4}','{x.Prop_s3}',
                            '{x.Prop_s2}','{x.Prop_s1}',{x.Prop_n6},{x.Prop_n5},{x.Prop_n4},{x.Prop_n3},{x.Prop_n2},
                            {x.Prop_n1},'{x.Prop_d3}','{x.Prop_d2}','{x.Prop_d1}',{(x.Prop_b3.GetValueOrDefault() ? 1 : 0)},{(x.Prop_b2 ? 1 : 0)},
                            {(x.Prop_b1.GetValueOrDefault() ? 1 : 0)}")
                                 .ToArray();

                var sql = insert + Environment.NewLine + string.Join(Environment.NewLine + " UNION ALL " + Environment.NewLine, selects);
                sqls.Add(sql);
            }
            this.TimeQueryExecution(sqls.ToArray());
        }

        public void TestTables_GuidPK_ClusterId()
        {
            Console.WriteLine("TestTables_GuidPK_ClusterId");
            var sw = new Stopwatch();

            var sqls = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var ttInt = DataGenerator.GetTestTable_ClusterId();

                var insert = @"
            INSERT INTO [dbo].[TestTable_guidPk_ClusterId]
              (Id,[Prop_s9],[Prop_s8],[Prop_s7],[Prop_s6],[Prop_s5],[Prop_s4],[Prop_s3]
              ,[Prop_s2],[Prop_s1],[Prop_n6],[Prop_n5],[Prop_n4],[Prop_n3],[Prop_n2]
              ,[Prop_n1],[Prop_d3],[Prop_d2],[Prop_d1],[Prop_b3],[Prop_b2],[Prop_b1])";


                var selects = ttInt.Select(x => $@"SELECT '{x.Id}', '{x.Prop_s9}','{x.Prop_s8}','{x.Prop_s7}','{x.Prop_s6}','{x.Prop_s5}','{x.Prop_s4}','{x.Prop_s3}',
                            '{x.Prop_s2}','{x.Prop_s1}',{x.Prop_n6},{x.Prop_n5},{x.Prop_n4},{x.Prop_n3},{x.Prop_n2},
                            {x.Prop_n1},'{x.Prop_d3}','{x.Prop_d2}','{x.Prop_d1}',{(x.Prop_b3.GetValueOrDefault() ? 1 : 0)},{(x.Prop_b2 ? 1 : 0)},
                            {(x.Prop_b1.GetValueOrDefault() ? 1 : 0)}")
                                 .ToArray();

                var sql = insert + Environment.NewLine + string.Join(Environment.NewLine + " UNION ALL " + Environment.NewLine, selects);
                sqls.Add(sql);
            }
            this.TimeQueryExecution(sqls.ToArray());
        }

        private TimeSpan TimeQueryExecution(string[] sqls)
        {
            var sw = Stopwatch.StartNew();
            using (var conn = new SqlConnection(this.connectionString)) // using same connection
            {
                conn.Open();
                for (int i = 0; i < sqls.Length; i++)
                {
                    var sw2 = Stopwatch.StartNew();
                    using (var command = new SqlCommand(sqls[i], conn))
                    {
                        command.CommandTimeout = 60_000;
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine($"    Executed insert {i} in {sw2.ElapsedMilliseconds}ms");
                }
            }
            sw.Stop();
            Console.WriteLine($"Stored 10k in {sw.ElapsedMilliseconds / 10}ms per 10k");
            return sw.Elapsed;
        }
    }
}
