using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using GHDoctor.Core.Repository;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

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
                SearchSite(query.SearchString, siteName);

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

        public GoogleSearchResults SearchSite(string query, string siteName)
        {
            WebClient webClient = new WebClient();
            string address = @"http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=" +
                query + " site:" + siteName;
            string result = webClient.DownloadString(address);
            var serializer = new JavaScriptSerializer();
            GoogleSearchResults searchResult = serializer.Deserialize<GoogleSearchResults>(result);
            return searchResult;
            
        }

        public GoogleSearchResults Search(string query)
        {
            WebClient webClient = new WebClient();
            string address = @"http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=" +
                query;
            string result = webClient.DownloadString(address);
            var serializer = new JavaScriptSerializer();
            GoogleSearchResults searchResult = serializer.Deserialize<GoogleSearchResults>(result);
            return searchResult;
            
        }



        public long GetNumberOfResultsForSearch(string query)
        {
            GoogleSearchResults searchResult = this.Search(query);
            return long.Parse(searchResult.responseData.cursor.estimatedResultCount);
        }

        public long GetNumberOfResultsForSiteSearch(string query, string site)
        {
            GoogleSearchResults searchResult = this.SearchSite(query, site);
            return long.Parse(searchResult.responseData.cursor.estimatedResultCount);
        }
        
    }

    [DataContract]
    public class GoogleSearchResults
    {
        [DataMember]
        public ResponseData responseData { get; set; }

        [DataMember]
        public string responseDetails {get; set;}

        [DataMember]
        public string responseStatus { get; set; }


    }

    [DataContract]    
    public class Cursor    
    {
        [DataMember]
        public string estimatedResultCount { get; set; }

        [DataMember]
        public int currentPageIndex { get; set; }

        [DataMember]
        public string moreResultsUrl { get; set; }    
    }

    [DataContract]
    public class ResponseData
    {
        [DataMember]
        public IEnumerable<Results> results { get; set; }

        [DataMember]
        public Cursor cursor { get; set; }

    }

    [DataContract]
    public class Results
    {
        [DataMember]
        public string unescapedUrl { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public string visibleUrl { get; set; }

        [DataMember]
        public string cacheUrl { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string titleNoFormatting { get; set; }

        [DataMember]
        public string content { get; set; }
    }
}
