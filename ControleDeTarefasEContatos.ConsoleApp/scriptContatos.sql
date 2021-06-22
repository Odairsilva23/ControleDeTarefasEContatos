insert into TBcontatos
	(
		[Nome],
		[Email],
		[Telefone], 
		[Empresa], 
		[Cargo]
		
	) 
	values 
	(
		'Pedro',
		 'pedro@gmail.com',
		'95959595',
		'ndd',
		'estagiario'
		
	)
insert into TBcontatos
	(
		[Nome],
		[Email],
		[Telefone], 
		[Empresa], 
		[Cargo]
		
	) 
	values 
	(
		'Lucas detoffol',
		 'Lucastf@gmail.com',
		'9595959595',
		'ndd',
		'estagiario'
		
	)
insert into TBcontatos
	(
		[Nome],
		[Email],
		[Telefone], 
		[Empresa], 
		[Cargo]
		
	) 
	values 
	(
		'Rech',
		 'Rech@gmail.com',
		'854585485',
		'ndd',
		'Cacique'	
	)
Delete from TBcontatos 
	where 
		[Id] = 1

select [Id], [Nome],[Email], [Telefone], [Empresa],[Cargo] from TBcontatos

select [Id], [Nome],[Email], [Telefone], [Empresa],[Cargo] from TBcontatos
	where 
	[Id] = 3
