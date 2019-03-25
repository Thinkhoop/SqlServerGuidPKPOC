using FizzWare.NBuilder;
using System;
using System.Linq;

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
                .With(x => x.Id = RT.Comb.Provider.Sql.Create()) // sequential... unless this is a bad implementation
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
               .With(x => x.Id = Guid.NewGuid()) // shouldn't matter if this is sequential or not?
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
    }
}
