using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//for sockets they are used for applications to communicate with each other and they are always on our computer any time we use a web browser or communication
//software (computer is like apartment building like street address and also had apartment within it where different people live and the mail office, 
//main office, etc.)(the street address is the IP address for our computer)(for the dyscord we are using version 4 addressing with less numbers rather 
//than version 6 for more numbers for IP address)
//if we want to host a minecraft server we have to pay for a static IP address so we have a dedicated IP address so that its not shared with all our neighbors 
//there are tcp protocal which is transiistino control and the datagram protocol
//tcp maintinas direct cpnnection (like talking on the phone and if someone hangs up connection is locked)
//udp does not maintain direct connection and throws message over wall and hopes the reciever gets it and most multiplayer games use this communticaiont


//port 80 is wlays used for web based communication and we can have multiple things running at one time because they use diffrent ports on our computer but with the same IP**


//TCP socket methods for dyscord**
//a socket is like a plug or a cord that the information can travel over 
//normally we want to use a tcp socket (most relibale)
//address gives us version 4 acces, stream means, and the protocol is the tcp type for the socket**
//when we create a socket we use socket var anme = new Socket(addressfamily.internetwork,sockettype.stream,protocoltype.tcp)**
//IPEndPoint variable = new IPEndPoint(Ipaddress.any,myport)** we need to have the point on our computer the first para.(ipaddress.any which means use our
//own ip address then use the port that we are listening on so that gives ut the end point**

//ipaddres varable name = ipaddress.parse(targettip)



//ipendpoint localendpoint  new ipendpint(ipaddress,targetport)
//we then bind to the**
//then we do listen 300 usually for**
//


//input  = new StreamReader(open local file)
//sockets can use stream reder and writer to read and write data
//socket client = listender.accept()//socket has accept which**

//stream = netstream = new networkstream(client) crete the stream connection the read the stream data then use read to end method to 
//read all the data on the socket
//and we always need to close the reader then the netstream then the client (we go from most recent opedned to less recent opedned when we close)**


//when we want to do IP of remote computer then
//we need the IPaddress and the port which is the port that the application the port is listening on for data
//remote endpoint will have the values of the ipvalues and the port
//then create socket which consists of the ipaddress then a stream then a tcp protocal
//then connect it to the reemote eenpoint
//then create stream to stream to socket then create a streamwriter to send data 
//dircetly to that socket**

namespace Dyscord
{
    public partial class SettingsForm : Form
    {
        public int myPort;
        public SettingsForm(Form owner, int nport)
        {
            InitializeComponent();

            this.Owner = owner;
            this.CenterToParent();
            this.myPort = nport;
            this.portTextBox.Text = nport.ToString();

            this.startButton.Click += new EventHandler(StartButton__Click);
            this.portTextBox.KeyPress += new KeyPressEventHandler(PortTextBox__KeyPress);



        }

        private void StartButton__Click(object sender, EventArgs e)
        {
            this.myPort = Int32.Parse(this.portTextBox.Text);
            this.Close();
        }

        private void PortTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) ||  e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; //do we always have an if or else for the handled and suppress** (prevents the text from not being put on
                //the form if a number is not put in**

                //how do we know when to add another form in our file did we do the same thing for edit person and people list
                //because we were adding something to the main form (person list and we were adding person edit form so we made a new form
                //within that file??)**

            }
        }


    }
}
