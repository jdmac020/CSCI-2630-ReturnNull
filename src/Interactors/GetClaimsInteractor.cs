using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Interactors;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetClaimsInteractor
    {
        ClaimEntity GetByPolicyId(Guid policyId);
    }

    public class GetClaimsInteractor : IGetClaimsInteractor
    {
        private ClaimsRepository Repo
        {
            get { return _repo ??(_repo = new ClaimsRepository()); }
            set { _repo = value; }
        }
        private ClaimsRepository _repo;
        public ClaimEntity GetByPolicyId(Guid policyId)
        {
            return Repo.GetByPolicyId(policyId);
        }

    }
}