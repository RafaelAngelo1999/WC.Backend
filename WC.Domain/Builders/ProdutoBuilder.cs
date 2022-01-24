using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Builders
{
    public class ProdutoBuilder
    {
        private readonly ProdutoDto _produto;
        public ProdutoBuilder()
        {
            _produto = new ProdutoDto();
        }

        public ProdutoBuilder SetTitulo(string titulo)
        {
            _produto.Titulo = titulo;
            return this;
        }
        public ProdutoBuilder SetDescricao(string descricao)
        {
            _produto.Descricao = descricao;
            return this;
        }
        public ProdutoBuilder SetCategoria(string categoria)
        {
            _produto.Categoria = categoria;
            return this;
        }
        public ProdutoBuilder SetSKU(string sku)
        {
            _produto.SKU = sku;
            return this;
        }
        public ProdutoBuilder SetPrecoPromocional(float precoPromocional)
        {
            _produto.PrecoPromocional = precoPromocional;
            return this;
        }
        public ProdutoBuilder SetPreco(float preco)
        {
            _produto.Preco = preco;
            return this;
        }
        public ProdutoBuilder SetMediaAvaliacao(float mediaAvaliacao)
        {
            _produto.MediaAvaliacao = mediaAvaliacao;
            return this;
        }
        public ProdutoBuilder SetImagens(List<ImagemProdutoDto> imagens)
        {
            _produto.Imagens = imagens;
            return this;
        }

        public ProdutoDto Build()
        {
            if (validate())
            {
                return _produto;
            }
            else
            {
                //criar e lançar exceção personalizada, sugestão: "InvalidProductException"
                throw new Exception();
            }
        }

        //O produto não pode ser criado se não tiver nome nem sku
        private bool validate()
        {
            return _produto.SKU != null && _produto.Titulo != null;
        }
    }

}
