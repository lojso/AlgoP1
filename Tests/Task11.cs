using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task11
    {
        private const string s0 = "0123456789";
        private const string s1 = "1234567890";
        private const string s2 = "2345678901";
        private const string s3 = "3456789012";
        private const string s4 = "4567890123";
        private const string s5 = "5678901234";
        private const string s6 = "6789012345";
        private const string s7 = "7890123456";
        private const string s8 = "8901234567";
        private const string s9 = "9012345678";
        
        [Test]
        public void TestAdd()
        {
            var filter = new BloomFilter(32);
            
            filter.Add(s0);
            
            Assert.True(filter.IsValue(s0) == true);
            Assert.True(filter.IsValue("awdfbswer0") == false);
        }
        
        [Test]
        public void TestAddTen()
        {
            var filter = new BloomFilter(32);
            filter.Add(s0);
            filter.Add(s1);
            filter.Add(s2);
            filter.Add(s3);
            filter.Add(s4);
            filter.Add(s5);
            filter.Add(s6);
            filter.Add(s7);
            filter.Add(s8);
            filter.Add(s9);
            
            Assert.True(filter.IsValue(s0) == true);
            Assert.True(filter.IsValue(s1) == true);
            Assert.True(filter.IsValue(s2) == true);
            Assert.True(filter.IsValue(s3) == true);
            Assert.True(filter.IsValue(s4) == true);
            Assert.True(filter.IsValue(s5) == true);
            Assert.True(filter.IsValue(s6) == true);
            Assert.True(filter.IsValue(s7) == true);
            Assert.True(filter.IsValue(s8) == true);
            Assert.True(filter.IsValue(s9) == true);
            Assert.True(filter.IsValue("awdfbswer0") == false);

            int a = 0;
        }
    }
}