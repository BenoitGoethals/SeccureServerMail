using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace ClassLibraryDomain
{
   public class MailValidator: AbstractValidator<Mail>
   {

       public MailValidator()
       {
           RuleFor(mailToValidate => mailToValidate.From).NotEmpty();
            RuleFor(mailToValidate => mailToValidate.To).NotEmpty();
            RuleFor(mailToValidate => mailToValidate.Message).NotEmpty();

            RuleFor(mailToValidate => mailToValidate.Body).NotEmpty();
            RuleFor(mailToValidate => mailToValidate.Classifications).Must(ValidClassiFication);
       }

        private bool ValidClassiFication(ISet<Classification> classifications)
       {
            
           return true;
       }
       public Boolean MailValide(Mail mail) 
       {
           
           // ValidationResult results = this.Validate(mail);
            this.ValidateAndThrow(mail);
           // bool validationSucceeded = results.IsValid;
           // throw new ValidationException(results.Errors);
       

           return true;
       }
    }
}
