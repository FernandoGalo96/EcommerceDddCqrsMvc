using NerdStore.Vendas.Application.Queries.ViewModels;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Queries;

public class PedidoQueries : IPedidoQueries
{
    private readonly IPedidoRepository _repository;

    public PedidoQueries(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId)
    {
        var pedido = await _repository.ObterPedidoRascunhoPorClienteId(clienteId);
        if (pedido == null) return null;

        var carrinho = new CarrinhoViewModel
        {
            ClienteId = pedido.ClienteId,
            ValorTotal = pedido.ValorTotal,
            PedidoId = pedido.Id,
            ValorDesconto = pedido.Desconto,
            SubTotal = pedido.Desconto + pedido.ValorTotal
        };

        if (pedido.VoucherId != null)
        {
            carrinho.VoucherCodigo = pedido.Voucher.Codigo;
        }

        foreach (var item in pedido.PedidoItems)
        {
            carrinho.Items.Add(new CarrinhoItemViewModel
            {
                ProdutoId = item.ProdutoId,
                ProdutoNome = item.ProdutoNome,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario,
                ValorTotal = item.ValorUnitario * item.Quantidade
            });
        }

        return carrinho;
    }

    public async Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId)
    {
        var pedidos = await _repository.ObterListaPorClienteId(clienteId);

        pedidos = pedidos.Where(p => p.PedidoStatus == PedidoStatus.Pago || p.PedidoStatus == PedidoStatus.Cancelado)
            .OrderByDescending(p => p.Codigo);

        if (!pedidos.Any()) return null;

        var pedidosView = new List<PedidoViewModel>();

        foreach (var pedido in pedidos)
        {
            pedidosView.Add(new PedidoViewModel
            {
                ValorTotal = pedido.ValorTotal,
                PedidoStatus = (int)pedido.PedidoStatus,
                Codigo = pedido.Codigo,
                DataCadastro = pedido.DataCadastro
            });
        }

        return pedidosView;
    }
}