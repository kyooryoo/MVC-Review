using System;
using System.ComponentModel.DataAnnotations;

// This model implement the business rule that 
// requires all members except "pay as you go"
// are at least 18 years old

namespace Bokly.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			// istead of 0 and 1, we use the props in MembershipType to increase code readability
			if (customer.MembershipTypeId == MembershipType.Unknown ||
				customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;

			if (customer.BirthDate == null)
				return new ValidationResult("Birthdate is required.");

			var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

			return (age >= 18) 
				? ValidationResult.Success 
				: new ValidationResult("Customer should be at least 18 years old to go on a membership.");
		}
	}
}