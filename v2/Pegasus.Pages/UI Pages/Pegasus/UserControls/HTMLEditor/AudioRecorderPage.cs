using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.UserControls.HTMLEditor;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Essay Page actions
    /// </summary>
    class AudioRecorderPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AudioRecorderPage));

        /// <summary>
        /// Record Audio.
        /// </summary>
        public void RecordAudio()
        {
            //Record Audio
            logger.LogMethodEntry("AudioRecorderPage", "RecordAudio",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select Record Audio Window
                this.SelectRecordAudioWindow();
                //Wait For Record Button Class Name
                base.WaitForElement(By.ClassName(
                    AudioRecorderPageResource.AudioRecorderPage_RecordButton_ClassName));
                IWebElement getRecordButton = base.GetWebElementPropertiesByClassName(
                     AudioRecorderPageResource.AudioRecorderPage_RecordButton_ClassName);
                //Click On Record Button To Start Recording
                base.ClickByJavaScriptExecutor(getRecordButton);
                // Recording Audio for One Minute
                this.RecordAudioForOneMinute();
                //Click On Record Button To Stop Recording 
                base.ClickByJavaScriptExecutor(getRecordButton);
                // Save Audio Recorded input value
                this.SaveAudioRecord();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AudioRecorderPage", "RecordAudio",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Record Audio Window.
        /// </summary>
        private void SelectRecordAudioWindow()
        {
            logger.LogMethodEntry("AudioRecorderPage", "SelectRecordAudioWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Click On Record Audio Image
            base.WaitForElement(By.Id(
                AudioRecorderPageResource.AudioRecorderPage_AudioRecord_Image_Id_Locator));
            base.ClickImageById(
                AudioRecorderPageResource.AudioRecorderPage_AudioRecord_Image_Id_Locator);
            //Switch To Popup Window
            base.WaitUntilPopUpLoads(
                AudioRecorderPageResource.AudioRecorderPage_RecordAudio_Window_Name);
            base.SelectWindow(
                AudioRecorderPageResource.AudioRecorderPage_RecordAudio_Window_Name);
            logger.LogMethodExit("AudioRecorderPage", "SelectRecordAudioWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Record Audio for One Minute.
        /// </summary>
        public void RecordAudioForOneMinute()
        {
            //Record Audio for One Minute
            logger.LogMethodEntry("AudioRecorderPage", "RecordAudioForOneMinute",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Fetching The Recording Time Value
                base.WaitForElement(By.ClassName(
                    AudioRecorderPageResource.AudioRecorderPage_CurrentTime_ClassName));
                string getRecordingCurretTime = base.GetElementTextByClassName(
                    AudioRecorderPageResource.AudioRecorderPage_CurrentTime_ClassName);
                //Reccursive Method To Record Audio For One Minute
                if (Convert.ToInt32(getRecordingCurretTime.Split(':')[0]) >= 
                    Convert.ToInt32(AudioRecorderPageResource.AudioRecorderPage_Recording_Time))
                {
                    return;
                }
                else
                {
                    RecordAudioForOneMinute();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AudioRecorderPage", "RecordAudioForOneMinute",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Audio Recorded input value.
        /// </summary>
        private void SaveAudioRecord()
        {
            logger.LogMethodEntry("AudioRecorderPage", "SaveAudioRecord",
                base.isTakeScreenShotDuringEntryExit);
            //Wait Till Record Saving Message Disappears
            bool IsSaveButtonEnabled = false;
            do
            {               
                IsSaveButtonEnabled = base.IsElementEnabledById(
                    AudioRecorderPageResource.AudioRecorderPage_SaveAndClose_Id_Locator);
            } while (IsSaveButtonEnabled == false);
            // Wait For SaveButton ID
            base.WaitForElement(By.Id(
                AudioRecorderPageResource.AudioRecorderPage_SaveAndClose_Id_Locator));
            IWebElement getSaveButtonId = base.GetWebElementPropertiesById(
                AudioRecorderPageResource.AudioRecorderPage_SaveAndClose_Id_Locator);
            //Click On Save And Close Button
            base.ClickByJavaScriptExecutor(getSaveButtonId);
            logger.LogMethodExit("AudioRecorderPage", "SaveAudioRecord",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
