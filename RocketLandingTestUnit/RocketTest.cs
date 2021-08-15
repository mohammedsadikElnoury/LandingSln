using Rocket;
using System.Threading.Tasks;
using Xunit;

namespace RocketLandingTestUnit
{
    public  class RocketTest
    {
        [Theory]
        [InlineData(5, 5, LandingResults.OkForLanding)]
        [InlineData(15, 16, LandingResults.OutOfPlatform)]
        public async Task Scenario1(int x, int y, string expected)
        {
            var obj = new RocketLanding(100, 100);
            var result = await obj.LandingRocketAsync(x, y);
            Assert.Equal(expected, result);
        }


        [Fact]
        public async Task Scenario2()
        {
            var obj=new  RocketLanding(100, 100);
            var result = await obj.LandingRocketAsync(7, 7);
            Assert.Equal(LandingResults.OkForLanding, result);
        }

        [Fact]
        public async Task Scenario3()
        {
            var obj = new RocketLanding(100, 100);
            var result1 = await obj.LandingRocketAsync(7, 8);
            var result2 = await obj.LandingRocketAsync(6, 7);
            var result3 = await obj.LandingRocketAsync(6, 6);
            var result = await obj.LandingRocketAsync(7, 7);
            Assert.Equal(LandingResults.Clash, result);
        }

        [Fact]
        public async Task Scenario4()
        {
            var obj = new RocketLanding(100, 100);
            var result1 = await obj.LandingRocketAsync(17, 8);
            var result2 = await obj.LandingRocketAsync(6, 17);
            var result3 = await obj.LandingRocketAsync(16, 6);
            var result = await obj.LandingRocketAsync(71, 7);
            Assert.Equal(LandingResults.OutOfPlatform, result);
        }

        [Fact]
        public async Task Scenario5()
        {
            var obj = new RocketLanding(100, 100);
            var result1 = await obj.LandingRocketAsync(7,8);
            var result2 = await obj.LandingRocketAsync(6,7);
            var result = await obj.LandingRocketAsync(8,8);
            Assert.Equal(LandingResults.Clash, result);
        }

        [Fact]
        public async Task Scenario6()
        {
            var obj = new RocketLanding(100, 100);
            var result1 = await obj.LandingRocketAsync(7, 8);
            var result2 = await obj.LandingRocketAsync(7, 7);
            var result = await obj.LandingRocketAsync(8, 8);
            Assert.Equal(LandingResults.Clash, result);
        }
    }
}
