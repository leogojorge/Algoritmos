using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode
{
    public static class ReverseLinkedList
    {
        public static void Call()
        {
            var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

            ReverseList(list);
        }

        public static ListNode ReverseList(ListNode head)
        {
            var current = head;
            ListNode prev = null;

            while (current is not null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
