using AutoMapper;
using EmployeeClock.DTO.TimeTransactions;
using EmployeeClock.Repository.Helpers;
using EmployeeClock.Repository.ResourseParameters;
using EmployeeClock.Repository.TimeTransactionRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.Json;
using EmployeeClock.Repository.EmployeeRepository;
using EmployeeClock.Entities;

namespace EmployeeClock.API.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TimeTransactionController : ControllerBase
    {


        private readonly ITransactionRepository _transactionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public TimeTransactionController(ITransactionRepository transactionRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet(Name = ("GetTimeTransactions"))]
        public async Task<IActionResult> GetAllTransactions([FromQuery] TimeTransactionResourceParameters resourceParameters)
        {
            var transactionsFromRepo = await _transactionRepository.GetTimeTransactionsAsync(resourceParameters);

            var nextPageLink = transactionsFromRepo.HasNext ? CreateTimetransactionResourceUri(resourceParameters, ResourceUriType.NextPage) : null;
            var previousPageLink = transactionsFromRepo.HasPrevious ? CreateTimetransactionResourceUri(resourceParameters, ResourceUriType.PreviousPage) : null;

            var paginationMetaData = new
            {
                totalCount = transactionsFromRepo.TotalCount,
                pageSize = transactionsFromRepo.PageSize,
                currentPage = transactionsFromRepo.CurrentPage,
                totalPages = transactionsFromRepo.TotalPages,
                nextPageLink,
                previousPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize
                (paginationMetaData));


            return Ok(_mapper.Map<IEnumerable<TimeTransactionDTO>>(transactionsFromRepo));
        }
        [HttpGet("{transactionID}", Name = ("GetTimeTransaction"))]

        public async Task<IActionResult> GetTransaction(Guid transactionID)
        {
            if (!_transactionRepository.TransactionExists(transactionID))
            {
                NotFound();
            }
            var transactionToReturn = await _transactionRepository.GetTimeTransactionAsync(transactionID);

            return Ok(_mapper.Map<TimeTransactionDTO>(transactionToReturn));

        }


        [HttpGet("{employeeID}/list", Name = ("GetTimeTransactionsByEmployeeID"))]
        public async Task<IEnumerable<TimeTransactionDTO>> GetAllTransactions(Guid employeeID, [FromQuery] TimeTransactionResourceParameters resourceParameters)
        {
            var transactionsFromRepo = await _transactionRepository.GetTimeTransactionsAsync(employeeID, resourceParameters);


            var nextPageLink = transactionsFromRepo.HasNextWithEmployeeID ? CreateTimetransactionResourceUri(resourceParameters, ResourceUriType.HasNextWithEmployeeID, employeeID) : null;
            var previousPageLink = transactionsFromRepo.HasPreviousWithEmployeeID ? CreateTimetransactionResourceUri(resourceParameters, ResourceUriType.HasPreviousWithEmployeeID, employeeID) : null;

            var paginationMetaData = new
            {
                totalCount = transactionsFromRepo.TotalCount,
                pageSize = transactionsFromRepo.PageSize,
                currentPage = transactionsFromRepo.CurrentPage,
                totalPages = transactionsFromRepo.TotalPages,
                nextPageLink,
                previousPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize
                (paginationMetaData));

            return _mapper.Map<IEnumerable<TimeTransactionDTO>>(transactionsFromRepo);
        }


        [HttpPost("{employeeID}", Name = ("CreateTimeTransaction"))]
        public async Task<ActionResult<TimeTransactionDTO>> CreateTransaction(Guid employeeID, TimeTransactionForCreationDTO transactionForCreation)
        {
            if (!await _employeeRepository.EmployeeExistAsync(employeeID))
            {
                return NotFound();
            }

            var transactionEntity = _mapper.Map<TimeTransaction>(transactionForCreation);
            transactionEntity.EmployeeID = employeeID;
            _transactionRepository.CreateTransaction(transactionEntity);
            _transactionRepository.SaveChangesAsync();

            var transactioToReturn = _mapper.Map<TimeTransactionDTO>(transactionEntity);
            return CreatedAtRoute("GetTimeTransactionsByEmployeeID", new { employeeID }, transactioToReturn);


        }
        [HttpPut(Name = ("UpdateTimeTransaction"))]

        public async Task<ActionResult> UpdateTimeTransaction(TimeTransactionForUpdateDTO transactionToUpdate)
        {
            if (!_transactionRepository.TransactionExists(transactionToUpdate.TransactionID))
            {
                NotFound();
            }
            var transactionEntity = await _transactionRepository.GetTimeTransactionAsync(transactionToUpdate.TransactionID);

            _mapper.Map(transactionToUpdate, transactionEntity);
            await _transactionRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{transactionID}", Name = ("PartialUpdateTransaction"))]

        public async Task<ActionResult> PartialUpdateOfTransaction(Guid transactionID, JsonPatchDocument<TimeTransactionForUpdateDTO> patchDocument)
        {
            if (!_transactionRepository.TransactionExists(transactionID))
            {
                return NotFound();
            }

            var transactionEntity = await _transactionRepository.GetTimeTransactionAsync(transactionID);
            if (transactionEntity == null)
            {
                return NotFound();
            }

            var transactionToPatch = _mapper.Map<TimeTransactionForUpdateDTO>(transactionEntity);
            patchDocument.ApplyTo(transactionToPatch, ModelState);
            if (!TryValidateModel(transactionToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(transactionToPatch, transactionEntity);
            _transactionRepository.SaveChangesAsync();
            return NoContent();

        }



        private string CreateTimetransactionResourceUri(TimeTransactionResourceParameters employeeResourceParameter, ResourceUriType type, Guid employeeID = default(Guid))
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetTimeTransactions", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber - 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetTimeTransactions", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber + 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                    });

                case ResourceUriType.HasPreviousWithEmployeeID:
                    return Url.Link("GetTimeTransactionsByEmployeeID", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber - 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                        employeeID = employeeID.ToString(),

                    });
                case ResourceUriType.HasNextWithEmployeeID:
                    return Url.Link("GetTimeTransactionsByEmployeeID", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber + 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                        employeeID = employeeID.ToString(),
                    });
                default:
                    return Url.Link("GetTimeTransactions", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                        employeeID = employeeID.ToString(),
                    });
            }
        }
    }



}

