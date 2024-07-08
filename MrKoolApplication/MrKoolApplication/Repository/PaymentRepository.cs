using MrKool.Data;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using MrKoolApplication.Models;
using MrKoolApplication.VNPay;

namespace MrKoolApplication.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DBContext _context;

        public PaymentRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

    }
}
