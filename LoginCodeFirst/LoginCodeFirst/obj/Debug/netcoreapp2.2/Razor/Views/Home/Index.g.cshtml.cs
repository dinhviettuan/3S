#pragma checksum "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc4f244cb23c38e2e3cb498f555725856ec7d298"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/_ViewImports.cshtml"
using LoginCodeFirst;

#line default
#line hidden
#line 2 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/_ViewImports.cshtml"
using LoginCodeFirst.Models;

#line default
#line hidden
#line 1 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc4f244cb23c38e2e3cb498f555725856ec7d298", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7718ab4769adcc520d9eb96342d373081781b5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(120, 53, true);
            WriteLiteral("\n<div class=\"text-center\">\n    <h1 class=\"display-4\">");
            EndContext();
            BeginContext(174, 20, false);
#line 8 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml"
                     Write(Localizer["Welcome"]);

#line default
#line hidden
            EndContext();
            BeginContext(194, 13, true);
            WriteLiteral("</h1>\n    <p>");
            EndContext();
            BeginContext(208, 24, false);
#line 9 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml"
  Write(Localizer["Learn about"]);

#line default
#line hidden
            EndContext();
            BeginContext(232, 50, true);
            WriteLiteral(" <a href=\"https://docs.microsoft.com/aspnet/core\">");
            EndContext();
            BeginContext(283, 48, false);
#line 9 "/home/local/3SI/tuan.dv/RiderProjects/LoginCodeFirst/LoginCodeFirst/Views/Home/Index.cshtml"
                                                                             Write(Localizer["building Web apps with ASP.NET Core"]);

#line default
#line hidden
            EndContext();
            BeginContext(331, 17, true);
            WriteLiteral("</a>.</p>\n</div>\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
