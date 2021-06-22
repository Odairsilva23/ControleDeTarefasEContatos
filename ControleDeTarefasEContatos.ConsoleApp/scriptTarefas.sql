insert into TBtarefas
	(
		[Titulo],
		[NivelDePrioridade],
		[DatadeCriacao], 
		[DataConclusao], 
		[PercentualConcluido]
		
	) 
	values 
	(
		'concerta ctr',
		 'Alta',
		'06/12/2021',
		'06/14/2021',
		30
		
	)

	SELECT SCOPE_IDENTITY();
insert into TBtarefas
	(
		[Titulo],
		[NivelDePrioridade],
		[DatadeCriacao], 
		[DataConclusao], 
		[PercentualConcluido]
	) 
	values 
	(
		'concertadsdsad',
		 'Baixa',
		'06/12/2021',
		'06/14/2021',
		100
	)
insert into TBtarefas 
	(
		[Titulo],
		[NivelDePrioridade],
		[DatadeCriacao], 
		[DataConclusao], 
		[PercentualConcluido]
	) 
	values 
	(
		'concerta ctr',
		 'Alta',
		'06/12/2021',
		'06/14/2021',
		30
	)
update TBtarefas 
	set	
		[NivelDePrioridade] = 1,
		[Titulo] = 'Lavar Telhado' ,
		[DataConclusao] = '06/14/2021',
		[PercentualConcluido] = '35'
	where 
		[Id] = 4

Delete from TBCadastroTarefas 
	where 
		[Id] = 1

select [Id], [Titulo],[NivelDePrioridade], [DatadeCriacao], [DataConclusao],[PercentualConcluido] from TBtarefas

select [Id], [Titulo],[NivelDePrioridade], [DatadeCriacao], [DataConclusao],[PercentualConcluido] from TBtarefas
	where 
	[Id] = 3
select [Id], [Titulo],[NivelDePrioridade], [DatadeCriacao], [DataConclusao],[PercentualConcluido] from TBtarefas
	ORDER BY 
	[NivelDePrioridade], [PercentualConcluido] 