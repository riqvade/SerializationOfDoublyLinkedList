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
        /// Adds a new element
        /// </summary>
        public void AddNode(string data)
        {
            ListNode node = new ListNode();
            node.Data = data;

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Sets random elements in nodes
        /// </summary>
        public void RandomShuffle()
        {
            Random random = new Random();

            if (Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                ListNode curNode = Head;
                while (curNode != null)
                {
                    curNode.Random = GetNode(random.Next(0, Count - 1));
                    curNode = curNode.Next;
                }
            }
        }

        /// <summary>
        /// Return node
        /// </summary>
        private ListNode GetNode(int number)
        {
            if (Count == 0)
            {
                Console.WriteLine("List is empty");

                return null;
            }
            else
            {
                if (number < Count)
                {
                    ListNode curNode = Head;
                    while (number != 0)
                    {
                        curNode = curNode.Next;
                        number--;
                    }

                    return curNode;
                }
                else
                {
                    Console.WriteLine("List have not node with number " + number.ToString());

                    return null;
                }
            }
        }

        /// <summary>
        /// Return Index Of node
        /// </summary>
        public int GetIndexOfNode(ListNode node)
        {
            int index = 0;

            if (Count == 0)
            {
                Console.WriteLine("List is empty");

                return -1;
            }
            else
            {
                ListNode curNode = Head;
                while ((curNode != node) && (curNode != null))
                {
                    curNode = curNode.Next;

                    index++;
                }

                return index;
            }
        }

        /// <summary>
        /// Serializes a doubly linked list
        /// </summary>
        public void Serialize(Stream s)
        {
            try
            {
                using (StreamWriter streamwriter = new StreamWriter(s))
                {
                    ListNode curNode = Head;
                    while (curNode != null)
                    {
                        int randomNodeNumber = GetIndexOfNode(curNode.Random);
                        streamwriter.WriteLine(curNode.Data + ":" + randomNodeNumber.ToString());
                        curNode = curNode.Next;
                    }
                }
                Console.WriteLine("List serialized");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process data file, possibly corrupted, details:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to exit.");
                Console.Read();
                Environment.Exit(0);
            }
            
        }

        /// <summary>
        /// Deserializes a doubly linked list
        /// </summary>
        public void Deserialize(Stream s)
        {
            string contentOfLine;
            List<int> randomNumbers = new List<int>();
            try
            {
                using (StreamReader streamReader = new StreamReader(s))
                {
                    while ((contentOfLine = streamReader.ReadLine()) != null)
                    {
                        AddNode(contentOfLine.Split(':')[0]);
                        randomNumbers.Add(Convert.ToInt32(contentOfLine.Split(':')[1]));
                    }
                }
                ListNode curNode = Head;
                for (int i = 0; i < Count; i++)
                {
                    curNode.Random = GetNode(randomNumbers[i]);
                    curNode = curNode.Next;
                }
                Console.WriteLine("List deserialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process data file, possibly corrupted, details:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to exit.");
                Console.Read();
                Environment.Exit(0);
            }
        }
    }
}
