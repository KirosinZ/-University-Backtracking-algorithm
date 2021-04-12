using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRIALG_BACKTRACK
{
    public static class SortedUniqueListExtension
    {
        public static SortedUniqueIntList ToSortedUniqueList(this IEnumerable<int> @this)
        {
            SortedUniqueIntList res = new SortedUniqueIntList();
            foreach (int i in @this)
            {
                res.Add(i);
            }
            return res;
        }
    }

    public class SortedUniqueIntList : IEnumerable<int>
    {
        class ListNode
        {
            public int Data { get; private set; }
            public ListNode Next { get; set; }

            public ListNode(int data, ListNode next = null)
            {
                Data = data;
                Next = next;
            }
        }

        ListNode head;

        public void Add(int data)
        {
            if (head == null)
            {
                head = new ListNode(data);
                return;
            }
            if (data < head.Data)
            {
                head = new ListNode(data, head);
                return;
            }

            var iter = head;
            for (; iter.Next != null && iter.Next.Data < data; iter = iter.Next) ;

            if (iter.Next != null && iter.Next.Data == data) return;

            iter.Next = new ListNode(data, iter.Next);
        }

        public void Remove(int data)
        {
            if (head == null) return;
            if (head.Data == data)
            {
                head = head.Next;
                return;
            }
            for (var iter = head; iter.Next != null; iter = iter.Next)
            {
                if (iter.Next.Data == data)
                {
                    iter.Next = iter.Next.Next;
                    return;
                }
            }
        }

        public void Clear()
        {
            head = null;
        }

        public bool IsEmpty { get => head == null; }

        public int First(Predicate<int> pred)
        {
            var iter = head;
            for (; iter != null && !pred(iter.Data); iter = iter.Next) ;
            if (iter == null) return -1;
            else return iter.Data;
        }

        public int Last(Predicate<int> pred)
        {
            int res = -1;
            for (var iter = head; iter != null; iter = iter.Next)
            {
                if (pred(iter.Data)) res = iter.Data;
            }
            return res;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var iter = head; iter != null; iter = iter.Next)
            {
                yield return iter.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(SortedUniqueIntList left, SortedUniqueIntList right)
        {
            var liter = left.head;
            var riter = right.head;
            for (; liter != null && riter != null && liter.Data == riter.Data; liter = liter.Next, riter = riter.Next) ;
            return liter == null && riter == null;
        }

        public static bool operator !=(SortedUniqueIntList left, SortedUniqueIntList right) => !(left == right);
    }
}
