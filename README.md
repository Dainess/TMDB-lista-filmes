# Lista de filmes

## Objetivo: 
Programa para um usuário criar listas de filmes a partir da API do TMDB

## Requisitos:
### Front-End:
        - Interface de pesquisa de filmes.
        - Exibição de detalhes dos filmes, incluindo a nota do TMDb.
        - Gerenciamento da lista de filmes favoritos (adicionar/remover).

### Back-End:
        - Gerenciamento de chamadas para a API do TMDb.
        - Armazenamento da lista de favoritos.
        - Lógica para compartilhar a lista de favoritos via link.

## Instruções de uso:
1) Baixe o projeto do GitHub
2) Crie uma conta no TMDB e requisite uma API de desenvolvedor
3) dentro do diretório onde o repo for clonado, vá em TMDBMovieList\tmdbmovielist.client\src 
4) crie dentro deste diretório um arquivo chamado config.js e o salve com o seguinte código:
	```
		var config = {
			TMDB_BEARER: 'TOKEN'
		}
	```
	trocando a palavra TOKEN pelo seu token de acesso da API obtida no TMDB.

5) Abra o Projeto no Visual Studio 2022
6) Clique em Start. Abrirá uma tela do navegador com a interface e o programa estará apto para uso

## O que não funciona como esperado:
1) O botão Remover Filme não atualiza a tela, precisa clicar de novo em Mostra Lista para ver o resultado
2) O link gerado só vai funcionar na máquina rodando a aplicação, não foi possível levantar um Heroku para o link ser compartilhável
3) Tal link também não está criptografado
4) Tratamento de dados não existe, o programa é ingênuo e confia que o dado virá bem tratado da API
5) Os links criados não estão em Unicode e estranham caracteres como 'ã'

## Tecnologias escolhidas:
	React, C# e MySQL 

## TO-DO:
	- CHECK Pesquisar filmes (uma caixa de busca e uma interface com os resultados)
	- CHECK Deve aparecer filme ou filmes na tela com as infos, especialmente a nota do TMDB
	- CHECK Usuário deve conseguir salvar filmes em uma lista	
	- CHECK um db 
		- tabela lista e filme? não tem pq ter usuario se a aplicação é local
			- apenas tabela filme na versão com uma lista só
		- duas opções: 
			- salvar todos os dados do filme no db ou 
			- salvar só id e título e recuperar pela API a cada exibição
				segunda opção escolhida
				- ficou bastante lento, talvez seja melhor reconsiderar
	- CHECK Opção para abrir a lista e ver todos os filmes nela
	- CHECK Limpar a tela
	- CHECK Remover os itens da lista
	- CHECK Usuário deve ser capaz de gerar um link de uma lista e compartilhar
		??? não está claro se ele precisa compartilhar essa lista com outros usuários ou um link qualquer de acesso
		a internet (provavelmente a segunda)
	- CHECK Exibir um pôster de cada filme
	- FAIL Remover não atualiza o mostra lista, precisa clicar de novo
	- README com passo a passo para configurar e executar a aplicação
		quaisquer problemas com a aplicação devem ser mencionados no README
	- CHECK Requisitos de atribuição
		You shall use the TMDB logo to identify your use of the TMDB APIs. You shall place the following notice prominently on your application: "This product uses the TMDB API but is not endorsed or certified by TMDB."
		Any use of the TMDB logo in your application shall be less prominent than the logo or mark that primarily describes the application and your use of the TMDB logo shall not imply any endorsement by TMDB. When attributing TMDB, the attribution must be within your application's "About" or "Credits" type section.
		When using a TMDB logo, we require you to use one of our approved logos.
	- CHECK eu não sei se esse db salvo desse jeito vai funcionar em um release?
	- CHECK proteger chaves de API
	- tratamento de erros (fluentvalidation)
		erro da busca vazia não funcionou
	- formato de exibição do release_date
	- vc precisa tratar esses dados que tão chegando, só fez pra release_date
	- passar esses requests e responses pra classes JSON apropriadas
	- Opção de múltiplas listas, lista default são "favoritos"
		- múltiplas listas vai pedir uma relação muitos-para-muitos entre filmes e listas
	- Ranquear os itens da lista 
	- Opção de buscar os filmes top rated
	- troca dos links no react pelo nome da entity
	- permitir buscas amplas (por ano, por gênero, país, língua original)
	- sincronia imperfeita entre Mostrar Lista e Adicionar Filme
	- async/await
	- testes unitários e de integração
	- deployment na Vercel
	- SSL
	- múltiplos usuários

## Sobre:
Projeto realizado por Daniel Couto Mittelman.
This product uses the TMDB API but is not endorsed or certified by TMDB.