using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {

        //fields
        private string _name;
        private int _age;
        private string _gender;

        //constructor
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        //properties
        public string Name 
        { 
            get => _name;
            set 
            {
                if (string.IsNullOrEmpty(value)) 
                { 
                    throw new ArgumentNullException("Invalid input!");
                }
                _name = value;
            }              
        }
        public int Age 
        {  
            get { return _age;} 
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                _age = value;
            }
        }
        public string Gender 
        { 
            get { return _gender;}
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                _gender = value;
            }
        }


        //methods
        public abstract string ProduceSound();
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());
            
            return sb.ToString().TrimEnd();
        }

    }
}
