﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 
namespace OfdbWgDataModel.Fassung {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ofdbgw {
        
        private ofdbgwResultat resultatField;
        
        /// <remarks/>
        public ofdbgwResultat resultat {
            get {
                return this.resultatField;
            }
            set {
                this.resultatField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultat {
        
        private string titelField;
        
        private string erscheinungartField;
        
        private string labelField;
        
        private string veroeffentlichtField;
        
        private string eanupcField;
        
        private string[] bilderField;
        
        private string freigabeField;
        
        private string indiziertField;
        
        private string laufzeitField;
        
        private string regionalcodeField;
        
        private string dvdformatField;
        
        private string tvnormField;
        
        private string verpackungField;
        
        private string bildformatField;
        
        private string[] tonformateField;
        
        private string[] untertitelField;
        
        private string extrasField;
        
        private string bemerkungenField;
        
        private string autorField;
        
        private string eintragsdatumField;
        
        /// <remarks/>
        public string titel {
            get {
                return this.titelField;
            }
            set {
                this.titelField = value;
            }
        }
        
        /// <remarks/>
        public string erscheinungart {
            get {
                return this.erscheinungartField;
            }
            set {
                this.erscheinungartField = value;
            }
        }
        
        /// <remarks/>
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
            }
        }
        
        /// <remarks/>
        public string veroeffentlicht {
            get {
                return this.veroeffentlichtField;
            }
            set {
                this.veroeffentlichtField = value;
            }
        }
        
        /// <remarks/>
        public string eanupc {
            get {
                return this.eanupcField;
            }
            set {
                this.eanupcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("bild", IsNullable=false)]
        public string[] bilder {
            get {
                return this.bilderField;
            }
            set {
                this.bilderField = value;
            }
        }
        
        /// <remarks/>
        public string freigabe {
            get {
                return this.freigabeField;
            }
            set {
                this.freigabeField = value;
            }
        }
        
        /// <remarks/>
        public string indiziert {
            get {
                return this.indiziertField;
            }
            set {
                this.indiziertField = value;
            }
        }
        
        /// <remarks/>
        public string laufzeit {
            get {
                return this.laufzeitField;
            }
            set {
                this.laufzeitField = value;
            }
        }
        
        /// <remarks/>
        public string regionalcode {
            get {
                return this.regionalcodeField;
            }
            set {
                this.regionalcodeField = value;
            }
        }
        
        /// <remarks/>
        public string dvdformat {
            get {
                return this.dvdformatField;
            }
            set {
                this.dvdformatField = value;
            }
        }
        
        /// <remarks/>
        public string tvnorm {
            get {
                return this.tvnormField;
            }
            set {
                this.tvnormField = value;
            }
        }
        
        /// <remarks/>
        public string verpackung {
            get {
                return this.verpackungField;
            }
            set {
                this.verpackungField = value;
            }
        }
        
        /// <remarks/>
        public string bildformat {
            get {
                return this.bildformatField;
            }
            set {
                this.bildformatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("format", IsNullable=false)]
        public string[] tonformate {
            get {
                return this.tonformateField;
            }
            set {
                this.tonformateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("sprache", IsNullable=false)]
        public string[] untertitel {
            get {
                return this.untertitelField;
            }
            set {
                this.untertitelField = value;
            }
        }
        
        /// <remarks/>
        public string extras {
            get {
                return this.extrasField;
            }
            set {
                this.extrasField = value;
            }
        }
        
        /// <remarks/>
        public string bemerkungen {
            get {
                return this.bemerkungenField;
            }
            set {
                this.bemerkungenField = value;
            }
        }
        
        /// <remarks/>
        public string autor {
            get {
                return this.autorField;
            }
            set {
                this.autorField = value;
            }
        }
        
        /// <remarks/>
        public string eintragsdatum {
            get {
                return this.eintragsdatumField;
            }
            set {
                this.eintragsdatumField = value;
            }
        }
    }
}
