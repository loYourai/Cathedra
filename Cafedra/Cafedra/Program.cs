using ConsoleApp1;
using System.Xml.Linq;
using static System.Console;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, Team!");
Console.WriteLine("First line");
Console.WriteLine("Second line");
Console.WriteLine("Second line");

// students, teachers, rooms, lessons

var cathedra = new Cathedra
{
    Name = "Tech Cathedra",
    Teachers = new[]
    {
        new Teacher
        {
            Name = "John"
        },
        new Teacher
        {
            Name = "Mary"
        }
    },
    Groups = new[]
    {
        new Group
        {
            Name = "A1",
            Lessons = new[]
            {
                new Lesson
                {
                    Name = "Math"
                }
            },
            Students = new[]
            {
                new Student
                {
                    Name = "Artem"
                }
            }
        },
        new Group
        {
            Name = "A2",
            Lessons = new[]
            {
                new Lesson
                {
                    Name = "Math"
                }
            },
            Students = new[]
            {
                new Student
                {
                    Name = "Artem"
                }
            }
        }
    }
};

foreach (var group in cathedra.Groups)
{
    Console.WriteLine($"{group.Name}: ");

    foreach (var student in group.Students)
    {
        Console.WriteLine($"{student.Name}");
    }
}

const string FileName = "meetings lesson.txt";
const int MaximumRoomLenght = 25;
const int MaximumNameLenght = 50;
const string FileName2 = "Group.txt";
//const int MaximumRoomLenght2 = 25;
//const int MaximumNameLenght2 = 50;

void ShowallGrroup()
{
    Console.WriteLine($"{"Group",20}"
        + $"{"Student",20}");

    var fileContent = File.ReadAllLines(FileName2);

    foreach (var line in fileContent)
    {
        var meetingContent = line.Split(",");

        Console.WriteLine($"{meetingContent[0],20}" +
              $"{meetingContent[1],20}");
    }

    //Console.WriteLine("Press any key to return to menu...");
    Console.ReadLine();
}

void Addstudent()
{
    Console.WriteLine("Group: ");
    var Group = Console.ReadLine();
    Console.WriteLine("Student: ");
    var student = Console.ReadLine();

    File.AppendAllText(FileName2, $"{Group},{student}" + Environment.NewLine);
}
void Showallessons()
{
    Console.WriteLine($"{"Date",20}"
        + $"{"Time",20}"
        + $"{"Room",20}" +
        $"{"Lesson",20}");

    var fileContent = File.ReadAllLines(FileName);

    foreach (var line in fileContent)
    {
        var meetingContent = line.Split(",");

        Console.WriteLine($"{meetingContent[0],20}" +
              $"{meetingContent[1],20}" +
              $"{meetingContent[2],20}" +
              $"{meetingContent[3],20}");
    }

    //Console.WriteLine("Press any key to return to menu...");
    Console.ReadLine();
}

void ShowError(string error)
{
    Console.WriteLine(error);
    Console.ReadLine();
}

void Addlessons() // meeting start time, duration, room, name
{
    Console.WriteLine("Start date:");
    var dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
    if (!dateParsingResult)
    {
        ShowError("Error! Invalid Start date");
        return;
    }



    Console.WriteLine("Time in Start: ");
    var Result = Console.ReadLine();



    // if (!durationParsingResult)
    // {
    //     ShowError("Error! Invalid meeting duration");
    //     return;
    // }

    //var a2 = File.ReadAllLines(FileName);
    // var b = duration;
    //  if (a = b)
    // {
    //      throw new ArgumentException("Invalid name");
    //  }

    Console.WriteLine("Room: ");
    var room = Console.ReadLine();
    if (string.IsNullOrEmpty(room))
    {
        ShowError("Error! Empty room");
        return;
    }

    if (room.Length > MaximumRoomLenght)
    {
        ShowError($"Error! Room should not be longer than {MaximumRoomLenght} symbols");
        return;
    }

    Console.WriteLine("Lesson: ");
    var name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        ShowError("Error! Empty name");
        return;
    }

    if (name.Length > MaximumNameLenght)
    {
        ShowError($"Error! Room should not be longer than {MaximumNameLenght} symbols");
        return;
    }

    File.AppendAllText(FileName, $"{startTime},{Result},{room},{name}" + Environment.NewLine);
}

void Exit()
{
    Environment.Exit(0);
}



void Menu()
{
    Console.Clear();
    Console.WriteLine("5.Show Group");
    Console.WriteLine("4. Add a student to a group");
    Console.WriteLine("3. Show all lessons");
    Console.WriteLine("2. Add lessons");
    Console.WriteLine("1. Exit calendar");
}

while (true)
{
    Menu();
    var keyInfo = Console.ReadKey();
    switch (keyInfo.Key)
    {
        case ConsoleKey.D1:
            Exit();
            break;
        case ConsoleKey.D2:
            Addlessons();
            break;
        case ConsoleKey.D3:
            Showallessons();
            break;
        case ConsoleKey.D4:
            Addstudent();
            break;
        case ConsoleKey.D5:
            ShowallGrroup();
            break;
        default: break;
    }
}


// initialize cathedra with default constructor
// cathedra.AddGroup();

// cathedra.AddTeacher();
// cathedra.AddTeacher();
// cathedra.AddTeacher();

// group.AddStudent();
// group.AddStudent();
// group.AddStudent();
// group.AddStudent();