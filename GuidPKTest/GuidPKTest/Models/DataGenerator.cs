using FizzWare.NBuilder;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace GuidPKTest.Models
{
    internal class DataGenerator
    {
        public static TestTable<int>[] GetTestTableWithIntPK(int listSize = 10_000)
        {
            return Builder<TestTable<int>>.CreateListOfSize(listSize)
                .All()
                .With(x => x.Id = 0)
                .With(x => x.Prop_d1 = DateTimeOffset.Now)
                .With(x => x.Prop_d2 = DateTimeOffset.Now)
                .With(x => x.Prop_d3 = DateTimeOffset.Now)
            .Build()
            .ToArray();
        }


        public static TestTable<Guid>[] GetTestTableWithGuidPK(int listSize = 10_000)
        {
            return Builder<TestTable<Guid>>.CreateListOfSize(listSize)
                .All()
                .With(x => x.Id = NewSequentialId())
                .With(x => x.Prop_d1 = DateTimeOffset.Now)
                .With(x => x.Prop_d2 = DateTimeOffset.Now)
                .With(x => x.Prop_d3 = DateTimeOffset.Now)
            .Build()
            .ToArray();
        }

        public static TestTable_ClusterId[] GetTestTable_ClusterId(int listSize = 10_000)
        {
            return Builder<TestTable_ClusterId>.CreateListOfSize(listSize)
               .All()
               .With(x => x.Prop_d1 = DateTimeOffset.Now)
               .With(x => x.Prop_d2 = DateTimeOffset.Now)
               .With(x => x.Prop_d3 = DateTimeOffset.Now)
               .With(x => x.ClusterId = 0)
               .With(x => x.Id = NewSequentialId())
           .Build()
           .ToArray();
        }

        public static TestTable_ExtraGuid[] GetTestTable_ExtraGuid(int listSize = 10_000)
        {
            return Builder<TestTable_ExtraGuid>.CreateListOfSize(listSize)
               .All()
               .With(x => x.Prop_d1 = DateTimeOffset.Now)
               .With(x => x.Prop_d2 = DateTimeOffset.Now)
               .With(x => x.Prop_d3 = DateTimeOffset.Now)
               .With(x => x.Id = 0)
               .With(x => x.ExtraGuid = Guid.NewGuid())
           .Build()
           .ToArray();
        }



        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out Guid guid);

        private static Guid NewSequentialId()
        {
            Guid guid;
            UuidCreateSequential(out guid);
            var s = guid.ToByteArray();
            var t = new byte[16];
            t[3] = s[0];
            t[2] = s[1];
            t[1] = s[2];
            t[0] = s[3];
            t[5] = s[4];
            t[4] = s[5];
            t[7] = s[6];
            t[6] = s[7];
            t[8] = s[8];
            t[9] = s[9];
            t[10] = s[10];
            t[11] = s[11];
            t[12] = s[12];
            t[13] = s[13];
            t[14] = s[14];
            t[15] = s[15];
            return new Guid(t);
        }
    }
}
