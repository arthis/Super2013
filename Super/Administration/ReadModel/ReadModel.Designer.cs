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

namespace Super.Administration.ReadModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Super2013Container : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Super2013Container object using the connection string found in the 'Super2013Container' section of the application configuration file.
        /// </summary>
        public Super2013Container() : base("name=Super2013Container", "Super2013Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Super2013Container object.
        /// </summary>
        public Super2013Container(string connectionString) : base(connectionString, "Super2013Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Super2013Container object.
        /// </summary>
        public Super2013Container(EntityConnection connection) : base(connection, "Super2013Container")
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
        public ObjectSet<AreaIntervento> AreaInterventoes
        {
            get
            {
                if ((_AreaInterventoes == null))
                {
                    _AreaInterventoes = base.CreateObjectSet<AreaIntervento>("AreaInterventoes");
                }
                return _AreaInterventoes;
            }
        }
        private ObjectSet<AreaIntervento> _AreaInterventoes;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TipoIntervento> TipoInterventoes
        {
            get
            {
                if ((_TipoInterventoes == null))
                {
                    _TipoInterventoes = base.CreateObjectSet<TipoIntervento>("TipoInterventoes");
                }
                return _TipoInterventoes;
            }
        }
        private ObjectSet<TipoIntervento> _TipoInterventoes;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the AreaInterventoes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAreaInterventoes(AreaIntervento areaIntervento)
        {
            base.AddObject("AreaInterventoes", areaIntervento);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TipoInterventoes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTipoInterventoes(TipoIntervento tipoIntervento)
        {
            base.AddObject("TipoInterventoes", tipoIntervento);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Super2013Model", Name="AreaIntervento")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class AreaIntervento : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new AreaIntervento object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="start">Initial value of the Start property.</param>
        /// <param name="creationDate">Initial value of the CreationDate property.</param>
        /// <param name="deleted">Initial value of the Deleted property.</param>
        public static AreaIntervento CreateAreaIntervento(global::System.Guid id, global::System.DateTime start, global::System.DateTime creationDate, global::System.Boolean deleted)
        {
            AreaIntervento areaIntervento = new AreaIntervento();
            areaIntervento.Id = id;
            areaIntervento.Start = start;
            areaIntervento.CreationDate = creationDate;
            areaIntervento.Deleted = deleted;
            return areaIntervento;
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
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Start
        {
            get
            {
                return _Start;
            }
            set
            {
                OnStartChanging(value);
                ReportPropertyChanging("Start");
                _Start = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Start");
                OnStartChanged();
            }
        }
        private global::System.DateTime _Start;
        partial void OnStartChanging(global::System.DateTime value);
        partial void OnStartChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> End
        {
            get
            {
                return _End;
            }
            set
            {
                OnEndChanging(value);
                ReportPropertyChanging("End");
                _End = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("End");
                OnEndChanged();
            }
        }
        private Nullable<global::System.DateTime> _End;
        partial void OnEndChanging(Nullable<global::System.DateTime> value);
        partial void OnEndChanged();
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                OnDeletedChanging(value);
                ReportPropertyChanging("Deleted");
                _Deleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Deleted");
                OnDeletedChanged();
            }
        }
        private global::System.Boolean _Deleted;
        partial void OnDeletedChanging(global::System.Boolean value);
        partial void OnDeletedChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Super2013Model", Name="TipoIntervento")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TipoIntervento : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TipoIntervento object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="start">Initial value of the Start property.</param>
        /// <param name="creationDate">Initial value of the CreationDate property.</param>
        /// <param name="deleted">Initial value of the Deleted property.</param>
        public static TipoIntervento CreateTipoIntervento(global::System.Guid id, global::System.DateTime start, global::System.DateTime creationDate, global::System.Boolean deleted)
        {
            TipoIntervento tipoIntervento = new TipoIntervento();
            tipoIntervento.Id = id;
            tipoIntervento.Start = start;
            tipoIntervento.CreationDate = creationDate;
            tipoIntervento.Deleted = deleted;
            return tipoIntervento;
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
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Start
        {
            get
            {
                return _Start;
            }
            set
            {
                OnStartChanging(value);
                ReportPropertyChanging("Start");
                _Start = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Start");
                OnStartChanged();
            }
        }
        private global::System.DateTime _Start;
        partial void OnStartChanging(global::System.DateTime value);
        partial void OnStartChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> End
        {
            get
            {
                return _End;
            }
            set
            {
                OnEndChanging(value);
                ReportPropertyChanging("End");
                _End = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("End");
                OnEndChanged();
            }
        }
        private Nullable<global::System.DateTime> _End;
        partial void OnEndChanging(Nullable<global::System.DateTime> value);
        partial void OnEndChanged();
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                OnDeletedChanging(value);
                ReportPropertyChanging("Deleted");
                _Deleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Deleted");
                OnDeletedChanged();
            }
        }
        private global::System.Boolean _Deleted;
        partial void OnDeletedChanging(global::System.Boolean value);
        partial void OnDeletedChanged();

        #endregion
    
    }

    #endregion
    
}
