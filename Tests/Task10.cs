using System;
using System.Diagnostics;
using Task10;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task10
    {
        [Test]
        public void PutTest()
        {
            PowerSet<int> set = new PowerSet<int>();
            
            set.Put(1);
            set.Put(1);
            set.Put(2);

            Assert.True(set.Size() == 2);
        }
        
        [Test]
        public void GetFromEmpty()
        {
            PowerSet<int> set = new PowerSet<int>();

            Assert.True(set.Get(1) == false);
            Assert.True(set.Get(0) == false);
        }

        
        [Test]
        public void RemoveTest()
        {
            PowerSet<int> set = new PowerSet<int>();
            
            set.Put(1);
            set.Put(1);
            set.Put(2);
            set.Put(2);
            set.Put(3);
            Assert.True(set.Size() == 3);
            
            Assert.True(set.Get(1));
            Assert.True(set.Get(2));
            Assert.True(set.Get(3));
            Assert.True(!set.Get(4));

            Assert.True(set.Remove(3));
            Assert.True(set.Size() == 2);
            Assert.True(set.Get(1));
            Assert.True(set.Get(2));
            Assert.True(!set.Get(3));
            
            Assert.True(set.Remove(2));
            Assert.True(set.Size() == 1);
            Assert.True(set.Get(1));
            Assert.True(!set.Get(2));
            Assert.True(!set.Get(3));
            
            Assert.True(!set.Remove(2));
            Assert.True(!set.Remove(3));
        }

        [Test]
        public void BasicLoadTest()
        {
            var set = GenerateSet(0, 20000);
            
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            set.Size();
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();
            
            stopwatch.Start();
            for (int i = 0; i < 20000; i++)
            {
                set.Get(i);
            }
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();
            
            stopwatch.Start();
            for (int i = 0; i < 20000; i++)
            {
                set.Remove(i);
            }
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();

        }

        [Test]
        public void Union()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            
            s2.Put(2);
            s2.Put(3);

            var union = s1.Union(s2);
            
            Assert.True(union.Size() == 3);
        }
        
        [Test]
        public void UnionDifferent()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            
            s2.Put(3);
            s2.Put(4);

            var union = s1.Union(s2);
            
            Assert.True(union.Size() == 4);
        } 
        
        [Test]
        public void UnionInternal()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            s1.Put(3);
            s1.Put(4);
            
            s2.Put(2);
            s2.Put(3);

            var union = s1.Union(s2);
            
            Assert.True(union.Size() == 4);
        }
        
        [Test]
        public void Intersection()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(2);
            s2.Put(3);

            var union = s1.Intersection(s2);
            
            Assert.True(union.Size() == 1);
        }
        
        [Test]
        public void IntersectionDifferent()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(3);
            s2.Put(4);

            var union = s1.Intersection(s2);
            
            Assert.True(union.Size() == 0);
        }
        
        [Test]
        public void IntersectionInternal()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            s1.Put(3);
            s1.Put(4);

            s2.Put(2);
            s2.Put(3);

            var union = s1.Intersection(s2);
            
            Assert.True(union.Size() == 2);
        }
        
        [Test]
        public void Difference()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(2);
            s2.Put(3);

            var union = s1.Difference(s2);
            
            Assert.True(union.Size() == 1);
        }
        
        [Test]
        public void DifferenceDifferent()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(3);
            s2.Put(4);

            var union = s1.Difference(s2);
            
            Assert.True(union.Size() == 2);
        }
        
        [Test]
        public void DifferenceInternal()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            s1.Put(3);
            s1.Put(4);

            s2.Put(2);
            s2.Put(3);

            var union = s1.Difference(s2);
            
            Assert.True(union.Size() == 2);
        }

                
        [Test]
        public void DifferenceSame()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(2);
            s1.Put(3);

            s2.Put(2);
            s2.Put(3);

            var union = s1.Difference(s2);
            
            Assert.True(union.Size() == 0);
        }

        
        [Test]
        public void IsSubset()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(2);
            s2.Put(3);
            
            
            Assert.True(!s1.IsSubset(s2));
        }
        
        [Test]
        public void IsSubsetDifferent()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);

            s2.Put(3);
            s2.Put(4);
            
            
            Assert.True(!s1.IsSubset(s2));
        }
        
        [Test]
        public void IsSubsetInternal()
        {
            var s1 = new PowerSet<int>();
            var s2 = new PowerSet<int>();
            
            s1.Put(1);
            s1.Put(2);
            s1.Put(3);
            s1.Put(4);

            s2.Put(3);
            s2.Put(4);
            
            Assert.True(s1.IsSubset(s2));
        }

        [Test]
        public void UnionLoad()
        {
            var set1 = GenerateSet(0, 5000);
            var set2 = GenerateSet(5000, 10000);
            
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var set = set1.Union(set2);
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();
        }
        
        [Test]
        public void DiffLoad()
        {
            var set1 = GenerateSet(0, 15000);
            var set2 = GenerateSet(5000, 20000);
            
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            set1.Difference(set2);
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();
        }
        
        [Test]
        public void IntersectionLoad()
        {
            var set1 = GenerateSet(0, 15000);
            var set2 = GenerateSet(5000, 20000);
            
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            set1.Intersection(set2);
            stopwatch.Stop();
            Assert.True(stopwatch.ElapsedMilliseconds <= 2000);
            stopwatch.Reset();
        }
        
        private PowerSet<int> GenerateSet(int from, int to)
        {
            var set = new PowerSet<int>();
            for (int i = from; i < to; i++)
            {
                set.Put(i);
            }
            return set;
        }
        
    }
}