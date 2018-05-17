using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOPLab2.Models
{
    public interface IReadIndRec
    {
        List<NewProducts> GetSingleProduct(int pIdParam);
    }
}