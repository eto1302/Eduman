#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2175a70f9f82f001c5e89040e13016ff9236c3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grades_Details), @"mvc.1.0.view", @"/Views/Grades/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Grades/Details.cshtml", typeof(AspNetCore.Views_Grades_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2175a70f9f82f001c5e89040e13016ff9236c3d", @"/Views/Grades/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d588e503af850c3b1fa2d4a54a238b11a18aef", @"/Views/_ViewImports.cshtml")]
    public class Views_Grades_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Eduman.Models.ViewModels.GradeDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn eduman-secbg-color text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Fees", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 26, true);
            WriteLiteral("\r\n<h1 class=\"text-center\">");
            EndContext();
            BeginContext(82, 13, false);
#line 3 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                   Write(Model.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(95, 31, true);
            WriteLiteral("</h1>\r\n<h2 class=\"text-center\">");
            EndContext();
            BeginContext(127, 17, false);
#line 4 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                   Write(Model.DateCreated);

#line default
#line hidden
            EndContext();
            BeginContext(144, 138, true);
            WriteLiteral("</h2>\r\n<hr class=\"hr-2 bg-dark\" />\r\n<div class=\"half-width mx-auto d-flex justify-content-between\">\r\n    <h3 class=\"text-center\">Student: ");
            EndContext();
            BeginContext(284, 51, false);
#line 7 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                                 Write($"{Model.StudentFirstName} {Model.StudentLastName}");

#line default
#line hidden
            EndContext();
            BeginContext(336, 44, true);
            WriteLiteral("</h3>\r\n    <h3 class=\"text-center\">Teacher: ");
            EndContext();
            BeginContext(382, 51, false);
#line 8 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                                 Write($"{Model.TeacherFirstName} {Model.TeacherLastName}");

#line default
#line hidden
            EndContext();
            BeginContext(434, 144, true);
            WriteLiteral("</h3>\r\n</div>\r\n<hr class=\"hr-2 bg-dark\" />\r\n<div class=\"half-width mx-auto d-flex justify-content-between\">\r\n    <h3 class=\"text-center\">Value: ");
            EndContext();
            BeginContext(579, 11, false);
#line 12 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                              Write(Model.Value);

#line default
#line hidden
            EndContext();
            BeginContext(590, 44, true);
            WriteLiteral("</h3>\r\n    <h3 class=\"text-center\">Subject: ");
            EndContext();
            BeginContext(635, 13, false);
#line 13 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
                                Write(Model.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(648, 120, true);
            WriteLiteral("</h3>\r\n</div>\r\n<hr class=\"hr-2 bg-dark\" />\r\n<h3 class=\"text-center\">Description</h3>\r\n<p class=\"text-center mt-4\">\r\n    ");
            EndContext();
            BeginContext(769, 17, false);
#line 18 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\Details.cshtml"
Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(786, 187, true);
            WriteLiteral("\r\n</p>\r\n<hr class=\"hr-2 bg-dark\" />\r\n<h3 class=\"text-center\">Actions</h3>\r\n<div class=\"mt-4 d-flex justify-content-around\">\r\n    <div class=\"mt-4 d-flex justify-content-around\">\r\n        ");
            EndContext();
            BeginContext(973, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2175a70f9f82f001c5e89040e13016ff9236c3d7541", async() => {
                BeginContext(1057, 11, true);
                WriteLiteral("Back To All");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1072, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Eduman.Models.ViewModels.GradeDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
