#pragma checksum "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efd80e112c806ac651db33faabfcc898a051c2b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Disrepairs_Edit), @"mvc.1.0.view", @"/Views/Disrepairs/Edit.cshtml")]
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
#line 2 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efd80e112c806ac651db33faabfcc898a051c2b0", @"/Views/Disrepairs/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a29d464de42611ed4aa001acf3df30cf0dda80", @"/Views/_ViewImports.cshtml")]
    public class Views_Disrepairs_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestVueWebApp.Repository.Models.Disrepair>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"app\">\r\n    <disrepair-edit-component");
            BeginWriteAttribute("edit-disrepair-url", " edit-disrepair-url=\"", 208, "\"", 300, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml"
WriteAttributeValue("", 229, Url.Action("Edit", "Disrepairs", new { FailureCd = Model.FailureCd } ), 229, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute(":disrepair", " :disrepair=\"", 301, "\"", 349, 1);
#nullable restore
#line 9 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml"
WriteAttributeValue("", 314, JsonConvert.SerializeObject(Model), 314, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></disrepair-edit-component>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 418, "\"", 462, 1);
#nullable restore
#line 12 "C:\Users\Егерь\source\repos\TestVueWebApp\Views\Disrepairs\Edit.cshtml"
WriteAttributeValue("", 424, Url.Content("~/bundle/disrepairs.js"), 424, 38, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestVueWebApp.Repository.Models.Disrepair> Html { get; private set; }
    }
}
#pragma warning restore 1591
