# Kentico.FormExtensions

## Documentation for Kentico Form Widget Configuration
[View Here](https://docs.kentico.com/k12/developing-websites/form-builder-development/customizing-the-form-widget#CustomizingtheFormwidget-Examples)

## ~/App_Code/FormWidgetMarkupInjection.cs

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

# ~/Views/Shared/Forms/_(ParialViewByFormName).cshtml

```csharp
@using Kentico.Forms.Web.Mvc.Widgets
@model CMS.OnlineForms.BizFormInfo
<section class="form-section contaner">
    <div class="row align-center">
        <div class="col-12">
            <h2>@Model.FormDisplayName</h2>
        </div>
        <div class="col-sm-12 col-md-8">
            <!-- Form -->
            @(FormWrapperRenderingConfiguration.CONTENT_PLACEHOLDER)
        </div>
    </div>
</section>
```