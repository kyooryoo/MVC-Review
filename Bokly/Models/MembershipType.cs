using System.ComponentModel.DataAnnotations;

namespace Bokly.Models
{
	public class MembershipType
	{
		public byte Id { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }
		[Required]
		public string Name { get; set; }

		// default value is 0, which means Unkown
		// following two props are used for avoiding magic numbers
		// which has ambiguous meanings and hard to read in code
		// in the file of Min18YearIfAMember.cs
		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
}