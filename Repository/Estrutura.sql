DROP TABLE contasPagar ; 
CREATE TABLE contasPagar (
id INT PRIMARY KEY IDENTITY(1,1) , 
nome VARCHAR(100) ,
valor DECIMAL (8,2),
tipo VARCHAR(100) , 
descricao VARCHAR(100) , 
status VARCHAR(100) 
);
SELECT * FROM contasPagar;


CREATE TABLE contasReceber (
id INT PRIMARY KEY IDENTITY(1,1) , 
nome VARCHAR(100) ,
valor DECIMAL (8,2),
tipo VARCHAR(100) , 
descricao VARCHAR(100) , 
status VARCHAR(100) 
);


DROP TABLE clientes_pessoa_fisica;
CREATE TABLE clientes_pessoa_fisica (
id INT PRIMARY KEY IDENTITY(1,1) , 
nome VARCHAR(100) ,
cpf VARCHAR (25) , 
data_nascimento DATETIME2 , 
rg VARCHAR(25) , 
sexo VARCHAR(25) 
);


