namespace Application.Messages.Models
{
    public record SendMessageModel
    {
        public string SenderUsername { get; set; } = string.Empty;

        public string ReceiverUsername { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
