using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace tde_loja
{
    public class ProdutoAlimenticio: Produto
    {
        private DateTime validade;

        public string Validade { get => validade.ToString("dd/MM/yy"); set => validade = DateTime.Parse(value); }

        public ProdutoAlimenticio(string nome, decimal preco, int estoque, decimal desconto, DateTime validade) : base (nome, preco, estoque, desconto)
        {
            this.validade = validade;
        }
        public override string TipoProduto()
        {
            return "Alimento";
        }
    }
}
