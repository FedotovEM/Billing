#pragma checksum "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fddb4bbe3ef308bb2e7763d6242517bf79cc3410"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Units_Delete), @"mvc.1.0.view", @"/Views/Units/Delete.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\_ViewImports.cshtml"
using TestVueWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\_ViewImports.cshtml"
using TestVueWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddb4bbe3ef308bb2e7763d6242517bf79cc3410", @"/Views/Units/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a29d464de42611ed4aa001acf3df30cf0dda80", @"/Views/_ViewImports.cshtml")]
    public class Views_Units_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestVueWebApp.Repository.Models.Unit>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"app\">\r\n    <unit-delete-component");
            BeginWriteAttribute("delete-unit-url", " delete-unit-url=\"", 202, "\"", 250, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
WriteAttributeValue("", 220, Url.Action("Delete", "Units"), 220, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("index-unit-url", " index-unit-url=\"", 251, "\"", 297, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
WriteAttributeValue("", 268, Url.Action("Index", "Units"), 268, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute(":unit", " :unit=\"", 298, "\"", 341, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
WriteAttributeValue("", 306, JsonConvert.SerializeObject(Model), 306, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></unit-delete-component>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 407, "\"", 446, 1);
#nullable restore
#line 12 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Units\Delete.cshtml"
WriteAttributeValue("", 413, Url.Content("~/bundle/Units.js"), 413, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestVueWebApp.Repository.Models.Unit> Html { get; private set; }
    }
}
#pragma warning restore 1591