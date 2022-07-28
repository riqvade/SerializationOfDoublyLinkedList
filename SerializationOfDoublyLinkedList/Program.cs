using SerializationOfDoublyLinkedList;

ListRandom list = new ListRandom();

list.AddNode("One");
list.AddNode("Two");
list.AddNode("Three");
list.AddNode("Four");
list.AddNode("Five");

list.RandomShuffle();

ListNode curNode = list.Head;
for (int i = 0; i < list.Count; i++)
{
    int curNodeNumber = list.GetIndexOfNode(curNode);
    int curNodeNextNumber = list.GetIndexOfNode(curNode.Next);
    int curNodePreviousNumber = list.GetIndexOfNode(curNode.Previous);
    int curNodeRandomNumber = list.GetIndexOfNode(curNode.Random);

    Console.WriteLine(": Node = " + curNodeNumber +
                      " Next = " + curNodeNextNumber +
                      " Previous = " + curNodePreviousNumber +
                      " Random = " + curNodeRandomNumber);
    curNode = curNode.Next;
}

FileStream fs = null;
try
{
    fs = new FileStream(@"C:\Users\Gleb\Desktop\ser\dat.txt", FileMode.Create);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Press Enter to exit.");
    Console.Read();
    Environment.Exit(0);
}

list.Serialize(fs);

try
{
    fs = new FileStream(@"C:\Users\Gleb\Desktop\ser\dat.txt", FileMode.Open);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Press Enter to exit.");
    Console.Read();
    Environment.Exit(0);
}

ListRandom list2 = new ListRandom();
list2.Deserialize(fs);

curNode = list2.Head;
for (int i = 0; i < list.Count; i++)
{
    int curNodeNumber = list2.GetIndexOfNode(curNode);
    int curNodeNextNumber = list2.GetIndexOfNode(curNode.Next);
    int curNodePreviousNumber = list2.GetIndexOfNode(curNode.Previous);
    int curNodeRandomNumber = list2.GetIndexOfNode(curNode.Random);

    Console.WriteLine(": Node = " + curNodeNumber +
                      " Next = " + curNodeNextNumber +
                      " Previous = " + curNodePreviousNumber +
                      " Random = " + curNodeRandomNumber);
    curNode = curNode.Next;
}