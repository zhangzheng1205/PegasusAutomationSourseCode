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
    public class CourseHome : BasePage
    {
        //locators
        By signOut = By.LinkText("Sign Out");
        By courseNameList = By.CssSelector(".title.ellipsis.ng-binding.pointer");
        By Title = By.TagName("title");

       
        public string getCourseName(Course.CourseTypeEnum courseName)
        {
            string courseNametoMatch = Course.Get(courseName).Name.ToString();
            return courseNametoMatch;
        }

       
        public bool loginSuccess()
        {
            base.WaitForElementDisplayedInUi(signOut, 10);
            bool success = base.IsElementPresent(signOut);
            return success;
        }

        
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

            IList<IWebElement> courseList = base.GetWebElementsProperties(courseNameList);

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
