using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Status;

namespace DajStatus
{
    class Program
    {
        static void Main(string[] args)
        {

            Status.StatusLibrary noviStatus = new Status.StatusLibrary();
            bool statusPostavljen = noviStatus.PostaviStatus("[CAMBRIDGE INSTITUTE] Online tečaj engleskog ili španjolskog jezika od 159 kn! ",
                "https://secure.ponudadana.hr/images/offers/29434/Cambridge_Institut___engleski_ili_spanjolski_jezik_online.jpg?v=1",
                "https://www.dajsve.com/pogled-ponuda-akcija-popust-PonudaDana/cambridge-institute-online-tecaj-engleskog-ili-spanjolskog-jezika-od-159-kn-tecaj-u-trajanju-60-sati-uz-mogucnost-stjecanja-certifikata-uz-nadoplatu?hpreview=a3Q2T0JBWkR3ckNzQitKekx1N3crQT09&grad=Zagreb");
            if (statusPostavljen) Console.WriteLine("Status je postavljen");
            else Console.WriteLine("Status nije postavljen");
            Console.ReadLine();
            
        }
    }
}
