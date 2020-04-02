using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace realSafewayz.Services
{
    public class PopulateThePickers
    {
        public ObservableCollection<string> GetTheIncidentsAndAddToList(ObservableCollection<string> listToPopulate)
        {
            string[] incidentsArray;
            incidentsArray = new string[7] { "Stabbing", "Shooting", "Kidnapping", "Drug Dealing", "Petty Robbery", "Gun Fight", "Sketchy Noises" };
            listToPopulate = new ObservableCollection<string>();

            for (int i = 0; i < incidentsArray.Length; i++)
            {
                listToPopulate.Add(incidentsArray[i]);
            }
            
            return listToPopulate;
        }
    }
}
