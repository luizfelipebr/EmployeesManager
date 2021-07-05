using EmployeesManager.Domain.Validator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesManager.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public IList<ValidationFailure> Errors { get; }

        public int StatusCode
        {
            get
            {
                return 400;
            }
        }

        public BusinessException() { }

        public BusinessException(string message) :
            this(message, new List<ValidationFailure> { new ValidationFailure { Message = message } })
        { }

        public BusinessException(string message, string field) :
           this(message, new List<ValidationFailure> { new ValidationFailure { Message = message, Field = field } })
        { }
        public BusinessException(IList<ValidationFailure> errors) :
            this(string.Empty, errors)
        { }

        public BusinessException(IList<FluentValidation.Results.ValidationFailure> errors) :
            this(string.Empty, (from failure in errors select new ValidationFailure { Field = failure.PropertyName, Message = failure.ErrorMessage, Codigo = failure.ErrorCode }).ToList())
        { }

        public BusinessException(string message, IList<FluentValidation.Results.ValidationFailure> errors) :
            this(message, (from failure in errors select new ValidationFailure { Field = failure.PropertyName, Message = failure.ErrorMessage, Codigo = failure.ErrorCode }).ToList())
        { }

        protected BusinessException(string message, IList<ValidationFailure> errors) :
            base(message)
        {
            Errors = errors;
        }

        public override string ToString() => JsonConvert.SerializeObject(Errors, Formatting.Indented);

    }
}
