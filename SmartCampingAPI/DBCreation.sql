CREATE TABLE [dbo].[TipoAlojamento](
	[TipoAlojamentoId] INT IDENTITY(1,1) NOT NULL,
	[Tipo] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([TipoAlojamentoId] ASC)
);

CREATE TABLE [dbo].[Alojamento](
	[AlojamentoId] INT IDENTITY(1,1) NOT NULL,
	[TipoAlojamentoId] INT NOT NULL,
	[Nome] VARCHAR(MAX) NOT NULL,
	[Descricao] VARCHAR(50) NOT NULL,
	[Capacidade] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([AlojamentoId] ASC),
	CONSTRAINT [FK_Alojamento_TipoAlojamento] FOREIGN KEY ([TipoAlojamentoId]) REFERENCES [dbo].[TipoAlojamento] ([TipoAlojamentoId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[MetodoPagamento](
	[MetodoPagamentoId] INT IDENTITY(1,1) NOT NULL,
	[Metodo] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([MetodoPagamentoId] ASC)
);

CREATE TABLE [dbo].[EstadoReserva](
	[EstadoReservaId] INT IDENTITY(1,1) NOT NULL,
	[Estado] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([EstadoReservaId] ASC),
);

CREATE TABLE [dbo].[TipoUtilizador](
	[TipoUtilizadorId] INT IDENTITY(1,1) NOT NULL,
	[Tipo] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([TipoUtilizadorId] ASC)
);

CREATE TABLE [dbo].[Utilizador](
	[UtilizadorId] INT IDENTITY(1,1) NOT NULL,
	[TipoUtilizadorId] INT NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[PalavraPasse] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([UtilizadorId] ASC),
	CONSTRAINT [FK_Utiliador_TipoUtilizador] FOREIGN KEY ([TipoUtilizadorId]) REFERENCES [dbo].[TipoUtilizador] ([TipoUtilizadorId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Funcionario](
	[FuncionarioId] INT IDENTITY(1,1) NOT NULL,
	[UtilizadorId] INT NOT NULL,
	[Nome] VARCHAR(100) NOT NULL,
	[Telemovel] INT NOT NULL,
	[Departamento] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([FuncionarioId] ASC),
	CONSTRAINT [FK_Fucionario_Utilizador] FOREIGN KEY ([UtilizadorId]) REFERENCES [dbo].[Utilizador] ([UtilizadorId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Cliente](
	[ClienteId] INT IDENTITY(1,1) NOT NULL,
	[UtilizadorId] INT NOT NULL,
	[Nome] VARCHAR(100) NOT NULL,
	[Telemovel] INT NOT NULL,
	[NIF] INT NOT NULL,
	[Morada] VARCHAR(MAX) NOT NULL,
	[CodPostal] VARCHAR(8) NOT NULL,
	[Localidade] VARCHAR(100) NOT NULL,
	PRIMARY KEY CLUSTERED ([ClienteId] ASC),
	CONSTRAINT [FK_Cliente_Utilizador] FOREIGN KEY ([UtilizadorId]) REFERENCES [dbo].[Utilizador] ([UtilizadorId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Reserva](
	[ReservaId] INT IDENTITY(1,1) NOT NULL,
	[ClienteId] INT NOT NULL,
	[AlojamentoId] INT NOT NULL,
	[MetodoId] INT NOT NULL,
	[EstadoId] INT NOT NULL,
	[DataInicio] VARCHAR(MAX) NOT NULL,
	[DataFim] VARCHAR(MAX) NOT NULL,
	[PrecoTotal] MONEY NOT NULL,
	[Pagamento] MONEY NOT NULL,
	PRIMARY KEY CLUSTERED ([ReservaId] ASC),
	CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([ClienteId]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_Reserva_Alojamento] FOREIGN KEY ([AlojamentoId]) REFERENCES [dbo].[Alojamento] ([AlojamentoId]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_Reserva_MetodoPag] FOREIGN KEY ([MetodoId]) REFERENCES [dbo].[MetodoPagamento] ([MetodoPagamentoId]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_Reserva_EstadoReserva] FOREIGN KEY ([EstadoId]) REFERENCES [dbo].[EstadoReserva] ([EstadoReservaId]) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE [dbo].[AlojamentoFotos](
	[AlojamentoFotosId] INT IDENTITY(1,1) NOT NULL,
	[AlojamentoId] INT NOT NULL,
	[Caminho] nvarchar(max) NOT NULL,
	PRIMARY KEY CLUSTERED ([AlojamentoFotosId] ASC),
	CONSTRAINT [FK_AlojamentoFotos_Alojamento] FOREIGN KEY ([AlojamentoId]) REFERENCES [dbo].[Alojamentos] ([AlojamentoId]) ON DELETE CASCADE ON UPDATE CASCADE
);