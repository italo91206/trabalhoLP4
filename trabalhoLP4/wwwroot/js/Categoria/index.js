let index = {
    cadastrarCategoria: function () {
        var nome = document.getElementById('Nome').value;
        var descricao = document.getElementById('descricao').value;
        var errors = document.getElementById('errors');

        if (nome.trim() == "" || descricao.trim() == "") {
            errors.innerHTML = "Forneça os dados";
        }
        else {
            let config = {
                method: "POST",
                body: JSON.stringify({
                    nome: nome,
                    descricao: descricao,
                }),
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                }
            };
            fetch("Categoria/Cadastrar", config)
                .then(function (response) {
                    return response.json();
                })
                .then(function (response) {
                    if (!response.operacao)
                        errors.innerHTML = "Dados não válidos";
                    else {
                        document.getElementById('Nome').value = "";
                        document.getElementById('descricao').value = "";
                        alert("Categoria cadastrado com sucesso!");
                    }
                })
        }
    },
    listarCategorias: function () {   
        document.getElementById('categorias-listagem').innerHTML = "";
        var header = `<tbody><tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                      </tr></tbody>`;
        let config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                'Accept': 'application/json'
            }
        }

        fetch("Categoria/Listar", config)
            .then(function (response) {
                return response.json();
            })
            .then(function (response) {
                if (response.operacao) {
                    var categorias = response.categorias;
                    var item = "";

                    for (var i = 0; i < categorias.length; i++){
                        item += "<tr>";
                        item += "<td>" + categorias[i].id + "</td>";
                        item += "<td>" + categorias[i].nome + "</td>";
                        item += "<td>" + categorias[i].descricao + "</td>";
                        item += "</tr>";
                    }
                    document.getElementById('categorias-listagem').innerHTML = header + item;
                }
            })
    }
}