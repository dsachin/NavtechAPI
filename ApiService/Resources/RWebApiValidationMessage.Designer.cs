//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiService.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RWebApiValidationMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RWebApiValidationMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ApiService.Resources.RWebApiValidationMessage", typeof(RWebApiValidationMessage).Assembly);
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
        ///   Looks up a localized string similar to Error occurred while gettting/posting data..
        /// </summary>
        internal static string CommonError {
            get {
                return ResourceManager.GetString("CommonError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provided customer Id is invalid..
        /// </summary>
        internal static string InvalidCustomerId {
            get {
                return ResourceManager.GetString("InvalidCustomerId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Order Status is invalid..
        /// </summary>
        internal static string InvalidOrderStatus {
            get {
                return ResourceManager.GetString("InvalidOrderStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Payment Type is invalid..
        /// </summary>
        internal static string InvalidPayement {
            get {
                return ResourceManager.GetString("InvalidPayement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product does not Exist..
        /// </summary>
        internal static string InvalidProductId {
            get {
                return ResourceManager.GetString("InvalidProductId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product is either out of stock or the order quantity cannnot be fulfilled..
        /// </summary>
        internal static string OutofStock {
            get {
                return ResourceManager.GetString("OutofStock", resourceCulture);
            }
        }
    }
}
