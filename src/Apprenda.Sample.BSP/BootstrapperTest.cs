using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apprenda.API.Extension.Bootstrapping;

namespace Apprenda.Sample.BSP
{
    public class BootstrapperTest : BootstrapperBase
    {
        public override BootstrappingResult Bootstrap(BootstrappingRequest bootstrappingRequest)
        {
            /*Provide the logic for your bootstrap policy. Within this method, you have access to the binaries of the component being deployed
             as well as custom properties, application and team information */
            return BootstrappingResult.Success();
        }
    }
}
