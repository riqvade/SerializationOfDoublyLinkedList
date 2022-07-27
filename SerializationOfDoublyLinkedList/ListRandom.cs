using SerializationOfDoublyLinkedList.Helpers;
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

        private static Random _random = new Random();


        /// <summary>
        /// Adds a new element to a doubly linked list
        /// </summary>
        public void AddNode(string data)
        {
            ListNode node = new ListNode();
            node.Data = data;

            if (Head == null)
            { 
                Head = node;
                Head.Random = Head; // что бы значение небыло null
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;

                ////////////////////////////////////////////////////

                int randomNodeNumber = _random.Next(0, Count - 1);
                ListNode currentNode = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (randomNodeNumber == i)
                    {
                        node.Random = currentNode.Random;

                        currentNode.Random = currentNode.Random.Random;

                        node.Random.Random = node;
                    }
                    currentNode = currentNode.Next;
                }
            }

            Tail = node;
            Count++;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddRandomNode()
        {
            List<ListNode> listNode = new List<ListNode>();
            for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                listNode.Add(currentNode);
            }

            ListStirrer.Shuffle(listNode);

            int i = 0;
            for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                currentNode.Random = listNode[i];
                i++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddRandomNodeAtDeserialize(List<int> listNodesRandomNumbers)
        {
            List<ListNode> listNode = new List<ListNode>();
            for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                listNode.Add(currentNode);
            }

            ListNode currentNode1 = Head;
            for (int i = 0; i < listNodesRandomNumbers.Count; i++)
            {
                currentNode1.Random = listNode[listNodesRandomNumbers[i]];

                currentNode1 = currentNode1.Next;
            }
        }

        /// <summary>
        /// Serializes a doubly linked list
        /// </summary>
        public void Serialize(Stream s)
        {
            List<ListNode> listNodes = new List<ListNode>();

            for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                listNodes.Add(currentNode);
            }

            using (StreamWriter streamwriter = new StreamWriter(s))
            {
                for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
                {
                    streamwriter.WriteLine(currentNode.Data + ":" + listNodes.IndexOf(currentNode.Random).ToString());

                    Console.WriteLine(listNodes.IndexOf(currentNode.Random).ToString());
                }
            }
            Console.WriteLine("List serialized");
        }

        /// <summary>
        /// Deserializes a doubly linked list
        /// </summary>
        public void Deserialize(Stream s)
        {
            List<string> listNodesData = new List<string>();

            List<int> listNodesRandomNumbers = new List<int>();

            string contentOfLine;
            try
            {
                using (StreamReader streamReader = new StreamReader(s))
                {
                    while ((contentOfLine = streamReader.ReadLine()) != null)
                    {
                        listNodesData.Add(contentOfLine.Split(':')[0]);
                        listNodesRandomNumbers.Add(Convert.ToInt32(contentOfLine.Split(':')[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось обработать файл данных, возможно, он поврежден, подробности:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to exit.");
                Console.Read();
                Environment.Exit(0);
            }

            for (int i = 0; i < listNodesData.Count; i++)
            {
                AddNode(listNodesData[i]);
            }

            AddRandomNodeAtDeserialize(listNodesRandomNumbers);

        }

    }
}
