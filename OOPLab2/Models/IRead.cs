using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOPLab2.Models
{
    public interface IRead 
    {
         List<NewProducts> GetProducts();
    }
}