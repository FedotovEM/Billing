#pragma checksum "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a7612cbb9f777a1ce1b77cc11de6b0d5801cfc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Streets_Create), @"mvc.1.0.view", @"/Views/Streets/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a7612cbb9f777a1ce1b77cc11de6b0d5801cfc3", @"/Views/Streets/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a29d464de42611ed4aa001acf3df30cf0dda80", @"/Views/_ViewImports.cshtml")]
    public class Views_Streets_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Create.cshtml"
  
    ViewData["Title"] = "About";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"app\">\r\n    <create-component");
            BeginWriteAttribute("create-street-url", " create-street-url=\"", 129, "\"", 170, 1);
#nullable restore
#line 8 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Create.cshtml"
WriteAttributeValue("", 149, Url.Action("Create"), 149, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></create-component>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 231, "\"", 272, 1);
#nullable restore
#line 11 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Create.cshtml"
WriteAttributeValue("", 237, Url.Content("~/bundle/streets.js"), 237, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
