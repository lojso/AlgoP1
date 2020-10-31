using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task9
    {
        [Test]
        public void Put()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(5);
            
            dict.Put("1", 1);
            Assert.True(dict.Get("1") == 1);
            
            dict.Put("1", -1);
            Assert.True(dict.Get("1") == -1);

            dict.Put("2", 2);
            Assert.True(dict.Get("1") == -1);
            Assert.True(dict.Get("2") == 2);
            
            Assert.True(dict.Get("3") == 0);
        }
        
        [Test]
        public void IsKey()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(5);
            
            dict.Put("1", 1);
            dict.Put("2", 2);

            Assert.True(dict.IsKey("1"));
            Assert.True(dict.IsKey("2"));
            Assert.True(!dict.IsKey("3"));
        }
        
        [Test]
        public void Hash()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(5);
            
            Assert.True(dict.HashFun("1") == 3);
        }
    }
}