#pragma checksum "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51576e1855ed38fa73209c2cd391116eca7aabdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Streets_Edit), @"mvc.1.0.view", @"/Views/Streets/Edit.cshtml")]
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
#line 2 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51576e1855ed38fa73209c2cd391116eca7aabdc", @"/Views/Streets/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a29d464de42611ed4aa001acf3df30cf0dda80", @"/Views/_ViewImports.cshtml")]
    public class Views_Streets_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestVueWebApp.Repository.Models.Street>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"app\">\r\n    <edit-component");
            BeginWriteAttribute("edit-street-url", " edit-street-url=\"", 195, "\"", 279, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml"
WriteAttributeValue("", 213, Url.Action("Edit", "Streets", new { StreetCd = Model.StreetCd } ), 213, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute(":street", " :street=\"", 280, "\"", 325, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml"
WriteAttributeValue("", 290, JsonConvert.SerializeObject(Model), 290, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></edit-component>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 384, "\"", 425, 1);
#nullable restore
#line 12 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Streets\Edit.cshtml"
WriteAttributeValue("", 390, Url.Content("~/bundle/streets.js"), 390, 35, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestVueWebApp.Repository.Models.Street> Html { get; private set; }
    }
}
#pragma warning restore 1591
