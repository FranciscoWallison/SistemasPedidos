-- SQLite
CREATE TABLE Produtos(
    id INTEGER PRIMARY KEY, 
    Descricao TEXT,
    DataCadastro datetime default current_timestamp,
    Preco integer
);

DROP TABLE Fornecedores;

CREATE TABLE Fornecedores(
    id INTEGER PRIMARY KEY, 
    Nome TEXT,
    RazaoSocial TEXT,
    Email TEXT,
    UF TEXT,
    CNPJ TEXT
);