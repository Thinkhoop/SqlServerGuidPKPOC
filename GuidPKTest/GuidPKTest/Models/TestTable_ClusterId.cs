using System;
using System.Data.SqlClient;

namespace GuidPKTest.Models
{
    /// <summary>
    /// Guid ID, non clustered, plus clustered int autoinc
    /// </summary>
    public class TestTable_ClusterId : TestTable<Guid>
    {
        public int ClusterId { get; set; }

        public static void CreateTableWithGuidPKAndClusterId (string connString)
        {
            var sql = @"
                       CREATE TABLE [dbo].[TestTable_guidPk_ClusterId](
	                        [Id] [uniqueidentifier] NOT NULL,
	                        [Prop_s1] [nvarchar](max) NULL,
	                        [Prop_s2] [nvarchar](max) NULL,
	                        [Prop_s3] [nvarchar](max) NULL,
	                        [Prop_s4] [nvarchar](max) NULL,
	                        [Prop_n1] [bigint] NULL,
	                        [Prop_n2] [decimal](18, 2) NULL,
	                        [Prop_s5] [nvarchar](max) NULL,
	                        [Prop_d1] [datetimeoffset](7) NOT NULL,
	                        [Prop_d2] [datetimeoffset](7) NOT NULL,
	                        [Prop_s6] [nvarchar](max) NULL,
	                        [Prop_s7] [nvarchar](max) NULL,
	                        [Prop_n5] [int] NULL,
	                        [Prop_s8] [nvarchar](max) NULL,
	                        [Prop_n6] [int] NULL,
	                        [Prop_s9] [nvarchar](max) NULL,
	                        [Prop_n4] [decimal](18, 2) NULL,
	                        [Prop_d3] [datetimeoffset](7) NULL,
	                        [Prop_b1] [bit] NULL,
	                        [Prop_b2] [bit] NOT NULL,
	                        [Prop_b3] [bit] NULL,
	                        [Prop_n3] [decimal](18, 2) NULL,
	                        [ClusterId] [int] IDENTITY(1,1) NOT NULL,
                        PRIMARY KEY NONCLUSTERED 
                        (
	                        [Id] ASC
                        ))";
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    try { 
                    command.CommandText = "DROP TABLE TestTable_guidPk_ClusterId";
                    command.ExecuteNonQuery();
                    }
                    catch { }
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
