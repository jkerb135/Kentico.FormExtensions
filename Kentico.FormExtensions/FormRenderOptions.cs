
using CMS.OnlineForms;

namespace Kentico.FormExtensions
{
    public class FormRenderOptions
    {
        /// <summary>
        /// <para>Configurable Path Location for Form Partial Views.</para>
        /// <para>Default Value is "~/Views/Shared/Forms/_{0}.cshtml"</para>
        /// <para>{0} is <see cref="CMS.OnlineForms.BizFormInfo"/>.FormName</para>
        /// </summary>
        public string ViewPath { get; set; } = "~/Views/Shared/Forms/_{0}.cshtml";

        /// <summary>
        /// <para>Current Form</para>
        /// </summary>
        public BizFormInfo BizForm { get; set; }
    }
}
