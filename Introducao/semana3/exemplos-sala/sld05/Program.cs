using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

var tuple1 = (10, 20);
Console.WriteLine(tuple1);

var tuple2 = (id: 1, name: "Náthalie", born: new DateTime(2003, 12, 15));
Console.WriteLine($"Tuple 2: {tuple2.id}, {tuple2.name}, {tuple2.born}");

List<(int id, string name, DateTime born)> list = new();
list.Add(tuple2);
list.Add((2, "Ciro", new DateTime(1967, 05, 06)));
list.ForEach(x => Console.WriteLine($"Tuple 3 {x.id} {x.name} {x.born.ToShortDateString()}"));

#region Exemplo 2 - Lambda e LINQ

string[] people = {"Náthalie", "Ciro", "Lili"};
char letter = 'K';
Console.WriteLine($"People with name started with '{letter}': {string.Join(", ", people.Where(x => x.StartsWith(letter)))}");
letter = 'N';
Console.WriteLine($"People with name started with '{letter}': {string.Join(", ", people.Where(x => x.StartsWith(letter)))}");

// people[0][1] = "e";
string ola = "haha";
//ola[1] = 'o';
Console.WriteLine($"{ola[1]}");

Console.WriteLine($"{people[0][1]}");

letter = 'i';
Console.WriteLine($"People with name started with '{letter}': {string.Join(", ", people.Where(x => x.Contains('I')))}");

#endregion

#region Linq Examples

List<int> list1 = new() { 1, 2, 3, 4, 5 };
var squaredList = list1.Select(x => x * x);
Console.WriteLine($"Original List: {string.Join(", ", list1)}");
Console.WriteLine($"Squared  List: {string.Join(", ", squaredList)}");
// Original List: 1, 2, 3, 4, 5
// Squared  List: 1, 4, 9, 16, 25
var summedList = list1.Select((x,index) => x + squaredList.ElementAt(index));
Console.WriteLine($"Summed   List: {string.Join(", ", summedList)}");
// Summed   List: 2, 6, 12, 20, 30

var listMultipleOfThree = list1.Where(x => x % 3 == 0).ToList();
listMultipleOfThree.AddRange(squaredList.Where(x => x % 3 == 0).ToList());
listMultipleOfThree.AddRange(summedList.Where(x => x % 3 == 0).ToList());
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree)}");
// List Multiple of Three: 3, 9, 6, 12, 30
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree.Order())}");

var students = new List<Student>{
   new Student(1, "Helder Almeida", "123456789", new DateTime(1987, 9, 24), new List<string>{"123456789", "73988342986"}),
   new Student(2, "Nicole Almeida", "987654321", new DateTime(2019, 1, 12), new List<string>{"123456789", "73987654321"}),
   new Student(3, "Gilvana Rocha", "123456789", new DateTime(1984, 11, 24), new List<string>{"123456789", "77988237086"})
};

var any = students.Any();
var anyHelder = students.Any(x => x.FullName.Contains("Helder"));
//var single = students.Single(x => x.Id == 10);
//throw exception
var singleOrDefault = students.SingleOrDefault(x => x.Id == 10);

var select = students.Select(x => x.PhoneNumbers);
var selectMany = students.SelectMany(x => x.PhoneNumbers);

var legalAge = students.Where(x => x.BirthDate <= DateTime.Today.AddYears(-18)).Select(x => x.FullName);
Console.WriteLine($"Legal age people: {string.Join(", ", legalAge)}");


Console.Read();
#endregion


 public class Student{
   public Student(int id, string fullName, string document, DateTime birthDate, List<string> phoneNumbers)
   {
      Id = id;
      FullName = fullName;
      Document = document;
      BirthDate = birthDate;
      PhoneNumbers = new List<string>(phoneNumbers);
   }

   public int Id { get; set; }
   public string FullName { get; set; }
   public string Document { get; set; }
   public DateTime BirthDate { get; set; }
   public List<string> PhoneNumbers { get; set; }
}