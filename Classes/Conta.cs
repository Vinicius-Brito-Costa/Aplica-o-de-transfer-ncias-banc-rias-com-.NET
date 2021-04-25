using System;
using ProjetoBanco.Enum;
namespace ProjetoBanco.Classes
{
    public class Conta
    {
        public string Nome { get; private set;}
        private TipoConta TipoConta { get; set;}
        private double Saldo { get; set; }
        private double Credito { get; set; }
        public Conta(string nomeUsuario, TipoConta tipoConta, double saldo, double credito){
            this.Nome = nomeUsuario;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque){
            if (this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

            return true;
        }
        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }
        public bool Transferir(double valorTransferencia, Conta contaDestino){
            bool result = false;
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
                result = true;
            }
            return result;
        }
        public string Informacoes(){
            string info = $"Nome: {this.Nome} | ";
            info += $"Tipo de conta: {this.TipoConta} | ";
            info += $"Saldo: {this.Saldo} | ";
            info += $"Crédito disponivel: {this.Credito} | ";
            return info;
        }
    }
}