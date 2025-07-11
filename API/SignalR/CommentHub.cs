using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR;

public class CommentHub(IMediator mediator) : Hub
{
    public async Task SendComment(AddComment.Command command)
    {
        var comment = await mediator.Send(command);

        await Clients.Group(command.ActivityId).SendAsync("ReceiveComment", comment.Value);
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var activityId = httpContext?.Request.Query["activityId"];

        if (string.IsNullOrEmpty(activityId))
        {
            throw new HubException("No activity with this id");
        }

        // Add the connection to a group based on the activity ID
        // This allows all clients connected to this activity to receive comments
        // when they are sent from the server
        await Groups.AddToGroupAsync(Context.ConnectionId, activityId!);

        // Load existing comments for the activity and send them to the client
        var result = await mediator.Send(new GetComments.Query { ActivityId = activityId! });

        // Sends the existing comments to the client that just connected
        await Clients.Caller.SendAsync("LoadComments", result.Value);
    }
}
