#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7cd189fb7ed8314869085919efd77ca6e960472"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmUser), @"mvc.1.0.view", @"/Views/Account/ConfirmUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ConfirmUser.cshtml", typeof(AspNetCore.Views_Account_ConfirmUser))]
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
#line 1 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\_ViewImports.cshtml"
using Eduman;

#line default
#line hidden
#line 2 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\_ViewImports.cshtml"
using Eduman.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7cd189fb7ed8314869085919efd77ca6e960472", @"/Views/Account/ConfirmUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d588e503af850c3b1fa2d4a54a238b11a18aef", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eduman.Models.ViewModels.ConfirmUserViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 401, true);
            WriteLiteral(@"
<h1 class=""text-center"">Confirm Users</h1>
<hr class=""eventures-bg-color hr-2 w-75"" />
<table class=""table w-75 mx-auto table-hover border-top-0"">
    <thead>
        <tr>
            <th scope=""col"">Student Name</th>
            <th scope=""col"">Student Username</th>
            <th scope=""col"">Role</th>
            <th scope=""col"">Action</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 19 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"
         foreach (var m in @Model)
        {

#line default
#line hidden
            BeginContext(524, 50, true);
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
            EndContext();
            BeginContext(576, 29, false);
#line 22 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"
                            Write($"{m.FirstName + m.LastName}");

#line default
#line hidden
            EndContext();
            BeginContext(606, 27, true);
            WriteLiteral("</th>\r\n                <td>");
            EndContext();
            BeginContext(634, 10, false);
#line 23 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"
               Write(m.Username);

#line default
#line hidden
            EndContext();
            BeginContext(644, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(672, 6, false);
#line 24 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"
               Write(m.Role);

#line default
#line hidden
            EndContext();
            BeginContext(678, 49, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(727, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7cd189fb7ed8314869085919efd77ca6e9604726261", async() => {
                BeginContext(818, 114, true);
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn eduman-bg-color\">Confirm</button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 26 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"
                                                                                            WriteLiteral(m.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(939, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
            BeginContext(1136, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 32 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Account\ConfirmUser.cshtml"

        }

#line default
#line hidden
            BeginContext(1168, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eduman.Models.ViewModels.ConfirmUserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
