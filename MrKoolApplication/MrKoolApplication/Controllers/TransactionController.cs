using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using MrKoolApplication.Models;

namespace MrKoolApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Areas")]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            var transactionDTOs = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransactionById(int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            return Ok(transactionDTO);
        }

        [HttpGet]
        [Route("GetByDate")]
        public ActionResult<IEnumerable<TransactionDTO>> GetByDate(DateTime date)
        {
            var transactions = _transactionRepository.GetByDate(date);
            var transactionDTOs = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionDTOs);
        }

        [HttpPut]
        [Route("UpdateTransaction/{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, TransactionDTO transactionDTO)
        {
            if (id != transactionDTO.TransactionID)
            {
                return BadRequest();
            }

            var transaction = _mapper.Map<Transaction>(transactionDTO);
            var exists = _transactionRepository.TransactionExist(id);
            if (!exists)
            {
                return NotFound();
            }

            var updateResult = _transactionRepository.UpdateTransaction(transaction);
            if (!updateResult)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            await _transactionRepository.DeleteTransactionAsync(transaction);
            return NoContent();
        }
    }
}
