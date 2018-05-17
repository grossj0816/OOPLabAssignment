using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Models
{
    public interface IInsert
    {
        bool AddProducts(string pNameParam, string catIdParam, string supIdParam, string unitPriceParam);
    }
}
