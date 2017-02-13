using System;
using System.Collections.Generic;

namespace TIUtilities.Logic.ValidationFramework
{

    //TODO: https://dotnetchris.wordpress.com/2009/02/11/creating-a-generic-validation-framework/
    public static class ValidationFactory
    {
        public static ValidationResult Validate<T>(T obj)
        {
            try
            {

                var validator = ObjectFactory.GetInstance<IValidator<T>>();
                return validator.Validate(obj);
            }
            catch (Exception ex)
            {
                var messages = new List<ValidationMessage> {new ValidationMessage {
                    Message = $"Error validating {obj}"
                }};

                messages.AddRange(FlattenError(ex));

                var result = new ValidationResult { Messages = messages };
                return result;
            }
        }

        private static IEnumerable<ValidationMessage> FlattenError(Exception exception)
        {
            var messages = new List<ValidationMessage>();
            var currentException = exception;

            do
            {
                messages.Add(new ValidationMessage { Message = exception.Message });
                currentException = currentException.InnerException;
            } while (currentException != null);

            return messages;
        }
    }
}