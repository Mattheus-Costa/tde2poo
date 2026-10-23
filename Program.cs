

using tde_loja;
int opcao;
int opcao2;
string Nome = string.Empty;
decimal Preco = 0m;
int Estoque = 0;
decimal Desconto = 0m;
string TipoHigiene;
float VolumeMl = 0;
DateTime Validade = DateTime.MinValue;

bool valido;


List<Produto> produtos = new List<Produto>();








do
{

    bool EntradaValida = true;
    try
    {
        Console.WriteLine("===SISTEMA MERCADO===");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Sair");
        opcao = int.Parse(Console.ReadLine() ?? "");
    }

    catch (FormatException)
    {
        Console.WriteLine("Insira um Valor Numérico");
        opcao = 0;
        EntradaValida = false;
    }

    if (EntradaValida) {
        switch (opcao)
        {
            case 1:


                valido = false;
                while (!valido)
                {
                    try
                    {

                        Console.WriteLine("Digite o Nome do Produto: ");
                        Nome = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(Nome))
                        {
                            throw new ArgumentException("O nome é obrigatório");
                        }

                        if (decimal.TryParse(Nome, out _))
                        {
                            throw new ArgumentException("O nome não pode ser um número");
                        }

                        Console.WriteLine("Digite o Preço do Produto: ");
                        Preco = decimal.Parse(Console.ReadLine()!);

                        if (Preco < 1)
                        {
                            throw new ArgumentOutOfRangeException(nameof(Preco), "O valor do preço não ser menor que 1");
                        }

                        Console.WriteLine("Digite o Estoque do Produto: ");
                        Estoque = int.Parse(Console.ReadLine()!);


                        if (Estoque < 0)
                        {
                            throw new ArgumentOutOfRangeException(nameof(Estoque), "O número de itens em estoque não pode ser negativo");
                        }

                        Console.WriteLine("Digite o Desconto a ser Aplicado o Produto: ");
                        Desconto = decimal.Parse(Console.ReadLine()!);

                        if (Desconto < 0 || Desconto > 100)
                        {
                            throw new ArgumentOutOfRangeException(nameof(Desconto), "O desconto deve estar entre 0% e 100%");
                        }

                        do {

                            try {
                                Console.WriteLine("===ESCOLHA O TIPO DE PRODUTO===");
                                Console.WriteLine("1 - Produto Alimentício");
                                Console.WriteLine("2 - Produto de Higiene Pessoal");
                                Console.WriteLine("3 - Produto de Limpeza");
                                opcao2 = int.Parse(Console.ReadLine() ?? "");
                            }

                            catch (FormatException)
                            {
                                Console.WriteLine("Insira um valor numérico!");
                                opcao2 = 0;
                            }
                         
                        } while (opcao2 < 1 || opcao2 > 3);

                      

                        switch (opcao2)
                        {
                            case 1:

                                do
                                {
                                    Console.WriteLine("Digite a Data de Validade do Produto: ");
                                    string entrada = (Console.ReadLine()!);

                                    if (DateTime.TryParse(entrada, out Validade))
                                    {
                                        break;
                                    }

                                    Console.WriteLine("Data inválida! Digite uma data válida.");
                                } while (true);




                                   valido = true;


                                Produto produto = new ProdutoAlimenticio(Nome, Preco, Estoque, Desconto, Validade);
                                produtos.Add(produto);

                             


                                break;

                            case 2:

                                Console.WriteLine("Digite o Tipo do Produto de Higiene: ");
                                TipoHigiene = (Console.ReadLine()!);

                                if (string.IsNullOrWhiteSpace(TipoHigiene))
                                {
                                    throw new ArgumentException("O tipo do produto de higiene deve ser preenchido", nameof(TipoHigiene));
                                }


                                valido = true;


                                Produto produto1 = new ProdutoHigiene(Nome, Preco, Estoque, Desconto, TipoHigiene);
                                produtos.Add(produto1);



                                break;


                            case 3:

                                do
                                {
                                    Console.WriteLine("Digite o Volume em ml do Produto: ");
                       
                                    string entrada2 = (Console.ReadLine()!);

                                    if (float.TryParse(entrada2, out VolumeMl))
                                    {


                                        if (VolumeMl >= 1)
                                        {
                                            break;
                                            
                                        }

                                        Console.WriteLine("O Volume não pode ser menor que 1");

                                    }

                                    else
                                    {

                                        Console.WriteLine("Volume Inválido! Digite um valor válido.");
                                    }

                                } while (true);
                           
                                valido = true;


                                Produto produto2 = new ProdutoLimpeza(Nome, Preco, Estoque, Desconto, VolumeMl);
                                produtos.Add(produto2);


                                break;


                            default:

                                Console.WriteLine("Opção Inválida!");
                                break;
                        }






                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erro: digite um valor numérico válido.");
                    }

                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }

                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                }




                break;

            case 2:


                if (produtos.Count == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    int i = 1;
                    foreach (Produto prod in produtos)
                    {


                        Console.WriteLine($"===PRODUTO {i}===");

                        if (prod is ProdutoAlimenticio alimento)
                        {

                            Console.WriteLine($"Tipo do Produto:{alimento.TipoProduto()}");
                            Console.WriteLine($"Nome do Produto: {alimento.Nome} ");
                            Console.WriteLine($"Preço do Produto: {alimento.Preco} ");
                            Console.WriteLine($"Preço Total (Com Desconto) do Produto: {alimento.CalcularDesconto()}");
                            Console.WriteLine($"Estoque do Produto: {alimento.Estoque}");
                            Console.WriteLine($"Validade do Produto: {alimento.Validade} ");
                            ;







                        }

                        else if (prod is ProdutoHigiene higiene)
                        {

                            Console.WriteLine($"Tipo do Produto:{higiene.TipoProduto()}");
                            Console.WriteLine($"Nome do Produto: {higiene.Nome} ");
                            Console.WriteLine($"Preço do Produto: {higiene.Preco} ");
                            Console.WriteLine($"Preço Total (Com Desconto) do Produto: {higiene.CalcularDesconto()}");
                            Console.WriteLine($"Estoque do Produto: {higiene.Estoque}");
                            Console.WriteLine($"Tipo de Higiene: {higiene.TipoHigiene} ");
                            ;







                        }

                        else if (prod is ProdutoLimpeza limpeza)
                        {

                            Console.WriteLine($"Tipo do Produto:{limpeza.TipoProduto()}");
                            Console.WriteLine($"Nome do Produto: {limpeza.Nome} ");
                            Console.WriteLine($"Preço do Produto: {limpeza.Preco} ");
                            Console.WriteLine($"Preço Total (Com Desconto) do Produto: {limpeza.CalcularDesconto()}");
                            Console.WriteLine($"Estoque do Produto: {limpeza.Estoque}");
                            Console.WriteLine($"Volume(ml): {limpeza.VolumeMl} ");
                            ;


                        }



                        i++;
                    }
                }

                break;


            case 3:
                Console.WriteLine("Encerrando...");
                break;

            default:

                Console.WriteLine("Opção Inválida!");
                break;
        }



    }



} while (opcao != 3);