
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class StaffManager
    {
        private List<Staff> list = new List<Staff>();

        public void AddStaff(Staff s)
        {
            if (SearchStaff(s.StaffId))
            {
                Console.WriteLine("Staff ID already exists.");
            }
            else
            {
                list.Add(s);
                Console.WriteLine("Staff added successfully.");
            }
        }

        public void ShowAll()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No staff found.");
                return;
            }

            foreach (Staff s in list)
            {
                Console.WriteLine("--------------------");
                s.Show();
            }
        }

        public bool SearchStaff(int id)
        {
            foreach (Staff s in list)
            {
                if (s.StaffId == id)
                {
                    return true;
                }
            }

            return false;
        }

        public void FindStaff(int id)
        {
            foreach (Staff s in list)
            {
                if (s.StaffId == id)
                {
                    Console.WriteLine("Staff found!");
                    s.Show();
                    return;
                }
            }

            Console.WriteLine("Staff not found.");
        }
    }
}
