using SerializationOfDoublyLinkedList;

ListRandom list = new ListRandom();

list.AddNode("zero");
list.AddNode("first");
list.AddNode("second");
list.AddNode("third");
list.AddNode("fourth");

list.AddRandomNode();

Console.WriteLine("1.Random: " + list.Head.Random.Data);
Console.WriteLine("2.Random: " + list.Head.Next.Random.Data);
Console.WriteLine("3.Random: " + list.Head.Next.Next.Random.Data);
Console.WriteLine("4.Random: " + list.Head.Next.Next.Next.Random.Data);
Console.WriteLine("5.Random: " + list.Head.Next.Next.Next.Next.Random.Data);

FileStream fs = new FileStream(@"C:\Users\riqvade\Desktop\ser\dat.txt", FileMode.Create);
list.Serialize(fs);


ListRandom list2 = new ListRandom();

try
{
    fs = new FileStream(@"C:\Users\riqvade\Desktop\ser\dat.txt", FileMode.Open);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Press Enter to exit.");
    Console.Read();
}

list2.Deserialize(fs);

Console.WriteLine("1.Random: " + list2.Head.Random.Data);
Console.WriteLine("2.Random: " + list2.Head.Next.Random.Data);
Console.WriteLine("3.Random: " + list2.Head.Next.Next.Random.Data);
Console.WriteLine("4.Random: " + list2.Head.Next.Next.Next.Random.Data);
Console.WriteLine("5.Random: " + list2.Head.Next.Next.Next.Next.Random.Data);