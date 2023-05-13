using Core.Models;
using Core.Ports.Driving.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Service
{
    public class MetadataService : Service<Metadata>, IMetadataService
    {
        public MetadataService(IMetadataRepository repository) : base(repository)
        {
        }
    }
}
