using AutoMapper;
using EmployeeClock.API.ResourseParameters;
using EmployeeClock.DTO.Employees;
using EmployeeClock.Entities;
using EmployeeClock.Repository.EmployeeRepository;
using EmployeeClock.Repository.Helpers;
using EmployeeClock.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeeClock.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    //[Authorize]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IPropertyCheckerService _propertyCheckerService;



        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
            _propertyCheckerService = propertyCheckerService ?? throw new ArgumentNullException(nameof(propertyCheckerService));
        }


        [HttpGet(Name = ("GetEmployees"))]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeResourceParameters resourceParameters)
        {

            if (!_propertyMappingService.ValidMappingExistsFor<EmployeeDTO, Employee>(resourceParameters.OrderBy))
            {
                return BadRequest();
            }

            var employeesFromRepo = await _employeeRepository.GetAllEmployeesAsync(resourceParameters);

            var nextPageLink = employeesFromRepo.HasNext ? CreateEmployeeResourceUri(resourceParameters, ResourceUriType.NextPage) : null;

            var previousPageLink = employeesFromRepo.HasPrevious ? CreateEmployeeResourceUri(resourceParameters, ResourceUriType.PreviousPage) : null;


            var paginationMetaData = new
            {
                totalCount = employeesFromRepo.TotalCount,
                pageSize = employeesFromRepo.PageSize,
                currentPage = employeesFromRepo.CurrentPage,
                totalPages = employeesFromRepo.TotalPages,
                nextPageLink,
                previousPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));


            var employeeToreturn = _mapper.Map<IEnumerable<EmployeeDTO>>(employeesFromRepo).ShapeData(resourceParameters.Fields);

            return Ok(employeeToreturn);
        }



        [HttpGet("{employeeID}", Name = ("GetEmployee"))]
        public async Task<IActionResult> GetEmployee(Guid employeeID, string? fields, bool includeTimeTransaction = false)
        {
            if (!_propertyCheckerService.TypeHasProperties<EmployeeDTO>
            (fields))
            {
                return BadRequest();
            }

            var employee = await _employeeRepository.GetEmployeeAsync(employeeID, includeTimeTransaction);
            if (employee == null)
            {
                return NotFound();
            }
            if (includeTimeTransaction)
            {
                return Ok(_mapper.Map<EmployeeWithTransactionsDTO>(employee).ShapeData(fields));
            }

            return Ok(_mapper.Map<EmployeeDTO>(employee).ShapeData(fields));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeForCreationDTO>> CreateEmployee(EmployeeForCreationDTO employeeForCreation)
        {
            var newEmployee = _mapper.Map<Employee>(employeeForCreation);
            _employeeRepository.CreateEmployee(newEmployee);
            await _employeeRepository.SaveChangesAsync();
            return CreatedAtRoute("GetEmployee", new { employeeID = newEmployee.EmployeeID, includeTimeTransaction = false }, newEmployee);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateEmployee(EmployeeForUpdateDTO employeeForUpdate)
        {
            if (!await _employeeRepository.EmployeeExistAsync(employeeForUpdate.EmployeeID))
            {
                return NotFound();
            };

            var employeeEntity = await _employeeRepository.GetEmployeeAsync(employeeForUpdate.EmployeeID);
            _mapper.Map(employeeForUpdate, employeeEntity);
            await _employeeRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{employeeID}")]
        public async Task<ActionResult> PartialUpdateEmployee(Guid employeeID, JsonPatchDocument<EmployeeForUpdateDTO> patchDocument)
        {
            if (!await _employeeRepository.EmployeeExistAsync(employeeID))
            {
                return NotFound();
            };


            var employeeEntity = await _employeeRepository.GetEmployeeAsync(employeeID);
            if (employeeEntity == null)
            {
                return NotFound();

            }

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDTO>(
                employeeEntity);

            patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(employeeToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeEntity);
            await _employeeRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{employeeID}")]
        public async Task<ActionResult> DeleteEmployee(Guid employeeID)
        {
            if (!await _employeeRepository.EmployeeExistAsync(employeeID))
            {
                return BadRequest();
            }
            var employeeToDelete = await _employeeRepository.GetEmployeeAsync(employeeID);

            _employeeRepository.DeleteEmployee(employeeToDelete);
            await _employeeRepository.SaveChangesAsync();

            return NoContent();

        }



        private string CreateEmployeeResourceUri(EmployeeResourceParameters employeeResourceParameter, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetEmployees", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber - 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetEmployees", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber + 1,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                    });
                default:
                    return Url.Link("GetEmployees", new
                    {
                        fields = employeeResourceParameter.Fields,
                        orderBy = employeeResourceParameter.OrderBy,
                        pageNumber = employeeResourceParameter.PageNumber,
                        pageSize = employeeResourceParameter.PageSize,
                        searchQuery = employeeResourceParameter.SearchQuery,
                    });
            }
        }
    }
}
