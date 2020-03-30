# Kentico.FormExtensions

```csharp
using Kentico.FormExtensions;

public class FormWidgetMarkupInjection
{
    public static void RegisterEventHandlers()
    {
        FormWidgetRenderingConfiguration.GetConfiguration.Execute += FormWidgetInjectMarkup;
    }


    private static void FormWidgetInjectMarkup(object sender, GetFormWidgetRenderingConfigurationEventArgs e)
    {
        e.Configuration.RenderFormLayoutFromViews(options =>
        {
            options.ViewPath = "~/Shared/Views/Forms/{0}.cshtml";
            options.BizForm = e.Form;
        });
    }
}
```
