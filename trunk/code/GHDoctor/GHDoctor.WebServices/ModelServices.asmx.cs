using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GHDoctor.Core.Services;
using GHDoctor.Core;
using System.Text;
using System.Xml;

namespace GHDoctor.WebServices
{
    /// <summary>
    /// Summary description for ModelServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aca van los web services que devuelven cosas del modelo
    public class ModelServices : System.Web.Services.WebService 
    {
        [WebMethod]
        public List<Category> GetAllCategories()
        {
            GHDoctorService ghSvc = new GHDoctorService();
            //IList<Category> ret = ghSvc.GetAllCategories().ToList<Category>();


/*
            DataContractSerializer dcs = new DataContractSerializer(typeof(Category));
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            dcs.WriteObject(writer, cust);
            writer.Close();
            string xml = sb.ToString();
            */

            return ghSvc.GetAllCategories().ToList<Category>();
        }
    }
}
