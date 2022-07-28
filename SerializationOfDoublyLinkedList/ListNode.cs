using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationOfDoublyLinkedList
{
    /// <summary>
    /// Element of Doubly linked list
    /// </summary>
    public class ListNode
    {
        /// <summary>
        /// Previous element
        /// </summary>
        public ListNode Previous {get; set; }

        /// <summary>
        /// Next element
        /// </summary>
        public ListNode Next { get; set; }


        /// <summary>
        /// Arbitrary element
        /// </summary>
        public ListNode Random { get; set; }

        /// <summary>
        /// Content of element
        /// </summary>
        public string Data { get; set; }
    }
}
