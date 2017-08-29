using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Patient
{
    public Patient(string departament, string doctor, string name, int room)
    {
        this.Departament = departament;
        this.Doctor = doctor;
        this.Name = name;
        this.Room = room;
    }

    public string Departament{ get; }
    public string Doctor { get; }
    public string Name { get; }
    public int Room { get; }
    
}

public class Program
{
    public static void Main()
    {
        List<Patient> patients = new List<Patient>();
        Dictionary<string, int> departaments = new Dictionary<string, int>();

        string input;
        while ((input = Console.ReadLine())!="Output")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            
                string departament = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patientName = tokens[3];

                if (!departaments.ContainsKey(departament)) { departaments.Add(departament, 1); }
                else
                {
                    if (departaments[departament] < 60)
                    { departaments[departament] += 1; }
                    else { continue; }
                }


                var currentRoom = (int)(Math.Ceiling(departaments[departament] / 3.0));

                Patient patient = new Patient(departament, doctor, patientName, currentRoom);
                patients.Add(patient);
        }


        while ((input = Console.ReadLine())!= "End")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 1)
            {
                var patientByDepartment = patients.GroupBy(x => new { x.Departament, x.Name }).Where(g => g.Key.Departament.Equals(tokens[0]));
                    //.Select(g => new { Dep = g.Key.Departament, Name = g.Key.Name});

                foreach (var item in patientByDepartment)
                {
                    Console.WriteLine($"{item.Key.Name}");
                }
            }
            else
            {
                int room;
                if (int.TryParse(tokens[1], out room))
                {
                    var patientByDepartmentAndRoom = patients.GroupBy(x => new { x.Departament, x.Name, x.Room }).Where(g => g.Key.Departament.Equals(tokens[0]) && g.Key.Room.Equals(int.Parse(tokens[1]))).Select(g => new { Dep = g.Key.Departament, Name = g.Key.Name, Room = g.Key.Room }).OrderBy(g => g.Name);

                    foreach (var person in patientByDepartmentAndRoom)
                    {
                        Console.WriteLine($"{person.Name}");
                    }
                }
                else // its doctor
                {
                    string doctor = tokens[0] + " " + tokens[1];
                    var patientsByDoctor = patients.GroupBy(x => new
                    {x.Doctor, x.Name}).Where(g => g.Key.Doctor.Equals(doctor)).Select(g => new { Doctor = g.Key.Doctor,Patients = g.Key.Name }).OrderBy( g => g.Patients);

                    foreach (var person in patientsByDoctor)
                    {
                        Console.WriteLine($"{person.Patients}");
                    }
                }
            }
        }


    }
}

