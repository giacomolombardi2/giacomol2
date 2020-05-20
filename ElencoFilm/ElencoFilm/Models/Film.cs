using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ElencoFilm.Models
{
    public class Film
    {
        public string Imagine { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class Films : ObservableCollection<Film>
    {
        public Films() 
        {
          
        }

        public void Load() //apre il file e carica i film
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string NomeDelFile = Path.Combine(path, "films.csv");

                if (File.Exists(NomeDelFile))
                {
                    StreamReader r = new StreamReader(NomeDelFile);
                    while( !r.EndOfStream)
                    {
                        string riga = r.ReadLine();
                        string[] dati = riga.Split(';');
                        Film FM = new Film { Name = dati[0], Imagine = dati[1], Link = dati[2] };
                        Add(FM);
                    }
                    r.Close();
                }
            }
            catch (Exception errore) { }

        }
        public void Save() //salva i film nel file
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string NomeDelFile = Path.Combine(path, "films.csv");

                StreamWriter w = new StreamWriter(NomeDelFile);

                foreach ( Film FM in this )
                {
                    w.WriteLine( $"{FM.Name};{FM.Imagine};{FM.Link}" );
                }
                w.Close();
            }
            catch (Exception errore) { }

        }

    }
}
