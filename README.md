# 🎣 Sistema de Gerenciamento de Mesas para Pesqueiro

> 💻 Desenvolvido em **C# (WinForms)** como projeto prático de gerenciamento de mesas para restaurantes/pesqueiros  
> 📅 Foco em **CRUD, POO e arquitetura em camadas (MVC + DAO)**  

---

## 🧭 Visão Geral

O **Sistema de Gerenciamento de Mesas** é uma aplicação desktop voltada para **controlar mesas, pedidos e clientes em um pesqueiro ou restaurante**.  
Permite gerenciar **status das mesas (livre, ocupada, desativada), pedidos, quantidade de pessoas e valores totais** de forma intuitiva e organizada.

---

## ✨ Funcionalidades Principais

### 🍽️ **Mesas**
- Controle de status: Livre, Ocupada, Desativada
- Visualização da quantidade de pessoas por mesa
- Alteração rápida de status e quantidade de clientes
- Finalização da mesa com limpeza de pedidos e atualização do status

### 🛒 **Pedidos**
- Adição de produtos às mesas
- Edição de quantidade diretamente no grid
- Exclusão de pedidos selecionados
- Cálculo automático do valor total da mesa
- Pesquisa de produtos pelo nome

### 📊 **Visualização**
- Grid organizado por mesa, mostrando pedidos e quantidades
- TextBox desativado mostrando o total de cada mesa
- Interface intuitiva para controle rápido do salão

---

## 🧱 Estrutura do Projeto

SistemaMesas/
> ├── SistemaMesas.View/ # Interface gráfica (WinForms)  
> ├── SistemaMesas.Model/ # Modelos (Mesa, Produto, Pedido, etc.)  
> ├── SistemaMesas.DAO/ # Acesso ao banco de dados (Data Access Object)  
> └── Banco.de.Dados/ # Scripts SQL e arquivos de banco de dados  

---

## 🧠 Tecnologias Utilizadas

| Camada | Tecnologias |
|--------|-------------|
| **Linguagem** | C# (.NET Framework / WinForms) |
| **Interface** | WinForms |
| **Banco de Dados** | MySQL |
| **Arquitetura** | MVC + DAO |
| **Recursos** | CRUD, POO, validação, cálculo de totais, filtros e pesquisa |

---

## 🚀 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/kauabaum/gerenciamento-mesas.git
   ```
---
1 - Abra o projeto no Visual Studio.

2 - Configure a string de conexão no arquivo DatabaseHelper.cs.

3 - Importe o script SQL da pasta /Banco.de.Dados.

4 - Execute o projeto e gerencie as mesas 🎉

---

💡 Destaques Técnicos

✅ Controle completo de mesas e pedidos
✅ Status das mesas com cores indicativas
✅ Quantidade de clientes por mesa
✅ Valor total calculado automaticamente
✅ Filtro de produtos e pesquisa rápida
✅ Edição e exclusão de pedidos diretamente no grid
✅ Interface prática e organizada

---

⚠️ ATENÇÃO: SISTEMA EM DESENVOLVIMENTO ⚠️

🔴 Algumas funcionalidades ainda podem estar incompletas ou instáveis
⚠️ Recomendado uso em ambiente de teste
🚧 Melhorias contínuas estão sendo aplicadas

---

📘 Contexto Acadêmico

📚 Projeto pessoal com objetivo de:

Aplicar conceitos de POO e CRUD

Implementar arquitetura MVC + DAO

Criar uma aplicação desktop funcional para gerenciamento de mesas em restaurantes/pesqueiros

---

Licença

Este projeto está sob a licença MIT — uso livre para fins educacionais e aprendizado.

✍️ Autor

[Kauã Davi de Senia Baum]
🎓 Estudante de Engenharia de Software / Análise e Desenvolvimento de Sistemas
💻 Apaixonado por desenvolvimento e boas práticas de programação

📫 Contato: [kaua.baum@outlook.com]
🌐 GitHub: https://github.com/kauabaum
