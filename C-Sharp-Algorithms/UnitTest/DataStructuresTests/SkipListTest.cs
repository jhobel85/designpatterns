using DataStructures.Lists;
using Xunit;

namespace UnitTest.DataStructuresTests
{
    public static class SkipListTest
    {
        /// <summary>
        /*          
•	51 cisel (100–50)  Protože začínáte na 100 a končíte na 50 (obě hodnoty jsou zahrnuty), je v tomto rozsahu 51 čísel, ne 50.
•	36 (35–0)
•	15 (-1 až -15)
•	20 (-16 až -35)
= 51 + 36 + 15 + 20 = 122 unikátních hodnot
        */
        ///</summary>
        [Fact]
        public static void DoTest()
        {
            var skipList = new SkipList<int>();

            for (int i = 100; i >= 50; --i)
                skipList.Add(i);

            for (int i = 0; i <= 35; ++i)
                skipList.Add(i);

            for (int i = -15; i <= 0; ++i)
                skipList.Add(i);

            for (int i = -15; i >= -35; --i)
                skipList.Add(i);

            Assert.True(skipList.Count == 122);

            skipList.Clear();

            for (int i = 100; i >= 0; --i)
                skipList.Add(i);

            Assert.True(skipList.Count == 101);
        }
    }
}
