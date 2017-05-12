ALTER TABLE [Cliente] ADD [Sobrenome] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170425203944_AddColumnCliente', N'1.1.1');

GO

CREATE TABLE [Estoque] (
    [IdEstoque] int NOT NULL,
    [Ativo] bit NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [IdProduto] int NOT NULL,
    [Quantidade] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Estoque] PRIMARY KEY ([IdEstoque]),
    CONSTRAINT [FK_Estoque_Produto_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produto] ([IdProduto]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Estoque_IdProduto] ON [Estoque] ([IdProduto]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170426023421_AddTableEstoque', N'1.1.1');

GO

