using System;
using System.Collections.Generic;
using System.Text;


namespace TransferenciaBancaria
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
        }

        public bool Saque(double valorSaque)
        {
            //validar Saldo
            if(Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta é {Nome}, {Saldo}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta é {Nome}, {Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Saque(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta" + TipoConta + " | ";
            retorno += "Nome" + Nome + " | ";
            retorno += "Saldo" + Saldo + " | ";
            retorno += "Credito" + Credito;
            return retorno;
        }
    }
}
