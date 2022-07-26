using SerializationOfDoublyLinkedList;

ListRandom list = new ListRandom();
list.Add("first");
list.Add("second");
list.Add("third");

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list.Head.Data);
    Console.WriteLine(list.Head.Next.Data);
    Console.WriteLine(list.Head.Next.Next.Data);
}
