﻿namespace WebApplication1.Controllers
{
    public class BuySignModel
    {
        public string CardAddressCountry { get; set; }
        public string CardAddressLine1 { get; set; }
        public string CardAddressLine2 { get; set; }
        public string CardAddressCity { get; set; }
        public string CardAddressZip { get; set; }
        public string CardCvc { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
    }
}