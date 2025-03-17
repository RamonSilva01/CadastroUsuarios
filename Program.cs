using System;
using System.Collections.Generic;

namespace CadastroUsuarios
{
    // Classe que representa um usuário
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }

        // Construtor para facilitar a criação de novos usuários
        public Usuario(string nome, string email, int idade)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
        }
    }

    class Program
    {
        // Lista que armazenará os usuários
        static List<Usuario> usuarios = new List<Usuario>();

        // Método para cadastrar um novo usuário
        static void CadastrarUsuario()
        {
            Console.WriteLine("Digite o nome do usuário:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do usuário:");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a idade do usuário:");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Por favor, insira uma idade válida.");
            }

            // Cria um novo objeto usuário e adiciona à lista
            usuarios.Add(new Usuario(nome, email, idade));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        // Método para listar todos os usuários cadastrados
        static void ListarUsuarios()
        {
            Console.WriteLine("\nLista de Usuários Cadastrados:");
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}, E-mail: {usuario.Email}, Idade: {usuario.Idade}");
            }
        }

        // Método para buscar um usuário pelo nome
        static void BuscarUsuario()
        {
            Console.WriteLine("Digite o nome do usuário para buscar:");
            string nomeBusca = Console.ReadLine();

            // Procura o usuário na lista
            var usuarioEncontrado = usuarios.Find(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuário encontrado! Nome: {usuarioEncontrado.Nome}, E-mail: {usuarioEncontrado.Email}, Idade: {usuarioEncontrado.Idade}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        static void Main(string[] args)
        {
            bool continuar = true;

            // Menu de opções
            while (continuar)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1 - Cadastrar Usuário");
                Console.WriteLine("2 - Listar Usuários");
                Console.WriteLine("3 - Buscar Usuário");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario();
                        break;

                    case "2":
                        ListarUsuarios();
                        break;

                    case "3":
                        BuscarUsuario();
                        break;

                    case "4":
                        continuar = false;
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }
    }
}
