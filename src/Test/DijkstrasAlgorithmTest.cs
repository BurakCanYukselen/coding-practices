using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Algoritms;
using Xunit;

namespace Test
{
    public class DijkstrasAlgorithmTest : TestBase<(int from, int to), int>
    {
        public static int[,] Graph => new int[,]
        {
            //A, B, C,  D,  E, F, G
            { 0, 4, 3, 0, 7, 0, 0 }, // A 
            { 4, 0, 6, 5, 0, 0, 0 }, // B 
            { 3, 6, 0, 11, 8, 0, 0 }, // C 
            { 0, 5, 11, 0, 2, 2, 10 }, // D 
            { 7, 0, 8, 2, 0, 0, 5 }, // E 
            { 0, 0, 0, 2, 0, 0, 3 }, // F 
            { 0, 0, 0, 10, 5, 3, 0 }, // G 
        };

        [Theory]
        [MemberData(nameof(ShortestPathTestCases))]
        public void ShortestPathTest(TestCase testCase)
        {
            // Arrange
            var algo = new Dijkstras();

            // Act
            var sut = algo.ShortestPath(Graph, testCase.Input.from, testCase.Input.to);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> ShortestPathTestCases => GenerateData(
            // A to F
            new TestCase((from: 0, to: 5), 11),
            // B to G
            new TestCase((from: 1, to: 6), 10),
            // C to F
            new TestCase((from: 2, to: 5), 12),
            // F to E
            new TestCase((from: 5, to: 4), 4)
        );
    }
}