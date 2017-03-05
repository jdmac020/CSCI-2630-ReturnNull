using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models; //Added
using EDeviceClaims.Interactors; //Added

namespace EDeviceClaims.Domain.Services
{
    // All Added by James
    public interface IClaimsService
    {
        ClaimsDomainModel StartClaim(Guid policyId);
    }

    public class ClaimsService: IClaimsService
    {
        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetClaimsInteractor GetClaimsInteractor
        {
            get { return _getClaimsInteractor ?? (_getClaimsInteractor = new GetClaimsInteractor()); }
            set { _getClaimsInteractor = value; }
        }
        private IGetClaimsInteractor _getClaimsInteractor;

        public ClaimsDomainModel StartClaim (Guid policyId)
        {
            var policy = _getPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("Policy for that Policy Id does not exist.");

            var existingClaim = _getClaimsInteractor.GetByPolicyId(policyId);

            return new ClaimsDomainModel();
        }

    }
}
