﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpDomain.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SharpDomain.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Cannot apply creation event &apos;{0}&apos; to an existing &apos;{1}&apos;.
        /// </summary>
        internal static string CannotApplyCreationEventToExistingEntity {
            get {
                return ResourceManager.GetString("CannotApplyCreationEventToExistingEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot modify a non-existing &apos;{0}&apos; with a non-creation event &apos;{1}&apos;.
        /// </summary>
        internal static string CannotApplyNonCreationEventToNewEntity {
            get {
                return ResourceManager.GetString("CannotApplyNonCreationEventToNewEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot apply event &apos;{0}&apos; with non-sequential version {1} on entity &apos;{2}&apos; with version {3}.
        /// </summary>
        internal static string CannotApplyNonSequentialVersionedEvent {
            get {
                return ResourceManager.GetString("CannotApplyNonSequentialVersionedEvent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current &apos;{0}&apos; already has appended events.
        /// </summary>
        internal static string EntityAlreadyHasAppendedEvents {
            get {
                return ResourceManager.GetString("EntityAlreadyHasAppendedEvents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current &apos;{0}&apos; id &apos;{1}&apos; do not correspond with event &apos;{2}&apos; id &apos;{3}&apos;.
        /// </summary>
        internal static string EntityDoNotCorrespondWithEvent {
            get {
                return ResourceManager.GetString("EntityDoNotCorrespondWithEvent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instance of type &apos;{0}&apos; cannot invoke method &apos;{1}&apos; for parameter of type &apos;{2}&apos;.
        /// </summary>
        internal static string InstanceCannotInvokeMethod {
            get {
                return ResourceManager.GetString("InstanceCannotInvokeMethod", resourceCulture);
            }
        }
    }
}