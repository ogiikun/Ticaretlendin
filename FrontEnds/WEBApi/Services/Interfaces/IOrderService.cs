using System.Collections.Generic;
using System.Threading.Tasks;
using WEBApi.Models.Orders;

namespace WEBApi.Services.Interfaces
{
    public interface IOrderService
    {
        //senkron direkt ordera istek 
        Task<OrderCreatedViewModel>CreateOrder(CheckOutInfoInput checkOutInfoInput);

        //asenkron rabbitmq ile
        Task SuspendOrder(CheckOutInfoInput checkOutInfoInput);

        Task<List<OrderViewModel>> GetOrder();
    }
}
