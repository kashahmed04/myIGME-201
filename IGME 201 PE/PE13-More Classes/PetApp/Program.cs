using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public interface ICat //is this an interface**
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();

    } 

    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name //how to know what it and what it returns
        {
            get
            {
                return;  
            }

            set
            {

            }
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public class Pets //do we have to say any accessibility for one to many*****
    {
        List<Pet> petList = new List<Pet>(); //creates a list of the pet objects??**

        public Pet this[int nPetEI] //is petEl in shumul referring to outside or inside value**
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEI]; //gets the instance based on the key if it exists**
                }
                catch
                {
                    returnVal = null; //if the instance is not in there according to the key**
                }
        
                return (returnVal); //returns the final value 
            }
        
            set
            {
               if(nPetEI < petList.Count) //if the index is within the count
                    //then we can change the value 
                {
                    petList[nPetEI] = value;
                }
                else
                {
                    petList.Add(value); //otherwise if its outside 
                    //of bounds then it adds the value in the list instead
                }
            }

        }

        public int Count
        {
            get
            {
                return petList.Count;
            }
        }

        public void Add(Pet pet) //is this how we do it**** (would we put void if nothing is there)**
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet); //what do these do**
        }
        public void RemoveAt(PetEI int) //why am I getting an error
        {
            petList.RemoveAt(petEI); //what do these do**
        }
    }

    public class Cat: Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine("Yuck, I don't like that!");
        }
        public override void Play()
        {
            Console.WriteLine("Where's that mouse....");
        }
        public void Purr()
        {
            Console.WriteLine("Purrrrrrrrrrrrrrrrrrrr....");
        }
        public void Scratch()
        {
            Console.WriteLine("Purrrrrrrrrrrrrrrrrrrr....");
        }
        public override void GotoVet()
        {
            Console.WriteLine("Hiss!");
        }

        public Cat()
        {

        }
    }

    public class Dog: Pet, IDog
    {
        public override void Eat()
        {
            Console.WriteLine("Yummy, I will eat anything!");
        }
        public override void Play()
        {
            Console.WriteLine("Throw the ball, throw the ball!");
        }
        public void Bark()
        {
            Console.WriteLine("Woof woof!");
        }
        public void NeedWalk()
        {
            Console.WriteLine("Woof woof, I need to go out");
        }
        public override void GotoVet()
        {
            Console.WriteLine("Whimper, whimper, no vet!");
        }

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge) //do we still have to to this. for rest of things in constructor**
        {

        }
    }
    static internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
