#pragma checksum "/app/Views/Kuji/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "636f4c124268dfadd3fc9fea13b660278d824845"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kuji_Index), @"mvc.1.0.view", @"/Views/Kuji/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/app/Views/_ViewImports.cshtml"
using app;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/app/Views/_ViewImports.cshtml"
using app.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/app/Views/Kuji/Index.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/app/Views/Kuji/Index.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"636f4c124268dfadd3fc9fea13b660278d824845", @"/Views/Kuji/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35d7228549089a448a9c85c9fd74602bc83b83a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Kuji_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Amidakuji.Models.KujiModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \n\n");
            WriteLiteral("\n");
#nullable restore
#line 7 "/app/Views/Kuji/Index.cshtml"
  
    ViewData["Title"] = "あみだくじ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div id=\"sawai\">\n    ");
#nullable restore
#line 13 "/app/Views/Kuji/Index.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 14 "/app/Views/Kuji/Index.cshtml"
     foreach (var result in Model.Result)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 16 "/app/Views/Kuji/Index.cshtml"
      Write(result.Item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 17 "/app/Views/Kuji/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Amidakuji.Models.KujiModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
