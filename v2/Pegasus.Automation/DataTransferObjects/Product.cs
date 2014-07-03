using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This class represents a product
    /// </summary>
    public class Product : BaseEntityObject
    {
        /// <summary>
        /// This is the id of the program course
        /// </summary>
        public Guid ProgramCourseId { get; set; }

        //TODO - Add the accessor to the program course

        /// <summary>
        /// This is the product type enum
        /// </summary>
        public enum ProductTypeEnum
        {
            NovaNET = 1,
            DigitalPath = 2,
            HedCoreGeneral = 3,
            HedCoreProgram = 4,
            HedMilGeneral = 5,
            HedMilProgram = 6,
            PromotedAdminDigitalPath = 7,
            DigitalPathDemo = 8
        }

        /// <summary>
        /// This is the type of product
        /// </summary>
        public ProductTypeEnum ProductType { get; set; }

        /// <summary>
        /// This is the license status
        /// </summary>
        public bool LicenseStatus { get; set; }

        /// <summary>
        /// This is the rumba resource id
        /// </summary>
        public String RumbaResourceId { get; set; }

        /// <summary>
        /// This is the rumba product id
        /// </summary>
        public String RumbaProductId {get;set;}

        /// <summary>
        /// This is the product demo access code.
        /// </summary>
        public String DemoAccessCode { get; set; }

        /// <summary>
        /// This is the product welcome message.
        /// </summary>
        public String WelcomeMessage { get; set; }

        /// <summary>
        /// This method is used to create a product
        /// </summary>
        public void StoreProductInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method returns the last created product of the given type
        /// </summary>
        /// <param name="productType">This is the type of the product</param>
        /// <returns>The product</returns>
        public static Product Get(ProductTypeEnum productType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Product>(
                x => x.ProductType == productType && x.IsCreated).OrderByDescending(
                x => x.creationDate).First();
        }

        public static List<Product> Get(Func<Product,bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }
    }
}
