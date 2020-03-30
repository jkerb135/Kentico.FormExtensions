using CMS.EventLog;
using CMS.OnlineForms;
using System;
using System.Web;
using System.Web.Mvc;
using File = System.IO.File;

namespace Kentico.FormExtensions
{
    internal class FormViewRenderer
    {
        protected string ViewLocation;
        protected BizFormInfo BizForm;

        protected string FormattedViewLocation;

        public FormViewRenderer(Action<FormRenderOptions> configuration)
            : this(Build(configuration))
        {
        }

        protected FormViewRenderer(FormRenderOptions options)
        {
            ViewLocation = options.ViewPath ?? throw new ArgumentNullException(nameof(options.ViewPath));
            BizForm = options.BizForm ?? throw new ArgumentNullException(nameof(options.BizForm));
            FormattedViewLocation = string.Format(ViewLocation, BizForm.FormName);
        }

        public bool HasView()
        {
            try
            {
                EventLogProvider.LogInformation(nameof(FormViewRenderer), nameof(HasView), FormattedViewLocation);
                return File.Exists(HttpContext.Current.Server.MapPath(FormattedViewLocation));
            }
            catch (Exception e)
            {
                EventLogProvider.LogException(nameof(FormViewRenderer), nameof(HasView), e);
                return false;
            }
        }

        public MvcHtmlString Render()
        {
            try
            {
                var controller = ViewRenderer.CreateController<EmptyController>();
                var html = ViewRenderer.RenderPartialView(FormattedViewLocation, BizForm,
                    controller.ControllerContext);
                return MvcHtmlString.Create(html);
            }
            catch (Exception e)
            {
                EventLogProvider.LogException(nameof(FormViewRenderer), nameof(Render), e);
                return MvcHtmlString.Empty;
            }
        }

        private static FormRenderOptions Build(Action<FormRenderOptions> configuration)
        {
            var options = new FormRenderOptions();
            configuration(options);
            return options;
        }
    }
}
