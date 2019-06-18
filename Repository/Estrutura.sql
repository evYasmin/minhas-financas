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
