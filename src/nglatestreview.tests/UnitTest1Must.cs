namespace nglatestreview.tests
{
    public class UnitTest1Must
    {
        [Fact]
        public void Pass()
        {
            Assert.Equal(7, 7);
        }

        [Fact]
        public void Fail()
        {
            Assert.Equal(6, 7);
        }
    }
}