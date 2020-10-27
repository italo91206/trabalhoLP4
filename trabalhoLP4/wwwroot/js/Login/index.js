let index = {
    login: function () {
        var login = document.getElementById('login').value;
        var senha = document.getElementById('senha').value;
        var errors = document.getElementById('errors');

        if (login.trim() == "" || senha.trim() == "") {
            errors.innerHTML = "Forneça os dados";
        }
        else {
            let config = {
                method: "POST",
                redirect: "follow",
                body: JSON.stringify({
                    login: login,
                    senha: senha
                }),
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                }
            };
            
            fetch("Login/Logar", config)
                .then(function (response) {
                    return response.json();
                })
                .then(function (response) {
                    if (!response.operacao)
                        errors.innerHTML = "Dados não válidos";
                    else
                        window.location.href = "/Produto";
                })
        }
    }
}