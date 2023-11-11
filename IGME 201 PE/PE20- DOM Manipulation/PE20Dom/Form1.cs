using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);


            // if you want to use example.html from a local folder (saved in c:\temp for example):
            //this.webBrowser1.Navigate("c:\\temp\\example.html");

            // or if you want to use the URL  (only use one of these Navigate() statements)
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");


        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h1");
            htmlElement = htmlElementCollection[0];
            htmlElement.InnerText= "My UFO Page";

            //so basically we call htmlelementcollection or htmlelement
            //does the previous one we have get overridden like over here we 
            //set the collection equal to a new array of h2 tags so now does the array of
            //h1 tags not exist??**(1)
            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h2");
            htmlElementCollection[0].InnerText = "My UFO Info";
            htmlElementCollection[1].InnerText = "My UFO Pictures";
            htmlElementCollection[2].InnerText = "";

            htmlElement = webBrowser.Document.Body;
            htmlElement.Style += "font-family: sans-serif; color: #Ff0000";

            htmlElementCollection = webBrowser.Document.GetElementsByTagName("p");
            htmlElementCollection[0].InnerHtml = "Report your UFO sightings here: <a href='http://www.nuforc.org'>http://www.nuforc.org</a>";
            //so in the innerhtml that basically sets the tags within the paragraph but it can also display text??
            //I tried using innertext then did innerhtml for the link and it was not working so I was wondering
            //why this worked instead??**(2)
            htmlElementCollection[1].InnerText = "";
            //so to apply multiple style rules we just use a ";" in between them??**(3)

            //can we only use specific things from an array when we get element by tag name or do we have to use all the elements if we get element by tag name??**(4)

            htmlElementCollection[0].Style += "color: #00A86B; font-weight: bold; font-size: 2em; text-transform: uppercase; text-shadow: 3px 2px #A44;";

            webBrowser.Document.GetElementById("lastParagraph");
            HtmlElement htmlElement1 = webBrowser.Document.CreateElement("img"); //why is my image not showing up**(5)
            htmlElement1.SetAttribute("src", "https://plus.unsplash.com/premium_photo-1682124677523-514b31279909?q=80&w=892&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
            htmlElement1.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, htmlElement1);

            htmlElement1 = webBrowser.Document.CreateElement("footer");

            htmlElement1.InnerHtml = "&copy;2023 Kashaf Ahmed"; //why is my footer not showing up either**(6)
            webBrowser.Document.Body.AppendChild(htmlElement1);



        }

    }
}
