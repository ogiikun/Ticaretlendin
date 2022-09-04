using System.Threading.Tasks;
using WEBApi.Models.FakePayments;

namespace WEBApi.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
