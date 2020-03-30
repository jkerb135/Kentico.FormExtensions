using System;
using Kentico.Forms.Web.Mvc.Widgets;

namespace Kentico.FormExtensions
{
    public static class FormExtensionHelper
    {
        /// <summary>
        /// <para>Allows form configuration to be loaded via MVC Views</para>
        /// </summary>
        /// <param name="formWidgetRenderingConfiguration"></param>
        /// <param name="configuration"></param>
        public static void RenderFormLayoutFromViews(this FormWidgetRenderingConfiguration formWidgetRenderingConfiguration, 
            Action<FormRenderOptions> configuration)
        {
            var render = new FormViewRenderer(configuration);

            if (render.HasView())
            {
                formWidgetRenderingConfiguration.FormWrapperConfiguration = new FormWrapperRenderingConfiguration()
                {
                    CustomHtmlEnvelope = render.Render()
                };
            }
        }
    }
}
