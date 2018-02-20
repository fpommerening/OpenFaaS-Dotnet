using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new OpenFaaS.Dotnet.TestFuntionContext();
            var sut = new Function.FunctionHandler(context);
            var myteststring = "HalloWorld";
            sut.Handle(myteststring);
            context.Content.Should().Be($"Hi there - your input was: {myteststring}");
        }
    }
}
