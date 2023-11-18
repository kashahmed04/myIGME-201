using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

//for exam 3 question 1 we analyze the applicaiton and list all of the controls in applicaiton and in pesudeocode what constructor
//needs and what event handlers we need and what method are needed and what the pesudocode should be for all of our methods

//for houdini picture box we triggered if the mouse entered or leave the image 
//for the 0 windows tutorial and the events have the lightning icons next to them when we hover over 
//all of our controls in windows app are seperate threads that are running but are very lmiited because we can only act on them based on the lmiited
//set of events we can trigger
//the button can also trigger when we hover over it to exit and it changes color
//but we cant have the picturebox do something based on another field and we can only have picturebox events which are very lmiited
//most flexible windows forms control is the timer control that llows us to do mainly anything
//we could have timer run every millisecond and every millisecond we could have timer control do seomthing but its still lmimited because
//it jumps into our code fresh each time and we need variables to store where our time was at when we restart program
//if we want to write a program that has total control over itself and does not need an external trigger to be initiated is with the thread class
namespace Dyscord
{
    public delegate void UpdateConversationDelegate(string text);

    public partial class DyscordForm : Form
    {
        string targetUser = "";
        string targetIp = "";
        int targetPort;
        string myIp = ""; //initialize strings because if we check length of null strings (default value for strings) then we get runtime errors
        int myPort = 2222;
        Thread thread;
        Socket listener;

        //bool is buttonclciked set it to false and if button is clicked then in our delegate where the button is clicked we set it to true
        //and for delegate method in listender then change the buttons to do soemthing 
        public DyscordForm()
        {
            InitializeComponent();

            //since we are using buttons, do we still need to set settings form to my port 
            //do we technically not need a port and just pass this into it then because we are just reading from our form
            this.Show();
            SettingsForm settingsForm = new SettingsForm(this, myPort); //show the settings form to get port that our application uses to listen for data(step 1)
            settingsForm.ShowDialog(); //difference between show and showdialog
            this.myPort = settingsForm.myPort;

            ThreadStart threadStart = new ThreadStart(Listen); //then we start a thread start clas object which defines which method will run in that thread(step2)
                                                               //we point to the listen method which usually has an inifinite loop so it stays there the whole
                                                               //time to listen for a conection
                                                               //we created a varible of the thread tpye here and down below we created a new thread based on the variable
                                                               //then after we start the htread which will then start the listen method
            thread = new Thread(threadStart); //create a thread varble that uses the threadstart and it launches the listen method in the line below
            thread.Start();//this starts the method

           

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());  //what is this for*******
            foreach(IPAddress ipAddress in ipHost.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.myIp = ipAddress.ToString();
                    break;
                }
            }

            this.loginButton.Click += new EventHandler(LoginButton__Click);
            this.usersButton.Click += new EventHandler(UsersButton__Click);
            this.sendButton.Click += new EventHandler(SendButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);

            
        }

       


        //make sure to terminate thread otherwise when we leave applictation it will still run in the background so best way to do that is with a form
        //closing evenet and its called anytime the form is closed and we decalred the delegate method and below we have our method
        //which closes the listener then abort the thread (terminate it)
        //listener is a global varable and its our telephone that answers the phone and we always need 2 sockets which is our telephone and our
        //friends telephone and the one in the class scope is our phone and when we receievw a call in the listen method
        //we create a new socket called client which is our friend thats trying to connect to us

        //we want to make sure to call abort method on our thread and its important for our thread variable in our contrsucture to be in the class scope
        //so we can use it in our methods after the constructor so we can terminate the thread

        //we can have thread change every captial a to lowercase or change field colors
        //or anything in the theme of our application for exam 3
        //if they click a button or anything do something to the whole program (yes)
        private void LoginButton__Click(object sender, EventArgs e)
        {
            if(userTextBox.TextLength > 0)
            {
                webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?login=" + userTextBox.Text + "&ip=" + myIp + ":" + myPort);
                webBrowser1.Visible = false;
                userTextBox.Enabled = false;
                loginButton.Enabled = false;
            }
        }

        private void UsersButton__Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?logins");
            webBrowser1.Visible = true;
            convRichTextBox.SendToBack();

        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection htmlElementCollection;
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("button");
            foreach(HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.Click += new HtmlElementEventHandler(HtmlElement__Click);
            }
        }

        private void HtmlElement__Click(object sender, HtmlElementEventArgs e)
        {
            string title;
            string[] ipPort;

            HtmlElement htmlElement = (HtmlElement)sender;
            title = htmlElement.GetAttribute("title");
            ipPort = title.Split(':');

            this.targetIp = ipPort[0];  
            this.targetPort = Int32.Parse(ipPort[1]);
            this.targetUser = htmlElement.GetAttribute("name");
            this.groupBox1.Text = "Conversing with " + targetUser;

            webBrowser1.Visible = false;
            webBrowser1.SendToBack();


        }
        private void SendButton__Click(object sender, EventArgs e)
        {
            if(targetIp.Length > 0)
            {
                IPAddress iPAddress = IPAddress.Parse(this.targetIp);
                IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, this.targetPort);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(remoteEndPoint);
                Stream netStream = new NetworkStream(server);
                StreamWriter writer = new StreamWriter(netStream);

                string msg = userTextBox.Text + ": " + msgRichTextBox.Text;
                writer.Write(msg.ToCharArray(),0,msg.Length);

                writer.Close();
                netStream.Close();
                server.Close();

                this.convRichTextBox.Text += "> " + this.targetUser + ": " + msgRichTextBox.Text + "\n";

                msgRichTextBox.Clear();
            }

        }


        private void ExitButton__Click(object sender, EventArgs e)
        {
            listener.Close(); 
            thread.Abort();
            Application.Exit();

        }

        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close(); 
            thread.Abort(); 

        }

        public void UpdateConversation(string text)
        {
            this.convRichTextBox.Text += text + "\n";



        }

        public void Listen() //step3
        {
            //creates our local listener socket this.listener which listens to messages form other computers and it listens for messages 
            //waiting for someone to call it and we have an inifnite loop and in there all its doing is waiting for a new connection on the socket
            //and if a remote computer tries to connecct to it then the accept method will accept that connection listener.accept
            //and the listen method has to be always active and has to be a seeprate method to answer phone calls from other users
            UpdateConversationDelegate updateConversationDelegate;
            //define the type of delegate in the class scope above and pass a string that will update the windws form control with the current text we recieved from the person
            //we communicate then it writes to the richtextbox and does not return a value (4 steps of delegate)
            //create a new delegate type above then point it to the method we want to call below (updateconversion) and this method can
            //add the text to the rich textbox and it requires a layer to be able to access the windows forms control (do it via 
            //a windows control)
            //You said that we need a layer to add onto our listen method in terms of accessing controls on the form (the delegate method) because
            //the listen method cant directly access the controls on our form right?
            updateConversationDelegate = new UpdateConversationDelegate(UpdateConversation);
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, this.myPort);
            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(serverEndpoint);
            listener.Listen(300); //creating our own telphone we are listening on and our phone needs to be ready to answer a call
            //so it creates the lsitner which is a new socket and its a class scoped variable for the listener and we 
            //can close it when out form cloese and it creates the socket we are listening on for connections from other people
            //creating the end point which is our ip address and the port we are lsiening on for IPENDPOINT
            //and initialize the port as 2222 which is the port is lsitenins on and it r=creates the endpoint then creates the socket
            //connected to the IP end point then the listen opens the listender for 300 so we cn recieve calls 

            //we want our thread to be able to access forms on our control so we use a delegate to do that 
            //if we want our thread to change every time it says yes we want it to change to no so we could have a thread running
            //and we could have another method to change yes to no 
            //so every no will be yes 

            //and we dont need IENPOINT all the way to the listender 300 for our code for the thread


            //waiting to get phone calls from any other users and it needs to write to our windows form so any time we get a message we want to write
            //to the richtextbox and a thread cant directly acess winsows controls because thats not allowed and listened is sectioned off in our form
            //and is running in the background and does not have access to our controls on the form and cant manipulate them so we need deleagte methods in
            //the lsitener to do it
            while (true) //method runs all the time in background and every time it looks at the richtexbox and just continuously replace the word yes with no 
                //and it will stay infinite loop and do that 
            {
                Socket client = listener.Accept();
                Stream netStream = new NetworkStream(client);
                StreamReader reader = new StreamReader(netStream);
                string result = reader.ReadToEnd();
                // only want this line for exam in the while true and no argument for the yes or no and we just pass the method in 
                Invoke(updateConversationDelegate, result); //calls our delegate method and we pass in result from it and thats the 
                //message that was read form the stream reader (invoke takes in delegate method then result that was read in when someone else types in an
                //answer)
                reader.Close();
                netStream.Close();
                client.Close();

            } //listener would listen for a button click then we change things based on that
            //also can just call the method itself in the invoke method 
            //and dont need input since we are not using sockets

        }

    }
}
