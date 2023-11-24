using System;

public enum Science
{
    MasterStudent,
    PhDstudent,
    PhDAssistantProfessor
}

public class Specializations
{
    public string SpecializationName { get; set; }
    public int SpecializationCode { get; set; }
    public DateTime ContractEndDate { get; set; }

    public Specializations(string name, int code, DateTime endDate)
    {
        SpecializationName = name;
        SpecializationCode = code;
        ContractEndDate = endDate;
    }

    public Specializations()
    {
        SpecializationName = "Default";
        SpecializationCode = 0;
        ContractEndDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Specialization: {SpecializationName}, Code: {SpecializationCode}, Contract End Date: {ContractEndDate}";
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class People
{
    private Person personInfo;
    private Science scienceStatus;
    private int specializationCode;
    private Specializations[] listOfSpecializations;

    public Person PersonInfo
    {
        get { return personInfo; }
        set { personInfo = value; }
    }

    public Science ScienceStatus
    {
        get { return scienceStatus; }
        set { scienceStatus = value; }
    }

    public int SpecializationCode
    {
        get { return specializationCode; }
        set { specializationCode = value; }
    }

    public Specializations[] ListOfSpecializations
    {
        get { return listOfSpecializations; }
        set { listOfSpecializations = value; }
    }

    public double TrainingLevel => 42.0; // Placeholder value for demonstration

    public bool this[Science index]
    {
        get { return scienceStatus == index; }
    }

    public People(Person person, Science science, int specCode)
    {
        personInfo = person;
        scienceStatus = science;
        specializationCode = specCode;
        listOfSpecializations = new Specializations[0];
    }

    public People()
    {
        personInfo = new Person();
        scienceStatus = Science.MasterStudent;
        specializationCode = 0;
        listOfSpecializations = new Specializations[0];
    }

    public void AddSpecializations(params Specializations[] specializations)
    {
        listOfSpecializations = specializations;
    }

    public override string ToString()
    {
        string specs = "";
        foreach (Specializations specialization in listOfSpecializations)
        {
            specs += specialization.ToString() + "\n";
        }

        return $"Person: {PersonInfo.Name}, Age: {PersonInfo.Age}, Science Status: {ScienceStatus}, " +
               $"Specialization Code: {SpecializationCode}\nSpecializations:\n{specs}";
    }

    public virtual string ToShortString()
    {
        return $"Person: {PersonInfo.Name}, Age: {PersonInfo.Age}, Science Status: {ScienceStatus}, " +
               $"Specialization Code: {SpecializationCode}, Training Level: {TrainingLevel}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person() { Name = "John Doe", Age = 30 };
        People scientist = new People(person, Science.PhDstudent, 123);

        Console.WriteLine("Short String:");
        Console.WriteLine(scientist.ToShortString());

        Console.WriteLine("\nIndexer Values:");
        Console.WriteLine($"Master Student: {scientist[Science.MasterStudent]}");
        Console.WriteLine($"PhD Student: {scientist[Science.PhDstudent]}");
        Console.WriteLine($"Assistant Professor: {scientist[Science.PhDAssistantProfessor]}");

        scientist.PersonInfo = new Person() { Name = "Alice Smith", Age = 28 };
        scientist.ScienceStatus = Science.PhDAssistantProfessor;
        scientist.SpecializationCode = 456;

        Console.WriteLine("\nString Representation after setting values:");
        Console.WriteLine(scientist.ToString());

        Specializations[] newSpecializations = {
            new Specializations("Bioinformatics", 789, DateTime.Now.AddDays(30)),
            new Specializations("Computer Science", 101, DateTime.Now.AddDays(60))
        };

        scientist.AddSpecializations(newSpecializations);

        Console.WriteLine("\nString Representation after adding specializations:");
        Console.WriteLine(scientist.ToString());

        // Performance comparison of array types
        int elementsCount = 100000;
        Specializations[] specializationArray = new Specializations[elementsCount];
        Specializations[,] specialization2DArray = new Specializations[elementsCount, 1];
        Specializations[][] specializationJaggedArray = new Specializations[elementsCount][];

        // Code for measuring time here
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < elementsCount; i++)
        {
            specializationArray[i] = new Specializations();
        }
        DateTime endTime = DateTime.Now;
        Console.WriteLine($"\nTime taken for 1D Array: {(endTime - startTime).TotalMilliseconds} milliseconds");

        startTime = DateTime.Now;
        for (int i = 0; i < elementsCount; i++)
        {
            specialization2DArray[i, 0] = new Specializations();
        }
        endTime = DateTime.Now;
        Console.WriteLine($"Time taken for 2D Array: {(endTime - startTime).TotalMilliseconds} milliseconds");

        startTime = DateTime.Now;
        for (int i = 0; i < elementsCount; i++)
        {
            specializationJaggedArray[i] = new Specializations[1];
            specializationJaggedArray[i][0] = new Specializations();
        }
        endTime = DateTime.Now;
        Console.WriteLine($"Time taken for Jagged Array: {(endTime - startTime).TotalMilliseconds} milliseconds");

        Console.ReadLine();
    }
}