#pragma checksum "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44ea59bb8078f83f37fbab3f8e20f89949f9b150"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grades_All), @"mvc.1.0.view", @"/Views/Grades/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Grades/All.cshtml", typeof(AspNetCore.Views_Grades_All))]
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
#line 1 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml"
using Eduman.Utilities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ea59bb8078f83f37fbab3f8e20f89949f9b150", @"/Views/Grades/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d588e503af850c3b1fa2d4a54a238b11a18aef", @"/Views/_ViewImports.cshtml")]
    public class Views_Grades_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eduman.Models.ViewModels.AllGradesViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(90, 301, true);
            WriteLiteral(@"
<h1 class=""text-center"">All Fees</h1>
<hr class=""eventures-bg-color hr-2 w-75"" />
<table class=""table w-75 mx-auto table-hover border-top-0"">
    <thead>
        <tr>
            <th scope=""col"">Subject</th>
            <th scope=""col"">Grades</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 15 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml"
         foreach (Subjects subject in (Subjects[])Enum.GetValues(typeof(Subjects)))
        {
             if (@Model.FirstOrDefault(m => m.Subject == subject.ToString()) != null)
             {

#line default
#line hidden
            BeginContext(590, 60, true);
            WriteLiteral("                 <tr>\r\n                     <th scope=\"row\">");
            EndContext();
            BeginContext(651, 7, false);
#line 20 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml"
                                Write(subject);

#line default
#line hidden
            EndContext();
            BeginContext(658, 34, true);
            WriteLiteral("</th>\r\n                     <td>\r\n");
            EndContext();
#line 22 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml"
                           
                             ViewData["subject"] = subject.ToString();
                             await Html.RenderPartialAsync("_GradesListingPartial", Model);
                         

#line default
#line hidden
            BeginContext(914, 52, true);
            WriteLiteral("                     </td>\r\n                 </tr>\r\n");
            EndContext();
#line 28 "C:\Users\vikmar\Desktop\SoftUni\SoftUni_C#Web\Eduman\EduMan\Views\Grades\All.cshtml"
             }
        }

#line default
#line hidden
            BeginContext(993, 22, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eduman.Models.ViewModels.AllGradesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591