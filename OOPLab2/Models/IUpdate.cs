using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Models
{
    public interface IUpdate
    {
        bool EditProducts(int pIdParam, string pNameParam, string catIdParam, string supIdParam, string priceParam);

    }
}
