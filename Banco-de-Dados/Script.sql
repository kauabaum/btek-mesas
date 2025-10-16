-- Criar o banco de dados
CREATE DATABASE IF NOT EXISTS pesqueiro_senia;

-- Usar o banco de dados
USE pesqueiro_senia;

-- Tabela de mesas (44 mesas fixas)
CREATE TABLE IF NOT EXISTS mesas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    numero INT NOT NULL,  -- Número da mesa
    status ENUM('livre', 'ocupada', 'desativada') DEFAULT 'livre',  -- Status da mesa
    quantidade_pessoas INT DEFAULT 0  -- Quantidade de pessoas na mesa
);

-- Inserir 44 mesas fixas, todas inicialmente como "livre"
INSERT INTO mesas (numero, status, quantidade_pessoas) 
VALUES
(1, 'livre', 0),
(2, 'livre', 0),
(3, 'livre', 0),
(4, 'livre', 0),
(5, 'livre', 0),
(6, 'livre', 0),
(7, 'livre', 0),
(8, 'livre', 0),
(9, 'livre', 0),
(10, 'livre', 0),
(11, 'livre', 0),
(12, 'livre', 0),
(13, 'livre', 0),
(14, 'livre', 0),
(15, 'livre', 0),
(16, 'livre', 0),
(17, 'livre', 0),
(18, 'livre', 0),
(19, 'livre', 0),
(20, 'livre', 0),
(21, 'livre', 0),
(22, 'livre', 0),
(23, 'livre', 0),
(24, 'livre', 0),
(25, 'livre', 0),
(26, 'livre', 0),
(27, 'livre', 0),
(28, 'livre', 0),
(29, 'livre', 0),
(30, 'livre', 0),
(31, 'livre', 0),
(32, 'livre', 0),
(33, 'livre', 0),
(34, 'livre', 0),
(35, 'livre', 0),
(36, 'livre', 0),
(37, 'livre', 0),
(38, 'livre', 0),
(39, 'livre', 0),
(40, 'livre', 0),
(41, 'livre', 0),
(42, 'livre', 0),
(43, 'livre', 0),
(44, 'livre', 0);

-- Tabela de produtos
CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,  -- Nome do produto
    preco DECIMAL(10, 2) NOT NULL  -- Preço do produto
);

-- Exemplo de dados para a tabela de produtos
INSERT INTO produtos (nome, preco) VALUES
('Hamburguer', 15.00),
('Batata Frita', 7.50),
('Refrigerante', 5.00),
('Água', 3.00),
('Suco Natural', 6.00);

-- Criar uma tabela para pedidos (relacionada a mesas e produtos)
CREATE TABLE IF NOT EXISTS pedidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    mesa_id INT,
    produto_id INT,
    quantidade INT DEFAULT 1,
    FOREIGN KEY (mesa_id) REFERENCES mesas(id),
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);
