#pragma checksum "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fc2ca005e402a1d9953f168b553028702fce821"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
#line 1 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/_ViewImports.cshtml"
using LoginCodeFirst;

#line default
#line hidden
#line 2 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/_ViewImports.cshtml"
using LoginCodeFirst.Models;

#line default
#line hidden
#line 3 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/_ViewImports.cshtml"
using LoginCodeFirst.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fc2ca005e402a1d9953f168b553028702fce821", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7039e44ca0ef7ba6cfead352bfaf077c8ccb979f", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<LoginCodeFirst.ViewModels.User.UserViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("ajax-modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#add-contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
  
    ViewBag.Title = UserLocalizer.GetLocalizedHtmlString("lbl_ListUser");

#line default
#line hidden
            BeginContext(137, 330, true);
            WriteLiteral(@"<div class=""container-fluid"">
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
            BeginContext(467, 214, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fc2ca005e402a1d9953f168b553028702fce8216541", async() => {
                BeginContext(628, 49, false);
#line 15 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
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
            BeginContext(681, 412, true);
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
            BeginContext(1094, 61, false);
#line 24 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(CommonLocalizer.GetLocalizedHtmlString("lbl_NumbericalOrder"));

#line default
#line hidden
            EndContext();
            BeginContext(1155, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1268, 51, false);
#line 27 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_StoreId"));

#line default
#line hidden
            EndContext();
            BeginContext(1319, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1432, 49, false);
#line 30 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_Email"));

#line default
#line hidden
            EndContext();
            BeginContext(1481, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1594, 52, false);
#line 33 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_FullName"));

#line default
#line hidden
            EndContext();
            BeginContext(1646, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1759, 49, false);
#line 36 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_Phone"));

#line default
#line hidden
            EndContext();
            BeginContext(1808, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(1921, 52, false);
#line 39 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_IsActive"));

#line default
#line hidden
            EndContext();
            BeginContext(1973, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(2086, 48, false);
#line 42 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(UserLocalizer.GetLocalizedHtmlString("lbl_Role"));

#line default
#line hidden
            EndContext();
            BeginContext(2134, 112, true);
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
            EndContext();
            BeginContext(2247, 53, false);
#line 45 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               Write(CommonLocalizer.GetLocalizedHtmlString("lbl_Actions"));

#line default
#line hidden
            EndContext();
            BeginContext(2300, 146, true);
            WriteLiteral("\n                                </th>\n                            </tr>\n                            </thead>\n                            <tbody>\n");
            EndContext();
#line 50 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                               var stt = 0;

#line default
#line hidden
            BeginContext(2491, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 51 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(2620, 77, true);
            WriteLiteral("                                <tr>\n                                    <td>");
            EndContext();
            BeginContext(2698, 3, false);
#line 55 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(2701, 87, true);
            WriteLiteral("</td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(2789, 50, false);
#line 57 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Store.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(2839, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(2964, 40, false);
#line 60 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(3004, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3129, 43, false);
#line 63 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(3172, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3297, 40, false);
#line 66 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(3337, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3462, 43, false);
#line 69 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(3505, 84, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n");
            EndContext();
#line 72 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                         if (item.Role == 1)
                                        {

#line default
#line hidden
            BeginContext(3692, 57, true);
            WriteLiteral("                                            <p>Admin</p>\n");
            EndContext();
#line 75 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(3878, 56, true);
            WriteLiteral("                                            <p>User</p>\n");
            EndContext();
#line 79 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                        }

#line default
#line hidden
            BeginContext(3976, 251, true);
            WriteLiteral("                                    </td>\n                                    <td>\n                                        <div id=\"modal-placeholder\"></div>\n                                        <a type=\"button\"  data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(4228, 88, false);
#line 83 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                                                                        Write(Url.Action("EditPassword",
                                          new {id = item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(4316, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(4319, 56, false);
#line 84 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                                          Write(UserLocalizer.GetLocalizedHtmlString("btn_EditPassword"));

#line default
#line hidden
            EndContext();
            BeginContext(4375, 129, true);
            WriteLiteral("\n                                        </a>\n                                        ||\n                                        ");
            EndContext();
            BeginContext(4504, 166, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fc2ca005e402a1d9953f168b553028702fce82119574", async() => {
                BeginContext(4616, 50, false);
#line 88 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                             WriteLiteral(item.Id);

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
            BeginContext(4670, 44, true);
            WriteLiteral(" ||\n                                        ");
            EndContext();
            BeginContext(4714, 300, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fc2ca005e402a1d9953f168b553028702fce82122353", async() => {
                BeginContext(4958, 52, false);
#line 91 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue(" ", 4812, "return", 4813, 7, true);
            AddHtmlAttributeValue(" ", 4819, "confirm(\'", 4820, 10, true);
#line 90 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
AddHtmlAttributeValue("", 4829, CommonLocalizer.GetLocalizedHtmlString("btn_YouDelete"), 4829, 56, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4885, "\')", 4885, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 91 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                                             WriteLiteral(item.Id);

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
            BeginContext(5014, 81, true);
            WriteLiteral("\n                                    </td>\n                                </tr>\n");
            EndContext();
#line 94 "/home/local/3SI/tuan.dv/RiderProjects/3S/LoginCodeFirst/LoginCodeFirst/Views/User/Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(5125, 173, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ResourcesServices<UserResources> UserLocalizer { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<LoginCodeFirst.ViewModels.User.UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
