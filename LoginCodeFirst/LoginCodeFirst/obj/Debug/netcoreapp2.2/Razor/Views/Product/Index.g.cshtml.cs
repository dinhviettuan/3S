#pragma checksum "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Index.cshtml", typeof(AspNetCore.Views_Product_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\_ViewImports.cshtml"
using LoginCodeFirst;

#line default
#line hidden
#line 2 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\_ViewImports.cshtml"
using LoginCodeFirst.Models;

#line default
#line hidden
#line 3 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\_ViewImports.cshtml"
using LoginCodeFirst.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1588c39f62425b32813524e24a7aff7f73faaebf", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<LoginCodeFirst.ViewModels.Product.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("ajax-modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#add-contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
  
    ViewBag.Title = ProductLocalizer.GetLocalizedHtmlString("lbl_ListProduct");

#line default
#line hidden
            BeginContext(149, 313, true);
            WriteLiteral(@"

<div class=""container-fluid"">
    <div class=""block-header"">
    </div>
    <!-- Basic Examples -->
    <div class=""row clearfix"">
        <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
            <div class=""card"">
                <div class=""header"">
                    <h2> 
                        ");
            EndContext();
            BeginContext(462, 219, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f6998", async() => {
                BeginContext(628, 49, false);
#line 18 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                                                 Write(CommonLocalizer.GetLocalizedHtmlString("btn_Add"));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute(")", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(681, 395, true);
            WriteLiteral(@"

                    </h2>  
                </div>
                <div class=""body"">
                    <div class=""table-responsive"">
                        <table class=""table table-bordered table-striped table-hover js-basic-example dataTable"">
                            <thead>
                            <tr>
                                <th>
                                    ");
            EndContext();
            BeginContext(1077, 62, false);
#line 28 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_NumbericalOrder"));

#line default
#line hidden
            EndContext();
            BeginContext(1139, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1252, 58, false);
#line 31 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_ProductName"));

#line default
#line hidden
            EndContext();
            BeginContext(1310, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1423, 54, false);
#line 34 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_BrandId"));

#line default
#line hidden
            EndContext();
            BeginContext(1477, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1590, 57, false);
#line 37 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_CategoryId"));

#line default
#line hidden
            EndContext();
            BeginContext(1647, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1760, 56, false);
#line 40 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_ModelYear"));

#line default
#line hidden
            EndContext();
            BeginContext(1816, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1929, 56, false);
#line 43 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_ListPrice"));

#line default
#line hidden
            EndContext();
            BeginContext(1985, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(2098, 52, false);
#line 46 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_Image"));

#line default
#line hidden
            EndContext();
            BeginContext(2150, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(2263, 54, false);
#line 49 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(ProductLocalizer.GetLocalizedHtmlString("lbl_Actions"));

#line default
#line hidden
            EndContext();
            BeginContext(2317, 146, true);
            WriteLiteral("\n                                </th>\n                            </tr>\n                            </thead>\n                            <tbody>\n");
            EndContext();
#line 54 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               var stt = 0;

#line default
#line hidden
            BeginContext(2508, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 55 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(2637, 73, true);
            WriteLiteral("                                <tr>\n                                <td>");
            EndContext();
            BeginContext(2711, 3, false);
#line 59 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                               Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(2714, 124, true);
            WriteLiteral("</td>\n                                <td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(2839, 44, false);
#line 62 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
            EndContext();
            BeginContext(2883, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3008, 46, false);
#line 65 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(3054, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3179, 42, false);
#line 68 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.BrandId));

#line default
#line hidden
            EndContext();
            BeginContext(3221, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3346, 45, false);
#line 71 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(3391, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3516, 44, false);
#line 74 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ModelYear));

#line default
#line hidden
            EndContext();
            BeginContext(3560, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3685, 44, false);
#line 77 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ListPrice));

#line default
#line hidden
            EndContext();
            BeginContext(3729, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3853, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f18002", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3863, "~/images/", 3863, 9, true);
#line 80 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
AddHtmlAttributeValue("", 3872, Html.DisplayFor(modelItem => item.Image), 3872, 41, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3930, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(4054, 176, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f19813", async() => {
                BeginContext(4176, 50, false);
#line 84 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                                                     Write(CommonLocalizer.GetLocalizedHtmlString("btn_Edit"));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 84 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                             WriteLiteral(item.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4230, 41, true);
            WriteLiteral("\n                                        ");
            EndContext();
            BeginContext(4271, 272, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e49ee9e2c7d3739d8e9241d66de7bcf8d31d66f22594", async() => {
                BeginContext(4487, 52, false);
#line 86 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                                                            Write(CommonLocalizer.GetLocalizedHtmlString("btn_Delete"));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue(" ", 4328, "return", 4329, 7, true);
            AddHtmlAttributeValue(" ", 4335, "confirm(\'", 4336, 10, true);
#line 85 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
AddHtmlAttributeValue("", 4345, CommonLocalizer.GetLocalizedHtmlString("btn_YouDelete"), 4345, 56, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4401, "\')", 4401, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 86 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                                                    WriteLiteral(item.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4543, 82, true);
            WriteLiteral("\n\n                                    </td>\n                                </tr>\n");
            EndContext();
#line 90 "C:\3S-master\LoginCodeFirst\LoginCodeFirst\Views\Product\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(4655, 171, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<StockResources> StockLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<ProductResources> ProductLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<StoreResources> StoreLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<LoginResources> LoginLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<CategoryResources> CategoryLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<CommonResources> CommonLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<BrandResources> BrandLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<LoginCodeFirst.ViewModels.Product.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
