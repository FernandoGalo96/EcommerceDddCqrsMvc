using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Events;

public class PedidoEventHandler : INotificationHandler<PedidoRascunhoIniciadoEvent>,
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
        INotificationHandler<PedidoAtualizadoEvent>,
     INotificationHandler<PedidoPagamentoRealizadoEvent>,
        INotificationHandler<PedidoPagamentoRecusadoEvent>

{
    private readonly IMediatorHandler _mediatorHandler;

    public PedidoEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task Handle(PedidoEstoqueRejeitadoEvent message, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoCommand(message.PedidoId, message.ClienteId));
    }

    public async Task Handle(PedidoPagamentoRealizadoEvent notification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new FinalizarPedidoCommand(notification.PedidoId, notification.ClienteId));
    }

    public async Task Handle(PedidoPagamentoRecusadoEvent notification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(notification.PedidoId, notification.ClienteId));
    }
}