using DataStructures.Lists;
using NUnit.Framework;

// SUMMARY COMMENT

// This file contains the NUnit test cases for the SkipList data structure. The tests cover the basic functionality of adding, removing, and checking for the existence of items in the SkipList.

namespace NUnitTest.DataStructuresTests
{
    [TestFixture]
    public class SkipListTests
    {
        private SkipList<int> list;

        [SetUp]
        public void SetUp()
        {
            list = new SkipList<int>();
        }

        [Test]
        public void Add_AddsItemToList()
        {
            list.Add(1);

            Assert.That(list.Contains(1), Is.True);
        }

        [Test]
        public void Add_IncrementsCount()
        {
            list.Add(1);

            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_DoesNotAddDuplicateItem()
        {
            list.Add(1);
            list.Add(1);

            Assert.That(list, Has.Count.EqualTo(1));
        }

        [Test]
        public void Contains_ReturnsTrueIfItemExists()
        {
            list.Add(1);

            Assert.That(list.Contains(1), Is.True);
        }

        [Test]
        public void Contains_ReturnsFalseIfItemDoesNotExist()
        {
            list.Add(1);

            Assert.That(list.Contains(2), Is.False);
        }

        [Test]
        public void Remove_RemovesItemFromList()
        {
            list.Add(1);
            list.Remove(1, out _);

            Assert.That(list.Contains(1), Is.False);
        }

        [Test]
        public void Remove_DecrementsCount()
        {
            list.Add(1);
            list.Remove(1, out _);

            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_ReturnsTrueIfItemExists()
        {
            list.Add(1);

            Assert.That(list.Remove(1, out _), Is.True);
        }

        [Test]
        public void Remove_ReturnsFalseIfItemDoesNotExist()
        {
            list.Add(1);

            Assert.That(list.Remove(2, out _), Is.False);
        }
    }
}