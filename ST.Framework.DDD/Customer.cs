using System;
using System.Collections.Generic;
using ST.Framework.DDD;

namespace Examples
{
	// Entity
	public class Customer
	{
		public Customer(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; private set; }

		public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

		// ..
	}

	public class PhoneNumber : ValueObject<PhoneNumber>
	{
		public readonly string Number;

		public PhoneNumber(string number)
		{
			Number = number;
		}

		public override int GetHashCode()
		{
			return new { Number }.GetHashCode();
		}

		protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
		{
			return new object[] { Number };
		}

		// ..
	}
}

namespace CustomerWithAddressBook
{
	// Entity
	public class Customer
	{
		public Customer(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; private set; }

		public PhoneBook PhoneNumbers { get; set; }

		// ..
	}

	public class PhoneBook : ValueObject<PhoneBook>
	{
		public readonly PhoneNumber HomeNumber;
		public readonly PhoneNumber MobileNumber;
		public readonly PhoneNumber WorkNumber;

		public PhoneBook(PhoneNumber homeNum, PhoneNumber mobileNum, PhoneNumber workNum)
		{
			HomeNumber = homeNum;
			MobileNumber = mobileNum;
			WorkNumber = workNum;
		}

		public override int GetHashCode()
		{
			return new { HomeNumber, MobileNumber, WorkNumber }.GetHashCode();
		}

		protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
		{
			return new object[] { HomeNumber, MobileNumber, WorkNumber };
		}
	}

	public class PhoneNumber : ValueObject<PhoneNumber>
	{
		public readonly string Number;

		public PhoneNumber(string number)
		{
			Number = number;
		}

		public override int GetHashCode()
		{
			return new { Number }.GetHashCode();
		}

		protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
		{
			return new object[] { Number };
		}

		// ..
	}
}
