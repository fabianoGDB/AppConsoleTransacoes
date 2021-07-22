using System;

using System.Collections.Generic;

namespace Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "x"){        
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        //Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listagem");
            if(listaContas.Count == 0){
                Console.WriteLine("Sem contas");
                return;
            }

            for(int i = 0;i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("Conta {0} > ",i);
                Console.WriteLine(conta);
            }
        }

        private static void Trasnferir(){
            Console.Write("Digite o indice da conta originária: ");
            int indiceContaO = int.Parse(Console.ReadLine());

            Console.Write("Digite o indice da conta destino: ");
            int indiceContaF = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor para transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaO].Transferir(valorTransferencia, listaContas[indiceContaF]);
        }

        private static void Sacar(){
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Depositar(){
            Console.Write("Digite o indice: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite um valor: ");
            double valorDeposito =  double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void InserirConta()
        {
            Console.Write("Inserir conta");
            Console.Write("Digite 1 para Física e 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite um Nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo de inicio: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (Enum.TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome
                                        );
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bom dia! escolha uma opção para prosseguir");
            Console.WriteLine();

            Console.WriteLine("1 Listar Contas");
            Console.WriteLine("2 Inserir nova conta");
            Console.WriteLine("3 Transferir");
            Console.WriteLine("4 Sacar");
            Console.WriteLine("5 Despositar");
            Console.WriteLine("c limpar tela");
            Console.WriteLine("x sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        
    }
}
