import { useEffect, useState } from 'react';
import './App.css';

function App() {
    function FavoritesButton({ filmResults, criarLinkLista }) {
        return (
            <button onClick={() => criarLinkLista(filmResults)}>Compartilhar</button>
        )
    }

    function PageContents({ filmResults, setFilmResults, mostrarLista }) {
        function FilmButton({ film, buttonState, mostrarLista }) {
            function removerFilme(id) {
                let url = `${server}/${id}`
                const requestOptions = {
                    method: 'DELETE',
                };
                fetch(url, requestOptions);
            }

            var filmButton;
            if (buttonState === 1) {
                filmButton = <button onClick={() => adicionarFilme(film)}>Adicionar Filme</button>
            } else if (buttonState === 2) {
                filmButton = <button onClick={() => { removerFilme(film.id); mostrarLista() }}>Remover Filme</button>
            }
            return (
                filmButton
            );
        }

        return (
            filmResults === undefined
                ? <p><em>Digite o título a buscar na base de dados, ou cheque seus filmes já salvos</em></p>
                : <div>
                    <table className="table table-striped" aria-labelledby="tableLabel">
                        <thead>
                            <tr>
                                <th>Poster</th>
                                <th>Id</th>
                                <th>Title</th>
                                <th>Original Language</th>
                                <th>Original Title</th>
                                <th>Popularity</th>
                                <th>Release Date</th>
                                <th>Vote average</th>
                                <th>Vote count</th>
                                <th>Adicionar filme na lista</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filmResults.map(film =>
                                <tr key={film.id}>
                                    <td><img src={film.poster_path} alt={film.title}></img></td>
                                    <td>{film.id}</td>
                                    <td>{film.title}</td>
                                    <td>{film.original_language}</td>
                                    <td>{film.original_title}</td>
                                    <td>{film.popularity}</td>
                                    <td>{film.release_date}</td>
                                    <td>{film.vote_average}</td>
                                    <td>{film.vote_count}</td>
                                    <td><FilmButton film={film} buttonState={buttonState} filmResults={filmResults} setFilmResults={setFilmResults} mostrarLista={mostrarLista} /></td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    <FavoritesButton filmResults={filmResults} criarLinkLista={criarLinkLista} setSharedLink={setSharedLink} setbuttonState={setbuttonState} buttonState={buttonState} />
                </div> 
        )
    }

    function ShareLink() {
        if (filmResults === undefined) {
            if (buttonState === 0)
            return (
                <div><p>Link para compartilhamento: </p><a href={sharedLink}>{sharedLink}</a></div>
            )
        }
        return 
    }

    const [filmResults, setFilmResults] = useState();
    const [buttonState, setbuttonState] = useState();
    const [sharedLink, setSharedLink] = useState();
    const server = 'https://localhost:7102/api/TMDB';

    useEffect(() => {
        
    }, []);

    const caixaPesquisa = <input type="text" name="nomeFilme" id="nomeFilme" placeholder="Insira o nome do filme"></input>
    const botaoPesquisa = <button onClick={buscarFilme}>Buscar Filme</button>
    const botaoLista = <button onClick={mostrarLista}>Mostrar Lista</button>
    const botaoInicio = <button onClick={limparTela}>Limpar tela</button>

    return (
        <div>
            <img id="attrib_logo" src="https://www.themoviedb.org/assets/2/v4/logos/v2/blue_square_1-5bdc75aaebeb75dc7ae79426ddd9be3b2be1e342510f8202baf6bffa71d7f5c4.svg" />
            <h1 id="tableLabel">Lista de filmes</h1>
            <p>Busque filmes e os salve em listas personalizadas</p>
            {caixaPesquisa}
            {botaoPesquisa}
            {botaoLista}
            {botaoInicio}
            <PageContents filmResults={filmResults} setFilmResults={setFilmResults} mostrarLista={mostrarLista} />
            <ShareLink />
            <p>This product uses the TMDB API but is not endorsed or certified by TMDB.</p>
        </div>
    );

    async function buscarFilme() {
        let nome = document.getElementById("nomeFilme").value;
        let movieTitle = nome.replaceAll(" ", "+");
        if (movieTitle === "") {
            console.log("O campo de pesquisa está vazio")
            return
        }
        let url = `${server}/${movieTitle}`

        //console.log(url)
        const response = await fetch(url);
        const data = await response.json();
        setFilmResults(data);
        setbuttonState(1);
    }

    function adicionarFilme(film) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                id: film.id,
                title: film.title,
                original_language: film.original_language,
                original_title: film.original_title,
                popularity: film.popularity,
                release_date: film.release_date,
                vote_average: film.vote_average,
                vote_count: film.vote_count,
                poster_path: film.poster_path
            })
        };
        fetch(server, requestOptions)
            .then(response => response.json())
    }

    async function mostrarLista() {
        let url = `${server}/getlist/basic`
        const response = await fetch(url);
        const data = await response.json();
        setFilmResults(data);
        setbuttonState(2);
    }

    function limparTela(code) {
        setFilmResults(undefined);
        setbuttonState(code);
    }

    function criarLinkLista(filmResults) {
        let url = `${server}/getlist/shareable?`;
        let something = filmResults.map(film => film.id + "+" + film.title.replace(/ /g, "_"));
        something.forEach((element) => url += "favorite=" + element + "&");
        limparTela(0)
        let ourLink = url.slice(0, url.length - 1)
        setSharedLink(ourLink);
        console.log(sharedLink);
        console.log(ourLink);
    }  
}

export default App;