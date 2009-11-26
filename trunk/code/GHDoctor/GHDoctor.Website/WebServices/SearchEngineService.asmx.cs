using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GHDoctor.Core.Services;

namespace GHDoctor.Website.WebServices
{
    /// <summary>
    /// Summary description for SearchEngineService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchEngineService : System.Web.Services.WebService
    {

        [WebMethod]
        public long GetNumberOfResultsForSearch(string query)
        {
            GHDoctorService svc = new GHDoctorService();
            return svc.GetNumberOfResultsForSearch(query);
        }
    }
}
