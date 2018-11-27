using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace XML
{
    public class Person
    {
        public Person() { }
        public Person(string name, string surname, DateTime birthday, string hobby)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Hobby = hobby;
        }
        [XmlElement(ElementName = "Firstname")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Lastname")]
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        [XmlElement(ElementName = "HOBBY")]
        public string Hobby { get; set; }
        public void ShowPersonProperty()
        {
            Console.WriteLine("============================");
            Console.WriteLine($"Name - - > {Name}");
            Console.WriteLine($"Surname - - > {Surname}");
            Console.WriteLine($"Birthday - - > {Birthday.ToShortDateString()}");
            Console.WriteLine($"Hobby - - > {Hobby}");
            Console.WriteLine("============================");
        }
    }
    class Controller
    {
        List<Person> list = new List<Person>();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
        public Controller()
        {
         
        }



        public void run()
        {

            DateTime time = new DateTime(1999, 10, 16);
            DateTime time1 = new DateTime(1995, 12, 10);
            DateTime time2 = new DateTime(1987, 11, 24);
            DateTime time3 = new DateTime(2000, 11, 12);
            Person Elvin = new Person("Elvin", "Camalzade", time, "Search innovation about Artificial Intelligence");
            Person Tofiq = new Person("Tofiq", "Tofiqli", time1, "To play football");
            Person Rafiq = new Person("Rafiq", "Rafiqli", time2, "To watch Tv show");
            Person Ismayil = new Person("Ismayil", "Ismayil", time3, "To collect old coins");
            list.Add(Elvin); list.Add(Tofiq); list.Add(Rafiq); list.Add(Ismayil);
            Console.WriteLine("If you do not have a xml file please write 1 to serialize " +
                "or if yo have xml file write 2 to deserialize" +
                "To add new person to list write 3" +
                "to delete person from list write 4 after name of person ");
            Console.Write("Select - > ");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                SerializerToXML();
            }
            else if (selection == 2)
            {
                list = DeserializerFromXml();
            }
            else if (selection == 3)
            {
                list = DeserializerFromXml();
                var person = AddNewPersonToList();
                list.Add(person);
                SerializerToXML();
            }
            else if (selection == 4)
            {
                list = DeserializerFromXml();
                Console.Write("Write person name for deleting - >");
                string name = Console.ReadLine();
                DeletePersonFromListWithName(name);
                SerializerToXML();
            }
            foreach (var item in list)
            {
                item.ShowPersonProperty();
            }
        }
        public void SerializerToXML()
        {
            using (StreamWriter sw = new StreamWriter("list2.xml"))
            {
                xmlSerializer.Serialize(sw, list);
            }
        }
        public List<Person> DeserializerFromXml()
        {
            List<Person> result;
            using (StreamReader reader = new StreamReader("list2.xml"))
            {
                result = xmlSerializer.Deserialize(reader) as List<Person>;
            }

            return result;
        }
        public void ExitProgram()
        {
            SerializerToXML();
        }
        public void DeletePersonFromListWithName(string name)
        {
            var person = list.SingleOrDefault(x => x.Name == name);
            list.Remove(person);
        }
        public Person AddNewPersonToList()
        {
            string name; string surname; string hobby;
            Console.Write("Name -> ");
            name = Console.ReadLine();
            Console.Write("Surname -> ");
            surname = Console.ReadLine();
            Console.Write("Year -> ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month -> ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day -> ");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            Console.WriteLine("Person's Hobby -> ");
            hobby = Console.ReadLine();
            Person person = new Person(name, surname, date, hobby);
            return person;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.run();
            
        }
    }
}




