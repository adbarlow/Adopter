using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Adopter.MarkupExtension
{
    [ContentProperty("ResrouceID")]
    public class EmbeddedResource : IMarkupExtension
    {
        public string ResourceID { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceID))
            {
                return null;
            }

            return ImageSource.FromResource(ResourceID);
        }
    }
}
