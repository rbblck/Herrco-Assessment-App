#pragma checksum "/Users/robertblack/Desktop/untitled folder 2/Herrco-Assessment-App/HerrcoApp/Views/Home/Instructions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5ad7e61bd3921e21843bf3c1422a531f8b9fe8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Instructions), @"mvc.1.0.view", @"/Views/Home/Instructions.cshtml")]
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
#line 1 "/Users/robertblack/Desktop/untitled folder 2/Herrco-Assessment-App/HerrcoApp/Views/_ViewImports.cshtml"
using HerrcoApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/robertblack/Desktop/untitled folder 2/Herrco-Assessment-App/HerrcoApp/Views/_ViewImports.cshtml"
using HerrcoApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5ad7e61bd3921e21843bf3c1422a531f8b9fe8e", @"/Views/Home/Instructions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e2ced8ff266e7eef994118fa4b4e3d7ec306a1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Instructions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/robertblack/Desktop/untitled folder 2/Herrco-Assessment-App/HerrcoApp/Views/Home/Instructions.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-sm-0 col-md-2"">


    </div>
    <div class=""col-sm-12 col-md-8"">
        <div>
            <h1><u>Instructions</u></h1>

            <p>
                The home page is the main app page with live updates for the spread sheet on demand.  It is initialised with a blank
                donut chart and the key / values are all 0.
            </p>

            <p>
                To get the number of CRUD updates, click or tap the floating update button at the bottom right part of the screen and
                it will compare the latest state of the spread sheet with the state it was in since the app was started or since the
                last click or tap of the update button.
            </p>

            <p>
                Any updated values will be displayed in a tickertape at the bottom of the screen, prefixed by the word “Update”
                followed by the product id and any changed values (the original value first and then the updated value with its
        ");
            WriteLiteral("        corresponding title).\n            </p>\n        </div>\n    </div>\n    <div class=\"col-sm-0 col-md-2\">\n\n    </div>\n</div>");
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
