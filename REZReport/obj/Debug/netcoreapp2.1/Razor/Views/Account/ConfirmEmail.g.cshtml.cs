#pragma checksum "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4d425db886f07030b3c5f3b81b1c063be42cb35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ConfirmEmail.cshtml", typeof(AspNetCore.Views_Account_ConfirmEmail))]
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
#line 1 "D:\2019\Sandeep\REZReport\REZReport\Views\_ViewImports.cshtml"
using REZReport;

#line default
#line hidden
#line 2 "D:\2019\Sandeep\REZReport\REZReport\Views\_ViewImports.cshtml"
using REZReport.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4d425db886f07030b3c5f3b81b1c063be42cb35", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"783f6e1437f174199fde3621e4dc620430ec1ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "EmailConfirm";

#line default
#line hidden
            BeginContext(50, 28, true);
            WriteLiteral("\r\n<h2>Email Confirm</h2>\r\n\r\n");
            EndContext();
#line 8 "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml"
 if (ViewBag.result.Status)
{

#line default
#line hidden
            BeginContext(110, 100, true);
            WriteLiteral("    <div>\r\n        <p>\r\n            Thank you for confirming your email.\r\n        </p>\r\n    </div>\r\n");
            EndContext();
#line 15 "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(222, 36, true);
            WriteLiteral("    <div>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(259, 20, false);
#line 20 "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml"
       Write(ViewBag.result.Error);

#line default
#line hidden
            EndContext();
            BeginContext(279, 28, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n");
            EndContext();
#line 23 "D:\2019\Sandeep\REZReport\REZReport\Views\Account\ConfirmEmail.cshtml"
}

#line default
#line hidden
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
