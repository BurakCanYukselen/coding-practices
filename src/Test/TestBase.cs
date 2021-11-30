using System.Collections.Generic;
using System.Linq;

namespace Test
{
    /// <summary>
    /// Base Test Class
    /// </summary>
    /// <typeparam name="TInput">Test Case Input Type</typeparam>
    /// <typeparam name="TOutput">Test Case Output Type</typeparam>
    public class TestBase<TInput, TOutput>
    {
        public class TestCase
        {
            public TInput Input { get; set; }
            public TOutput Output { get; set; }

            public TestCase()
            {
            }

            public TestCase(TInput input, TOutput output)
            {
                Input = input;
                Output = output;
            }
        }

        public static IEnumerable<object[]> GenerateData(params TestCase[] testCases) =>
            testCases.Select(p => new[] { p }).ToList();
    }
}