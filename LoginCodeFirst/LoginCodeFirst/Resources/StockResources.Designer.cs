﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginCodeFirst.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class StockResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StockResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("LoginCodeFirst.Resources.StockResources", typeof(StockResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string lbl_ListStock {
            get {
                return ResourceManager.GetString("lbl_ListStock", resourceCulture);
            }
        }
        
        public static string lbl_StoreId {
            get {
                return ResourceManager.GetString("lbl_StoreId", resourceCulture);
            }
        }
        
        public static string lbl_ProductId {
            get {
                return ResourceManager.GetString("lbl_ProductId", resourceCulture);
            }
        }
        
        public static string lbl_Quantity {
            get {
                return ResourceManager.GetString("lbl_Quantity", resourceCulture);
            }
        }
        
        public static string lbl_EditStock {
            get {
                return ResourceManager.GetString("lbl_EditStock", resourceCulture);
            }
        }
        
        public static string lbl_AddStock {
            get {
                return ResourceManager.GetString("lbl_AddStock", resourceCulture);
            }
        }
        
        public static string msg_QuantityGreaterThan1 {
            get {
                return ResourceManager.GetString("msg_QuantityGreaterThan1", resourceCulture);
            }
        }
        
        public static string err_AddStockFailure {
            get {
                return ResourceManager.GetString("err_AddStockFailure", resourceCulture);
            }
        }
        
        public static string err_EditStockFailure {
            get {
                return ResourceManager.GetString("err_EditStockFailure", resourceCulture);
            }
        }
    }
}
