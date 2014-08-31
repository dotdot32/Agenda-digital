using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using AgendaDigital.negocios.Clases;
namespace AgendaDigital.negocios.Clases
{
    public class clIdioma
    {

        public static int idioma;

        public static Page pgn;

        public static ResourceDictionary LanguageDictionary()
        {

            ResourceDictionary dict = new ResourceDictionary();

            switch (idioma)
            {

                case 1:

                    dict.Source = new Uri("..\\Recursos\\StringResources.es-US.xaml", UriKind.Relative);

                    break;

                case 0:

                    dict.Source = new Uri("..\\Recursos\\StringResources.xaml", UriKind.Relative);

                    break;
            }
            return dict;
      
           // this.Resources.MergedDictionaries.Add(dict);

        }
    }
}
