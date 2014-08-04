#region

using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Action Row Cut Copy Paste of Assets  .
    /// </summary>
    [Binding]
    public class ManageAssets : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ManageAssets));

        /// <summary>
        /// Verify The Customized Content Asset.
        /// </summary>   
        /// <param name="assetType">This is AssetType.</param>
        /// <param name="activityTypeEnum">This is Activity by type enum.</param>
       [When(@"I should able to see the ""(.*)"" customized content ""(.*)"" Assets")]
        public void VerifyTheCustomizedContentAsset(
           String assetType, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Customized Content Asset
            Logger.LogMethodEntry("ManageAssets",
                "VerifyTheCustomizedContentAsset",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Custom Content Asset
            new CustomContentPage().VerifyCustomContentAsset
               ((AddAssessmentPage.AssetTypeEnum)Enum.Parse
               (typeof(AddAssessmentPage.AssetTypeEnum), assetType), activityTypeEnum);
            Logger.LogMethodExit("ManageAssets",
                "VerifyTheCustomizedContentAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }      
      
      /// <summary>
       /// Select The Copy And Paste Link.
      /// </summary>
      /// <param name="assetTypeEnum">This is asset type enum.</param>
        [When(@"I select the ""(.*)"" CopyPaste link")]
        public void SelectTheCopyAndPasteLink(String assetTypeEnum)
        {
            //Select The Copy And Paste Link 
            Logger.LogMethodEntry("ManageAssets", "SelectTheCopyAndPasteLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Select CopyPaste Link
            new CustomContentPage().SelectCopyPasteLink
              ((AddAssessmentPage.AssetTypeEnum)Enum.Parse
              (typeof(AddAssessmentPage.AssetTypeEnum), assetTypeEnum));
            Logger.LogMethodExit("ManageAssets", "SelectTheCopyAndPasteLink",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clear The Clear Clipboard.
        /// </summary>
        [When(@"I Clear the Clipboard link")]
        public void ClearTheClearClipboard()
        {
            //Clear The Clear Clipboard 
            Logger.LogMethodEntry("ManageAssets",
                "ClearTheClearClipboard",
               base.IsTakeScreenShotDuringEntryExit);
            //Click The Clear Clipboard Link
            new CustomContentPage().ClickTheClearClipboardLink();
            Logger.LogMethodExit("ManageAssets",
                "ClearTheClearClipboard",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand Button Of NonLicensed Folder.
        /// </summary>
        [When(@"I click on the expand button of Non licensed Folder")]
        public void ExpandButtonOfNonLicensedFolder()
        {
            //Expand Button Of NonLicensed Folder 
            Logger.LogMethodEntry("ManageAssets",
                "ExpandButtonOfNonLicensedFolder",
               base.IsTakeScreenShotDuringEntryExit);
            //Click The Expand Button NonLicensed Folder
            new CustomContentPage().ClickTheExpandButtonNonLicensedFolder();
            Logger.LogMethodExit("ManageAssets",
                "ExpandButtonOfNonLicensedFolder",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove The Copied Content.
        /// </summary>
        /// <param name="assetTypeEnum">This is Asset Type Enum.</param>
        [When(@"I remove the ""(.*)"" copied content")]
        public void RemoveTheCopiedContent(String assetTypeEnum)
        {
            //Remove The Copied Content
            Logger.LogMethodEntry("ManageAssets", "RemoveTheCopiedContent",
               base.IsTakeScreenShotDuringEntryExit);
            //Remove The Copied Content In Global
            new CustomContentPage().RemoveTheCopiedContentInGlobal
              ((AddAssessmentPage.AssetTypeEnum)Enum.Parse
              (typeof(AddAssessmentPage.AssetTypeEnum), assetTypeEnum));
           Logger.LogMethodExit("ManageAssets", "RemoveTheCopiedContent",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cut And Paste Link.
        /// </summary>
        /// <param name="assetType">This is asset type.</param>
        [When(@"I select the ""(.*)"" CutPaste link")]
        public void SelectTheCutAndPasteLink(String assetType)
        {
            //Select The Cut And Paste Link
            Logger.LogMethodEntry("ManageAssets", "SelectTheCutAndPasteLink",
              base.IsTakeScreenShotDuringEntryExit);
            //Select The CutPaste Link
            new CustomContentPage().SelectTheCutPasteLink
              ((AddAssessmentPage.AssetTypeEnum)Enum.Parse
              (typeof(AddAssessmentPage.AssetTypeEnum), assetType));
            Logger.LogMethodExit("ManageAssets", "SelectTheCutAndPasteLink",
           base.IsTakeScreenShotDuringEntryExit);
        }
    }
 }

