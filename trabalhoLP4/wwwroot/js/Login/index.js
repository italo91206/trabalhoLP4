let index = {
    login: function () {
        var login = document.getElementById('usuario').value;
        var senha = document.getElementById('senha').value;
        var errors = document.getElementById('errors');

        if (login.trim() == "" || senha.trim() == "") {
            errors.innerHTML = "Forneça os dados";
        }
        else {
            let config = {
                method: "POST",
                body: JSON.stringify({
                    login: login,
                    senha: senha
                }),
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                }
            };

            fetch("login/logar", config)
                .then(function (RetornoServidor) {
                    return RetornoServidor.text();
                })
                .then(function (obj) {
                    console.log(obj);
                })
        }
    }
}