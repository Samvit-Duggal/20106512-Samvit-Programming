
using HospitalManagement.Models;
using HospitalManagement.Services;

StaffManager mgr = new StaffManager();

int ch = -1;

while (ch != 0)
{
    Console.WriteLine("\n================================");
    Console.WriteLine("        STAFF MANAGEMENT");
    Console.WriteLine("================================");
    Console.WriteLine("1. Add Doctor");
    Console.WriteLine("2. Add Nurse");
    Console.WriteLine("3. Add Administrative Staff");
    Console.WriteLine("4. Display All Staff");
    Console.WriteLine("5. Search Staff");
    Console.WriteLine("0. Exit");
    Console.WriteLine("================================");

    Console.Write("Enter choice: ");
    if (!int.TryParse(Console.ReadLine(), out ch))
    {
        Console.WriteLine("Invalid choice.");
        ch = -1;
        continue;
    }

    if (ch >= 1 && ch <= 3)
    {
        Console.Write("Enter Name: ");
        string nm = Console.ReadLine() ?? "";

        Console.Write("Enter Staff ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
        {
            Console.WriteLine("Invalid Staff ID.");
            continue;
        }

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nm) ||
            string.IsNullOrWhiteSpace(dept))
        {
            Console.WriteLine("Name and department cannot be empty.");
            continue;
        }

        if (ch == 1)
        {
            Console.Write("Enter Specialization: ");
            string spec = Console.ReadLine() ?? "";

            Doctor d = new Doctor(nm, id, dept, spec);
            mgr.AddStaff(d);
        }
        else if (ch == 2)
        {
            Console.Write("Enter Shift: ");
            string shift = Console.ReadLine() ?? "";

            Nurse n = new Nurse(nm, id, dept, shift);
            mgr.AddStaff(n);
        }
        else
        {
            Console.Write("Enter Role: ");
            string role = Console.ReadLine() ?? "";

            AdministrativeStaff a =
                new AdministrativeStaff(nm, id, dept, role);

            mgr.AddStaff(a);
        }
    }
    else if (ch == 4)
    {
        mgr.ShowAll();
    }
    else if (ch == 5)
    {
        Console.Write("Enter Staff ID to search: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            mgr.FindStaff(id);
        }
        else
        {
            Console.WriteLine("Invalid Staff ID.");
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
