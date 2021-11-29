using System;
using Algoritms;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class SpecialStackTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SpecialStackTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SpecialStackMethodsTest()
        {
            var stack = new SpecialStack();
            stack.Push(5); _testOutputHelper.WriteLine($"Push: 5 | Min: {stack.GetMin()} \n ------------");
            stack.Push(3); _testOutputHelper.WriteLine($"Push: 3 | Min: {stack.GetMin()} \n ------------");
            stack.Push(-3); _testOutputHelper.WriteLine($"Push: -3 | Min: {stack.GetMin()} \n ------------");
            stack.Push(10); _testOutputHelper.WriteLine($"Push: 10 | Min: {stack.GetMin()} \n ------------");
            stack.Push(-20); _testOutputHelper.WriteLine($"Push: -20 | Min: {stack.GetMin()} \n ------------");
            stack.Push(0); _testOutputHelper.WriteLine($"Push: 0 | Min: {stack.GetMin()} \n ------------");
            stack.Push(100); _testOutputHelper.WriteLine($"Push: 100 | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
            _testOutputHelper.WriteLine($"Pop: {stack.Pop()} | Min: {stack.GetMin()} \n ------------");
        }
    }
}