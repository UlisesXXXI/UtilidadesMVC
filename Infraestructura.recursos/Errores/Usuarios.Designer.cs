﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructura.recursos.Errores {
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
    public class Usuarios {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Usuarios() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infraestructura.recursos.Errores.Usuarios", typeof(Usuarios).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es un formato de email valido.
        /// </summary>
        public static string EmailNoCorrecto {
            get {
                return ResourceManager.GetString("EmailNoCorrecto", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email es obligatorio.
        /// </summary>
        public static string EmailRequerido {
            get {
                return ResourceManager.GetString("EmailRequerido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No coincide password y el campo confirmación de password.
        /// </summary>
        public static string NoCoincidePasswordYConfirmacion {
            get {
                return ResourceManager.GetString("NoCoincidePasswordYConfirmacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password requerido.
        /// </summary>
        public static string Password {
            get {
                return ResourceManager.GetString("Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirmación de password obligatorio.
        /// </summary>
        public static string RePassword {
            get {
                return ResourceManager.GetString("RePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nombre de usuario es obligatorio.
        /// </summary>
        public static string UserNameRequerido {
            get {
                return ResourceManager.GetString("UserNameRequerido", resourceCulture);
            }
        }
    }
}