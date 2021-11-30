using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Trie_ContactsTest : TestBase<string[], string>
    {
        [Theory]
        [MemberData(nameof(ContactsTestCases))]
        public void ContactsTest(TestCase testCase)
        {
            // Arrange
            var algo = new Trie_Contacts();

            // Act
            var sut = algo.Operate(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> ContactsTestCases => GenerateData(
            new TestCase(new string[] { "add hack", "add hackerrank", "find hac", "find hak" }, "2,0"),
            new TestCase(new string[] { "add ed", "add eddie", "add edward", "find ed", "add edwina", "find edw", "find a" }, "3,2,0")
        );
    }
}