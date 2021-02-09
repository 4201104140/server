using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Api.Utilities
{
    public class ApiExplorerGroupConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace;
            controller.ApiExplorer.GroupName = controllerNamespace.Contains(".Public.") ? "public" : "internal";
        }
    }
}
