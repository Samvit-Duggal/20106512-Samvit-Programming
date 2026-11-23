
namespace HospitalManagement.Models
{
    public class Doctor : Staff
    {
        public string Spec { get; set; }

        public Doctor(string nm, int id, string dept, string spec)
            : base(nm, id, dept)
        {
            Spec = spec;
        }

        public override void Work()
        {
            Console.WriteLine(Name + " is treating patients.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Specialization: " + Spec);
            Work();
        }
    }
}
