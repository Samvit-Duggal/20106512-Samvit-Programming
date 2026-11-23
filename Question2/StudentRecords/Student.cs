
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Module> Mods { get; set; }

    public Student(int id, string nm)
    {
        Id = id;
        Name = nm;
        Mods = new List<Module>();
    }

    public void AddMod(Module m)
    {
        Mods.Add(m);
    }

    public void Show()
    {
        Console.WriteLine("\nStudent ID: " + Id);
        Console.WriteLine("Student Name: " + Name);

        for (int i = 0; i < Mods.Count; i++)
        {
            Console.WriteLine("\nModule " + (i + 1));
            Mods[i].Show();
        }
    }
}
