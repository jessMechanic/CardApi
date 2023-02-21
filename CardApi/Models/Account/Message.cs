﻿namespace CardApi.Models.Account
{
    public class Message
    {
        public Guid Id { get; set; }
        public User? Sender { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? TimeStap { get; set; }

    }
}
