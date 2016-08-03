using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pegasus.Automation;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages.Integration.MMND
{
    
    /// <summary>
    /// This class represents the API and locators of Course Home Page in MMND
    /// </summary>
    public class CourseHome : BasePage
    {
       
        
        //locators
        By signOut = By.LinkText("Sign Out");
        By courseNameList = By.CssSelector(".title.ellipsis.ng-binding.pointer");
        By templateNameList = By.CssSelector(".template-card-title.ellipsis.ng-binding.pointer");
        By Title = By.TagName("title");

       /// <summary>
       /// Accepts Enum Course and Reads the course NAME from XML file
       /// </summary>
       /// <param name="courseName">CourseTypeEnum</param>
       /// <returns>String CourseName</returns>
        public string getCourseName(Course.CourseTypeEnum courseName)
        {
            string courseNametoMatch = Course.Get(courseName).Name.ToString();
            return courseNametoMatch;
        }

       /// <summary>
       /// Locates the signout button present and returns true or false
       /// </summary>
       /// <returns></returns>
        public bool loginSuccess()
        {
            base.WaitForElementDisplayedInUi(signOut, 10);
            bool success = base.IsElementPresent(signOut);
            return success;
        }

        /// <summary>
        /// Clicks the given course or template.Accepted parameters are "coursetypeenum" for course and "string" for Template
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool clickCourse(Course.CourseTypeEnum courseName)
        {
            bool success = false;

            IList<IWebElement> courseList = base.GetWebElementsProperties(courseNameList);

            string courseNametoMatch = getCourseName(courseName);
                
            foreach(IWebElement course in courseList)
           {

               
                if(course.GetAttribute("title")==courseNametoMatch)
                {
                    success = true;
                    base.ClickByJavaScriptExecutor(course);
                    break;
                }
           }
            return success;
        }

        public bool clickCourse(String courseName)
        {
            bool success = false;

            IList<IWebElement> courseList = base.GetWebElementsProperties(templateNameList);

            //string courseNametoMatch = getCourseName(courseName);

            foreach (IWebElement course in courseList)
            {

               if (course.GetAttribute("title") == courseName)
                {
                    success = true;
                    base.ClickByJavaScriptExecutor(course);
                    break;
                }
            }
            return success;
        }
      
         

    }
}
