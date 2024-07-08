using MrKoolApplication.Models;

namespace MrKoolApplication.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> GetPaymentByIdAsync(int id);
        Task UpdatePaymentAsync(Payment payment);
    }
}
