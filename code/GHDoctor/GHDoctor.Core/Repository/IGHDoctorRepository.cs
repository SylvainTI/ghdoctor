using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHDoctor.Core.Repository
{
    public interface IGHDoctorRepository
    {
        /// <summary>
        /// Devuelve todas las categorías.
        /// </summary>
        /// <returns></returns>
        IList<Category> GetCategories();

        /// <summary>
        /// Devuelve todas las queries de una categoría.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        IList<CommonQuery> GetCommonQueries(int categoryCode);
    }
}
