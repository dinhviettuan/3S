using Xunit;

namespace TestProject1
{
    public class TestUser
    {
            [Fact]
            public void PassingTest()
            {
                Assert.Equal(2, 2);
            }
 
            [Fact]
            public void FailingTest()
            {
                Assert.Equal(2, 3);
            }
        }
    }
}