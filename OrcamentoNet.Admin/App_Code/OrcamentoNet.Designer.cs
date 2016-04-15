﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4223
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("OrcamentoNetModel", "FK_Estado", "estado", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(OrcamentoNetModel.estado), "cidade", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(OrcamentoNetModel.cidade))]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("OrcamentoNetModel", "pedido_orcamento_cidade", "pedido_orcamento", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(OrcamentoNetModel.pedido_orcamento), "cidade", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(OrcamentoNetModel.cidade))]

// Original file name:
// Generation date: 28/07/2012 13:22:49
namespace OrcamentoNetModel
{
    
    /// <summary>
    /// There are no comments for OrcamentoNetEntities in the schema.
    /// </summary>
    public partial class OrcamentoNetEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new OrcamentoNetEntities object using the connection string found in the 'OrcamentoNetEntities' section of the application configuration file.
        /// </summary>
        public OrcamentoNetEntities() : 
                base("name=OrcamentoNetEntities", "OrcamentoNetEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new OrcamentoNetEntities object.
        /// </summary>
        public OrcamentoNetEntities(string connectionString) : 
                base(connectionString, "OrcamentoNetEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new OrcamentoNetEntities object.
        /// </summary>
        public OrcamentoNetEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "OrcamentoNetEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for cidade in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<cidade> cidade
        {
            get
            {
                if ((this._cidade == null))
                {
                    this._cidade = base.CreateQuery<cidade>("[cidade]");
                }
                return this._cidade;
            }
        }
        private global::System.Data.Objects.ObjectQuery<cidade> _cidade;
        /// <summary>
        /// There are no comments for estado in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<estado> estado
        {
            get
            {
                if ((this._estado == null))
                {
                    this._estado = base.CreateQuery<estado>("[estado]");
                }
                return this._estado;
            }
        }
        private global::System.Data.Objects.ObjectQuery<estado> _estado;
        /// <summary>
        /// There are no comments for pedido_orcamento in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<pedido_orcamento> pedido_orcamento
        {
            get
            {
                if ((this._pedido_orcamento == null))
                {
                    this._pedido_orcamento = base.CreateQuery<pedido_orcamento>("[pedido_orcamento]");
                }
                return this._pedido_orcamento;
            }
        }
        private global::System.Data.Objects.ObjectQuery<pedido_orcamento> _pedido_orcamento;
        /// <summary>
        /// There are no comments for cidade in the schema.
        /// </summary>
        public void AddTocidade(cidade cidade)
        {
            base.AddObject("cidade", cidade);
        }
        /// <summary>
        /// There are no comments for estado in the schema.
        /// </summary>
        public void AddToestado(estado estado)
        {
            base.AddObject("estado", estado);
        }
        /// <summary>
        /// There are no comments for pedido_orcamento in the schema.
        /// </summary>
        public void AddTopedido_orcamento(pedido_orcamento pedido_orcamento)
        {
            base.AddObject("pedido_orcamento", pedido_orcamento);
        }
    }
    /// <summary>
    /// There are no comments for OrcamentoNetModel.cidade in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Cd_Cidade
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="OrcamentoNetModel", Name="cidade")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class cidade : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new cidade object.
        /// </summary>
        /// <param name="cd_Cidade">Initial value of Cd_Cidade.</param>
        /// <param name="nm_Cidade">Initial value of Nm_Cidade.</param>
        public static cidade Createcidade(long cd_Cidade, string nm_Cidade)
        {
            cidade cidade = new cidade();
            cidade.Cd_Cidade = cd_Cidade;
            cidade.Nm_Cidade = nm_Cidade;
            return cidade;
        }
        /// <summary>
        /// There are no comments for Property Cd_Cidade in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long Cd_Cidade
        {
            get
            {
                return this._Cd_Cidade;
            }
            private set
            {
                this.OnCd_CidadeChanging(value);
                this.ReportPropertyChanging("Cd_Cidade");
                this._Cd_Cidade = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Cd_Cidade");
                this.OnCd_CidadeChanged();
            }
        }
        private long _Cd_Cidade;
        partial void OnCd_CidadeChanging(long value);
        partial void OnCd_CidadeChanged();
        /// <summary>
        /// There are no comments for Property Nm_Cidade in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Nm_Cidade
        {
            get
            {
                return this._Nm_Cidade;
            }
            set
            {
                this.OnNm_CidadeChanging(value);
                this.ReportPropertyChanging("Nm_Cidade");
                this._Nm_Cidade = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Nm_Cidade");
                this.OnNm_CidadeChanged();
            }
        }
        private string _Nm_Cidade;
        partial void OnNm_CidadeChanging(string value);
        partial void OnNm_CidadeChanged();
        /// <summary>
        /// There are no comments for estado in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("OrcamentoNetModel", "FK_Estado", "estado")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public estado estado
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<estado>("OrcamentoNetModel.FK_Estado", "estado").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<estado>("OrcamentoNetModel.FK_Estado", "estado").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for estado in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<estado> estadoReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<estado>("OrcamentoNetModel.FK_Estado", "estado");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<estado>("OrcamentoNetModel.FK_Estado", "estado", value);
                }
            }
        }
        /// <summary>
        /// There are no comments for pedido_orcamento in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("OrcamentoNetModel", "pedido_orcamento_cidade", "pedido_orcamento")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<pedido_orcamento> pedido_orcamento
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<pedido_orcamento>("OrcamentoNetModel.pedido_orcamento_cidade", "pedido_orcamento");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<pedido_orcamento>("OrcamentoNetModel.pedido_orcamento_cidade", "pedido_orcamento", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for OrcamentoNetModel.estado in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Cd_Estado
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="OrcamentoNetModel", Name="estado")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class estado : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new estado object.
        /// </summary>
        /// <param name="cd_Estado">Initial value of Cd_Estado.</param>
        /// <param name="nm_Estado">Initial value of Nm_Estado.</param>
        /// <param name="sg_Estado">Initial value of Sg_Estado.</param>
        public static estado Createestado(long cd_Estado, string nm_Estado, string sg_Estado)
        {
            estado estado = new estado();
            estado.Cd_Estado = cd_Estado;
            estado.Nm_Estado = nm_Estado;
            estado.Sg_Estado = sg_Estado;
            return estado;
        }
        /// <summary>
        /// There are no comments for Property Cd_Estado in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long Cd_Estado
        {
            get
            {
                return this._Cd_Estado;
            }
            private set
            {
                this.OnCd_EstadoChanging(value);
                this.ReportPropertyChanging("Cd_Estado");
                this._Cd_Estado = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Cd_Estado");
                this.OnCd_EstadoChanged();
            }
        }
        private long _Cd_Estado;
        partial void OnCd_EstadoChanging(long value);
        partial void OnCd_EstadoChanged();
        /// <summary>
        /// There are no comments for Property Nm_Estado in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Nm_Estado
        {
            get
            {
                return this._Nm_Estado;
            }
            set
            {
                this.OnNm_EstadoChanging(value);
                this.ReportPropertyChanging("Nm_Estado");
                this._Nm_Estado = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Nm_Estado");
                this.OnNm_EstadoChanged();
            }
        }
        private string _Nm_Estado;
        partial void OnNm_EstadoChanging(string value);
        partial void OnNm_EstadoChanged();
        /// <summary>
        /// There are no comments for Property Sg_Estado in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Sg_Estado
        {
            get
            {
                return this._Sg_Estado;
            }
            set
            {
                this.OnSg_EstadoChanging(value);
                this.ReportPropertyChanging("Sg_Estado");
                this._Sg_Estado = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Sg_Estado");
                this.OnSg_EstadoChanged();
            }
        }
        private string _Sg_Estado;
        partial void OnSg_EstadoChanging(string value);
        partial void OnSg_EstadoChanged();
        /// <summary>
        /// There are no comments for cidade in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("OrcamentoNetModel", "FK_Estado", "cidade")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<cidade> cidade
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<cidade>("OrcamentoNetModel.FK_Estado", "cidade");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<cidade>("OrcamentoNetModel.FK_Estado", "cidade", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for OrcamentoNetModel.pedido_orcamento in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Cd_Pedido_Orcamento
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="OrcamentoNetModel", Name="pedido_orcamento")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
	public partial class pedido_orcamento : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new pedido_orcamento object.
        /// </summary>
        /// <param name="cd_Pedido_Orcamento">Initial value of Cd_Pedido_Orcamento.</param>
        /// <param name="email_Validado">Initial value of Email_Validado.</param>
        public static pedido_orcamento Createpedido_orcamento(long cd_Pedido_Orcamento, bool email_Validado)
        {
            pedido_orcamento pedido_orcamento = new pedido_orcamento();
            pedido_orcamento.Cd_Pedido_Orcamento = cd_Pedido_Orcamento;
            pedido_orcamento.Email_Validado = email_Validado;
            return pedido_orcamento;
        }
        /// <summary>
        /// There are no comments for Property Cd_Pedido_Orcamento in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long Cd_Pedido_Orcamento
        {
            get
            {
                return this._Cd_Pedido_Orcamento;
            }
            private set
            {
                this.OnCd_Pedido_OrcamentoChanging(value);
                this.ReportPropertyChanging("Cd_Pedido_Orcamento");
                this._Cd_Pedido_Orcamento = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Cd_Pedido_Orcamento");
                this.OnCd_Pedido_OrcamentoChanged();
            }
        }
        private long _Cd_Pedido_Orcamento;
        partial void OnCd_Pedido_OrcamentoChanging(long value);
        partial void OnCd_Pedido_OrcamentoChanged();
        /// <summary>
        /// There are no comments for Property Dt_Cadastro in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> Dt_Cadastro
        {
            get
            {
                return this._Dt_Cadastro;
            }
            set
            {
                this.OnDt_CadastroChanging(value);
                this.ReportPropertyChanging("Dt_Cadastro");
                this._Dt_Cadastro = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Dt_Cadastro");
                this.OnDt_CadastroChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _Dt_Cadastro;
        partial void OnDt_CadastroChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnDt_CadastroChanged();
        /// <summary>
        /// There are no comments for Property Email in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnEmailChanging(value);
                this.ReportPropertyChanging("Email");
                this._Email = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Email");
                this.OnEmailChanged();
            }
        }
        private string _Email;
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        /// <summary>
        /// There are no comments for Property Nm_Comprador in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Nm_Comprador
        {
            get
            {
                return this._Nm_Comprador;
            }
            set
            {
                this.OnNm_CompradorChanging(value);
                this.ReportPropertyChanging("Nm_Comprador");
                this._Nm_Comprador = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Nm_Comprador");
                this.OnNm_CompradorChanged();
            }
        }
        private string _Nm_Comprador;
        partial void OnNm_CompradorChanging(string value);
        partial void OnNm_CompradorChanged();
        /// <summary>
        /// There are no comments for Property Observacao in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Observacao
        {
            get
            {
                return this._Observacao;
            }
            set
            {
                this.OnObservacaoChanging(value);
                this.ReportPropertyChanging("Observacao");
                this._Observacao = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Observacao");
                this.OnObservacaoChanged();
            }
        }
        private string _Observacao;
        partial void OnObservacaoChanging(string value);
        partial void OnObservacaoChanged();
        /// <summary>
        /// There are no comments for Property Telefone in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefone
        {
            get
            {
                return this._Telefone;
            }
            set
            {
                this.OnTelefoneChanging(value);
                this.ReportPropertyChanging("Telefone");
                this._Telefone = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Telefone");
                this.OnTelefoneChanged();
            }
        }
        private string _Telefone;
        partial void OnTelefoneChanging(string value);
        partial void OnTelefoneChanged();
        /// <summary>
        /// There are no comments for Property Titulo in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Titulo
        {
            get
            {
                return this._Titulo;
            }
            set
            {
                this.OnTituloChanging(value);
                this.ReportPropertyChanging("Titulo");
                this._Titulo = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Titulo");
                this.OnTituloChanged();
            }
        }
        private string _Titulo;
        partial void OnTituloChanging(string value);
        partial void OnTituloChanged();
        /// <summary>
        /// There are no comments for Property Dt_Alteracao in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> Dt_Alteracao
        {
            get
            {
                return this._Dt_Alteracao;
            }
            set
            {
                this.OnDt_AlteracaoChanging(value);
                this.ReportPropertyChanging("Dt_Alteracao");
                this._Dt_Alteracao = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Dt_Alteracao");
                this.OnDt_AlteracaoChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _Dt_Alteracao;
        partial void OnDt_AlteracaoChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnDt_AlteracaoChanged();
        /// <summary>
        /// There are no comments for Property Email_Validado in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public bool Email_Validado
        {
            get
            {
                return this._Email_Validado;
            }
            set
            {
                this.OnEmail_ValidadoChanging(value);
                this.ReportPropertyChanging("Email_Validado");
                this._Email_Validado = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Email_Validado");
                this.OnEmail_ValidadoChanged();
            }
        }
        private bool _Email_Validado;
        partial void OnEmail_ValidadoChanging(bool value);
        partial void OnEmail_ValidadoChanged();
        /// <summary>
        /// There are no comments for Property Gostou in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<bool> Gostou
        {
            get
            {
                return this._Gostou;
            }
            set
            {
                this.OnGostouChanging(value);
                this.ReportPropertyChanging("Gostou");
                this._Gostou = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Gostou");
                this.OnGostouChanged();
            }
        }
        private global::System.Nullable<bool> _Gostou;
        partial void OnGostouChanging(global::System.Nullable<bool> value);
        partial void OnGostouChanged();
        /// <summary>
        /// There are no comments for Property Opiniao_Comprador in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Opiniao_Comprador
        {
            get
            {
                return this._Opiniao_Comprador;
            }
            set
            {
                this.OnOpiniao_CompradorChanging(value);
                this.ReportPropertyChanging("Opiniao_Comprador");
                this._Opiniao_Comprador = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Opiniao_Comprador");
                this.OnOpiniao_CompradorChanged();
            }
        }
        private string _Opiniao_Comprador;
        partial void OnOpiniao_CompradorChanging(string value);
        partial void OnOpiniao_CompradorChanged();
        /// <summary>
        /// There are no comments for Property Pesquisa_Respondida in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<bool> Pesquisa_Respondida
        {
            get
            {
                return this._Pesquisa_Respondida;
            }
            set
            {
                this.OnPesquisa_RespondidaChanging(value);
                this.ReportPropertyChanging("Pesquisa_Respondida");
                this._Pesquisa_Respondida = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Pesquisa_Respondida");
                this.OnPesquisa_RespondidaChanged();
            }
        }
        private global::System.Nullable<bool> _Pesquisa_Respondida;
        partial void OnPesquisa_RespondidaChanging(global::System.Nullable<bool> value);
        partial void OnPesquisa_RespondidaChanged();
        /// <summary>
        /// There are no comments for Property Pesquisa_Revisada in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<bool> Pesquisa_Revisada
        {
            get
            {
                return this._Pesquisa_Revisada;
            }
            set
            {
                this.OnPesquisa_RevisadaChanging(value);
                this.ReportPropertyChanging("Pesquisa_Revisada");
                this._Pesquisa_Revisada = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Pesquisa_Revisada");
                this.OnPesquisa_RevisadaChanged();
            }
        }
        private global::System.Nullable<bool> _Pesquisa_Revisada;
        partial void OnPesquisa_RevisadaChanging(global::System.Nullable<bool> value);
        partial void OnPesquisa_RevisadaChanged();
        /// <summary>
        /// There are no comments for Property Pontos_Melhoria in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Pontos_Melhoria
        {
            get
            {
                return this._Pontos_Melhoria;
            }
            set
            {
                this.OnPontos_MelhoriaChanging(value);
                this.ReportPropertyChanging("Pontos_Melhoria");
                this._Pontos_Melhoria = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Pontos_Melhoria");
                this.OnPontos_MelhoriaChanged();
            }
        }
        private string _Pontos_Melhoria;
        partial void OnPontos_MelhoriaChanging(string value);
        partial void OnPontos_MelhoriaChanged();
        /// <summary>
        /// There are no comments for Property Status_Pedido_Comprador in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> Status_Pedido_Comprador
        {
            get
            {
                return this._Status_Pedido_Comprador;
            }
            set
            {
                this.OnStatus_Pedido_CompradorChanging(value);
                this.ReportPropertyChanging("Status_Pedido_Comprador");
                this._Status_Pedido_Comprador = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Status_Pedido_Comprador");
                this.OnStatus_Pedido_CompradorChanged();
            }
        }
        private global::System.Nullable<long> _Status_Pedido_Comprador;
        partial void OnStatus_Pedido_CompradorChanging(global::System.Nullable<long> value);
        partial void OnStatus_Pedido_CompradorChanged();
        /// <summary>
        /// There are no comments for cidade in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("OrcamentoNetModel", "pedido_orcamento_cidade", "cidade")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public cidade cidade
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<cidade>("OrcamentoNetModel.pedido_orcamento_cidade", "cidade").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<cidade>("OrcamentoNetModel.pedido_orcamento_cidade", "cidade").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for cidade in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<cidade> cidadeReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<cidade>("OrcamentoNetModel.pedido_orcamento_cidade", "cidade");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<cidade>("OrcamentoNetModel.pedido_orcamento_cidade", "cidade", value);
                }
            }
        }
    }
}