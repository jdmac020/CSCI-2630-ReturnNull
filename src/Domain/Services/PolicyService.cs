using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IPolicyService
  {
    IEnumerable<PolicyDomainModel> GetByUserId(string userId);
    PolicyDomainModel GetById(Guid id);
    //^^^ Added by James (Above)
  }

  public class PolicyService : IPolicyService
  {
    private IGetPolicyInteractor _getPolicyInteractor;

    private IGetPolicyInteractor GetPolicyInteractor
    {
      get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
      set { _getPolicyInteractor = value; }
    }

    public IEnumerable<PolicyDomainModel> GetByUserId(string userId)
    {
      var policyEntities = GetPolicyInteractor.GetByUserId(userId);

      return policyEntities.Select(policyEntity => new PolicyDomainModel(policyEntity)).ToList();
    }

    //Added by James (Below)
    public PolicyDomainModel GetById(Guid id)
    {
       var entity = GetPolicyInteractor.GetById(id);

       if (entity == null) return null;

       return new PolicyDomainModel(entity);
    }
  }
}
