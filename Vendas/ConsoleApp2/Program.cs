using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        //static int produtosL { get; set; } = 2;
        //static int vendasL { get; set; } = 1;

        public static string[,] VENDAS { get; set; } = new string[2, 3];
        public static string[,] PRODUTOS { get; set; } = new string[2, 4];


        static void Main(string[] args)
        {

            int opcaoEscolhida = 1;


            while (opcaoEscolhida != 0)
            {
                msgMenuIniciar();
                opcaoEscolhida = Convert.ToInt32(Console.ReadLine());

                switch (opcaoEscolhida)
                {
                    case 1:
                        cadastrarProduto();
                        break;

                    case 2:
                        realizarVenda();
                        break;

                    case 3:
                        relatorioDeVendas();
                        break;

                    case 4:
                        relatorioVendedor();
                        break;
                }

            }

        }


        static void relatorioVendedor()
        {

            Console.Clear();

            string vendedor;
            double totalVendas = 0;

            Console.WriteLine("Informe o vendedor avaliado");

            vendedor = Console.ReadLine();

            Console.WriteLine("Vendas realizadas pelo vendedor " + vendedor);


            for (int l = 0; l < VENDAS.GetLength(0); l++)
            {
                if (vendedor == VENDAS[l, 1])
                {
                    for (int c = 0; c < VENDAS.GetLength(1); c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Console.WriteLine("Produto: " + VENDAS[l, 0]);
                                break;

                            case 1:
                                Console.WriteLine("Vendedor: " + VENDAS[l, 1]);
                                break;

                            case 2:
                                Console.WriteLine("Valor da Venda: R$" + Convert.ToDouble(VENDAS[l, c]) * coletaValorProduto());
                                totalVendas = (Convert.ToDouble(VENDAS[l, c]) * coletaValorProduto()) + totalVendas;
                                break;
                        }
                    }

                    Console.WriteLine("O total vendido pelo vendedor " + vendedor + " foi de R$" + totalVendas);
                    Console.WriteLine("A comissao foi de R$" + (totalVendas * 0.1));

                }
            }

            if (totalVendas == 0)
            {
                Console.WriteLine("Esse vendedor nao realizou nenhuma venda!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        static void relatorioDeVendas()
        {
            //idProduto - codFunc - valor

            Console.Clear();

            Console.WriteLine("Vendas Realizadas");

            for (int l = 0; l < VENDAS.GetLength(0); l++)
            {
                Console.WriteLine();

                for (int c = 0; c < VENDAS.GetLength(1); c++)
                {

                switch (c)
                    {
                        case 0:
                            Console.WriteLine("Produto: " + VENDAS[l,0]);
                            break;

                        case 1:
                            Console.WriteLine("Vendedor: " + VENDAS[l,1]);
                            break;

                        case 2:
                            Console.WriteLine("Valor da Venda: R$" + Convert.ToDouble(VENDAS[l, c]) * coletaValorProduto());
                            break;
                    }

                }

            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        static void atualizaEstoque(int l, int c)
        {
            int produtoEmEstoque;

            produtoEmEstoque = Convert.ToInt32(PRODUTOS[coletaCodProduto(), 3]) - Convert.ToInt32(VENDAS[l, 2]);

            if (produtoEmEstoque < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nao ha essa quantidade de produtos em estoque. A venda foi cancelada.");
                Console.WriteLine("Cadastre novamente!");

                for (int i = 0; i < 3; i++)
                {
                    VENDAS[l, i] = "0";
                }

            }

            else 
            {
                PRODUTOS[coletaCodProduto(), 3] = Convert.ToString(produtoEmEstoque);
                //Array.Copy(VENDAS, 0, VENDAS, l + 1, 4);
            }

        }



        static void realizarVenda()
        {
           
            Console.Clear();

            Console.WriteLine("DADOS DE VENDA");

            for (int l = 0; l < VENDAS.GetLength(0); l++)
            {

                for (int c = 0; c < VENDAS.GetLength(1); c++)
                {
                    
                        switch (c)
                        {
                            case 0:
                                Console.WriteLine("Informe o codigo do produto");
                                VENDAS[l, c] = Console.ReadLine();
                                break;

                            case 1:
                                Console.WriteLine("Informe o codigo do funcionario");
                                VENDAS[l, c] = Console.ReadLine();
                                break;

                            case 2:
                                Console.WriteLine("Informe a quantidade de produtos vendidos");
                                VENDAS[l, c] = Console.ReadLine();

                                atualizaEstoque(l, c);
                                
                                break;
                        }
                    
                }

            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey();

        }


        static void cadastrarProduto()
        {
            Console.Clear();


            int idProduto = 0;

            Console.WriteLine("Para cadastrar o produto informe alguns dados");

            for (int l = 0; l < PRODUTOS.GetLength(0); l++)
            {
                idProduto++;

                for (int c = 0; c < PRODUTOS.GetLength(1); c++)
                {

                    switch (c)
                    {
                        case 0:
                            PRODUTOS[l, c] = Convert.ToString(idProduto);
                            break;

                        case 1:
                            Console.WriteLine("\nInforme a descricao do produto " + idProduto);
                            PRODUTOS[l, c] = Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("\nInforme o valor do produto");
                            PRODUTOS[l, c] = Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("\nInforme a quantidade de produtos");
                            PRODUTOS[l, c] = Console.ReadLine();
                            break;
                    }
                
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey();

        }


        static int coletaCodProduto()
        {
            int linhaProduto = 0;

            for (int l = 0; l < PRODUTOS.GetLength(0); l++)
            {
                for (int c = 0; c < PRODUTOS.GetLength(0); c++)
                {
                    if (PRODUTOS[l, 0] == VENDAS[l, 0])
                    {
                        linhaProduto = l;
                    }
                }

            }
            return linhaProduto;
        }

        static double coletaValorProduto()
        {
            double valorProduto = 0;

            for (int l = 0; l < PRODUTOS.GetLength(0); l++)
            {
                for (int c = 0; c < PRODUTOS.GetLength(0); c++)
                {
                    if ( PRODUTOS[l, 0] == VENDAS[l, 0])
                    {
                        valorProduto = Convert.ToDouble(PRODUTOS[l, 2]);
                    }
                }

            }

            return valorProduto;

            }

        static void msgMenuIniciar()
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-= ROUPAS+ =-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine();
            Console.WriteLine("MENU: \n================================================");
            Console.WriteLine("1 - CADASTRAR PRODUTOS");
            Console.WriteLine("2 - REALIZAR UMA VENDA");
            Console.WriteLine("3 - RELATORIO DE VENDAS");
            Console.WriteLine("4 - RELATORIO DE VENDAS POR FUNCIONARIO");
            Console.WriteLine("\n0 - SAIR\n");
            Console.WriteLine("Selecione uma opcao ");


        }













    }
}
