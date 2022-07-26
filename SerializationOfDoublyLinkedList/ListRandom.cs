using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationOfDoublyLinkedList
{
    /// <summary>
    /// Doubly linked list
    /// </summary>
    public class ListRandom
    {
        /// <summary>
        /// Current element
        /// </summary>
        public ListNode Head { get; set; }

        /// <summary>
        /// Last element
        /// </summary>
        public ListNode Tail { get; set; }

        /// <summary>
        /// Number of elements
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// Adds a new element to a doubly linked list
        /// </summary>
        public void Add(string data)
        {
            ListNode node = new ListNode(data);

            if (Head == null)
            { 
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }


        public void Serialize(Stream s)
        {
        }

        public void Deserialize(Stream s)
        {
        }

    }
}
