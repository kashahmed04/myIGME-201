using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//in shumul only the lines with arrows are the inheritences right??(1)*****
namespace PetApp
{
    public interface ICat //interface
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

    // Class: Pet
    // Author: Kashaf Ahmed
    // Purpose: Abstract pet class that has a name and age field as well as a name property
    // it also has abstract methods that will be overridden from the child Cat and Dog classes.
    //There's also a default constructor and a constructor that holds the name and age fields
    // Restrictions: None
    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name //this property gets the name if we want to access it via the "object instance." or set a value but have an = sign at the end of the reference
                            //right??(2)******
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value; //value basically is used based on whatever the user puts in or we put in ourselves??(3)*********
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

    // Class: Pets
    // Author: Kashaf Ahmed
    // Purpose: Creates a list of pet objects and has an indexer property with the key
    //being the indexer and the value being the pet instance wheather that be a dog or a cat
    //it also hasthe add and remove count as well as the count of whats in the list for the petList
    // Restrictions: None
    public class Pets //so basically for 1-1 or 1-many we dont need inheritence with it and it jsut defines how classes are related??(4)*****
    {
        public List<Pet> petList = new List<Pet>(); //can we also do sorted list here and just put pet or does the sorted list have to take a prop. and value
                                                       //whereas just a list does not??(5)****
                                                       //is there a way to do the same thing with a sortedlist??(6)*****
                                                       //when is the case where we would use a sortedlist or a list for 1-many relationships and in general??(7)*****

        public Pet this[int nPetEI] 
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
                    returnVal = null; //if the key does not exist, then it returns null
                }

                return (returnVal); //returns the final value 
            }

            set
            {
                if (nPetEI < petList.Count) //if the index is within the count
                                            //then we can change the value 
                {
                    petList[nPetEI] = value;
                }
                else
                {
                    petList.Add(value); //otherwise if its outside 
                    //of bounds then it adds the instance instead
                    //over here could we have just taken away the if statement and put this there why do we have to have this if statement if we??(8)****
                    //are adding regardless of if its out of bounds****
                }
            }

        }


        public int Count
        {
            get
            {
                return petList.Count; //count is not 0 based right??(9)*****
            }
        }

        public void Add(Pet pet) //we put void here because there is no : return type after the method name right??**(10)
        {
            if(pet!= null){
                petList.Add(pet);
            }

        }

        public void Remove(Pet pet)
        {
            if(pet != null)
            {
                petList.Remove(pet);
            }
            
        }
        public void RemoveAt(int petEI)
        {
            petList.RemoveAt(petEI); //why do we have another remove here if we have it above??****(11)
        }
    }


    // Class: Cat
    // Author: Kashaf Ahmed
    // Purpose: Inherits the Pet parent class and the ICat interface and prints out the console certain behaviors based on which
    //method is called from the random in the main. Also has a default constructor.
    // Restrictions: None
    public class Cat: Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine(Name + "Yuck, I don't like that!");
        }
        public override void Play()
        {
            Console.WriteLine(Name + "Where's that mouse....");
        }
        public void Purr()
        {
            Console.WriteLine(Name + "Purrrrrrrrrrrrrrrrrrrr....");
        }
        public void Scratch()
        {
            Console.WriteLine(Name + "Purrrrrrrrrrrrrrrrrrrr....");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + "Hiss!");
        }

        public Cat()
        {

        }
    }


    // Class: Dog
    // Author: Kashaf Ahmed
    // Purpose: Inherits the Pet parent class and the IDog interface and prints out the console certain behaviors based on which
    //method is called from the random in the main. It also has a constructor for the name and the age and we call base to reference the
    //parent for those values, but for the license its only in the child so we have to make a field out of it then we can initialize
    // Restrictions: None
    public class Dog: Pet, IDog
    {
        public string szLicense;
        public override void Eat()
        {
            Console.WriteLine(Name + "Yummy, I will eat anything!");
        }
        public override void Play()
        {
            Console.WriteLine(Name + "Throw the ball, throw the ball!");
        }
        public void Bark()
        {
            Console.WriteLine(Name + "Woof woof!");
        }
        public void NeedWalk()
        {
            Console.WriteLine(Name + "Woof woof, I need to go out");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + "Whimper, whimper, no vet!");
        }

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.szLicense = szLicense; //if we have something thats not defined within the parent and only the child in a constructor would we always have
            //to create a field for it then we could use this.??****(12)
        }
    }


    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Sets calss instances and interfaces intially to null then it creates a random variable and we make a 
    //for loop going from 0-49 (50 values) and it creates cat and dog instances based on if the random number was 1 or something else.
    //We also add each instance to the list when we are finished with that instance. Finally we reference the petList and get a random cat or dog object 
    //then call their methods based on a random number and we di a siwtch statement for that.
    // Restrictions: None
    static internal class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null; //whats the difference between this and having an instance with new Classname() (why did we do this??)(12)****
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets(); //Over here since we have an instance, that instance will hold the values from the pets that we are about to have via the loop right??****(13)
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int randomNum = rand.Next(1, 11);
                if (randomNum == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                        Console.WriteLine("Dog's name => ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Age => ");
                        string age = Console.ReadLine();
                        int? ageNum = null;
                        Console.WriteLine("License => ");
                        string license = Console.ReadLine();
                        int? licenseNum = null;
                        while (ageNum == null)
                        {
                            try
                            {
                                ageNum = int.Parse(age);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Age => ");
                                age = Console.ReadLine();
                            }
                        }
                        while (licenseNum == null)
                        {
                            try
                            {
                                licenseNum = int.Parse(license);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Age => ");
                                license = Console.ReadLine();
                            }
                        }
                        dog = new Dog(licenseNum.ToString(), name, (int)ageNum);
                        pets.Add(dog);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        Console.WriteLine("Cat's name => ");
                        string catName = Console.ReadLine();
                        Console.WriteLine("Age => ");
                        string catAge = Console.ReadLine();
                        int? ageNumCat = null;
                        while (ageNumCat == null)
                        {
                            try
                            {
                                ageNumCat = int.Parse(catAge);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Age => ");
                                catAge = Console.ReadLine();
                            }
                        }
                        cat = new Cat(); //when we have default constructor and want to access from parent can just do default constructor
                        //then add from . notation because its inheriting from parent so thats how we use it (inherits all except private members)
                        cat.Name = catName; 
                        cat.age = (int)ageNumCat;
                        pets.Add(cat);


                    }
                }
                else
                {
                    thisPet = pets[rand.Next(0, pets.petList.Count)];

                    if(thisPet == null)
                    {
                        continue; //we are allowed to do this because its in the loop even though its in a seperate block
                    }

                    //do we have to set thisPet equal****
                    //to pets because it we are getting a pet object and it needs to be stored in a pet object so when*****
                    //its indexed via the pets list with its index as the key (the int in the indexer property), it can work??****(14)

                    if (thisPet.GetType() == typeof(Dog)) //why are my if statements not working isnt this how we check or should we use "is" because its not
                                                          //the exact type or can we use this way if there is inheritence??****(15)
                    {
                        iDog = (Dog)thisPet;
                        int dogRand = rand.Next(0, 5);
                        switch(dogRand){
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Bark();
                                break;
                            case 2:
                                iDog.Play();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                iDog.GotoVet();
                                break;

                        }
                    }
                    if (thisPet.GetType() == typeof(Cat)) //why is this wrong******(16)
                    {
                        iCat = (Cat)thisPet;
                        int catRand = rand.Next(0, 4); //are these switch statements ok or was there another way to do it??****(17)
                        switch (catRand)
                        {
                            case 0:
                                iCat.Eat(); //my list only had like 5-6 values and the example had more than that so I was wodnering what was wrong1(8)*****
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                iCat.Scratch();
                                break;
                            case 3:
                                iCat.Purr();
                                break;

                        }
                    }

                }

            }

        }
    }
}
