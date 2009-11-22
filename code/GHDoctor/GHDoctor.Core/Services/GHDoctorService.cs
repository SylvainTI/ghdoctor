using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using GHDoctor.Core.Repository;

namespace GHDoctor.Core.Services
{
    public class GHDoctorService
    {
        // Pensar bien como tiene que ser este servicio, va a ser consumido desde un web service 
        // que luego la aplicación Silverlight va a usar.

        public void GetResults(IList<CommonQuery> queries, string siteName)
        {
            if (String.IsNullOrEmpty(siteName))
                throw new Exception("Se debe especificar nombre del sitio.");

            foreach (var query in queries)
            {
                Search(query.SearchString, siteName);

            }        
        }

        public IList<Category> GetAllCategories()
        {
            GHDoctorRepository ghDoctorRepository = new GHDoctorRepository();
            return ghDoctorRepository.GetCategories();
        }

        public IList<CommonQuery> GetCommonQueries(int categoryCode)
        {
            GHDoctorRepository ghDoctorRepository = new GHDoctorRepository();
            return ghDoctorRepository.GetCommonQueries(categoryCode);
        }

        private void Search(string query, string siteName)
        {
            WebClient webClient = new WebClient();
            string address = @"http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=" +
                query + " site:" + siteName;
            string result = webClient.DownloadString(address);
        }
    }
}
