import React from "react";

export default class ConsultarRepos extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaUserRepos: [],
            user: ''
        };
    };

    buscaRepos = () => {
        console.log("agora faremos a chamada para a API")

        fetch('https://api.github.com/users/saulomsantos/repos')

            .then(userRepos => userRepos.json())

            .then(infos => this.setState({ listaUserRepos: infos }))

            .catch(erro => console.log(erro))

    }




    componentDidMount() {
        this.buscaRepos()
    }


    atualizaNomeUsuario = async (event) => {
        //Nome Usuario > valor input.
        await this.setState({ user: event.target.value })
        console.log(this.state.user)
    }



    render() {
        return (
            <div>
                <main>
                    <section>
                        <h2>Lista de Repositorios do Usuario</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Nome do Repositorio</th>
                                    <th>Descrição</th>
                                    <th>Data de Criação</th>
                                    <th>Tamanho</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.listaUserRepos.map((repositorio) => {
                                        return (
                                            <tr key={repositorio.id}>
                                                <td>{repositorio.id}</td>
                                                <td>{repositorio.name}</td>
                                                <td>{repositorio.description}</td>
                                                <td>{repositorio.created_at}</td>
                                                <td>{repositorio.size}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                    <h2>Listagem de repositórios públicos do Usuário gitHub</h2>
                    <form onSubmit={this.cadastrarTipoEvento}>
                        <div>
                            <input
                                type="text"
                                //atualiza o tipo de input
                                //valor do status é do input
                                value={this.state.user}
                                placeholder="Insira o nome do usuario"
                                //cada vez que tiver uma mudanca (por tecla)
                                onChange={this.atualizaNomeUsuario}
                            />

                            <button type="button" onClick={this.limparCampos} style={{ display: '' }}>
                                Cancelar
                            </button>

                        </div>
                    </form>
                    <section>

                    </section>
                </main>
            </div>

        )
    }
}

