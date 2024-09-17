using NerdStore.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStore.Catalogo.Domain.Events;

public class ProdutoAbaixoEstoqueEvent : DomainEvent
{
    public int QauntidadeRestante { get; private set; }

    public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
    {
        QauntidadeRestante = quantidadeRestante;
    }
}