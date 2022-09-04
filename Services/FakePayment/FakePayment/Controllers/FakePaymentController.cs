using FakePayment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using Shared.Dtos;

namespace FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {


        [HttpPost]

        public IActionResult ReceivePayment(PaymentDto paymentDto)
        {

            //paymentdto ile ödeme işlemi gerçekleştir
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
