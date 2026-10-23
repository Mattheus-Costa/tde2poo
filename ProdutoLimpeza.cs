using System;
using System.Collections.Generic;
using System.Text;

namespace tde_loja
{
    public class ProdutoLimpeza: Produto
    {
        private float volumeMl;

        public float VolumeMl { get => volumeMl; set => volumeMl = value; }

        public ProdutoLimpeza(string nome, decimal preco, int estoque,decimal desconto, float volumeMl) : base(nome, preco, estoque, desconto)
        {
            this.volumeMl = volumeMl;
        }
        public override string TipoProduto()
        {
            return "Limpeza";
        }
    }
}
