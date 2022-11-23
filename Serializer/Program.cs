// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using my_diary_tests;


XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<NoteData>));
List<NoteData> data = new List<NoteData>();
Random random = new Random();
const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
string head = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
string content = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
data.Add(new NoteData(head, content));
using(FileStream fs = new FileStream(@"C:\Users\Владислава\RiderProjects\my-diary-tests\my-diary-tests\text.xml", FileMode.OpenOrCreate))
{
    xmlSerializer.Serialize(fs, data);
    Console.WriteLine("object serialized");
}
