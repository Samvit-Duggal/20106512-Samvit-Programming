
namespace HospitalManagement.Models
{
    public class Nurse : Staff
    {
        public string Shift { get; set; }

        public Nurse(string nm, int id, string dept, string shift)
            : base(nm, id, dept)
        {
            Shift = shift;
        }

        public override void Work()
        {
            Console.WriteLine(Name + " is taking care of patients.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Shift: " + Shift);
            Work();
        }
    }
}
