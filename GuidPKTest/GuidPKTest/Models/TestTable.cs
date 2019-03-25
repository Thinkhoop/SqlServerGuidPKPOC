using System;
using System.Data.SqlClient;

namespace GuidPKTest.Models
{
    /// <summary>
    /// Int id
    /// </summary>
    public class TestTable<TPk>
    {
        public TPk Id { get; set; }
        public string Prop_s1 { get; set; }
        public string Prop_s2 { get; set; }
        public string Prop_s3 { get; set; }
        public string Prop_s4 { get; set; }
        public string Prop_s5 { get; set; }
        public string Prop_s6 { get; set; }
        public string Prop_s7 { get; set; }
        public string Prop_s8 { get; set; }
        public string Prop_s9 { get; set; }
        public long? Prop_n1 { get; set; }
        public decimal? Prop_n2 { get; set; }
        public decimal? Prop_n3 { get; set; }
        public decimal? Prop_n4 { get; set; }
        public int? Prop_n5 { get; set; }
        public int? Prop_n6 { get; set; }
        public DateTimeOffset Prop_d1 { get; set; }
        public DateTimeOffset Prop_d2 { get; set; }
        public DateTimeOffset? Prop_d3 { get; set; }
        public bool? Prop_b1 { get; set; }
        public bool Prop_b2 { get; set; }
        public bool? Prop_b3 { get; set; }

        public static void CreateTableWithIntIdentityPK(string connString)
        {
            var sql = @"
                    CREATE TABLE [dbo].[TestTable_intPk](
	                    [Id] [int] IDENTITY(1,1) PRIMARY KEY,
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
                    )";

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    try
                    {
                        command.CommandText = "DROP TABLE TestTable_intPk";
                        command.ExecuteNonQuery();
                    }
                    catch { }
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
            }
        }

        public static void CreateTableWithGuidPK(string connString)
        {
            var sql = @"
                        CREATE TABLE [dbo].[TestTable_guidPk](
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
                        PRIMARY KEY CLUSTERED 
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
                    command.CommandText = "DROP TABLE TestTable_guidPk";
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
