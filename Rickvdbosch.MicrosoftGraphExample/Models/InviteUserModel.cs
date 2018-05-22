using System.ComponentModel.DataAnnotations;

namespace Rickvdbosch.MicrosoftGraphExample.Models
{
    public class InviteUserModel
    {
        public string DisplayName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.MultilineText)]
        public string InviteMessage { get; set; }

        public bool SendInviteMessage { get; set; }

        public string Status { get; set; }
    }
}