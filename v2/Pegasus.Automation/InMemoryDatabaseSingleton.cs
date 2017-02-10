using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System;
using Pegasus.Automation.DataTransferObjects;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// Thi class is a singleton.
    /// </summary>B
    internal class InMemoryDatabaseSingleton
    {
        /// <summary>
        /// This is the in memory database.
        /// </summary>
        private readonly InMeoryDatabase _inMemoryDatabase = null;

        /// <summary>
        /// This is the singleton instance class.
        /// </summary>
        private static InMemoryDatabaseSingleton _inMemoryDatabaseSingleton = null;

        /// <summary>
        /// This is the private constructor of the database and
        /// deserialize xml data in memory based on environment variable.
        /// </summary>
        private InMemoryDatabaseSingleton()
        {
            _inMemoryDatabase = new InMeoryDatabase();

            // based on environment deserialize xml data in memory
            switch (AutomationConfigurationManager.ApplicationTestEnvironment.ToUpper())
            {
                case "CGIE": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "PPE": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "PROD": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "VCD": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                    (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                case "VCDAKAMAI": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                    ("VCD")); break;
                case "CGIEAKAMAI": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                   ("CGIE")); break;
                case "PPEAKAMAI": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                   ("PPE")); break;
                case "PRODAKAMAI": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                   ("PROD")); break;
                case "VCDNP": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                ("VCDNP")); break;
                case "CGIENP": this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                   ("CGIENP")); break;

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
        private void DeserializeTheXmlDataInMemory(String xmlTestDataFilePath)
        {
            // get xml data based on file path
            String getXmlData = File.ReadAllText(xmlTestDataFilePath);
            var xmlDocument = new XmlDocument();
            // load xml data
            xmlDocument.LoadXml(getXmlData);
            // created xml serializer
            XmlNodeList xmlNodeList;
            XmlSerializer xmlSerializer;
            // desearlize data
            DesearlizeOrganzationTestData(xmlDocument, out xmlNodeList, out xmlSerializer);
            DesearlizeUserTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeCourseTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeProgramTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeActivityTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeClassTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeProductTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeGradeTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeActivityQuestionsListTestData(xmlDocument, out xmlNodeList, out xmlSerializer);
            DesearlizeLicenseTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeQuestionTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeToolLinksData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeWelcomeMessageTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            DesearlizeAlertTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
        }

        /// <summary>
        /// Desearlize Product Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeProductTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            //Get Xml Node List For Class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfProduct");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Product>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get product list
                var getProductList = (List<Product>)
                 xmlSerializer.Deserialize(reader);
                foreach (Product products in getProductList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(products);
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
        private void DesearlizeClassTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfClass");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Class>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get class list
                var getClassList = (List<Class>)
                 xmlSerializer.Deserialize(reader);
                foreach (Class classes in getClassList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(classes);
                }
            }
        }

        /// <summary>
        /// Desearlize Grade Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeGradeTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfGrade");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Grade>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get grade list
                var getGradeList = (List<Grade>)
                 xmlSerializer.Deserialize(reader);
                foreach (Grade grades in getGradeList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(grades);
                }
            }
        }

        /// <summary>
        /// Desearlize Welcome Message Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeWelcomeMessageTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfWelcomeMessage");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<WelcomeMessage>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get Welcome Message list
                var getWelcomeMessageList = (List<WelcomeMessage>)
                 xmlSerializer.Deserialize(reader);
                foreach (WelcomeMessage welcomeMessage in getWelcomeMessageList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(welcomeMessage);
                }
            }
        }

        /// <summary>
        /// Desearlize Welcome Message Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeAlertTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for class
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfAlert");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Alert>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get Welcome Message list
                var getAlertList = (List<Alert>)
                 xmlSerializer.Deserialize(reader);
                foreach (Alert alert in getAlertList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(alert);
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
        private void DesearlizeActivityTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for activity
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfActivity");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Activity>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get activity list
                var getActivityList = (List<Activity>)
                 xmlSerializer.Deserialize(reader);
                foreach (Activity activities in getActivityList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(activities);
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
        private void DesearlizeProgramTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for programs
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfProgram");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Program>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get program list
                var getProgramList = (List<Program>)
                 xmlSerializer.Deserialize(reader);
                foreach (Program programs in getProgramList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(programs);
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
        private void DesearlizeUserTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for courses
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfUser");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<User>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get users list
                var getUserList = (List<User>)
                 xmlSerializer.Deserialize(reader);
                foreach (User users in getUserList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(users);
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
        private void DesearlizeCourseTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml data based on file path
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfCourse");
            // created Object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Course>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created Object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get course list
                var getCourseList = (List<Course>)
                 xmlSerializer.Deserialize(reader);
                foreach (Course courses in getCourseList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(courses);
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
        private void DesearlizeOrganzationTestData(XmlDocument xmlDocument,
            out XmlNodeList xmlNodeList, out XmlSerializer xmlSerializer)
        {
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfOrganization");
            xmlSerializer = new XmlSerializer(typeof(List<Organization>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                var organizationList = (List<Organization>)
                 xmlSerializer.Deserialize(reader);
                foreach (Organization organizations in organizationList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(organizations);
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
        private void DesearlizeActivityQuestionsListTestData(XmlDocument xmlDocument,
            out XmlNodeList xmlNodeList, out XmlSerializer xmlSerializer)
        {
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfActivityQuestionsList");
            xmlSerializer = new XmlSerializer(typeof(List<ActivityQuestionsList>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                var activityQuestionsList = (List<ActivityQuestionsList>)
                 xmlSerializer.Deserialize(reader);
                foreach (ActivityQuestionsList activityQuestions in activityQuestionsList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(activityQuestions);
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
        private void DesearlizeLicenseTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {

            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfLicense");
            xmlSerializer = new XmlSerializer(typeof(List<License>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                var licenseList = (List<License>)
                 xmlSerializer.Deserialize(reader);
                foreach (License license in licenseList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(license);
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
        private void DesearlizeQuestionTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {

            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfQuestion");
            xmlSerializer = new XmlSerializer(typeof(List<Question>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                var questionList = (List<Question>)
                 xmlSerializer.Deserialize(reader);
                foreach (Question question in questionList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(question);
                }
            }
        }

        /// <summary>
        /// Desearlize Integration Tool Links Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeToolLinksData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {

            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfToolLinks");
            xmlSerializer = new XmlSerializer(typeof(List<ToolLinks>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get organization list
                var linkList = (List<ToolLinks>)
                 xmlSerializer.Deserialize(reader);
                foreach (ToolLinks link in linkList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(link);
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
            return _inMemoryDatabaseSingleton ?? (_inMemoryDatabaseSingleton = new InMemoryDatabaseSingleton());
        }

        /// <summary>
        /// This is the instance of the database
        /// </summary>
        public static InMeoryDatabase DatabaseInstance
        {
            get { return GetInstance()._inMemoryDatabase; }
        }
    }
}
