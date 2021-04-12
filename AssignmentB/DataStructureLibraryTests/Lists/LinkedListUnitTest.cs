using System;
using DataStructureLibrary.Lists;
using DataStructureLibrary.Lists.Abstractions;
using Xunit;

namespace DataStructureLibraryTests
{
    public class LinkedListUnitTest
    {
        [Fact]
        public void CreateEmptyLinkedList()
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Add_EmptyLinkedList_ElementAdded()
        {
            ILinkedList<int> list = new LinkedList<int>();

            list.Add(1);

            var index = list.IndexOf(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(0, index);
        }

        [Fact]
        public void Push_EmptyLinkedList_ElementInserted()
        {
            ILinkedList<int> list = new LinkedList<int>();

            list.Push(1);

            var index = list.IndexOf(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(0, index);
        }

        [Fact]
        public void InsertAt0_EmptyLinkedList_ElementInserted()
        {
            ILinkedList<int> list = new LinkedList<int>();

            list.InsertAt(0, 1);

            var index = list.IndexOf(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(0, index);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void InsertAt_LinkedListWithData_ElementInserted(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Push(i);
            }

            list.InsertAt(index, 99);

            var elementIndex = list.IndexOf(99);
            Assert.Equal(6, list.Count);
            Assert.Equal(index, elementIndex);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void InsertAt_EmptyLinkedListAndWrongIndex_ArgumentExceptionThrown(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Throws<ArgumentException>(() => list.InsertAt(index, 1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void InsertAt_LinkedWithListAndWrongIndex_ArgumentExceptionThrown(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Push(5);

            Assert.Throws<ArgumentException>(() => list.InsertAt(index, 1));
        }

        [Fact]
        public void Contains_LinkedListWithData_ElementFound()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            var containsResult = list.Contains(5);

            Assert.True(containsResult);
        }

        [Fact]
        public void Contains_LinkedListWithData_ElementNotFound()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            var containsResult = list.Contains(99);

            Assert.False(containsResult);
        }

        [Fact]
        public void IndexOf_LinkedListWithUniqueData_ElementFound()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            var index = list.IndexOf(5);

            Assert.Equal(5, index);
        }

        [Fact]
        public void IndexOf_LinkedListWithDuplicateData_ElementFound()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    list.Push(j);
                }
            }

            var index = list.IndexOf(5);

            Assert.Equal(5, index);
        }

        [Fact]
        public void IndexOf_LinkedListWithData_ElementNotFound()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            var index = list.IndexOf(20);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void Remove_LinkedListEmtpy_LinkedListNotChange()
        {
            ILinkedList<int> list = new LinkedList<int>();

            list.Remove(20);

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Remove_LinkedListWithDataAndElementNotContained_LinkedListNotChange()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            list.Remove(20);

            Assert.Equal(10, list.Count);
        }

        [Fact]
        public void Remove_LinkedListWithSingleElementAndElementContained_ElementRemoved()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Push(5);

            list.Remove(5);

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Remove_LinkedListWithDataAndElementContained_ElementRemoved()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Push(i);
            }

            list.Remove(5);

            Assert.Equal(9, list.Count);
        }

        [Fact]
        public void Remove_LinkedListWithDataAndElementContainedMultipleTimes_FirstOcurrenceRemoved()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    list.Push(j);
                }
            }

            list.Remove(5);

            Assert.Equal(29, list.Count);
            Assert.Equal(14, list.IndexOf(5));
        }

        [Fact]
        public void RemoveAt_LinkedListWithSingleElementAndElementContained_ElementRemoved()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Push(5);

            list.RemoveAt(0);

            Assert.Equal(0, list.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void RemoveAt_LinkedListWithData_ElementRemoved(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Push(i);
            }

            list.RemoveAt(index);

            Assert.Equal(4, list.Count);
            Assert.False(list.Contains(index));
        }

        [Fact]
        public void RemoveAt_LinkedListWithDataAndElementContainedMultipleTimes_FirstOcurrenceRemoved()
        {
            ILinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    list.Push(j);
                }
            }

            list.RemoveAt(5);

            Assert.Equal(29, list.Count);
            Assert.Equal(14, list.IndexOf(5));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void RemoveAt_EmptyLinkedListAndWrongIndex_ArgumentExceptionThrown(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Throws<ArgumentException>(() => list.RemoveAt(index));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void RemoveAt_LinkedListWithDataAndWrongIndex_ArgumentExceptionThrown(int index)
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Push(5);

            Assert.Throws<ArgumentException>(() => list.RemoveAt(index));
        }
    }
}
