using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    class JediCouncil
    {
        List<Jedi> members = new List<Jedi>();

        //változtatás eventje
        public event CouncilChangedDelegate CouncilChanged;

        //változtatás delegátja
        public delegate void CouncilChangedDelegate(string message);

        public void Add(Jedi newJedi)
        {
            //Hozzáad egy Jedit
            members.Add(newJedi);
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    CouncilChanged("A tanács elesett!");
            }
        }

        //predikátum a 300 alattiakra
        public bool beginners(Jedi j)
        {
            return j.MidiChlorianCount < 300;
        }

        //kezdő jedikről ad listát
        public List<Jedi> getBeginners()
        {
            return members.FindAll(beginners);
        }
    }
}
