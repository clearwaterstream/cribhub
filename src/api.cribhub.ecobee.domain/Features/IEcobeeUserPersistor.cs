using api.cribhub.ecobee.domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.domain.Features
{
    public interface IEcobeeUserPersistor
    {
        Task Add(EcobeeUserAuthInfo userAuthInfo, CancellationToken cancellationToken);
    }
}
