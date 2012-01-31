﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace ReadModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ReadModelContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ReadModelContainer object using the connection string found in the 'ReadModelContainer' section of the application configuration file.
        /// </summary>
        public ReadModelContainer() : base("name=ReadModelContainer", "ReadModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ReadModelContainer object.
        /// </summary>
        public ReadModelContainer(string connectionString) : base(connectionString, "ReadModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ReadModelContainer object.
        /// </summary>
        public ReadModelContainer(EntityConnection connection) : base(connection, "ReadModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<NoteItem> NoteItemSet
        {
            get
            {
                if ((_NoteItemSet == null))
                {
                    _NoteItemSet = base.CreateObjectSet<NoteItem>("NoteItemSet");
                }
                return _NoteItemSet;
            }
        }
        private ObjectSet<NoteItem> _NoteItemSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TotalsPerDayItem> TotalsPerDayItemSet
        {
            get
            {
                if ((_TotalsPerDayItemSet == null))
                {
                    _TotalsPerDayItemSet = base.CreateObjectSet<TotalsPerDayItem>("TotalsPerDayItemSet");
                }
                return _TotalsPerDayItemSet;
            }
        }
        private ObjectSet<TotalsPerDayItem> _TotalsPerDayItemSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Intervento_Basic> Intervento_BasicSet
        {
            get
            {
                if ((_Intervento_BasicSet == null))
                {
                    _Intervento_BasicSet = base.CreateObjectSet<Intervento_Basic>("Intervento_BasicSet");
                }
                return _Intervento_BasicSet;
            }
        }
        private ObjectSet<Intervento_Basic> _Intervento_BasicSet;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the NoteItemSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToNoteItemSet(NoteItem noteItem)
        {
            base.AddObject("NoteItemSet", noteItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TotalsPerDayItemSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTotalsPerDayItemSet(TotalsPerDayItem totalsPerDayItem)
        {
            base.AddObject("TotalsPerDayItemSet", totalsPerDayItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Intervento_BasicSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToIntervento_BasicSet(Intervento_Basic intervento_Basic)
        {
            base.AddObject("Intervento_BasicSet", intervento_Basic);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ReadModel", Name="Intervento_Basic")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Intervento_Basic : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Intervento_Basic object.
        /// </summary>
        /// <param name="guid">Initial value of the Guid property.</param>
        /// <param name="inizio">Initial value of the Inizio property.</param>
        /// <param name="fine">Initial value of the Fine property.</param>
        /// <param name="isEseguito">Initial value of the IsEseguito property.</param>
        /// <param name="creationDate">Initial value of the CreationDate property.</param>
        public static Intervento_Basic CreateIntervento_Basic(global::System.Guid guid, global::System.DateTime inizio, global::System.DateTime fine, global::System.Boolean isEseguito, global::System.DateTime creationDate)
        {
            Intervento_Basic intervento_Basic = new Intervento_Basic();
            intervento_Basic.Guid = guid;
            intervento_Basic.Inizio = inizio;
            intervento_Basic.Fine = fine;
            intervento_Basic.IsEseguito = isEseguito;
            intervento_Basic.CreationDate = creationDate;
            return intervento_Basic;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Guid
        {
            get
            {
                return _Guid;
            }
            set
            {
                if (_Guid != value)
                {
                    OnGuidChanging(value);
                    ReportPropertyChanging("Guid");
                    _Guid = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Guid");
                    OnGuidChanged();
                }
            }
        }
        private global::System.Guid _Guid;
        partial void OnGuidChanging(global::System.Guid value);
        partial void OnGuidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Inizio
        {
            get
            {
                return _Inizio;
            }
            set
            {
                OnInizioChanging(value);
                ReportPropertyChanging("Inizio");
                _Inizio = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Inizio");
                OnInizioChanged();
            }
        }
        private global::System.DateTime _Inizio;
        partial void OnInizioChanging(global::System.DateTime value);
        partial void OnInizioChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Fine
        {
            get
            {
                return _Fine;
            }
            set
            {
                OnFineChanging(value);
                ReportPropertyChanging("Fine");
                _Fine = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Fine");
                OnFineChanged();
            }
        }
        private global::System.DateTime _Fine;
        partial void OnFineChanging(global::System.DateTime value);
        partial void OnFineChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsEseguito
        {
            get
            {
                return _IsEseguito;
            }
            set
            {
                OnIsEseguitoChanging(value);
                ReportPropertyChanging("IsEseguito");
                _IsEseguito = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsEseguito");
                OnIsEseguitoChanged();
            }
        }
        private global::System.Boolean _IsEseguito;
        partial void OnIsEseguitoChanging(global::System.Boolean value);
        partial void OnIsEseguitoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                OnCreationDateChanging(value);
                ReportPropertyChanging("CreationDate");
                _CreationDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreationDate");
                OnCreationDateChanged();
            }
        }
        private global::System.DateTime _CreationDate;
        partial void OnCreationDateChanging(global::System.DateTime value);
        partial void OnCreationDateChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ReadModel", Name="NoteItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class NoteItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new NoteItem object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static NoteItem CreateNoteItem(global::System.Guid id)
        {
            NoteItem noteItem = new NoteItem();
            noteItem.Id = id;
            return noteItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                OnCreationDateChanging(value);
                ReportPropertyChanging("CreationDate");
                _CreationDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreationDate");
                OnCreationDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _CreationDate;
        partial void OnCreationDateChanging(Nullable<global::System.DateTime> value);
        partial void OnCreationDateChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ReadModel", Name="TotalsPerDayItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TotalsPerDayItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TotalsPerDayItem object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        /// <param name="newCount">Initial value of the NewCount property.</param>
        /// <param name="editCount">Initial value of the EditCount property.</param>
        public static TotalsPerDayItem CreateTotalsPerDayItem(global::System.Int32 id, global::System.DateTime date, global::System.Int32 newCount, global::System.Int32 editCount)
        {
            TotalsPerDayItem totalsPerDayItem = new TotalsPerDayItem();
            totalsPerDayItem.Id = id;
            totalsPerDayItem.Date = date;
            totalsPerDayItem.NewCount = newCount;
            totalsPerDayItem.EditCount = editCount;
            return totalsPerDayItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 NewCount
        {
            get
            {
                return _NewCount;
            }
            set
            {
                OnNewCountChanging(value);
                ReportPropertyChanging("NewCount");
                _NewCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NewCount");
                OnNewCountChanged();
            }
        }
        private global::System.Int32 _NewCount;
        partial void OnNewCountChanging(global::System.Int32 value);
        partial void OnNewCountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 EditCount
        {
            get
            {
                return _EditCount;
            }
            set
            {
                OnEditCountChanging(value);
                ReportPropertyChanging("EditCount");
                _EditCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EditCount");
                OnEditCountChanged();
            }
        }
        private global::System.Int32 _EditCount;
        partial void OnEditCountChanging(global::System.Int32 value);
        partial void OnEditCountChanged();

        #endregion
    
    }

    #endregion
    
}
