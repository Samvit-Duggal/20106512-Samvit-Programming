
Dictionary<int, Student> students = new Dictionary<int, Student>();

string[] names = {
    "Rahul Sharma", "Priya Patel", "Amit Kumar",
    "Sneha Gupta", "Rohan Verma", "Anjali Singh",
    "Arjun Mehta", "Pooja Shah", "Karan Malhotra",
    "Neha Agarwal", "Aditya Joshi", "Simran Kaur",
    "Vivek Mishra", "Riya Kapoor", "Akash Yadav",
    "Shreya Nair", "Varun Bansal", "Isha Reddy",
    "Nikhil Jain", "Meera Desai"
};

// Add 20 student records
for (int i = 0; i < 20; i++)
{
    int id = 101 + i;

    Student s = new Student(id, names[i]);

    int m1 = 60 + (i * 3) % 35;
    int m2 = 55 + (i * 4) % 40;
    int m3 = 50 + (i * 5) % 45;
    int m4 = 65 + (i * 2) % 30;
    int m5 = 58 + (i * 3) % 37;

    s.AddMod(new Module("Advanced Programming", m1, GetGrade(m1)));
    s.AddMod(new Module("Advanced Databases", m2, GetGrade(m2)));
    s.AddMod(new Module("Networking & Security", m3, GetGrade(m3)));
    s.AddMod(new Module("Web Development", m4, GetGrade(m4)));
    s.AddMod(new Module("Cloud Computing", m5, GetGrade(m5)));

    students.Add(id, s);
}

int ch = -1;

// Main menu
while (ch != 0)
{
    Console.WriteLine("\n================================");
    Console.WriteLine("       STUDENT RECORD SYSTEM");
    Console.WriteLine("================================");
    Console.WriteLine("1. Search Student");
    Console.WriteLine("2. Display All Students");
    Console.WriteLine("0. Exit");
    Console.WriteLine("================================");
    Console.Write("Enter choice: ");

    if (!int.TryParse(Console.ReadLine(), out ch))
    {
        Console.WriteLine("Invalid choice.");
        ch = -1;
        continue;
    }

    if (ch == 1)
    {
        Console.Write("Enter Student ID: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (students.ContainsKey(id))
            {
                students[id].Show();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID.");
        }
    }
    else if (ch == 2)
    {
        foreach (Student s in students.Values)
        {
            s.Show();
            Console.WriteLine("-------------------------");
        }
    }
    else if (ch == 0)
    {
        Console.WriteLine("Exiting program...");
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}

// Calculate grade from marks
static string GetGrade(int marks)
{
    if (marks >= 80)
        return "A";
    else if (marks >= 70)
        return "B+";
    else if (marks >= 60)
        return "B";
    else if (marks >= 50)
        return "C";
    else if (marks >= 40)
        return "D";
    else
        return "F";
}
