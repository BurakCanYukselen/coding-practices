using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Microsoft.VisualBasic.CompilerServices;
using Xunit;

namespace Test
{
    public class Trie_NoPrefixSetTest : TestBase<string[], string>
    {
        [Theory]
        [MemberData(nameof(NoPrefixSetTestCases))]
        public void NoPrefixSetTest(TestCase testCase)
        {
            // Arrange
            var algo = new Trie_NoPrefixSet();

            // Act
            var sut = algo.NoPrefixSet(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> NoPrefixSetTestCases => GenerateData(
            new TestCase(new string[] { "aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad" }, "BAD SET: aabcde"),
            new TestCase(new string[] { "aab", "aac", "aacghgh", "aabghgh" }, "BAD SET: aacghgh")
        );
    }
}