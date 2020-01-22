using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Programm
    {
        struct FachMitNote
        {
            public string Name;
            public double Note;
        }

        public static void Main()
        {
            Console.WriteLine("Notendurchschnitt");
            //Console.WriteLine("Bitte die Note für Mathematik eingeben:");
            //var noteMathematik = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Deutsch eingeben:");
            //var noteDeutsch = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Englisch eingeben:");
            //var noteEnglisch = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Latein eingeben:");
            //var noteLatein = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Informarik eingeben:");
            //var noteInformatik = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Biologie eingeben:");
            //var noteBiologie = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Chemie eingeben:");
            //var noteChemie = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Geschichte eingeben:");
            //var noteGeschichte = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Erdkunde eingeben:");
            //var noteErdkunde = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Musik eingeben:");
            //var noteMusik = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Sport eingeben:");
            //var noteSport = double.Parse(Console.ReadLine());
            //Console.WriteLine("Bitte die Note für Religion eingeben:");
            //var noteReligion = double.Parse(Console.ReadLine());

            List<FachMitNote> fächerMitNote = new List<FachMitNote>();

            while (nochEinFachMehr())
            {
                Console.Clear();
                Console.WriteLine("Was für ein Fach?");
                var Fach = Console.ReadLine();
                Console.WriteLine($"Bitte die Note für {Fach} eingeben:");
                var note = double.Parse(Console.ReadLine());

                FachMitNote fachMitNote;
                fachMitNote.Name = Fach;
                fachMitNote.Note = note;
                fächerMitNote.Add(fachMitNote);
            }

            int notenAnzahl = 0;
            double gesammtwert = 0;
            Console.Clear();
            //Fächer mit Note ausgeben
            foreach (FachMitNote  fachMitNote in fächerMitNote)
            {
                notenAnzahl += 1;
                gesammtwert += fachMitNote.Note;
                Console.WriteLine(fachMitNote.Name+" "  + fachMitNote.Note );
            }


            Console.WriteLine();
            double notendurchschnitt = gesammtwert / notenAnzahl ;
            Console.WriteLine($"Dein Notendurchschnitt ist {notendurchschnitt}");


        }

        public static bool nochEinFachMehr()
        {
            Console.WriteLine("Möchtest du ein Fach hinzufügen? [j/n]");
            var antwort = Console.ReadLine();
            return (antwort.Substring(0, 1).ToLower() == "j");
        }

    }
   

    
}
    


  
