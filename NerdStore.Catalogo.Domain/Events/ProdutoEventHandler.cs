using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Events;

namespace NerdStore.Catalogo.Domain.Events;

public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>,
    INotificationHandler<PedidoIniciadoEvent>,
    INotificationHandler<PedidoProcessamentoCanceladoEvent>
{
    private readonly IProdutoRepository _repository;
    private readonly IEstoqueService _estoqueService;
    private readonly IMediatorHandler _mediatorHandler;

    public ProdutoEventHandler(IProdutoRepository repository, IEstoqueService estoqueService, IMediatorHandler mediatorHandler)
    {
        _repository = repository;
        _estoqueService = estoqueService;
        _mediatorHandler = mediatorHandler;
    }

    public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterPorId(mensagem.AggregateId);
    }

    public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
    {
        var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

        if (result)
        {
            await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
        }
        else
        {
            await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
        }
    }

    public async Task Handle(PedidoProcessamentoCanceladoEvent message, CancellationToken cancellationToken)
    {
        await _estoqueService.ReporListaProdutosPedido(message.ProdutosPedido);
    }
}