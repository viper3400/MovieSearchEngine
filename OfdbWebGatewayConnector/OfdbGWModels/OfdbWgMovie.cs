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
namespace OfdbWgDataModel.Movie {
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
        
        private string jahrField;
        
        private string bildField;
        
        private string imdbidField;
        
        private ofdbgwResultatBewertung bewertungField;
        
        private ofdbgwResultatRegie regieField;
        
        private object secondunitregieField;
        
        private ofdbgwResultatProduzent produzentField;
        
        private object drehbuchField;
        
        private object cutField;
        
        private ofdbgwResultatPerson[] soundtrackField;
        
        private string[] genreField;
        
        private string kurzbeschreibungField;
        
        private string beschreibungField;
        
        private ofdbgwResultatPerson1[] besetzungField;
        
        private ofdbgwResultatProduktionsland produktionslandField;
        
        private string alternativField;
        
        private ofdbgwResultatTitel[] fassungenField;
        
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
        public string jahr {
            get {
                return this.jahrField;
            }
            set {
                this.jahrField = value;
            }
        }
        
        /// <remarks/>
        public string bild {
            get {
                return this.bildField;
            }
            set {
                this.bildField = value;
            }
        }
        
        /// <remarks/>
        public string imdbid {
            get {
                return this.imdbidField;
            }
            set {
                this.imdbidField = value;
            }
        }
        
        /// <remarks/>
        public ofdbgwResultatBewertung bewertung {
            get {
                return this.bewertungField;
            }
            set {
                this.bewertungField = value;
            }
        }
        
        /// <remarks/>
        public ofdbgwResultatRegie regie {
            get {
                return this.regieField;
            }
            set {
                this.regieField = value;
            }
        }
        
        /// <remarks/>
        public object secondunitregie {
            get {
                return this.secondunitregieField;
            }
            set {
                this.secondunitregieField = value;
            }
        }
        
        /// <remarks/>
        public ofdbgwResultatProduzent produzent {
            get {
                return this.produzentField;
            }
            set {
                this.produzentField = value;
            }
        }
        
        /// <remarks/>
        public object drehbuch {
            get {
                return this.drehbuchField;
            }
            set {
                this.drehbuchField = value;
            }
        }
        
        /// <remarks/>
        public object cut {
            get {
                return this.cutField;
            }
            set {
                this.cutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("person", IsNullable=false)]
        public ofdbgwResultatPerson[] soundtrack {
            get {
                return this.soundtrackField;
            }
            set {
                this.soundtrackField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("titel", IsNullable=false)]
        public string[] genre {
            get {
                return this.genreField;
            }
            set {
                this.genreField = value;
            }
        }
        
        /// <remarks/>
        public string kurzbeschreibung {
            get {
                return this.kurzbeschreibungField;
            }
            set {
                this.kurzbeschreibungField = value;
            }
        }
        
        /// <remarks/>
        public string beschreibung {
            get {
                return this.beschreibungField;
            }
            set {
                this.beschreibungField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("person", IsNullable=false)]
        public ofdbgwResultatPerson1[] besetzung {
            get {
                return this.besetzungField;
            }
            set {
                this.besetzungField = value;
            }
        }
        
        /// <remarks/>
        public ofdbgwResultatProduktionsland produktionsland {
            get {
                return this.produktionslandField;
            }
            set {
                this.produktionslandField = value;
            }
        }
        
        /// <remarks/>
        public string alternativ {
            get {
                return this.alternativField;
            }
            set {
                this.alternativField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("titel", IsNullable=false)]
        public ofdbgwResultatTitel[] fassungen {
            get {
                return this.fassungenField;
            }
            set {
                this.fassungenField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatBewertung {
        
        private string noteField;
        
        private string stimmenField;
        
        private string platzField;
        
        /// <remarks/>
        public string note {
            get {
                return this.noteField;
            }
            set {
                this.noteField = value;
            }
        }
        
        /// <remarks/>
        public string stimmen {
            get {
                return this.stimmenField;
            }
            set {
                this.stimmenField = value;
            }
        }
        
        /// <remarks/>
        public string platz {
            get {
                return this.platzField;
            }
            set {
                this.platzField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatRegie {
        
        private ofdbgwResultatRegiePerson personField;
        
        /// <remarks/>
        public ofdbgwResultatRegiePerson person {
            get {
                return this.personField;
            }
            set {
                this.personField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatRegiePerson {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatProduzent {
        
        private ofdbgwResultatProduzentPerson personField;
        
        /// <remarks/>
        public ofdbgwResultatProduzentPerson person {
            get {
                return this.personField;
            }
            set {
                this.personField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatProduzentPerson {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatPerson {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatPerson1 {
        
        private string idField;
        
        private string nameField;
        
        private string rolleField;
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string rolle {
            get {
                return this.rolleField;
            }
            set {
                this.rolleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatProduktionsland {
        
        private string nameField;
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ofdbgwResultatTitel {
        
        private string landField;
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string land {
            get {
                return this.landField;
            }
            set {
                this.landField = value;
            }
        }
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
}
