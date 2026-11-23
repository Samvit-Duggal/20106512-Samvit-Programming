
namespace HospitalManagement.Models
{
    public abstract class Staff
    {
        public string Name { get; set; }
        public int StaffId { get; set; }
        public string Dept { get; set; }

        public Staff(string nm, int id, string dept)
        {
            Name = nm;
            StaffId = id;
            Dept = dept;
        }

        public abstract void Work();

        public virtual void Show()
        {
            Console.WriteLine("Staff ID: " + StaffId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Dept);
        }
    }
}
