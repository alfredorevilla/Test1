using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DynamicData(nameof(GetContains_should_return_true_DynamicData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Contains_should_return_true(int[][] collection, int number)
        {
            Assert.IsTrue(Program.Contains(collection, number));
        }

        [DynamicData(nameof(GetContains_should_return_false_DynamicData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Contains_should_return_false(int[][] collection, int number)
        {
            Assert.IsFalse(Program.Contains(collection, number));
        }

        [TestMethod]
        public void Contains_should_return_false_on_empty_or_collections()
        {
            var array = new int[][] { null };
            Assert.IsFalse(Program.Contains(array, 2));

            array = new int[][] { new int[] { } };
            Assert.IsFalse(Program.Contains(array, 0));
        }

        [TestMethod]
        public void Contains_should_return_true_on_empty_or_collections_1()
        {
            var array = new int[][] { null, new[] { 1, 2, 3 } };
            Assert.IsTrue(Program.Contains(array, 2));
        }

        [TestMethod]
        public void Contains_should_return_true_on_empty_or_collections_2()
        {
            var array = new int[][] { new int[] { }, new[] { 1, 2, 3 } };
            Assert.IsTrue(Program.Contains(array, 3));
        }

        private static int[][] array1 = new int[][]
          {
                new[] { 1, 2, 3, 4, 5 },
                new [] { 7, 9, 40, 50, 60 },
                new [] { 31, 32, 45, 55, 65 },
                new [] { 33, 34, 46, 56, 66 },
                new [] { 34, 46, 56, 66, 76 }
          };

        public static IEnumerable<object[]> GetContains_should_return_true_DynamicData()
        {
            yield return new object[]
            {
                array1,
                2
            };
            yield return new object[]
            {
                array1,
                56
            };
            yield return new object[]
           {
                array1,
                2
           };
            yield return new object[]
            {
                array1,
                55
            };
        }

        public static IEnumerable<object[]> GetContains_should_return_false_DynamicData()
        {
            int[][] array = new int[][]
            {
                new [] { 1, 2, 3, 4, 5 },
                new [] { 7, 9, 40, 50, 60 },
                new [] { 31, 32, 45, 55, 65 },
                new [] { 33, 34, 46, 56, 66 },
                new [] { 34, 46, 56, 66, 76 }
            };

            yield return new object[]
            {
                array,
                0
            };
            yield return new object[]
            {
                array,
                6
            };
            yield return new object[]
            {
                array,
                59
            };
            yield return new object[]
            {
                array,
                70
            };
        }
    }
}