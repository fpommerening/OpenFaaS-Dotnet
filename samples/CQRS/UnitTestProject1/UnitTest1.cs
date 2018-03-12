using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new OpenFaaS.Dotnet.TestFuntionContext();
            var sut = new Function.FunctionHandler(context);
            var myteststring = " {\"Name\":\"Spartakiade\",\"Description\":\"Konferenz in Berlin\",\"Start\":\"2018-03-17T09:00:00\",\"End\":\"2018-03-18T18:00:00\",\"RegistrationStart\":\"2018-02-01T00:00:00\",\"RegistrationEnd\":\"2018-03-16T23:59:59\"}";
            sut.Handle(myteststring);
            

        }
    }
}
