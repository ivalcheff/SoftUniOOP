namespace _00.Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Lawyer lawyer = new Lawyer();

            student.Address = "10429 Spectrum";

            student.Father = new Person { Firstname = "Svetlozar", Lastname = "Georgiev", Address = "Brestnik 145"};
            student.Father.Father = new Person { Firstname = "Ivan", Lastname = "Georgiev", Address = "Antim I 30" };

            lawyer.Company = "Ernst and Young";
            student.Firstname = "Iva";

            Console.WriteLine(student.SayHello()); 

        }
    }
}
