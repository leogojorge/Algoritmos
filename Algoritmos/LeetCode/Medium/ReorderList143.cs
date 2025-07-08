using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algoritmos.LeetCode.Easy;

namespace Algoritmos.LeetCode.Medium
{
    public static class ReorderList143
    {
        public static void Call()
        {
            var head = new ListNode(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4, new ListNode(5)))));

            ReorderList(head);
        }
        public static void ReorderList(ListNode head)
        {
            if (head is null) return;

            var stack = new Stack<ListNode>();

            var node = head;
            var fastPointer = head;
            var slowPointer = head;

            while (fastPointer is not null && fastPointer.next is not null)
            {
                fastPointer = fastPointer.next.next;
                slowPointer = slowPointer.next;
            }

            while (slowPointer is not null)
            {
                var temp = slowPointer.next;
                stack.Push(slowPointer);
                slowPointer.next = null;
                slowPointer = temp;
            }

            while (stack.Count > 0)
            {
                var temp = node.next;
                var last = stack.Pop();

                if (last == node.next) break;

                node.next = last;
                last.next = temp;
                node = temp;
            }
        }
    }
}
