using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Jedi j = new Jedi();
            j.MidiChlorianCount = 120;
            j.Name = "Jedi1";

            j = feladat2(j);

            Console.WriteLine(j.Name);
            Console.WriteLine(j.MidiChlorianCount);

            feladat3();

            JediCouncil council = new JediCouncil();
            addmembers(council);
            feladat4(council);
        }

        [Description("Feladat2")]
        public static Jedi feladat2(Jedi j)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi)); 
            FileStream stream = new FileStream("jedi.txt", FileMode.Create); 
            serializer.Serialize(stream, j); 
            stream.Close();

            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();
            return clone;
        }

        //üzenet kiírása konzolra
        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }

        [Description("Feladat3")]
        public static void feladat3()
        {
            JediCouncil council = new JediCouncil();
            //kiíró függvény hozzáadása az eseményhez
            council.CouncilChanged += MessageReceived;

            council.Add(new Jedi());
            council.Add(new Jedi());

            council.Remove();
            council.Remove();
        }

        [Description("Feladat4")]
        public static void feladat4(JediCouncil council)
        {
            List<Jedi> list = council.getBeginners();
            foreach(Jedi j in list)
                Console.WriteLine(j.Name);
        }

        //tanács feltöltése
        public static void addmembers(JediCouncil council)
        {
            //jedik létrehozása és hozzáadása
            Jedi jedi1 = new Jedi();
            jedi1.MidiChlorianCount = 310;
            jedi1.Name = "jedi1";
            council.Add(jedi1);

            Jedi jedi2 = new Jedi();
            jedi2.MidiChlorianCount = 200;
            jedi2.Name = "jedi2";
            council.Add(jedi2);

            Jedi jedi3 = new Jedi();
            jedi3.MidiChlorianCount = 40;
            jedi3.Name = "jedi3";
            council.Add(jedi3);
        }
    }
}
