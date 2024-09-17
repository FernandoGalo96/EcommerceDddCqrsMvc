using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.Mvc.Extensions;

public class SummaryViewComponent : ViewComponent
{
    private readonly DomainNotificationHandler _notifications;

    public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
    {
        _notifications = (DomainNotificationHandler)notifications;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var notification = await Task.FromResult(_notifications.ObterNotificacoes());
        notification.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

        return View();
    }
}