using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
	public class InsurancePolicy
	{
		private int policyId;

		public int PolicyId
		{
			get { return policyId; }
			set { policyId = value; }
		}
		private string policyHolderName;

		public string PolicyHolderName
		{
			get { return policyHolderName; }
			set { policyHolderName = value; }
		}
		private string policyType;


		public string PolicyType
		{
			get { return policyType; }
			set { policyType = value; }
		}

		private decimal premiumAmount;

		public decimal PremiumAmount
		{
			get { return premiumAmount; }
			set { premiumAmount = value; }
		}

		private int policyTerm;

		public int PolicyTerm
		{
			get { return policyTerm; }
			set { policyTerm = value; }
		}
		private bool isActive;

		public bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		public InsurancePolicy(int id, string name, string type, decimal amount, int term, bool active)
		{
			this.policyId = id;
			this.policyHolderName = name;
			this.policyType = type;
			this.PremiumAmount = amount;
			this.policyTerm = term;
			this.isActive = active;
		}
		public override string ToString()
		{
            return $"ID: {PolicyId}, Name: {PolicyHolderName}, Type: {PolicyType},Premium: {PremiumAmount}, Term: {PolicyTerm} yrs, Active: {IsActive}";
        }
	}
}