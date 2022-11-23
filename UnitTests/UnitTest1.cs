using Test.Services;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            for(int i = 0; i < 100; i++)
            {
                var service = new PaymentService(new InputParams { CountPeople = 3 + i, InitAmount = 10 + i });

                var result = service.Start().Result.BalanceAmount;
                Assert.Equal(1, result);
            }
        }
    }
}