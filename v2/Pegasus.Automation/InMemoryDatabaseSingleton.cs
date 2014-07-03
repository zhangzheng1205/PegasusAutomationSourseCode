using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// Thi class is a singleton.
    /// </summary>
    internal class InMemoryDatabaseSingleton
    {
        /// <summary>
        /// This is the in memory database.
        /// </summary>
        private InMeoryDatabase inMemoryDatabase = null;

        /// <summary>
        /// This is the singleton instance class.
        /// </summary>
        private static InMemoryDatabaseSingleton inMemoryDatabaseSingleton = null;

        /// <summary>
        /// This is the private constructor of the database and
        /// deserialize xml data in memory based on environment variable.
        /// </summary>
        private InMemoryDatabaseSingleton()
        {
            inMemoryDatabase = new InMeoryDatabase();

            // based on environment deserialize xml data in memory
            switch (AutomationConfigurationManager.ApplicationTestEnvironment)
            {
                case "ST": this.DeserializeTheXMLDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "VM": this.DeserializeTheXMLDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "PPE": this.DeserializeTheXMLDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "PROD": this.DeserializeTheXMLDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                default: throw new ArgumentException("The suggested environment was not found");
            }
        }

        /// <summary>
        /// Get the In Memory Test Data XML File Path.
        /// </summary>
        /// <param name="applicationEnvironment">This is application nvironment name.</param>
        /// <returns>In memory TestData xml file path.</returns>
        private String GetInMemoryTestDataFilePath(string applicationEnvironment)
        {
            // get xml file path
            String xmlFilePath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
            + "\\..\\..\\..\\..\\v2\\Pegasus.Automation\\InMemoryTestData\\PegasusTestData"
            + applicationEnvironment + ".xml").Replace("file:\\", "");
            return xmlFilePath;
        }

        /// <summary>
        /// Deserialize The XML Data In Memory.
        /// </summary>
        /// <param name="xmlTestDataFilePath">This is the xml file path.</param>
        private void DeserializeTheXMLDataInMemory(String xmlTestDataFilePath)
        {
            // get xml data based on file path
            String getXmlData = File.ReadAllText(xmlTestDataFilePath);
            XmlDocument xmlDocument = new XmlDocument();
            // load xml data
            xmlDocument.LoadXml(getXmlData);
            // created xml serializer
            XmlNodeList xmlNodeList;
            XmlSerializer xmlSerializer;
            // desearlize data
            desearlizeOrganzationTestData(xmlDocument, out xmlNodeList, out xmlSerializer);
            desearlizeCourseTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            desearlizeUserTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            desearlizeProgramTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            desearlizeActivityTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            desearlizeClassTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            desearlizeProductTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
        }

        /// <summary>
        /// Desearlize Product Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeProductTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            //Get Xml Node List For Class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfProduct");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Product>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get product list
                List<Product> getProductList = (List<Product>)
                 xmlSerializer.Deserialize(reader);
                foreach (Product products in getProductList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(products);
                }
            }
        }

        /// <summary>
        /// Desearlize Class Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeClassTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfClass");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Class>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get class list
                List<Class> getClassList = (List<Class>)
                 xmlSerializer.Deserialize(reader);
                foreach (Class classes in getClassList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(classes);
                }
            }
        }

        /// <summary>
        /// Desearlize Activity Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeActivityTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for activity
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfActivity");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Activity>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get activity list
                List<Activity> getActivityList = (List<Activity>)
                 xmlSerializer.Deserialize(reader);
                foreach (Activity activities in getActivityList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(activities);
                }
            }
        }

        /// <summary>
        /// Desearlize Program Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeProgramTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for programs
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfProgram");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Program>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get program list
                List<Program> getProgramList = (List<Program>)
                 xmlSerializer.Deserialize(reader);
                foreach (Program programs in getProgramList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(programs);
                }
            }
        }

        /// <summary>
        /// Desearlize User Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeUserTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for courses
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfUser");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<User>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get users list
                List<User> getUserList = (List<User>)
                 xmlSerializer.Deserialize(reader);
                foreach (User users in getUserList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(users);
                }
            }
        }

        /// <summary>
        /// Desearlize Course Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeCourseTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml data based on file path
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfCourse");
            // created Object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Course>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created Object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get course list
                List<Course> getCourseList = (List<Course>)
                 xmlSerializer.Deserialize(reader);
                foreach (Course courses in getCourseList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(courses);
                }
            }
        }

        /// <summary>
        /// Desearlize Organization Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void desearlizeOrganzationTestData(XmlDocument xmlDocument,
            out XmlNodeList xmlNodeList, out XmlSerializer xmlSerializer)
        {
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfOrganization");
            xmlSerializer = new XmlSerializer(typeof(List<Organization>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                XmlNodeReader reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                List<Organization> organizationList = (List<Organization>)
                 xmlSerializer.Deserialize(reader);
                foreach (Organization organizations in organizationList)
                {
                    // push in memory
                    inMemoryDatabase.Insert(organizations);
                }
            }
        }

        /// <summary>
        /// This class returns the instance of the in memory database
        /// </summary>
        /// <returns></returns>
        private static InMemoryDatabaseSingleton GetInstance()
        {
            //if the instance doesnt exist then create a new one
            if (inMemoryDatabaseSingleton == null)
            {
                inMemoryDatabaseSingleton = new InMemoryDatabaseSingleton();
            }

            return inMemoryDatabaseSingleton;
        }

        /// <summary>
        /// This is the instance of the database
        /// </summary>
        public static InMeoryDatabase DatabaseInstance
        {
            get { return GetInstance().inMemoryDatabase; }
        }
    }
}
