using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ElencoFilm.Models;
using Xamarin.Essentials;

namespace ElencoFilm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Films Archivio { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Archivio = new Films(); //crea un archivio di film
            Archivio.Load(); //carica i film
            DatiView.ItemsSource = Archivio; //collega Archivio con la datiview
        }

        private void Add_click(object sender, EventArgs e) //aggiunge all archivio un film con nome, link e immagine
        {
            Archivio.Add(new Film { Name = "Giacomo", Link = "Http://www.youtube.com", Imagine = "" });
        }

        private void Save_click(object sender, EventArgs e) // si salva il film
        {
            Archivio.Save();
        }

        async private void Video_click(object sender, EventArgs e) //apre il link
        {
            // Il record corrente passato con . , è dentro all'attributo "CommandParameter"
            // il quale è dentro al Button...
            // Button ci arriva come object e va fatto un cast con l'operatore as
            // Se l'operatore as torna null, qualcosa è andato storto... meglio non fare nulla
            Button B = sender as Button;
            if (B != null)
            {
                // Anche CommandParameter è un object e serve un cast a Film
                Film FM = B.CommandParameter as Film;
                if (FM != null)
                {
                    await Browser.OpenAsync(FM.Link, BrowserLaunchMode.SystemPreferred);
                }
            }
        }

    }
}