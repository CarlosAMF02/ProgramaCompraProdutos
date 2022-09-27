using Checkpoint2EE.Entidades;
using Checkpoint2EE.Entidades.Enums;

List<Produto> produtos = new List<Produto>();
List<Funcionario> funcionarios = new List<Funcionario>();
List<Pedido> pedidos = new List<Pedido>();

int opcao = 0;

while(opcao != 8)
{
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionário");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionários");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento do Funcionário");
    Console.WriteLine("8 - Sair");

    Console.WriteLine("Digite a opção desejada: ");
    opcao = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("---- CADASTRAR PRODUTO ----");

            Produto produto = new Produto();

            Console.Write("Digite o id do Produto: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Produto: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Digite o valor do Produto: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);

            continue;
        case 2:
            Console.WriteLine("---- CADASTRAR FUNCIONÁRIO ----");

            Console.Write("Digite o tipo de funcionario: (V para vendedor e G para gerente) ");
            string tipoFuncionario = Console.ReadLine();
            Funcionario funcionario;
            if (tipoFuncionario == "V")
            {
                funcionario = new Vendedor();

                Console.Write("Digite o nome do Vendedor: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Digite a matricula do Vendendor: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("Digite o salário do Vendedor: ");
                funcionario.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(funcionario);
            }
            else if (tipoFuncionario == "G")
            {
                funcionario = new Gerente();

                Console.Write("Digite o nome do Gerente: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Digite a matricula do Gerente: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("Digite o salário do Gerente: ");
                funcionario.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(funcionario);
            }
            else
            {
                Console.WriteLine("Tipo de funcionário inexistente!");
            }
            break;
        case 3:
            Console.WriteLine("---- CADASTRAR PEDIDO ----");

            Pedido pedido = new Pedido();

            Console.Write("Digite a matricula do funcionário: ");
            string matricula = Console.ReadLine();

            pedido.Funcionario = funcionarios.Find(func => func.Matricula == matricula);

            Console.Write("Digite a quantidade de itens do pedido: ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                ItemPedido item = new ItemPedido();

                Produto pp = null;

                while (pp == null)
                {
                    Console.Write($"Id do Produto do Item Pedido - {i + 1}: ");
                    int idProduto = int.Parse(Console.ReadLine());

                    pp = produtos.Find(produto => produto.Id == idProduto);
                    if (pp == null) Console.WriteLine("Produto inexistente! Digite novamente o id do produto");
                };

                item.Produto = pp;
                item.Valor = item.Produto.Valor;

                Console.Write($"Quantidade do Produto do Item Pedido - {i + 1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                pedido.AdicionarItem(item);
            }

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Processando;

            pedidos.Add(pedido);

            break;
        case 4:
            Console.WriteLine("---- LISTAR PRODUTOS ---- ");

            foreach (Produto p in produtos)
            {
                Console.WriteLine(p);
            }
            break;
        case 5:
            Console.WriteLine("---- LISTAR FUNCIONÁRIOS ----");

            foreach (Funcionario f in funcionarios)
            {
                Console.WriteLine(f);
            }
            break;
        case 6:
            Console.WriteLine("---- LISTAR PEDIDOS ----");

            foreach (Pedido p in pedidos)
            {
                Console.WriteLine(p);
            }
            break;
        case 7:
            Console.WriteLine("---- CALCULAR PAGAMENTO DO FUNCIONÁRIO ----");

            Console.Write("Digite o número de matrícula do funcionário: ");
            string matriculaFuncionario = Console.ReadLine();

            Funcionario func = funcionarios.Find(f => f.Matricula == matriculaFuncionario);

            double pagamento = 0;

            if (func != null)
            {
                pagamento = func.CalcularPagamento(pedidos);
                Console.WriteLine($"O Salário foi de R${pagamento:F2}");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado!");
            }
            break;
    }
}