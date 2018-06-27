using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LabooGF.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class GFContext : DbContext
    {
        public DbSet<Responsavel> Responsaveis
        {
            get;
            set;
        }

        public DbSet<Aluno> Alunos
        {
            get;
            set;
        }

        public DbSet<Voluntario> Voluntarios
        {
            get;
            set;
        }

        //Referência para o nome da string de conexão
        public GFContext() : base("gf") { }

        //Desabilita o padrão de gerar os nomes das tabelas no plural.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}