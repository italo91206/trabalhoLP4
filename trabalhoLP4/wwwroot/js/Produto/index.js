let index = {
    cadastrarProduto: function () {
        var nome = document.getElementById('Nome').value;
        var descricao = document.getElementById('descricao').value;
        var categoria = document.getElementById('categoria').value;
        var preco = parseInt(document.getElementById('preco').value, 10);
        var quantidade = parseInt(document.getElementById('quantidade').value, 10);

        var errors = document.getElementById('errors');

        if (nome.trim() == "" || descricao.trim() == "" || categoria.trim() == "" || preco < 0.01 || quantidade < 1) {
            errors.innerHTML = "Forneça os dados";
        }
        else {
            let config = {
                method: "POST",
                body: JSON.stringify({
                    nome: nome,
                    descricao: descricao,
                    categoria: categoria,
                    preco: preco,
                    qtd: quantidade
                }),
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                }
            };
            fetch("Produto/Cadastrar", config)
                .then(function (response) {
                    return response.json();
                })
                .then(function (response) {
                    if (!response.operacao)
                        errors.innerHTML = "Dados não válidos";
                    else {
                        document.getElementById('Nome').value = "";
                        document.getElementById('descricao').value = "";
                        document.getElementById('categoria').value = "";
                        document.getElementById('preco').value = 0;
                        document.getElementById('quantidade').value = 0;
                        alert("Produto cadastrado com sucesso!");
                    }
                })
        }
    },
    listarProdutos: function () {        
        let config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                'Accept': 'application/json'
            }
        }
        fetch("Produto/Listar", config)
            .then(function (response) {
                return response.json();
            })
            .then(function (response) {
                if (response.operacao) {
                    var produtos = response.produtos;
                    var item = "";
                    console.log({ produtos });
                    for (var i = 0; i < produtos.length; i++){
                        item += "<tr>";
                        item += "<td>" + produtos[i].id + "</td>";
                        item += "<td>" + produtos[i].nome + "</td>";
                        item += "<td>" + produtos[i].descricao + "</td>";
                        item += "<td>" + produtos[i].preco + "</td>";
                        item += "<td>" + produtos[i].qtd + "</td>";
                        item += "<td>" + produtos[i].categoria + "</td>";
                        item += "</tr>";
                    }
                    document.getElementById('produtos-listagem').innerHTML += item;
                }
            })
    }
}