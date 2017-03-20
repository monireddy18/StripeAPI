using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using Stripe;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var result = GetResult();
            return View();
        }

        public string GetResult()
        {
            BuySign(null);
            return "";
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static string BuySign(BuySignModel model)
        {
            var errorMessage = string.Empty;
            var validationError = string.Empty;
            var chargeId = string.Empty;

            //if (ModelState.IsValid)
            //{
                //try
                //{
                    var tokenId = GetTokenId(model);
                    chargeId = ChargeCustomer(tokenId);
                //}
                //catch (Exception e)
                //{
                //    errorMessage = e.Message;
                //}
            //}

            return null;
            //...rest of the code omitted for clarity
        }

        private static string ChargeCustomer(string tokenId)
        {
          
                var myCharge = new StripeChargeCreateOptions
                {
                    Amount = 50,
                    Currency = "gbp",
                    Description = "Charge for property sign and postage",
                    SourceTokenOrExistingSourceId = tokenId
                };

                var chargeService = new StripeChargeService();
                var stripeCharge = chargeService.Create(myCharge);

                return stripeCharge.Id;
            
        }

        private static string GetTokenId(BuySignModel model)
        {
            
                var myCardToken = new StripeCreditCardOptions
                {
                    //AddressCountry = model.CardAddressCountry,
                    //AddressLine1 = model.CardAddressLine1,
                    //AddressLine2 = model.CardAddressLine2,
                    //AddressCity = model.CardAddressCity,
                    //AddressZip = model.CardAddressZip,
                    //Cvc = model.CardCvc.ToString(CultureInfo.CurrentCulture),
                    //ExpirationMonth = model.CardExpirationMonth,
                    //ExpirationYear = model.CardExpirationYear,
                    //Name = model.CardName,
                    //Number = model.CardNumber

                    AddressCountry = "Brazil (BR)",
                    AddressLine1 = " ",
                    AddressLine2 = " ",
                    AddressCity = " ",
                    AddressZip = " ",
                    Cvc = "954",
                    ExpirationMonth = "1",
                    ExpirationYear = "2020",
                    Name = " ",
                    Number = "4000000760000002"
                };

                var myToken = new StripeTokenCreateOptions
                {
                    Card = myCardToken
                };
                var tokenService = new StripeTokenService();
                var stripeToken = tokenService.Create(myToken);

                return stripeToken.Id;
            
        }
    }
}