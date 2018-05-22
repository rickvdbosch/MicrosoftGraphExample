using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

using Rickvdbosch.MicrosoftGraphExample.Helpers;
using Rickvdbosch.MicrosoftGraphExample.Models;

namespace Rickvdbosch.MicrosoftGraphExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InviteUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InviteUser(InviteUserModel inviteUserModel)
        {
            var graphServiceClient = GraphServiceClientHelper.CreateGraphServiceClient();
            var invitation = await graphServiceClient.Invitations.Request().AddAsync(new Invitation
            {
                InviteRedirectUrl = "http://localhost:2509",
                InvitedUserDisplayName = inviteUserModel.DisplayName,
                InvitedUserEmailAddress = inviteUserModel.EmailAddress,
                InvitedUserMessageInfo = new InvitedUserMessageInfo
                {
                    CustomizedMessageBody = inviteUserModel.InviteMessage
                },
                SendInvitationMessage = inviteUserModel.SendInviteMessage
            });

            inviteUserModel.Status = invitation.Status;

            return View(inviteUserModel);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}