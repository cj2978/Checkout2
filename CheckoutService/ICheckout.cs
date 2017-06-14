using System.ServiceModel;

namespace CheckoutService
{
    [ServiceContract]
    public interface ICheckout
    {
        [OperationContract]
        void Scan(string item);

        [OperationContract]
        int GetTotalPrice();
    }
}
