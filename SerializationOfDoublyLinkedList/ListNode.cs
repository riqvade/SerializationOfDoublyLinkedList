using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationOfDoublyLinkedList
{
    /// <summary>
    /// Element of list
    /// </summary>
    public class ListNode
    {
        /// <summary>
        /// Previous element
        /// </summary>
        public ListNode? Previous {get; set; }

        /// <summary>
        /// Next element
        /// </summary>
        public ListNode Next { get; set; }


        /// <summary>
        /// Arbitrary element inside the list
        /// </summary>
        public ListNode Random { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Data { get; set; }

        public ListNode(string data)
        {
            Data = data;
        }

    }
}
