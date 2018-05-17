using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOPLab2.Models
{
    public class CheckProductValues
    {
        //private fields in db
        private string productName = "n/a";
        private string categoryID = "n/a";
        private string supplierID = "n/a";
        private string unitPrice = "n/a";



        private BrokenRules brokenRules = new BrokenRules();
        private bool isInvalid = false;
        private bool isValid = false;


        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (value.Length < 20)
                {
                    this.productName = value;
                    this.isValid = true;
                    brokenRules.RemoveRule("Product Name Length");
                }
                else
                {
                    this.isInvalid = true;
                    brokenRules.AddRule("Product Name Length", "Product Name length is too long");
                }
            }
        }

        public string CategoryID
        {
            get
            {
                return this.categoryID;
            }
            set
            {
                if (value.Length < 4)
                {
                    this.categoryID = value;
                    this.isValid = true;
                    brokenRules.RemoveRule("Category ID Length");
                }
                else
                {
                    this.isInvalid = true;
                    brokenRules.AddRule("Category ID Length", "Category ID number is too big");
                }
            }
        }

        public string SupplierID
        {
            get
            {
                return this.supplierID;
            }
            set
            {
                if (value.Length < 4)
                {
                    this.supplierID = value;
                    this.isValid = true;
                    brokenRules.RemoveRule("Supplier ID Length");
                }
                else
                {
                    this.isInvalid = true;
                    brokenRules.AddRule("Supplier ID Length", "Supplier ID number is too big");
                }
            }
        }

        public string UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                if (value.Length < 4)
                {
                    this.unitPrice = value;
                    this.isValid = true;
                    brokenRules.RemoveRule("Unit Price Length");
                }
                else
                {
                    this.isInvalid = true;
                    brokenRules.AddRule("Unit Price Length", "Unit Price number is too big");
                }
            }
        }



        public bool IsValid
        {
            get
            {
                if (brokenRules.Count() > 0)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }


        public bool IsInvalid
        {
            get
            {
                return this.isInvalid;
            }
        }


        public string Save()
        {

            if (this.IsValid == true)
            {
                return "Saved!!";
            }
            else
            {
                string message = "Not Saved! ";

                foreach (var e in brokenRules.ListErrors())
                {
                    message = message + e + "/n";
                }

                return message;
                 
            }

        }

        public CheckProductValues(string aProductName, string aCategoryID, string aSupplierID, string aUnitPrice)
        {
            this.ProductName = aProductName;
            this.CategoryID = aCategoryID;
            this.SupplierID = aSupplierID;
            this.UnitPrice = aUnitPrice;

        }

    }
}