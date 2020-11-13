let index = {
    cadastrarProduto: function () {
        var nome = document.getElementById('Nome').value;
        var descricao = document.getElementById('descricao').value;
        var categoria = parseInt(document.getElementById('categoria').value, 10);
        var preco = parseFloat(document.getElementById('preco').value, 10);
        var quantidade = parseInt(document.getElementById('quantidade').value, 10);
        var categoriaSelect = document.getElementById('categoria');
        var antesSelect = `<option value="0" selected=""></option>`;

        var errors = document.getElementById('errors');

        if (nome.trim() == "" || descricao.trim() == "" || categoria == 0 || preco < 0.01 || quantidade < 1) {
            errors.innerHTML = "Forneça os dados";
        }
        else {
            this.listarCategorias();
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

                        categoriaSelect.innerHTML = antesSelect;

                        alert("Produto cadastrado com sucesso!");
                    }
                })
        }
    },
    listarProdutos: function () {   
        document.getElementById('produtos-listagem').innerHTML = "";
        var header = `<tbody><tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th>Preço</th>
                        <th>Quantidade</th>
                        <th>Categoria</th>
                    </tr></tbody>`;
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
                    document.getElementById('produtos-listagem').innerHTML = header + item;
                }
            })
    },
    listarCategorias: function () {
        var nome = document.getElementById('Nome').value;
        var categoria = document.getElementById('categoria');
        var antes = `<option value="0" selected=""></option>`;

        if (nome.trim() != "") {
            errors.innerHTML = "Forneça os dados";
        }

        let config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                'Accept': 'application/json'
            }
        };

        fetch("Produto/ListarCategorias", config)
            .then(function (response) {
                return response.json();
            })
            .then(function (response) {
                if (response.operacao) {
                    var categorias = response.categorias;
                    var node;
                    categorias.innerHTML = antes;
                    for (var i = 0; i < categorias.length; i++) {
                        node = document.createElement("OPTION")
                        node.value = categorias[i].id;
                        node.innerText = categorias[i].nome;
                        categoria.appendChild(node);
                    }
                }
            })
    }
}