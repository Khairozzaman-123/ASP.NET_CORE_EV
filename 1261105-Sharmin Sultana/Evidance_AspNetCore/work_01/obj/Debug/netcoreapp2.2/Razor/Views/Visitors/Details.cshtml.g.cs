#pragma checksum "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59cc514cd453f5af1a927ae2ec88d5a1ab29f651"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Visitors_Details), @"mvc.1.0.view", @"/Views/Visitors/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Visitors/Details.cshtml", typeof(AspNetCore.Views_Visitors_Details))]
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
#line 1 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\_ViewImports.cshtml"
using work_01;

#line default
#line hidden
#line 2 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\_ViewImports.cshtml"
using work_01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59cc514cd453f5af1a927ae2ec88d5a1ab29f651", @"/Views/Visitors/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bff49a12a178b6e69a33afd67df073c05760467", @"/Views/_ViewImports.cshtml")]
    public class Views_Visitors_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<work_01.Models.Visitor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Visitors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm rounded shadow-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success shadow btn-sm w-25"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 210, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-8 offset-2\">\r\n        <div class=\"card card rounded shadow-lg mt-5\">\r\n            <div class=\"card-header shadow\">\r\n                <h2 class=\"float-left\">Details of ");
            EndContext();
            BeginContext(287, 17, false);
#line 11 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                                             Write(Model.VisitorName);

#line default
#line hidden
            EndContext();
            BeginContext(304, 85, true);
            WriteLiteral("</h2>\r\n                <div class=\"d-flex justify-content-end\">\r\n                    ");
            EndContext();
            BeginContext(389, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59cc514cd453f5af1a927ae2ec88d5a1ab29f6515942", async() => {
                BeginContext(483, 91, true);
                WriteLiteral("\r\n                        <i class=\"fa fa-backward\"></i> Back to List\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(578, 184, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <dl class=\"row\">\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
            EndContext();
            BeginContext(763, 47, false);
#line 21 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.VisitorName));

#line default
#line hidden
            EndContext();
            BeginContext(810, 104, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        <strong>");
            EndContext();
            BeginContext(915, 43, false);
#line 24 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                           Write(Html.DisplayFor(model => model.VisitorName));

#line default
#line hidden
            EndContext();
            BeginContext(958, 105, true);
            WriteLiteral("</strong>\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
            EndContext();
            BeginContext(1064, 40, false);
#line 27 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1104, 96, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        ");
            EndContext();
            BeginContext(1201, 42, false);
#line 30 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayFor(model => model.City.cName));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 96, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
            EndContext();
            BeginContext(1340, 41, false);
#line 33 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1381, 96, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        ");
            EndContext();
            BeginContext(1478, 37, false);
#line 36 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1515, 96, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
            EndContext();
            BeginContext(1612, 45, false);
#line 39 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.VisitDate));

#line default
#line hidden
            EndContext();
            BeginContext(1657, 96, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        ");
            EndContext();
            BeginContext(1754, 41, false);
#line 42 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayFor(model => model.VisitDate));

#line default
#line hidden
            EndContext();
            BeginContext(1795, 96, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
            EndContext();
            BeginContext(1892, 41, false);
#line 45 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
            EndContext();
            BeginContext(1933, 100, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2033, "\"", 2052, 2);
            WriteAttributeValue("", 2039, "/", 2039, 1, true);
#line 48 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
WriteAttributeValue("", 2040, Model.Image, 2040, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2053, 174, true);
            WriteLiteral(" class=\"detailImage\" width=\"150\" height=\"150\"/>\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                ");
            EndContext();
            BeginContext(2227, 152, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59cc514cd453f5af1a927ae2ec88d5a1ab29f65113061", async() => {
                BeginContext(2342, 33, true);
                WriteLiteral("<i class=\"fa fa-pencil\"></i> Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\MSI PC\Desktop\1261105-Sharmin Sultana\Evidance_AspNetCore\work_01\Views\Visitors\Details.cshtml"
                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2379, 58, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<work_01.Models.Visitor> Html { get; private set; }
    }
}
#pragma warning restore 1591
