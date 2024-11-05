﻿using FluentMigrator;

namespace EdirSalesBancoDeDados.Infrastructure.Migrations
{
    [Migration(2)]
    public class Version00002 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Grupos")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()  // Chave primária com auto-incremento
               .WithColumn("NomeGrupo").AsString(255).NotNullable()  // Nome do Grupo

               // Campos herdados de EntityBase
               .WithColumn("DataCadastro").AsDateTime().Nullable()  // Data de cadastro
               .WithColumn("DataAlteracao").AsDateTime().Nullable()  // Data de alteração
               .WithColumn("UsuarioCadastroId").AsInt32().Nullable()  // Usuário que cadastrou
               .WithColumn("UsuarioAlteracaoId").AsInt32().Nullable();  // Usuário que alterou
        }
    }
}
