using Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//sorts whatever we put in based on the key in alphabetical order (by the ASCII value) (if we use a sorted list)

//it remmebers eveyrthing that came before and if we had 5 people and wanted to do 5 factorial then we do 5 times 4 factorial so then it keeps turning to
//the next part until we get to the base case (it makes a copy of the method for each time it calls itself and they get lined up and waiting for the base case
//and when we get to facotrial(0) then the line of people pass their answer back and does the math from bottom to top when it does the math)
////recursion with factorial
////0! is 1 
//string sNumber = null; //read in string from user
//int nNumber = 0; //read in the value
//int nAnswer = 0;
//
//do
//{
//    Console.WriteLine("Enter a positive integer: "); //facortial only works with pos. valeus
//    sNumber = Console.ReadLine();
//
//} while (!int.TryParse(sNumber, out nNumber) && nNumber >= 0);
//
//nAnswer = 1;
//while (nNumber > 0) //factorial is like 4*3*2*1 (multilpes all of the numbers before the number we put in an multiply it)
//{
//    nAnswer *= nNumber; //dont need a base case for it and it wont accept 0 because then the answer will be 0 
//    --nNumber;
//}

//why cant we have protected for interface because isnt it techinically referencing things within the child and parent classes so dont they inherit from the interface 
//(the interface is outside of the class and is different and the class is inheriting the interface)
//same for the DrawMe because it was an abstact and it still means its overridden and it's only going to be used throughougt the classes only****(can classes be protected)****
//does protected not allow instances (we are still allowed to create instances of classes when its protected and the protected fields can only be accessed from the class with this.
//not the instance .)(we can access it internally but not externally)
//constrcutor is named r and is named double and it calls the base constructor
//and passes r and 0 into the base constructor** so do we over ride the constructor basically when
//we do this for child classes with their own values?
//when we do new it creates a new object and when we did new circle and we passed in raidus we passed r to the circle class and that created an object for us 
//and then when we created the circle object it puts all the members in the instance and now the when we use circle consuructor it gets passed to the parent
//because we used base and r for x and 0 for y and then after that and the constructor allows us to set the members of new object we created when it ref. child class
//when it gets created)
//we can use base to access methods from the parent (our shape method has an area method and our circle over rides it with its own area and if we want to call
//the base version still in the child (circle) we would do base.Area() and it would call the version in the parent and not the childs over ridden version of it)
//we can have an if statament if circle was a rectangle then we could do the base.Area()
//we would seal a class for secuuity features so we cant inherit or in some way hack the secuirty features (if we inherit we can impersnate the parent class)
//why are childclasses camel case in question 2 in PE11 it was**
//in this case if we had static things within a class (is it common?(no)) we would use the class name then . notation to access the method or variable or whatever
//is sttaic (static members apply to everything in the class/struct including its children and parent)(same as structures to access)
//do we have to create a constructor within the child always(we have to ref. the base constructor for the child classes like we did with each child class to make
//an instance)(first we create the values for the children then input them into the parent with base(kind of like the para. from the child being put into the parent
//as an argument when we create the child values like double r in circle for example))
//(we need a child constructor always)(we can also make our own unique child constructor by having rectangle do public Recntagnle(double w, double h) {
// this.x = w then this.y = h} or just use the base thing we did in which is more efficient whereas the thing we just did duplicates the code from the parent
//constructos (so basically making a seperate child constructor does not use base and would be sep. from parent unless we use base keyword and with this.
//it has its own constructor and when we ref. area in the instance it goes to that child consturcror with this. then uses that then does area)
//and then to just use an inherited constructor just use base(yes) (so when we use base for the circle class then it ref. the parent constructor and when we use
//this.x this.x in the circle then it inherits that parent constructor and thats how we can access those values that are intiialized)
//for private it means its only within the class not the instance (outside of it)(only this.)
//we can still use this. within the child when it references parent because we are technically in a class, but we are referencing the parent class instead
////of something within the child
//can we create an instance of a class within a class of a differnt class or the same class type we are in (yes and we can define classes within other classes)
//constructors usually have the same name as the class 
//our constructure we write ourselves overrides the default constructor otherwise if we dont have our own constructure we use the default and use . notation
//but if we have our own constructor we have to make the default constureutre as well if we want to use it otheriwse we would get an error
//in consutrctors we can do anything in them as well as initialize fields 
//since static members dont count as instances that means we have to explicitly change the values within the children (if we make static within parent 
//then we can use the parentclass.static thing but if in child its only accessible within the child and only access with childclass.static)
///(we can have private static things but its only accessible within the class and it can be shared within the class and the protected can only be seen with this. not instance)
//if we had Shapes myRect = new Rectangle(1,2) then to access rectangle stuff within it we would explicitly cast it
//bool isSquare = ((Rectangle)myRect).IsSquare exactly to access it
//would this myrect var be equal to a rectangle now instead of shape for the rest of the main block meaning it can also access reectnalge stuff since it was casted (yes)
//we need to explicitly cast when we are trying to set a less specific type equal to a more specific type 
//if shape was not abstract and wanted to set circle equal to shape we have to do that explicitly because it's more specific (we can say shape = circle variable though because
//its more generic and now we can take that shape lump of clay and make the circle out of it)(always can take a more generic class and implicitly cast it to a specific class)
//since its abstacrtct we can only create the variable then have it point to the child (set it to any of its children) (Shapes shape = new child())(in the case its abstract)
//interface is more generic and take a varible of it and if class inherits from it we can point to any object of it from the interface (like above statement) (alwyays the case)
//can use typeof() or something is inctance of something to see if its an instance of something and we can use it with other data types
//(usually used if(instance.GetType() var. typeof(class)) (used for seeing if its the exact same thing so use same exact class like circle instance and circle class)
//and the "is" is used for if they are similar like parent and child (if they are related 
//alyways put Gettype() when using typeof()
//we need to have an instance and we need to compare it with the data type always (like classes)
//put the instance in the first part then compare to a class

//if we use a shape class and define it to be a new shape like rectangle it only does the things that are common within parent and child like the methods and stuff
//but if we want stuff only within the child accessible then we would access the rectangle class specifcially and not just the parent setting equal to new rectangle 
/*
 * what data do I need to save about my shapes and how could I structure it to make it easier to get to 
 * we start by drawing yumul diagrams 
 * Have a parent class called shape and its a generic class that the children will inherit from (have as many shared prop,fields,methods and construcors in it)
 * our child classes get created from the parent class 
 * For interfaces put Inameofinterface before interface names as well (put I before interface names)(naming convention)
 *for interfaces can we use captial or lowercase i because in class we used I but in shumul it said i (have to put uppercase I (pascalecase)))
 *always have 4 boxes defining child and parent classes and we leave the boxes blank if we dont use it 
 *interfaces:
 *class can contain fields and stuff and we can create new instances and we cant create instances out of interfaces it and its just used as a handle so its a way to
 *pick up an object and use it and we can define an interface variable like the IdrawObject drawObject (just a varibale not an instance no new keyword)
 *interfaces are not a data type we can create and we can only declare variable of that type and we can basically have a student and teacher class inherit the Iperson
 *interface and we can use the interface when we create the instance of the teacher and student objects and now we can make a variable of the teacher and access
 *the name from the teacher class and have only some things that are similar (within those classes that we want to use) 
 *in the interface to access only specific values 
 *within the interface for the things we want to use like name and age instead of a class having a thousand things in it and its a way to give us a handle
 *to get certan things from larger classes but interfaces only take in properties and methods and we 
 *usually just reference things there and we dont make anything and we reference 
 *the drawme method for the interface above for the blood and other classes (so basically interfaces are pointers)(yes)
 *usually put the ";" right after the reference of the method means its a ref. (no code block it means we defined a method that does not do anything and it does not make sense)
 *(no implementation in interface)(interface defines the references)
 *classes have to have each property and each method that we use in the interface to use it (the interface) not only a couple (if its inherited everything in interface must be
 *in the class)
 *shumul diagrams:
 * first box is name of class(public means it can be accessed anywhere in our application across out application,(we would access with instance name. or this. within
 * and outside the code block for the class or where its defined for whatever is public)
 * (-symbol in front from shumul for private)
 *when it says same assembly for internal thats only within the same dll files only and we would access it the same way like this. and the instance . outside the class
 *why would we want to use internal within a dll if its only accessible in the dll and the code never even runs in there because theres no main 
 *if we want methods only within the dll itself from within the dll so that we dont expose a bunch or stuff to the outside world that nobodody needs to see 
 *it basically hides stuff that's only used in the dll and not anywhere else outside of it (we want to make it as simple as possible)(only make things
 *public that we want people to see)
 *for private its only accessible within the class codeblock but we can access it with this. within the teacher class for example if the teacher class was private 
 *for structs it was only in the sturcture not within the namespace
 *when we make the class abstract its like a sealed class and we cant create an object out of it ex. the shape shape1 = new shape() becaue its too generic
 *but it can have things inherit out of it (can still make a Shapes instance but with the a new child class() declaration instead for abstract)
 * (we can make our class abstract and it can only be used to derive new classes and cant be used to create a generic shape instance with that fomula because its empty, and only child classes
 * can be made out of abstract classes)(after we over ride (do we over ride or just get created in child for abstract since its empty in parent(it counts as an over ride))(we have 
 * to explicitly say its an abstract method otheriwse it complains theres not a code block) 
 * (we can then access it via the instance with . notation once we over ride it in the child class with the 
 * child instance only or could we also do it with the parent definer then new child class() since it was inherited)(yes)
 * (we access methods from objects instances by circle.nameofmethod(para.))(do we need to set it to variable though so it does not get lost or)(we need to have a variable to 
 * store it in unless we want to just print it out to the screen)
 * but not abstract constuctor cause its tech.default
 * constructor)(abstract is only with classes,methods, and prop. but they have to be contained within abstract classes though and not alone)(can only have abstract
 * prop. and methods but we dont do abstract prop. and abstact can only be in abstact class)
 * fields in our class is the second box(any data type that is not a property that we have to declare in the class)(we usually declare in class the instance fields thhough only
 * //unless we make something sttaic for that class)
 * in this case we got 2 doubles and an int. (fields) for the A:shape class)(+ means accessible from outide the class(public))
 * (private is the - and only accessible within the shape class basically its 
 * within the code block that defines the shape for private)(the = means protected (the fields is accessible only within the class and the children and nowhere else for protected)
 * (in this case the x and y (the doubles) are only available within shape and any derived classes of shape llike the children but not available from
 * outside the family tree of our classes)
 *the third box are any methods or properties(they have a + sign so they are public, but they could also have a - sign for private and they can also be proectetd and internal
 *(internal is also used for fields) and its not really common, only private public and protected) we have some additional attributes after the
 *area method declarstion (:v means its a virtual method which means that we are trying to define a default method for calculating the area of the shape and any children that
 *inherit from shape, they can inherit this formula (area method) by default and we use the area of a rectangle by default in the parent class and then we can over ride it within out
 *child classes for the specific shape(put virtual when we want to over ride in child only)
 *in the cylinder the last box is saying that the name of the variable then the dataa type usually
 *method : its return type but if it took in something put it in the () of the method 
 *(draw me had a :a after it which means its an abstract method we put the :a after for methods and A: before for parent or child classes for abstract)(oppisite)
 *for the second box we do "method name(para.) : return type then accessibility"(for methods only) 
 *as well as for the second entry in it, we use the name of the method then () then : 
 *the return type of the method if there is one (put nothing if no return type and that means void) (do all methods need accessibility like virtual, and abstract,etc.)
 *default for methods is internal for methods and its restricted as possible (most restricted is private or internal for most things)
 *we should make it as explicit as possible and include all of theaccessiblity even though its public
 *:v for virtual(we always assume it must be an over ridden method for the children if we use :v)(yes), then :o for child overrding
 *draw me is an abstract method and it would be different for every child shape and abstract means it cant have any code block with it and no implementation code within the parent
 *and the child must implemement its own method for drawing it
 *we want to have a constrcutore that accesspts our 2 dimensions (x and y)(if we want to use default and our own default constructor, 
 *then we include that in the diagram otherwise we
 *dont include it in our diagram if we dont use the empty constructor)(yes) (if we have only the default do we still include it in shumul)(if we only use default we can leave
 *out the constructor for it if its only default) 
 *will return an error if we over ride our custom constructors (create custom constructor only once and not do it again with the same exact signautre)(yes)
 *if we create a custom constructor and we try to use a defualt constructor without it being defined then we get an error 
 *
 *shumul:
 *to derive we create more boxes and create a box for the circle class which has 4 parts (the second part is empty for all children because we are not making any new fields
 *for the child specifically and the parent would not see anything new or over ridden within the child class)(yes)
 *theres no private with classes in shumul so is it true in general(yes)
 *(we can combine public with abstract ssealed static or nothing or we could do internal with any of those 3 combined or nothing)
 *the third box will have two methods that will overridden (virtual or abstract to be over ridden and child must implement with a code block)
 *in child class and we need to overide the area method from our parent so we use 
 *:o to say we are overriding default method
 *(do we always have to have a :a (abstract blank method) or a :v (virtual = default method, methods only or) associated with a :o
 *(over ridiing a defult method in the child, only)(we can associate :o with both)
 *and the drawing method was absract in parent method so we also do :o when we implmement an abstract method
 *for our constructor for a circle we accept radius for our parameter and it calls parent constructor passing the x dimension as the radius and y as 0********
 *in order to call anything specifically in parent we use the "base" keyword (in JS it was super) base refers to the parent class and lets us access
 *the specific implememntation in the parent and not the overidden one within the child
 *in the parent class(if we want to call default area nethod from parent class we do base.area) or would it be parent instance = new childinstaance() then
 *after we can acccess it there with instances too if it was a parent instance or child (either or)
 *
 *
 *for rectangle its missing the area method because it was inherited from parent shape class so we dont add that into the rectagnle because we can just call the default from
 *parent and we also add a boolean which is a property to see if its a square or not to implement that parent method((read only) :r)
 *
 *we could use the property for the rectangle by returning true or false if it was x=y and when we create an instance, we could do if(reectangle.IsSquare){console.write
 *line("thisrectangle is a square))} basically it checks and we can do something based on that
 *
 *classes constructors structs methods properties data types (any data types) enum and delegates are pascale case
 * 
 *
 *shumul allows us to easily go from diagram to code
 *child classes always point to their parent when making shumul digrams (bottom to top) (always)
 *and the lines styles are specific to the kind of class that the parent is (if we are inheriting from a normal (public) parent class thats not abstract then its a solid line
 *to point frm child to parent, but if we inherit from an absratct class then we use dotted line)(in our diagram it was a dotted line to go from parent to child)if our
 *parent class was not abstract it would be a solid line**
 *
 *
 *
 *1-1 class relationships and 1-to-many on shumul
 *1-1 means 2 classes that are related to each other and it means there can be one instance of wife per husbane
 *we can also have 1-many and we can have customers class which contains customers and we can have one of those then
 *a customer class then have an list of customers in customers class and have one to many relatinoship 
 *the list of the customers is each customer from our customer class (customers has a bunch of customer class objects)
 *
 */


namespace Shape //namespace could be anything we want and not just the same name as class or struct 
{
    //we just go from our syntax in diagram (code block for our class that defines the scope of our class
    //variables that are constants we use all uppercase because it's just a constant) 

    //classes,structs,interfaces,enums,delegates dont take in para. and dont have a return type and methods can have a return type and
    //para.and properties (similar to a method)

    public interface IDrawOjbect //interfaces,classes and structs cant have a return type 
    {
        void DrawMe(); //the shape class inherits from this method interface (when parent inherits the children get it as well and we only have to define it 
                        //in the parent and not the child for all the things in the interface if the parent only inherits it and it gets passed to children)
    }

    public class Blood : IDrawOjbect //inherits interface and we do the same with shape because it inherits from the interface as well and we can have
                                     //any amount of interface inheritence but classes its only 1 parent per child
    {
        public virtual void DrawMe() //empty code block for virtual means it does not do anything and its the default implementation(if it was empty)(we could add code to it)
                                     //if it was abstract we would not do that because we could not add code to it because it has ";" after it or if it was a ref. for
                                     //an interfcae
        {
            
        } 
    }

    public abstract class Shapes : IDrawOjbect 
    {
        public const double PI = Math.PI; //create the pi variable
        protected double x;           //protected means we only acessible in the parent and child classes but not outside those(cant be used in main for example)
                                    
        protected double y;

        //to access constants they are just like a sttaic variable we have to access it via the class name not the instance name

        private int myInt; //myIny only available in this code block(and it does not get inherited)

        public virtual double Area()
        {
            return this.x * this. y; //default area calculation (used for our x and y within our class members when we use this.
                                     //is it only within the parent class or is it also within the children
                                     //and then in the main when we create and instance thats when we use the object instance (variable) we created then
                                     //the . notiation)
        }

        //does not have return type indicated so use void and no code block since its abstract(any child class must implememnt the method otherwise its a compile
        //time error because its an instance type without a code block like fields
        public abstract void DrawMe(); //if a method and is abstract, then we can just do ; (no code)

        public Shapes()
        {

        }

        //we can only have public constructors

        public Shapes(double x, double y)
        {
            this.x = x; //we pass in variables with this. always within constructors in the parent method and in general in the parent
                        //or child as well and with the instance we would just use the instance name instead of this.
            this.y = y; //the this keyword refers to our field member x and set it equal to the x variable that has been passed from our
                        //child method into our parent constructor

        }
    }

    //always update our digram if we update our code 

    //use : after class name then the parent class to show its inheritence
    //in c# we are limited to inheriting from 1 parent class
    public class Circle : Shapes, IDrawOjbect
    {  //use , if a child inherits from a class and interface(only 1 class but infinite amount of interfaces)

        public int myInt;
        
           
        
        //over ride the area calculation (use override keyword to override parent method)
        public override double Area()
        {
            return Shapes.PI * this.x * this.x; //we use this. even though we are in child does it mean its using the x and y from the parent(yes)
        } //use the class name.PI because it's like a static variable so we use the class name(not this. not instances allowed for both cases)

        public override void DrawMe() //by default they throw an exception if it was abstacr and we create it in child until we put code into it wihtin child the no error
        {
            //draw a circle for the specific calculation
        }

        public Circle(double r) : base(r, 0) //when we say double r how then do the base why do we have to say
            //double r specifically is it because we are creating the type for the constrcutor for circle itself so we can pass in doubles with the instance
        {

        }
    }


        public class Sphere : Shapes 
        {
            
            public override double Area()
            {
                return 4 * PI * this.x * this.x;
            }

            public override void DrawMe() 
            {
                //draw a sphere for the specific calculation
            }

            public Sphere(double r) : base(r, 0) 
            {

            }
        }

        internal class Cylinder: Shapes
        {
            public override double Area()
            {
                return 2 * PI * this.x * this.x + 2 * PI * this.x * this.y;
            }

            public override void DrawMe()
            {
                //draw a Cylinder for the specific calculation (drawing stuff wont be on exmas)(yes)
            }

            public Cylinder(double r, double h) : base(r, h)
            {

            }
        }

        internal class Rectangle : Shapes
        {
            public bool IsSqaure
            {
                get
                {
                    if( x == y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public override void DrawMe()
            {
                //draw a Rectagnle for the specific calculation 
            }

            public Rectangle(double w, double h) : base(w, h) //the rectangle class needs this in the beginning before the colon
                                                              //so we can tell it to have a width and height and set it to**
            //this.x = w and this.y = h to the parent class instead of using base but we should use base so it can set the x and y as the hieight we pass in
            //same thing as just removing base and doing this.x = w and this.y = h (we dont use ";" for the ref. to the base here it gives us an error)
            {
                    //anything like fields or methods or prop. we make in constructor we usually inisitzlie here with this. (sets whatever members that are within
                    //the local class)(and we can call methods in other parts of code not just parent same for property)(but just calling)(we can also make new instances 
                    //and work with that)(we can make methods but its bad practice)
            }
        }


    }



    //classes can also be sealed which means it cant be inherited and we could hve made our child classes sealed so nothing inherits from it
    //we use static in unit 1 otherwise we had to make Program.OurMethod (create instance of program to access our things in it)(we use it where main is)
    //(dont use static when we create instances though)(static means it never changes)

    //shumul diagram gives us the relationships between classes
    static internal class Program
    {
        static void Main(string[] args)
        {
            MyMethod();
        // if MyMethod() is not static, then we need an instance of Program to call it
        //Program p = new Program()
        //p.MyMethod();

            Circle circle = new Circle(5.5); //cant call default constructor because we overrode it with our own constructor when we inherited otherwise if it was not there
                                             //then we could use defualt or we could create a default and use it here
                                             //if its empty then use instance. notation and do it manually if its default
            Cylinder cylinder = new Cylinder(3, 6);
            Rectangle rectangle = new Rectangle(1, 2);
            Blood blood = new Blood(); //Shapes shape1 = blood; we cant do this implicitly or even when we cast it because no common inheritence the interface does not count
        //because its a refernece not a class that can inherit or have that relationship or have others inherit from it (they are not related because they are not related by class)

            Circle circle2;
            circle2 = circle; //we have one circle object but now we have two circles pointing at the circle object and circle 2 is lost if something was equal to it
            circle2.myInt = 1; //myInt does noting so why did we do this and its private so how could we use it if its only defined in parent
        //for myInt in the child its somethnig new the parent cant access right because its private in the parent and the child cant see if but if the child
        //has the same thing as a public accessibility the parent would not see it right(yes)

         
            //can parent see whats in the child(no)
            //Shapes shape = new Shapes(); //cant make a vaiable of shape because its an abstrac method(too generic)
           

            Shapes shape; 

            // cannot instatiate (create an instance) of an abstract class
            // shape = new Shapes();

            // we can implicitly set a parent data type to a child data type(yes)
            shape = rectangle; //the parent is now equal to the recetangle child class so now it calls the appropriate method and if it was inherited then
                               //it calls the overrideen method if it was over ridden, if not, then it calls the parent defult in this case it calls the defauly
                               ////since nothing was overridden in rectangle would it just be shape.Area(w,h) and in this case it would call the parent
                               ///doesnt shapes pointer change to rectangle now instead of the parent and the parent shape is lost now
            
            // and it calls the method as defined in the child class
            // this will draw a rectangle
            shape.DrawMe(); //this calls the DrawMe() method in rectangle because its the inherited class we set shape to 

            shape.Area();//we can use the parent variable to call specific things from the child thats common in child and parent and calls correct overrideen method
                         //involed in the shape(polymorphism)(calls the correct method based on the relationships)**************
                         //shape.IsSquare; //we cant call this because its not accessible within the parent and child and only within child
                         //class and if its only in child class parent cant see it(yes)
                         //but didnt we change the pointer to point to rectangle in this case above with shape = rectange so why could we not access shape.IsSquare***************


            // we can also access objects via interfaces that the object is derived from
            IDrawOjbect drawOjbect; // create a drawobject variable and does not point to anything 

            //blood and shape dont have a common parent, but they both share the interface(its not a class) and the interface is not like a class and its more specific
            //the shape and the blood are not related so we cant set blood = shape because theres not association within classes for them and the interface does not count
            //because its not a class

            // blood inherits the IDrawObject interface
            drawOjbect = blood; //ref. variable and now we point it to blood
            
            //this will draw blood
            drawOjbect.DrawMe(); 
            //the interface contains the drawme method and we can use it do call the drawme method and same thing for the drawobject point to the circle
            //and change direction of mirror to point to something else and we cnan turn mirror around to point to the drawme method for circle instead of blood now

        //since parent points to it the children would also get the interface??**** (I thought there was no inheritence with interfaces)****

            //circle inherits from the IDrawObject interface(do we have to do this for interfaces
            //because shoouldnt everything by default inherit it since its on the top of the application or*************
            drawObject = circle; 
            drawOjbect.DrawMe();

            //call the DrawObject with each object instance
            DrawObject(circle); //the DrawObject only takes in things that have inherited the IDrawObject so now it can call the proper drawme for the inherited things
        //that inherited drawme
            DrawObject(cylinder); //anything defined below an interface will be inherited autpmatically if its the parent and the child gets it autpmatically
                                    //unless only a child gets it (if parent only everything in the interface has to be in parent and children inherit it otherwise
                                    //if its only in the child the child will have to have everything from the interface)******
            DrawObject(blood);

        //we can set a more generic data type equal to a child data type like parent = child
        //the parent types are more general and the child types are more specific and the lump of clay is**
        //the parent and we can make the more specfic shape which is the child
        //but not the other way around(unless we destroy parent)************
        //when would we want to destroy parent****************
        //we cant set a child class equal to parent class because its more specific*************

          
            //when we have a structure the sturcutre variable instance name is the actual object(a copy)
            //but with a ref. variable instance name, it points to the object in memeory and not the object itself
            //(not a copy)



        //NEW NOTES
        //the most useful things with classes is that because of the family tree of how the classes are related we can access any child class by any parent datatype
        //ex. access circle by using shape to access circle and circle can also be used with the interface because it was inherited by the parent but if it was
        //only the child, then we could only use it with the child instance(yes)
        //interface gives us easy handles to work on(ex. phone with keyboard and we could use it across all of the apps and the keyboard is the interface
        //wheere each child would be an app where we could use the keyboard sepcifically)(the keyboard interface gives us input to all apps on our phone
        //and eveyryhting on our phone inherits from keyboard interface)(only cares about allowing users to enter data and type into an app nothing else)
        //do properties usually take a return type in shumul(no)

        //any parent data type can be used to access any child datatype and we could pass in any of our drawObject because Idrawobject was iherited by the children
        //because the parent inherited it so if the parent inherits it the children automatically get it otherwise if its only some children we would have to
        //explcitly cast to the parent

        
        }



        // a generic method to draw an object via the IDrawObject interface
        // drawObject can point to the object passed in if that object inherits the IDrawObject interface
        // otherwise you will get a runtime error
        static void DrawObject(IDrawOjbect drawOjbect)
        {
            drawOjbect.DrawMe();//method that accepts drawobject and we can call it based on the circle or rectangle or shape and draws the different objects with it
        } //pass any oject that inherits from this interface


        static void PrintAreaOfShape(Shapes shape)
        {
            if(shape.GetType() == typeof(Circle))//we could figure out which data type the object is and its the gettype is = to type of Circle(only put in the classes not
                                                 //instances for typeof)(its like instanceof() in js)
            {
            Console.WriteLine("circle!"); //we could also do if(shape is Circle)
            }
            if(shape.GetType() == typeof(Rectangle)) //all children inherit everything from parent and parents dont inherit from the children 
            //if we want to access child specific, then we have to have a reference pointing to the child data type
            {
            Rectangle r; //creating a varibale not an instance
            r = (Rectangle)shape;  //we explicitly cast because c# does not know how to make shape look like rectangle
                                   //but it does know how to make rectangle look like shape(we can
                                   //do parent datatype to child but not implicitly do child to parent we have to do it explicitly)
            if (r.IsSqaure)
            {
                Console.WriteLine("Sqaure!");
            } //we could also do this way to do PE10 for epxlicitly casting the interfcae
            }

            if(shape is IDrawOjbect)
            {
            IDrawOjbect drawOjbect = (IDrawOjbect)shape; //explicitly casting the shape which is a rectangle now to an idrawibject interface(why because its inherited already)
            }

        Console.WriteLine("The area is: " + shape.Area());//since children classes overrode area methods from parents and if we do shape.area() it will
        //call the correct child method and it knows what kind of object it really is even though its passed in as a shape because the children inherit from that class
        //so when we do parent = new child() then it calls the correct inherited method also works if we explicitly casted the child to the parent)

        }
        static void MyMethod()
        {
        
        }

        //abstraction is using encapsulation and abstracts the functionality for us so we dont have to know the details of how it works**(phone ex.)*****************
        
    }




//we want to create a library when we work with classes and when we develop a project (team project) and there is one executable and we have all of these dll files
//and its library files (dynamic linked library) and lets us extend the application with additional functionality with forms and stuff like that
//and its used to complete the application in certain parts (so many people can work on different parts)
//the module we work on for project should be our own dll file

//game and song inherit from the interfaces and they use common data types and they inherit it (polymorphism(look at a circle by usuing shape variable being able to generalize
//the objects based on their inhertience)while interhitence is the children inherit from parent and can over ride 
//abstract song class we have fields like year and lyrics and it has prop./methods and theres the property name and methods 
//and each child class had the different devices the song can be played on and it inherits the play method and how to play it based on the deivce as well as its own
//fields to have the name of the tape and the side and the record name and different fields for based on how the device works to play the song
//to copy a song we have a virtual method in the parent and we can override it within the child for MP3 

//we want to have a dll that has all of our classes implemented and then our song application connects the dll(use class library .NET framework)

