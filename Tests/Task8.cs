using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task8
    {
        [Test]
        public void Add()
        {
            HashTable h = new HashTable(5, 3);
            
            Assert.True(h.Put("1") == 3);
            Assert.True(h.Put("1") == 3);
        }
        
        [Test]
        public void AddFullTable()
        {
            HashTable h = new HashTable(5, 3);

            h.Put("1");
            h.Put("2");
            h.Put("3");
            h.Put("4");
            h.Put("5");

            Assert.True(h.Put("6") == -1);
        }
        
        [Test]
        public void Hash()
        {
            HashTable h = new HashTable(5, 3);
            

            Assert.True(h.HashFun("1")== 3);
        }
        
        [Test]
        public void Seek()
        {
            HashTable h = new HashTable(5, 3);
            
            Assert.True(h.SeekSlot("1") == 3);
        }
        
        [Test]
        public void SeekSame()
        {
            HashTable h = new HashTable(5, 3);

            h.Put("1");
            
            Assert.True(h.SeekSlot("1") == 3);
        }
        
        [Test]
        public void FindVal()
        {
            HashTable h = new HashTable(5, 3);
            
            h.Put("1");
            
            Assert.True(h.Find("0") == -1);
            Assert.True(h.Find("1") == 3);
        }
    }
}