using Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//why cant we have protected for interface because isnt it techinically referencing things within the child and parent classes so dont they inherit from the interface**
//same for the DrawMe because it was an abstact and it still means its overridden and it's only going to be used throughougt the classes only (does protected not allow instances)**
//constrcutor is named r and is named double and it calls the base constructor
//and passes r and 0 into the base constructor** so do we over ride the constructor basically when
//we do this for child classes with their own values? (is it being put in the parent constructor in the parent when we call base or only the method in there)****
//we would seal a class for secuuity features so we cant inherit or in some way hack the secuirty features (if we inherit we can impersnate the parent class)
//why are childclasses camel case in question 2 in PE11 it was**
//in this case if we had static things within a class (is it common?(no)) we would use the class name then . notation to access the method or variable or whatever
//is sttaic (static members apply to everything in the class/struct including its children and parent)(same as structures to access)
//do we have to create a constructor within the child always(we have to ref. the base constructor for the child classes like we did with each child class to make
//an instance)(first we create the values for the children then input them into the parent with base(kind of like the para. from the child being put into the parent****
//as an argument*****))
//(we need a child constructor always)(we can also make our own unique child constructor by having rectangle do public Recntagnle(double w, double h) {
// this.x = w then this.y = h} or just use the base thing we did in which is more efficient whereas the thing we just did duplicates the code from the parent
//constructos (so basically making a seperate child constructor does not use base but still ref. the parent class with this. how would it be seperate****
//then because it still ref. the parent)******* and then to just use an inherited constructor just use base******
//we can still use this. within the child when it references parent because we are technically in a class, but we are referencing the parent class instead****
////of something within the child****
//can we create an instance of a class within a class of a differnt class or the same class type we are in******
//initizlize things from the class and have the same name as the class for constructor
//othwise we would have to do the class var. =  new class() then use . notiation for the constructor(or not be able to access constructor at all or what type of error)****
//our constructure we write ourselves overrides the default constructor otherwise if we dont have our own constructure we use the default and use . notation
//but if we have our own constructor we have to make the default constureutre as well if we want to use it otheriwse we would get an error
//in consutrctors we can do anything in them as well as initialize fields 
//since static members dont count as instances that means we have to explicitly change the values within the children (if we make static within parent 
//then we can use the parentclass.static thing but if in child its only accessible within the child and only access with childclass.static)(anything thats defined within the
//child that is newly defined its only within the child)(would the static also be inherited because we cant use it with instances but it still could be inherited since****
////we can still reference it in child but with parent classname)*****(what is default accesiblity with static we cant change it to make it public or anythign right)*****
//if we had Shapes myRect = new Rectangle(1,2) then to access rectangle stuff within it we would explicitly cast it**** 
//bool isSquare = ((Rectangle)myRect).IsSquare exactly to access it**** 
//would this myrect var be equal to a rectangle now instead of shape for the rest of the main block meaning it can also access reectnalge stuff since it was casted*****
//can use typeof() or something is inctance of something to see if its an instance of something and we can use it with other data types
//(usually used if(instance var. typeof(class)) then do something or if instance var instance of class do this***** (can we use classes only for these or is it just to comapre****
//instances and classes***** (usually use GetType() only with instances right for the typeof() only??)****

//if we use a shape class and define it to be a new shape like rectangle it only does the things that are common within parent and child like the methods and stuff
//but if we want stuff only within the child accessible then we would access the rectangle class specifcially and not just the parent setting equal to new rectangle 
/*
 * what data do I need to save about my shapes and how could I structure it to make it easier to get to 
 * we start by drawing yumul diagrams 
 * Have a parent class called shape and its a generic class that the children will inherit from (have as many shared prop,fields,methods and construcors in it)
 * our child classes get created from the parent class 
 * For interfaces put Inameofinterface before interface names as well (put I before interface names)(naming convention)
 *for interfaces can we use captial or lowercase i because in class we used I but in shumul it said i******
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
 *usually just reference things there and we dont make anything and we reference (when we reference we dont put any code block just the signature and the ";" right)****
 *the drawme method for the interface above for the blood and other classes (so basically interfaces are pointers)*******
 *classes have to have each property and each method that we use in the interface to use it (the interface) not only a couple****
 *shumul diagrams:
 * first box is name of class(public means it can be accessed anywhere in our application across out application,(we would access with instance name. or this. within
 * and outside the code block for the class or where its defined for whatever is public)
 * (-symbol in front from shumul for private)
 *when it says same assembly for internal thats only within the same dll files only and we would access it the same way like this. and the instance . outside the class
 *why would we want to use internal within a dll if its only accessible in the dll and the code never even runs in there because theres no main*****
 *for private its only accessible within the class codeblock but we can access it with this. within the teacher class for example if the teacher class was private 
 *for structs it was only in the sturcture not within the namespace
 *when we make something protected is it also availabele with the instances of the class or only the classes themselves****
 *when we make the class abstract its like a sealed class and we cant create an object out of it ex. the shape shape1 = new shape() becaue its too generic
 *but it can have things inherit out of it (can still make a Shapes instance but with the a new child class() declaration instead for abstract)****
 * (we can make our class abstract and it can only be used to derive new classes and cant be used to create a generic shape instance with that fomula because its empty, and only child classes
 * can be made out of abstract classes)(after we over ride (do we over ride or just get created in child for abstract since its empty in parent(it counts as an over ride))(we have 
 * to explicitly say its an abstract method otheriwse it complains theres not a code block) 
 * (can we not make empty code block out of abstrcact instead of doing the signature then ";" after)****
 * (we can then access it via the instance with . notation once we over ride it in the child class with the 
 * child instance only or could we also do it with the parent definer then new child class() since it was inherited)*****
 * (we access methods from objects instances by circle.nameofmethod(para.))(do we need to set it to variable though so it does not get lost or)****
 * (empty methods and placeholders for the child class can we also have abstract and we can have a private constrcutor****
 * (why would we want that same for private methods or fields****)
 * but not abstract constuctor cause its tech.default
 * constructor)(abstract is only with classes,methods, and prop. but they have to be contained within abstract classes though nd not alone)****
 * fields in our class is the second box(any data type that is not a property that we have to declare in the class)(we usually declare in class the instance fields thhough only
 * //unless we make something sttaic for that class)
 * in this case we got 2 doubles and an int. (fields) for the A:shape class)(+ means accessible from outide the class(public))
 * (private is the - and only accessible within the shape class basically its 
 * within the code block that defines the shape for private)(the = means protected (the fields is accessible only within the class and the children and nowhere else for protected)
 * (in this case the x and y (the doubles) are only available within shape and any derived classes of shape llike the children but not available from
 * outside the family tree of our classes)
 *will there ever be a case where we have to have 2 parent classes and a bunch of children in the same application or would it be 2 different appliactions**
 *the third box are any methods or properties(they have a + sign so they are public, but they could also have a - sign for private and they can also be proectetd and internal
 *(internal is also used for fields) and its not really common, only private public and protected) we have some additional attributes after the
 *area method declarstion (:v means its a virtual method which means that we are trying to define a default method for calculating the area of the shape and any children that
 *inherit from shape, they can inherit this formula (area method) by default and we use the area of a rectangle by default in the parent class and then we can over ride it within out
 *child classes for the specific shape(put virtual when we want to over ride in child only)
 *in the cylinder the last box is saying that the name of the variable then the dataa type usually
 *(all data types in shumul or just the case of the consttructor)***** 
 *method : its return type but if it took in something put it in the () of the method 
 *(draw me had a :a after it which means its an abstract method we put the :a after for methods and A: before for parent or child classes for abstract)(oppisite)
 *for the second box we do "method name(para.) : return type then accessibility"**** (for methods only) 
 *as well as for the second entry in it, we use the name of the method then () then : 
 *the return type of the method if there is one (put nothing if no return type and that means void) (do all methods need accessibility like virtual, and abstract,etc.)****
 *:v for virtual(we always assume it must be an over ridden method for the children if we use :v)*****, then :o for child overrding
 *draw me is an abstract method and it would be different for every child shape and abstract means it cant have any code block with it and no implementation code within the parent
 *and the child must implemement its own method for drawing it
 *we want to have a constrcutore that accesspts our 2 dimensions (x and y)(if we want to use default and our own default constructor, 
 *then we include that in the diagram otherwise we
 *dont include it in our diagram if we dont use the empty constructor)(yes) (if we have only the default do we still include it in shumul)****
 *will return an error if we over ride our custom constructors (create custom constructor only once and not do it again with the same exact signautre)(yes)
 *if we create a custom constructor and we try to use a defualt constructor without it being defined then we get an error 
 *
 *shumul:
 *to derive we create more boxes and create a box for the circle class which has 4 parts (the second part is empty for all children because we are not making any new fields
 *for the child specifically and the parent would not see anything new or over ridden within the child class)(yes)
 *theres no private with classes in shumul so is it true in general******
 *(we can combines public with abstract ssealed static or nothing or we could do internal with any of those 3 combined or nothing) (how woud it look in shumul)*******
 *(same for private or no because its not in classes)****
 *the third box will have two methods that will be defined (over ridden)(which should we say)*******
 *in child class and we need to overide the area method from our parent so we use 
 *:o to say we are overriding default method
 *(do we always have to have a :a (abstract blank method) or a :v (virtual = default method, methods only or) associated with a :o
 *(over ridiing a defult method in the child, only)(we can associate :o with both)
 *and the drawing method was absract in parent method so we also do :o when we implmement an abstract method
 *for our constructor for a circle we accept radius for our parameter and it calls parent constructor passing the x dimension as the radius and y as 0********
 *in order to call anything specifically in parent we use the "base" keyword (in JS it was super) base refers to the parent class and lets us access
 *the specific implememntation in the parent and not the overidden one within the child**
 *in the parent class(if we want to call default area nethod from parent class we do base.area)********** or would it be parent instance = new childinstaance() then******
 *after we can acccess it there with instances too if it was a parent instance or child*****
 *it accesses the one from parent instead of circle child class when we call base (the defult method)(why would we use the parent method if circle has different
 *calculations for its area when we do base for the consutrcotr)*********
 *base can be used to acces anyting from parent class and the limitations are*******
 *
 *
 *for rectangle its missing the area method because it was inherited from parent shape class so we dont add that into the rectagnle because we can just call the default from
 *parent and we also add a boolean which is a property to see if its a square or not to implement that parent method((read only) :r)**
 *
 *we could use the property for the rectangle by returning true or false if it was x=y and when we create an instance, we could do if(reectangle.IsSquare){console.write
 *line("thisrectangle is a square))} basically it checks and we can do something based on that
 *
 *classes constructors structs methods properties data types (any data types) enum and delegates are pascale case
 * 
 *
 *shumul allows us to easily go from diagram to code
 *child classes always point to their parent when making shumul digrams (bottom to top)** (always)**
 *and the lines styles are specific to the kind of class that the parent is (if we are inheriting from a normal (public) parent class thats not abstract then its a solid line
 *to point frm child to parent, but if we inherit from an absratct class then we use dotted line)(in our diagram it was a dotted line to go from parent to child)if our
 *parent class was not abstract it would be a solid line**
 *
 *
 *
 *1-1 class relationships and 1-to-many on shumul****
 *
 *interfaces:
 *So basically an interface is a pointer and only references the prpo and methods and we dont initialize or do anything there we basically******
 *only write the signatures of it in there any do the ";" at the end**** (whats an examples of a property with a get and set being ref. in a ******
 *interface and a method that has a return type and para.)********************* and classes basically can inherit and have instances but interfaces is just a pointer*****
 *and only ref. the common things within some of the classes so we could access them from the interfaces instead of the classes themselesv (they dont make a copy)*****
 *so when we create an the interface varuable and we set that variable equal to another instance of a class it basically does what**** (would this only work
 *if it was inherited or would it also work on other classes without explicit casting)*****
 *how would we use it in the main*******
 */


namespace Shape //does namespace always have to be same name of the class/struct like how constructor is
                //with classes and structs*****
{
    //we just go from our syntax in diagram (code block for our class that defines the scope of our class
    //variables that are constants we use all uppercase because** 

    //classes,structs,interfaces, and what else dont take in para. and dont have a return type**

    public interface IDrawOjbect //interfaces,classes and structs cant have a return type 
    {
        void DrawMe(); //the shape class inherits from this method interface**
    }

    public class Blood : IDrawOjbect //inherits interface and we do the same with shape because it inherits from the interface as well and we can have
                                     //any amount of interface inheritence but classes its only 1 parent per child**
    {
        public virtual void DrawMe() //isnt this technically an abstract method** why did we not use a: does a v: take precendce over an a:** (does****
                                        //the child inherit this method or the one from the parent)****
        {
            //draw blood
        } 
    }

    public abstract class Shapes : IDrawOjbect 
    {
        public const double PI = Math.PI; //create the pi variable**
        protected double x;           //protected means we only acessible in the parent and child classes but not outside those(cant be used in main for example)
                                        //why would we want protected if we cant use them in main with the instances****
        protected double y;

        //to access constants they are just like a sttaic variable we have to access it via the class name not the instance name**

        private int myInt; //myIny only available in this code block(and it does not get inherited)******

        public virtual double Area()
        {
            return this.x * this. y; //default area calculation (used for our x and y within our class members when we use this.
                                     //is it only within the parent class or is it also within the children
                                     //and then in the main when we create and instance thats when we use the object instance (variable) we created then
                                     //the . notiation)
        }

        //does not have return type indicated so use void and no code block since its abstract(any child class must implememnt the method otherwise its a compile****
        //time error because its an instance type without a code block like fields*****
        public abstract void DrawMe(); //if a method does not return anything, then we can just do ;** do we usually do****
                                       //this for interfaces and abstract methods and virtual methods*****

        public Shapes()
        {

        }

        //constructors (default and its set as public)(like we did right above here or what was that**
        //convention for constructors (default)**
        //constructors are always the same name as class**
        //we can only have public constructors****

        public Shapes(double x, double y)
        {
            this.x = x; //we pass in variables with this. always within constructors in the parent method and in general in the parent
                        //or child as well and with the instance we would just use the instance name instead of this.
            this.y = y; //the this keyword refers to our field member x and set it equal to the x variable that has been passed from our
                        //child method into our parent constructor** (our para. x)*****

            //if we wanted to access area within our constructor would it be this.Area()??**** How would we reference methods with para in constructors**
            //and would we also call it within the child the the instance.the method name then the para. also with this. then when we create the child** 
            //class we would also do the same thing to access it then in the instance just fill the values in***** (when to use this. to access a method in a constructor
            //or child)*****
        }
    }

    //always update our digram if we update our code 

    //use : after class name then the parent class to show its inheritence
    //in c# we are limited to inheriting from 1 parent class
    public class Circle : Shapes, IDrawOjbect
    {  //use , if a child inherits from a class and interface(only 1 class but infinite amount of interfaces)

        public int myInt;
        
            //sealed makes sure nothing inherits from shape (if it did how would inheritence work then)*****
            //static class cant be inherited**
            //why would we have a static class**
        
        //over ride the area calculation (use override keyword to override parent method)**
        public override double Area()
        {
            return Shapes.PI * this.x * this.x; //we use this. even though we are in child?? does it mean its using the x and y from the parent********************
        } //use the class name.PI because it's like a static variable so we use the class name(not this. not instances allowed for both cases)**

        public override void DrawMe() //by default they throw an exception if it was abstacr and we create it in child until we put code into it wihtin child the no error*****
        {
            //draw a circle for the specific calculation
        }

        public Circle(double r) : base(r, 0) //when we say double r how then do the base why do we have to say
            //double r specifically is it because we are creating the type for the constrcutor for circle itself so we can pass in doubles with the instance**
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
                //draw a Cylinder for the specific calculation (drawing stuff wont be on exmas)**
            }

            public Cylinder(double r, double h) : base(r, h) //why do we have to do the doubles before the colon**
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

            public Rectangle(double w, double h) : base(w, h) //the rectangle class needs this in the beginning before the colon**
                                                              //so we can tell it to have a width and height and set it to**
            //this.x = w and this.y = h to the parent class instead of using base but we should use base so it can set the x and y as the hieight we pass in**
            //same thing as just removing base and doing this.x = w and this.y = h (why would we still need a code block cant we use ";"****
            {

            }
        }


    }



    //classes can also be sealed which means it cant be inherited and we could hve made our child classes sealed so nothing inherits from it
    //we use static in unit 1 otherwise we had to make Program.OurMethod (create instance of program to access our things in it)then make our methods and variables*****
    //math class and console class are static and cant be inherited or instantiated(cant create an instance out of it)*****

    //shumul diagram gives us the relationships between classes
    //we dont have to use static in unit 2??*******
    static internal class Program
    {
        static void Main(string[] args)
        {
            MyMethod();
        // if MyMethod() is not static, then we need an instance of Program to call it
        //Program p = new Program()
        //p.MyMethod();
        //cant we just make the program not static then it would work**

            Circle circle = new Circle(5.5); //cant call default constructor because we overrode it with our own constructor when we inherited otherwise if it was not there
                                             //then we could use defualt or we could create a default and use it here*****
            Cylinder cylinder = new Cylinder(3, 6);
            Rectangle rectangle = new Rectangle(1, 2);
            Blood blood = new Blood(); //Shapes shape1 = blood; we cant do this implicitly or even when we cast it because no common inheritence the interface does not count****
        //because its a refernece not a class that can inherit or have that relationship or have others inherit from it****

            Circle circle2;
            circle2 = circle; //we have one circle object but now we have two circles pointing at the circle object and circle 2 is lost if something was equal to it**
            circle2.myInt = 1; //myInt does noting so why did we do this and its private so how could we use it if its only defined in parent
        //for myInt in the child its somethnig new the parent cant access right because its private in the parent and the child cant see if but if the child****
        //has the same thing as a public accessibility the parent would not see it right****

            //we can use any parent class type to point at child type and vice versa*****
            //can parent see whats in the child(no)
            //Shapes shape = new Shapes(); //cant make a vaiable of shape because its an abstrac method(too generic)
            //only when its abstract we cant create an instance rght*****

            Shapes shape; 

            // cannot instatiate (create an instance) of an abstract class
            // shape = new Shapes();*****

            // we can implicitly set a parent data type to a child data type****
            shape = rectangle; //the parent is now equal to the recetangle child class so now it calls the appropriate method and if it was inherited then**
                               //it calls the overrideen method if it was over ridden, if not, then it calls the parent defult in this case it calls the defauly**
                               ////since nothing was overridden in rectangle would it just be shape.Area(w,h) and in this case it would call the parent*****
                               ///doesnt shapes pointer change to rectangle now instead of the parent and the parent shape is lost now**********
            
            // and it calls the method as defined in the child class
            // this will draw a rectangle
            shape.DrawMe(); //this calls the DrawMe() method in rectangle because its the inherited class we set shape to** 

            shape.Area();//we can use the parent variable to call specific things from the child thats common in child and parent and calls correct overrideen method
                         //involed in the shape(polymorphism)(calls the correct method based on the relationships)****
                         //shape.IsSquare; //we cant call this because its not accessible within the parent and child and only within child
                         //class and if its only in child class parent cant see it****
                         //but didnt we change the pointer to point to rectangle in this case above with shape = rectangle*****


            // we can also access objects via interfaces that the object is derived from
            IDrawOjbect drawOjbect; // create a drawobject variable and does not point to anything 

            //blood and shape dont have a common parent, but they both share the interface(its not a class) and the interface is not like a class and its more specific
            //the shape and the blood are not related so we cant set blood = shape because theres not association within classes for them and the interface does not count
            //because its not a class

            // blood inherits the IDrawObject interface
            drawOjbect = blood; //ref. variable and now we point it to blood**
            
            //this will draw blood
            drawOjbect.DrawMe(); //anything thats above can point to whats below it and it we have the interface everything below is inherited by
                                 //the interface or do we have to still say it explicitly wwith the class declarations**
            //the interface contains the drawme method and we can use it do call the drawme method and same thing for the drawobject point to the circle
            //and change direction of mirror to point to something else and we cnan turn mirror around to point to the drawme method for circle instead of blood now** 

        //since parent points to it the children would also get the interface??**** (I thought there was no inheritence with interfaces)****

            //circle inherits from the IDrawObject interface**** (do we have to do this for interfaces
            //because shoouldnt everything by default inherit it since its on the top of the application or****
            drawObject = circle; 
            drawOjbect.DrawMe();//*****

            //call the DrawObject with each object instance
            DrawObject(circle); //the DrawObject only takes in things that have inherited the IDrawObject so now it can call the proper drawme for the inherited things
        //that inherited drawme
            DrawObject(cylinder); //anything defined below an interface will be inherited autpmatically if its the parent and the child gets it autpmatically****
                                    //unless only a child gets it****
            DrawObject(blood);

        //we can set a more generic data type equal to a child data type like parent = child****
        //the parent types are more general and the child types are more specific and the lump of clay is**
        //the parent and we can make the more specfic shape which is the child**
        //but not the other way around(unless we destroy parent)**
        //when would we want to destroy parent**
        //we cant set a child class equal to parent class because its more specific****

            //circle is pointing to the object that was created so we have our circle variable on one side and the object is somewhere else and its pointing at the circle
            //object we had created and we would lose the circle if nothing was pointing to it*****
            //when we have a structure the sturcutre variable instance name is the actual object(a copy)**
            //but with a ref. variable instance name, it points to the object in memeory and not the object itself
            //(not a copy)**



        //NEW NOTES
        //the most useful things with classes is that because of the family tree of how the classes are related we can access any child class by any parent datatype
        //ex. access circle by using shape to access circle and circle can also be used with the interface because it was inherited by the parent but if it was**
        //only the child, then we could only use it with the child instance**
        //interface gives us easy handles to work on(ex. phone with keyboard and we could use it across all of the apps and the keyboard is the interface
        //wheere each child would be an app where we could use the keyboard sepcifically)(the keyboard interface gives us input to all apps on our phone
        //and eveyryhting on our phone inherits from keyboard interface)(only cares about allowing users to enter data and type into an app nothing else)**
        //do properties usually take a return type in shumul***********************

        //any parent data type can be used to access any child datatype and we could pass in any of our drawObject because Idrawobject was iherited by the children**
        //because the parent inherited it so if the parent inherits it the children automatically get it otherwise if its only some children we would have to**
        //explcitly cast to the parent**

        
        }



        // a generic method to draw an object via the IDrawObject interface
        // drawObject can point to the object passed in if that object inherits the IDrawObject interface
        // otherwise you will get a runtime error**
        static void DrawObject(IDrawOjbect drawOjbect)
        {
            drawOjbect.DrawMe();//method that accepts drawobject and we can call it based on the circle or rectangle or shape and draws the different objects with it
        } //pass any oject that inherits from this interface


        static void PrintAreaOfShape(Shapes shape)
        {
            if(shape.GetType() == typeof(Circle))//we could figure out which data type the object is and its the gettype is = to type of Circle(only put in the classes not
                                                 //instances for typeof)(its like instanceof() in js)****
            {
            Console.WriteLine("circle!"); //we could also do if(shape is Circle)
            }
            if(shape.GetType() == typeof(Rectangle)) //all children inherit everything from parent and parents dont inherit from the children 
            //if we want to access child specific, then we have to have a reference pointing to the child data type**
            {
            Rectangle r; //creating a varibale not an instance**
            r = (Rectangle)shape;  //we explicitly cast because c# does not know how to make shape look like rectangle
                                   //but it does know how to make rectangle look like shape**(we can
                                   //do parent datatype to child but not implicitly do child to parent we have to do it explicitly)**
            if (r.IsSqaure)
            {
                Console.WriteLine("Sqaure!");
            } //we could also do this way to do PE10 for epxlicitly casting the interfcae**
            }

            if(shape is IDrawOjbect) //if we want to do this in PE10 instead of explicitly casting**
            {
            IDrawOjbect drawOjbect = (IDrawOjbect)shape; //explicitly casting the shape which is a rectangle now to an idrawibject interface(why because its inherited already)**
            }

        Console.WriteLine("The area is: " + shape.Area());//since children classes overrode area methods from parents and if we do shape.area() it will**
        //call the correct child method and it knows what kind of object it really is even though its passed in as a shape because the children inherit from that class**
        //so when we do parent = new child() then it calls the correct inherited method also works if we explicitly casted the child to the parent)*******

        }
        static void MyMethod()
        {
        
        }

        //do child classes usually have constructors as well or is it only the parent class**

        //polymorphism is using a parent class type to access the children and having our object take on diffreentshapes (like overriding) to be their own**
        //encapsulation is keepting data stored in one place so we dont have to write it over and over and embed the methods within the class and we can just reference
        //if whenever we need it**(otherwise we just copy and paste code)**
        //abstraction is using encapsulation and abstracts the functionality for us so we dont have to know the details of how it works**(phone ex.)
        
    }




//we want to create a library when we work with classes and when we develop a project (team project) and there is one executable and we have all of these dll files
//and its library files (dynamic linked library) and lets us extend the application with additional functionality with forms and stuff like that
//and its used to complete the application in certain parts (so many people can work on different parts)**
//the module we work on for project should be our own dll file

//game and song inherit from the interfaces and they use common data types and they inherit it (polymorphism)**
//abstract song class we have fields like year and lyrics and it has prop./methods and theres the property name and methods 
//and each child class had the different devices the song can be played on and it inherits the play method and how to play it based on the deivce as well as its own
//fields to have the name of the tape and the side and the record name and different fields for based on how the device works to play the song**
//to copy a song we have a virtual method in the parent and we can override it within the child for MP3 

//we want to have a dll that has all of our classes implemented and then our song application connects the dll(use class library .NET framework)

