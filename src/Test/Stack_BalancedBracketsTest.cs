using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Stack_BalancedBracketsTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void BalancedBrackets_v1(List<TestCase> testCases)
        {
            var resultList = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Stack_BalancedBrackets();

                // Act
                var sut = algo.CheckBracketBalance_V1(testCase.Inputs);
                var result = true;
                for (int i = 0; i < testCase.Outputs.Length; i++)
                    if (testCase.Outputs[i] != sut[i])
                    {
                        result = false;
                        break;
                    }

                resultList.Add(result);
            }

            // Assert
            Assert.True(resultList.All(p => p == true));
        }

        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void BalancedBrackets_v2(List<TestCase> testCases)
        {
            var resultList = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Stack_BalancedBrackets();

                // Act
                var sut = algo.CheckBracketBalance_V2(testCase.Inputs);
                var result = true;
                for (int i = 0; i < testCase.Outputs.Length; i++)
                    if (testCase.Outputs[i] != sut[i])
                    {
                        result = false;
                        break;
                    }

                resultList.Add(result);
            }

            // Assert
            Assert.True(resultList.All(p => p == true));
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
                            Inputs = new string[]
                            {
                                "3",
                                "{[()]}",
                                "{[(])}",
                                "{{[[(())]]}}"
                            },
                            Outputs = new string[]
                            {
                                "YES",
                                "NO",
                                "YES"
                            }
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public string[] Inputs { get; set; }
            public string[] Outputs { get; set; }
        }
    }
}