using System;
using System.Collections.Generic;
using ProjetoBanco.Classes;
using ProjetoBanco.Enum;
namespace ProjetoBanco
{
    class Program : LogHelper
    {
        static List<Conta> Contas = new List<Conta>();
        static void Main(string[] args)
        {
            bool executar = true;
            while (executar)
            {
                switch (ObterOpcaoUsuario())
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        AdicionarConta();
                        break;
                    case "3":
                        Transferir();
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
                    case "X":
                        executar = false;
                        Log("Obrigado por usar os serviços da Dev Bank.");
                        break;
                    default:
                        Log("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        private static string ObterOpcaoUsuario()
        {
            string[] listaDeOpcoes = {
                "",
                "Dev Bank a seu dispor!",
                "Informe a opção desejada:",
                "1 - Listar contas",
                "2 - Inserir nova conta",
                "3 - Transferir",
                "4 - Sacar",
                "5 - Depositar",
                "C - Limpar tela",
                "X - Sair",
                ""
            };
            Display(listaDeOpcoes);
            string opcaoUsuario = Input("Digite sua opção: ").ToUpper();
            Log("");
            return opcaoUsuario;
        }
        private static void ListarContas()
        {
            int qntContas = Contas.Count;
            string[] listaUsuarios = new string[qntContas];
            int index = 0;
            Contas.ForEach(conta =>
            {
                listaUsuarios[index] = $"ID: {index + 1} | {conta.Informacoes()}";
                index++;
            });
            if (qntContas == 0)
                Log("Nenhuma conta cadastrada.");
            Display(listaUsuarios);
            Log("");
        }
        private static void AdicionarConta()
        {
            string nome = Input("Digite seu nome: ");
            TipoConta tipoConta = ObterTipoConta();
            double saldo = ObterValor("saldo");
            double credito = ObterValor("crédito");
            Conta Conta = new Conta(nome, tipoConta, saldo, credito);
            Contas.Add(Conta);
        }
        private static void Transferir(){
            ListarContas();

            int indiceOrigem = Int32.Parse(Input("Digite o numero da conta de origem: ")) - 1;
            int indiceDestino = Int32.Parse(Input("Digite o numero da conta de destino: ")) - 1;
            double valorTransferido = double.Parse(Input("Digite o valor a ser transferido: "));

            Contas[indiceOrigem].Transferir(valorTransferido, Contas[indiceDestino]);
        }
        private static void Sacar(){
            ListarContas();

            int indiceConta = Int32.Parse(Input("Digite o numero da conta: ")) - 1;
            double valorSacado = double.Parse(Input("Digite o valor a ser sacado: "));

            Contas[indiceConta].Sacar(valorSacado);
        }
        private static void Depositar(){
            ListarContas();

            int indiceConta = Int32.Parse(Input("Digite o numero da conta: ")) - 1;
            double valorDepositado = double.Parse(Input("Digite o valor a ser depositado: "));

            Contas[indiceConta].Depositar(valorDepositado);
        }
        private static TipoConta ObterTipoConta()
        {
            TipoConta tipoConta = TipoConta.PessoaFisica;
            bool repetir = true;
            while (repetir)
            {
                string[] listaDeOpcoes = { "Tipos de conta disponiveis:", "1 - Pessoa Fisica", "2 - Pessoa Juridica" };
                Display(listaDeOpcoes);

                string escolha = Input("Digite sua escolha: ");
                if (escolha == "1" || escolha == "2")
                {
                    repetir = false;
                    if (escolha == "2")
                    {
                        tipoConta = TipoConta.PessoaJuridica;
                    }
                }
                else
                {
                    repetir = true;
                }
            }
            return tipoConta;
        }
        private static double ObterValor(string nomeValor)
        {
            double valor = 0;
            bool repetir = true;
            while (repetir)
            {
                string input = Input($"Digite seu {nomeValor} atual: ");
                if (double.TryParse(input, out valor))
                {
                    return valor;
                }
                Log("Valor digitado não é valido!");
                Log("");
            }
            return valor;
        }
    }
}
