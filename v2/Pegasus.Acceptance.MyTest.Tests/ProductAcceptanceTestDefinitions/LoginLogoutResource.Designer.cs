﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoginLogoutResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoginLogoutResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions.LoginLogoutResou" +
                            "rce", typeof(LoginLogoutResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 5.
        /// </summary>
        internal static string LoginLogout_Custom_TimeToWait_Element {
            get {
                return ResourceManager.GetString("LoginLogout_Custom_TimeToWait_Element", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sign out.
        /// </summary>
        internal static string LoginLogout_Signout_Link_Title_Locator {
            get {
                return ResourceManager.GetString("LoginLogout_Signout_Link_Title_Locator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pegasus Login.
        /// </summary>
        internal static string LoginLogout_Window_Name_Title {
            get {
                return ResourceManager.GetString("LoginLogout_Window_Name_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to mode=backdoor.
        /// </summary>
        internal static string LoginPage_Backdoor_Mode {
            get {
                return ResourceManager.GetString("LoginPage_Backdoor_Mode", resourceCulture);
            }
        }
    }
}
