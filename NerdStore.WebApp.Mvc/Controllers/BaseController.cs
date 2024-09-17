using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers;

public abstract class BaseController : Controller
{
    private readonly DomainNotificationHandler _domainNotification;
    private readonly IMediatorHandler _mediator;

    protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

    protected BaseController(INotificationHandler<DomainNotification> domainNotification, IMediatorHandler mediator)
    {
        _domainNotification = (DomainNotificationHandler)domainNotification;
        _mediator = mediator;
    }

    protected bool OperacaoValida()
    {
        return !_domainNotification.TemNotificacao();
    }

    protected IEnumerable<string> ObterMensagensErro()
    {
        return _domainNotification.ObterNotificacoes().Select(c => c.Value).ToList();
    }

    protected void NotificarErro(string codigo, string mensagem)
    {
        _mediator.PublicarNotificacao(new DomainNotification(codigo, mensagem));
    }
}