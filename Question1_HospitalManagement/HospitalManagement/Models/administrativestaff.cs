
namespace HospitalManagement.Models
{
    public class AdministrativeStaff : Staff
    {
        public string Role { get; set; }

        public AdministrativeStaff(string nm, int id, string dept, string role)
            : base(nm, id, dept)
        {
            Role = role;
        }

        public override void Work()
        {
            Console.WriteLine(Name + " is managing hospital records.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Role: " + Role);
            Work();
        }
    }
}
