using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "CleanArchitecture.Domain";
        private const string ApplicationNamespace = "CleanArchitecture.Application";
        private const string InfrastructureNamespace = "CleanArchitecture.Infrastructor";
        private const string PersistanceNamespace = "CleanArchitecture.Persistance";
        private const string PresentationNamespace = "CleanArchitecture.Presentation";
        private const string ApiNamespace = "CleanArchitecture.API";
        // arrange -> action -> assert 
        [Fact]
        public void Domain_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //arrange
            var assembly = Domain.AssemblyReference.Assembly;
            var ortherProject = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PersistanceNamespace,
                PresentationNamespace,
                ApiNamespace
            };
   
        }
    }
}
