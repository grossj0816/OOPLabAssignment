using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    
namespace OOPLab2.Models
{
    public abstract class Products
    {
        //instance variables crud behaviors
        IRead readOperation;
        IInsert insertOperation;
        IDelete deleteOperation;
        IReadIndRec individualRecord;
        IUpdate updateOperation;


        //private fields in db
        private int productID = 20;
        private string productName = "n/a";
        private string categoryID = "n/a";
        private string supplierID = "n/a";
        private string unitPrice = "n/a";


        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }


        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
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
                this.categoryID = value;
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
                this.supplierID = value;
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
                this.unitPrice = value;
            }
        }

        //READ
        public List<NewProducts> PerformReadOperation()
        {
            return this.readOperation.GetProducts();    
        }

        public void SetReadOperation(IRead read)
        {
            this.readOperation = read;
        }

        


        //CREATE
        public bool PerformInsertOperation(string pname, string catID, string supID, string price)
        {

            return this.insertOperation.AddProducts(pname.Trim(), catID, supID, price);
        }
        
        public void SetInsertOperation(IInsert insert)
        {
            this.insertOperation = insert;
        }




        //DELETE
        public bool PerformDeleteOperation(int pID)
        {
            return this.deleteOperation.DestroyProducts(pID);
        }

        public void SetDeleteOperation(IDelete delete)
        {
            this.deleteOperation = delete;
        }




        //idividual product
        public List<NewProducts> PerformSelectOperation(int pID)
        {
            return this.individualRecord.GetSingleProduct(pID);
        }

        public void SetSelectOperation(IReadIndRec indRec)
        {
            this.individualRecord = indRec;
        }




        //UPDATE
        public bool PerformUpdateOperation(int pID, string pname, string catID, string supID, string price)
        {
            return this.updateOperation.EditProducts(pID, pname.Trim(), catID, supID, price);
        }

        public void SetUpdateOperation(IUpdate update)
        {
            this.updateOperation = update;
        }
    }











    //SUBCLASS
    public class NewProducts : Products
    {
        public NewProducts()
        {

        }



        public NewProducts(IRead rd)
        {
            this.SetReadOperation(rd);
        }



        public NewProducts(IInsert id)
        {
            this.SetInsertOperation(id);
        }



        public NewProducts(IDelete d)
        {
            this.SetDeleteOperation(d);
        }



        public NewProducts(IReadIndRec ir)
        {
            this.SetSelectOperation(ir);
        } 



        public NewProducts(IUpdate ud)
        {
            this.SetUpdateOperation(ud);
        }



        public NewProducts(int aProductID, string aProductName, string aCategoryID, string aSupplierID, string aUnitPrice)
        {
            this.ProductID = aProductID;
            this.ProductName = aProductName;
            this.CategoryID = aCategoryID;
            this.SupplierID = aSupplierID;
            this.UnitPrice = aUnitPrice;
        }

    }

}