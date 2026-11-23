
public class Module
{
    public string Name { get; set; }
    public int? Marks { get; set; }
    public string Grade { get; set; }

    public Module(string nm, int? marks, string grade)
    {
        Name = nm;
        Marks = marks;
        Grade = grade;
    }

    public void Show()
    {
        Console.WriteLine("Module: " + Name);

        if (Marks == null)
        {
            Console.WriteLine("Marks: Not Available");
            Console.WriteLine("Grade: Not Available");
        }
        else
        {
            Console.WriteLine("Marks: " + Marks);
            Console.WriteLine("Grade: " + Grade);
        }
    }
}
