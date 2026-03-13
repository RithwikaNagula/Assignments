using System;
using System.Collections;
using InsuranceLibrary.Models;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        List<InsurancePolicy> policies = new List<InsurancePolicy>();


        public bool AddPolicy(InsurancePolicy policy)
        {
            if (GetPolicyById(policy.PolicyId) != null)
                return false;

            policies.Add(policy);
            return true;
        }


        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

       
        public InsurancePolicy GetPolicyById(int id)
        {
            foreach (InsurancePolicy p in policies)
            {
                if (p.PolicyId == id)
                    return p;
            }
           
            return null;
              
        }

 
        public bool UpdatePolicy(int id, decimal newPremium, int newTerm)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy != null)
            {
                policy.PremiumAmount = newPremium;
                policy.PolicyTerm = newTerm;
                return true;
            }
            return false;
        }

        public bool DeactivatePolicy(int id)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy != null)
            {
                policy.IsActive = false;
                return true;
            }
            return false;
        }

    }
}
