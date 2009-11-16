using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHDoctor.Core.Repository
{
    public class GHDoctorRepository : IGHDoctorRepository
    {
        GHDoctorDataContext dataContext = new GHDoctorDataContext();

        #region IGHDoctorRepository Members

        public IList<Category> GetCategories()
        {
            return dataContext.Categories.ToList();
        }

        public IList<CommonQuery> GetCommonQueries(int categoryCode)
        {
            return dataContext.Categories.Where(c => c.Code == categoryCode).SingleOrDefault().CommonQueries.ToList();
        }

        #endregion
    }
}
