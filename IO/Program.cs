using System;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.Xml.Serialization;

namespace IO;
class Program
{
            // define an array 
    static string[] callsigns = new string[]{
        "ABC", "TEST", "ACDC", "BMT"
    };

    static void Main(string[] args)
    {
        // Set console encoding
        // Console.WriteLine("Console.OutputEncoding = ", Console.OutputEncoding );
        // Console.OutputEncoding = System.Text.Encoding.UTF8;

        // CultureInfo globalization = CultureInfo.CurrentCulture;
        // CultureInfo localization = CultureInfo.CurrentUICulture;

        // Console.WriteLine("The current globalization is {0}: {1}", globalization.Name, globalization.DisplayName);
        // Console.WriteLine("The current localization is {0}: {1}", localization.Name, localization.DisplayName);
        // Console.WriteLine();

        // // Select a culture code
        // Console.WriteLine("en-US; English (United-Stated)");
        // Console.WriteLine("da-DK; Danish (Denmark))");
        // Console.WriteLine("de-AT; German (Austria))");
        // Console.WriteLine("Enter an ISO culture code: ");
        // string? newCulture = Console.ReadLine();

        // if(!string.IsNullOrEmpty(newCulture)) {
        //     CultureInfo ci = new CultureInfo(newCulture);
        //     CultureInfo.CurrentCulture = ci;
        //     CultureInfo.CurrentUICulture = ci;

        //     Console.WriteLine($"You selected a new culture: {newCulture}");
        // }

        // Console.WriteLine();
        // Console.Write("Enter your name: ");
        // string? name = Console.ReadLine();

        // Console.WriteLine("Enter your date of birth: ");
        // string? dob = Console.ReadLine();
        // Console.WriteLine(dob);

        // Console.WriteLine("Enter your salary: ");
        // string? salary = Console.ReadLine();

        // if (!string.IsNullOrEmpty(name) &&
        //     !string.IsNullOrEmpty(dob) &&
        //     !string.IsNullOrEmpty(salary)) {
        //         DateTime dateOfBirth = DateTime.Parse(dob);
        //         int minutes = (int)DateTime.Today.Subtract(dateOfBirth).TotalMinutes;
        //         decimal earns = decimal.Parse(salary);

        //         Console.WriteLine("{0} was born on a {1:dddd}, and is {2:N0} minutes old. He earns {3:C}", name, dateOfBirth, minutes, earns);
        //     }

        //WorkWithText();

        // WorkWithXml();

        //WorkWithDirectory();

        List<Person> people = new List<Person> {
            new Person("Patrick", 5000M),
            new Person("Antoine", 12M),
            new Person("Jesus", 0M),
        };

        // create object that will format a List of Person as XML
        XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
        // create a file to write to
        string path = Combine(CurrentDirectory, "people.xml");

        using (FileStream stream = File.Create(path)) {
            // serialize the object graph to the stream
            xs.Serialize(stream, people);
        };

    }

    static void WorkWithText() {
        string textFile = Combine(CurrentDirectory, "streams.txt");

        // create a text file and return a writer helper
        StreamWriter text = File.CreateText(textFile);
        foreach(string item in callsigns) {
            text.WriteLine(item); // text is a helper writer that helps generating/managing text file
        }
        text.Close(); // release the ressources

        Console.WriteLine("{0} contains {1:N0} bytes", 
        arg0: textFile, 
        arg1: new FileInfo(textFile).Length);

        Console.WriteLine(File.ReadAllText(textFile));
    }

    static void WorkWithXml() {
        // define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");

        FileStream xmlFileStream = File.Create(xmlFile); // wrap the file steam in a XML writer and automatically indent nested elements
        XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings {Indent = true});

        // write the xml declaration
        xml.WriteStartDocument();
        // write root element
        xml.WriteStartElement("callsigns");

        foreach(string item in callsigns) {
            xml.WriteElementString("callsign", item);
        }

        // write the close root element
        xml.WriteEndElement();
        // close the writer and streams
        xml.Close();
        xmlFileStream.Close();

        // output all the content of the file
        Console.WriteLine("(0) containes {1:N0} bytes",
        arg0: xmlFile,
        arg1: new FileInfo(xmlFile).Length);
        Console.WriteLine(File.ReadAllText(xmlFile));

        // xml reader
        using(XmlReader reader = XmlReader.Create("streams.xml")) {
            while (reader.Read())
            {
                // check if we are on an element node named callsign
                if ( (reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) {
                    reader.Read();
                    Console.WriteLine($"{reader.Value}");
                }
            }
        }

    }

    static void WorkWithDirectory() {
        // define a directory path for a new folder
        Console.WriteLine("Enter the name of the folder: ");
        string? nameFolder = Console.ReadLine();
        string newFolder = Combine(GetFolderPath(SpecialFolder.Desktop), nameFolder!); // return the personal document of the currently logged in user
        Console.WriteLine("Working with:", newFolder);
        Console.WriteLine($"Does it exist? {Exists(newFolder)}");
        // create a directory
        Console.WriteLine("Creating the folder...");
        CreateDirectory(newFolder);
        Console.WriteLine($"Does it exist? {Exists(newFolder)}");
        Console.WriteLine("Confirm that the directory exists and press ENTER to continue");
        Console.ReadLine();

        // delete directory
        Console.WriteLine("Deleting the directory...");
        Delete(newFolder, recursive: true);
        Console.WriteLine($"Does it exist? {Exists(newFolder)}");
    }
}
