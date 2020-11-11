using AlgoP1;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task12
    {
        [Test]
        public void TestZeroKeyRewrite()
        {
            var c = new NativeCache<string>(5);
            
            c.Put("0", "0");
            c.Put("1", "1");
            c.Put("2", "2");
            c.Put("3", "3");
            c.Put("4", "4");

            c.Get("1");
            c.Get("2");
            c.Get("3");
            c.Get("4");

            c.Put("5", "5");
            
            Assert.IsTrue(c.IsKey("5"));
            Assert.IsTrue(c.Get("5").Equals("5"));
            Assert.IsTrue(!c.IsKey("0"));
        }
        
        [Test]
        public void TestOneKeyRewrite()
        {
            var c = new NativeCache<string>(5);
            
            c.Put("0", "0");
            c.Put("1", "1");
            c.Put("2", "2");
            c.Put("3", "3");
            c.Put("4", "4");

            c.Get("0");
            c.Get("2");
            c.Get("3");
            c.Get("4");

            c.Put("5", "5");
            
            Assert.IsTrue(c.IsKey("5"));
            Assert.IsTrue(c.Get("5").Equals("5"));
            Assert.IsTrue(!c.IsKey("1"));
        }
    }
}