#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01914585f06657305b708689a5eb3b66a4c38e25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_All), @"mvc.1.0.view", @"/Views/Event/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Event/All.cshtml", typeof(AspNetCore.Views_Event_All))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01914585f06657305b708689a5eb3b66a4c38e25", @"/Views/Event/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d588e503af850c3b1fa2d4a54a238b11a18aef", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eduman.Models.ViewModels.AllEventsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn eduman-secbg-color text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Event", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(78, 443, true);
            WriteLiteral(@"
<h1 class=""text-center"">All Orders</h1>
<hr class=""eventures-bg-color hr-2 w-75"" />
<table class=""table w-75 mx-auto table-hover border-top-0"">
    <thead>
        <tr>
            <th scope=""col"">Student Name</th>
            <th scope=""col"">Subject</th>
            <th scope=""col"">Teacher Name</th>
            <th scope=""col"">Date Absent</th>
            <th scope=""col"">Action</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 20 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
     foreach (var m in @Model)
    {

#line default
#line hidden
            BeginContext(560, 42, true);
            WriteLiteral("        <tr>\r\n            <th scope=\"row\">");
            EndContext();
            BeginContext(603, 17, false);
#line 23 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
                       Write(m.StudentUsername);

#line default
#line hidden
            EndContext();
            BeginContext(620, 23, true);
            WriteLiteral("</th>\r\n            <td>");
            EndContext();
            BeginContext(644, 6, false);
#line 24 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
           Write(m.Type);

#line default
#line hidden
            EndContext();
            BeginContext(650, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(674, 17, false);
#line 25 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
           Write(m.TeacherUsername);

#line default
#line hidden
            EndContext();
            BeginContext(691, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(715, 40, false);
#line 26 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
           Write(m.EventDate.ToString("dd/MM/yyyy hh:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(755, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(778, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01914585f06657305b708689a5eb3b66a4c38e256427", async() => {
                BeginContext(888, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
                                                                                                           WriteLiteral(m.Id);

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
            BeginContext(899, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 29 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Event\All.cshtml"
        
    }

#line default
#line hidden
            BeginContext(938, 22, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eduman.Models.ViewModels.AllEventsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591