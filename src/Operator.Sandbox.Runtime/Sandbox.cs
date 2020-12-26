using System;
using System.Threading.Tasks;
using k8s.Models;
using KubeOps.Operator.Controller;
using KubeOps.Operator.Entities;
using KubeOps.Operator.Entities.Annotations;
using KubeOps.Operator.Finalizer;
using KubeOps.Operator.Services;

namespace Operator.Sandbox.Runtime
{
    public class MetricDeclarationController : ResourceControllerBase<MetricDeclarationEntity>
    {
        public MetricDeclarationController(IResourceServices<MetricDeclarationEntity> services) : base(services)
        {
        }

        protected override Task<TimeSpan?> Created(MetricDeclarationEntity resource)
        {
            var result = base.Created(resource);
            Console.WriteLine($"Created entity {resource.Metadata.Name} for metric {resource.Spec.MetricName}");
            return result;
        }

        protected override Task Deleted(MetricDeclarationEntity resource)
        {
            var result = base.Deleted(resource);
            Console.WriteLine($"Created entity {resource.Metadata.Name} for metric {resource.Spec.MetricName}");
            return result;
        }

        protected override Task<TimeSpan?> Updated(MetricDeclarationEntity resource)
        {
            var result = base.Updated(resource);
            Console.WriteLine($"Updated entity {resource.Metadata.Name} for metric {resource.Spec.MetricName}");
            return result;
        }
    }

    public class MetricDeclarationSpec
    {
        [Required]
        [Description("Name of metric to report")]
        public string MetricName { get; set; }
    }

    [KubernetesEntity(Group = "promitor.io", ApiVersion = "v1alpha")]
    public class MetricDeclarationEntity : CustomKubernetesEntity<MetricDeclarationSpec>
    {
    }
}
