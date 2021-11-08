using System;
using System.Runtime.CompilerServices;
using Algoritms;
using Xunit;

namespace Test
{
    public class DijkstrasAlgorithmTest
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
        [InlineData(0, 5, 11)] // A to F
        [InlineData(1, 6, 10)] // B to G
        [InlineData(2, 5, 12)] // C to F
        [InlineData(5, 4, 4)] // F to E
        public void ShortestPathTest(int from, int to, int expected)
        {
            // Arrange
            var algo = new Dijkstras();

            // Act
            var sut = algo.ShortestPath(Graph, from, to);

            // Assert
            Assert.Equal(expected, sut);
        }
    }
}