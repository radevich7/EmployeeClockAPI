using EmployeeClock.DTO.Employees;
using EmployeeClock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _employeePropertyMapping = new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
        {
            { "employeeID", new PropertyMappingValue(new List<string>(){"employeeID "}) },
            { "name", new PropertyMappingValue(new List<string>(){"FirstName ", "LastName"}) },
            { "age", new PropertyMappingValue(new List<string>(){"DateOfBirth "}, true) },
        };

        private IList<IPropetyMapping> _propetyMappings = new List<IPropetyMapping>();

        public PropertyMappingService()
        {
            _propetyMappings.Add(new PropertyMapping<EmployeeDTO, Employee>(_employeePropertyMapping));
        }


        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrEmpty(fields))
            {
                return true;
            }


            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(' ');
                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }

            }
            return true;

        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            //get matching mapping

            var matchingMapping = _propetyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;

            }

            throw new Exception($"Cannot find exact property mapping instance " + $"for <{typeof(TSource)}, {typeof(TDestination)}");
        }


    }


}
