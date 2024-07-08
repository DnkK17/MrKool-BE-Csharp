using Microsoft.AspNetCore.Mvc;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using MrKoolApplication.Models;
using MrKoolApplication.VNPay;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly VnPayPayment _vnPayPayment;

        public PaymentController(IPaymentRepository paymentRepository, IRequestRepository requestRepository, VnPayPayment vnPayPayment)
        {
            _paymentRepository = paymentRepository;
            _requestRepository = requestRepository;
            _vnPayPayment = vnPayPayment;
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                var request = await _requestRepository.GetRequestByIdAsync(paymentDto.RequestId);
                if (request == null)
                {
                    return BadRequest(new { Message = "Invalid Request ID" });
                }

                var amount = request.TotalPrice ?? 0;
                var payment = new Payment
                {
                    OrderId = paymentDto.RequestId.ToString(),
                    Amount = (decimal)amount,
                    Status = "Pending",
                    CreatedDate = DateTime.UtcNow,
                    RequestId = paymentDto.RequestId // Set RequestId
                };

                payment = await _paymentRepository.CreatePaymentAsync(payment);

                var paymentUrl = _vnPayPayment.CreatePaymentUrl(payment.OrderId, payment.Amount, paymentDto.OrderInfo);
                return Ok(new { Url = paymentUrl });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback([FromQuery] Dictionary<string, string> vnpayData)
        {
            var orderId = vnpayData["vnp_TxnRef"];
            var payment = await _paymentRepository.GetPaymentByIdAsync(int.Parse(orderId));

            if (payment == null)
            {
                return BadRequest(new { Status = "Failed", Message = "Payment not found" });
            }

            var isValidSignature = _vnPayPayment.ValidateSignature(vnpayData);
            if (isValidSignature)
            {
                payment.Status = "Success";
            }
            else
            {
                payment.Status = "Failed";
            }

            await _paymentRepository.UpdatePaymentAsync(payment);
            return Ok(new { Status = isValidSignature ? "Success" : "Failed" });
        }
    }

}
