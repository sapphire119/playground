using ValueTypeStructs;
using Xunit;
using Xunit.Abstractions;

namespace TestProj
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            Point.Origin.X = 0;
        }


        [Fact]
        public void Test1()
        {
            var copy = Point.Origin;
            copy.X = 42;
            Assert.Equal(0, Point.Origin.X);
            Assert.Equal(42, copy.X);

        }

        [Fact]
        public void Test2()
        {
            ref var origin = ref Point.Origin;
            origin.X = 42;

            Assert.Equal(42, Point.Origin.X);
            Assert.Equal(42, origin.X);
        }

        [Fact]
        public void Test3()
        {
            ref readonly var origin = ref Point.ReadOnlyOrigin;

            //Compile error
                //origin.X = 42;

            Assert.Equal(0, origin.X);
            Assert.Equal(0, Point.ReadOnlyOrigin.X);
        }

        [Fact]
        public void Test4()
        {
            ref readonly var origin = ref Point.ReadOnlyOrigin;

            //Method call happens on defensive copy
            origin.TranslateInSpace(42, 0);

            Assert.Equal(0, Point.ReadOnlyOrigin.X);
            Assert.Equal(0, origin.X);
        }
    }
}