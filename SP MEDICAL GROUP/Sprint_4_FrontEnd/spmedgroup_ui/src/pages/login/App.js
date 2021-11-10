
import "../../assets/css/style_geral.css"

function App() {
  return (
    <div className="body_login">
        <div className="grid posix_login">
            <div className="bem_vindo_login">
                <div className="img_medicos_login"></div>
                <div className="msg_login">
                    <h1>SP Medical Group</h1>
                    <p>Fique tranquilo, nossa família de especialistas em saúde vai cuidar da
                        sua!
                    </p>
                </div>
            </div>
            <div className="box_login">
                <form action="" className="dados_login">
                    <h1>Entre e seja bem-vindo!</h1>
                    <div className="inputs_login">
                        <input type="email" name="" id="" placeholder="E-mail" />
                        <input type="password" name="" id="" placeholder="Senha" />
                        <button type="submit">Entrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
  );
}

export default App;
