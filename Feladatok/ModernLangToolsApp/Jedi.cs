using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    public class Jedi
    {
        private string name;

        //name property-je
        [XmlAttribute("Név")]
        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }

        private int midiChlorianCount;

        //midiChlorianCount property-je
        [XmlAttribute("MidiChlorianSzám")]
        public int MidiChlorianCount
        {
            get { return midiChlorianCount; }
            set
            {
                //10-nél nagyobbnak kell lennie
                if (value <= 10) throw new ArgumentException("You are not a true jedi!");
                midiChlorianCount = value;
            }
        }

    }
}
