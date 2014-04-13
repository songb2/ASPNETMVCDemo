using System.Web.Mvc;

namespace MvcModels.Models
{
    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            AddressSummary model = (AddressSummary)bindingContext.Model ?? new AddressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");

            return model;
        }

        private string GetValue(ModelBindingContext bindingContext, string name)
        {
            name = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + name; // eg. [0].City, [0].Country
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue == "")
            {
                return "<Not Specified>";
            }
            else
            {
                return (string)result.AttemptedValue;
            }
        }
    }
}