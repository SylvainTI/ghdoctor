using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GHDoctor.Core.Repository;
using GHDoctor.Core.Services;
using System.IO;
using System.Web.Script.Serialization;

namespace GHDoctorTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        
        public void TraeTodasLasCategoriasYConsulta()
        {
            IGHDoctorRepository repository = new GHDoctorRepository();

            var list = repository.GetCategories();
            Assert.IsTrue(list.Count > 0);

            var category = list[0];
            var queries = repository.GetCommonQueries(category.Code);

            var service = new GHDoctorService();
            // Prueba con las primeras 2 para que no tarde tanto el test.
            service.GetResults(queries.Take(2).ToList(), "fi.uba.ar");
        }

        [TestMethod]
        public void PruebaDeserializarJSONdeGoogle()
        {
            // Prueba con una respuesta a una consulta que está en un archivo de texto.
            string example = File.ReadAllText(@"..\..\..\GHDoctorTests\SearchResultExample.txt");
            var serializer = new JavaScriptSerializer();
            var jsonObject = serializer.Deserialize<GoogleSearchResults>(example);
            Assert.IsNotNull(jsonObject);
            Assert.IsTrue(jsonObject.GetType() == typeof(GoogleSearchResults));
            Assert.IsNotNull(jsonObject.responseData);
            Assert.IsNotNull(jsonObject.responseData.cursor);
            Assert.AreEqual(jsonObject.responseData.cursor.estimatedResultCount, "46500");
        }


    }
}
