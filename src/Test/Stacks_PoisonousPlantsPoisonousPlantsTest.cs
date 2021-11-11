using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Stacks_PoisonousPlantsPoisonousPlantsTest
    {
        [Fact]
        public void Debug()
        {
        }

        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void PoisonousPlantsPoisonousPlantsTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Stacks_PoisonousPlantsPoisonousPlants();

                // Act
                var sut = algo.GetTheDay(testCase.Input);
                results.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }


        public class TestCaseGenerator : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new List<TestCase>()
                    {
                        new TestCase()
                        {
                            Input = new string[] { "7", "6 5 8 4 7 10 9", },
                            Output = 2
                        }
                    }
                };
            }
        }

        public class TestCase
        {
            public string[] Input { get; set; }
            public int Output { get; set; }
        }
    }
}