using System;
using System.Collections.Generic;
using System.Text;

namespace tde_loja
{
    public class ProdutoHigiene : Produto
    {
        private string tipohigiene;

        public string TipoHigiene { get => tipohigiene; set => tipohigiene = value; }

        public ProdutoHigiene(string nome, decimal preco, int estoque, decimal desconto, string tipohigiene) : base(nome, preco, estoque, desconto)
        {
            this.tipohigiene = tipohigiene;
        }
        public override string TipoProduto()
        {
            return "Higiene Pessoal";
        }
    }
}
