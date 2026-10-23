using System;
using System.Collections.Generic;
using System.Text;

namespace tde_loja
{
    public abstract class Produto: IDesconto
    {
        private string nome;
        private decimal preco;
        private int estoque;

        private decimal desconto;

        public string Nome { get => nome; set => nome = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public decimal Desconto { get => desconto; set => desconto = value; }

        public Produto(string nome, decimal preco, int estoque, decimal desconto)
        {
            this.nome = nome;
            this.preco = preco;
            this.estoque = estoque;
            this.desconto = desconto;
        }
        public abstract string TipoProduto();

        public decimal CalcularDesconto()

        {

            return preco - (preco * desconto/100m);
        }



    }
}
