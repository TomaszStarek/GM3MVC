#pragma checksum "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6eeb9cd8711716655184c06f85ca520c598ca72c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AwarieGm3_DisplayTop), @"mvc.1.0.view", @"/Views/AwarieGm3/DisplayTop.cshtml")]
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
#line 1 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\_ViewImports.cshtml"
using tutorial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\_ViewImports.cshtml"
using tutorial.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eeb9cd8711716655184c06f85ca520c598ca72c", @"/Views/AwarieGm3/DisplayTop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdbf6704702fe03c5f5d2b0f0afb1049aed94e47", @"/Views/_ViewImports.cshtml")]
    public class Views_AwarieGm3_DisplayTop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<tutorial.Models.TopDowntimeModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AwarieGM3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplayTop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6eeb9cd8711716655184c06f85ca520c598ca72c4505", async() => {
                WriteLiteral(@"
        Od: <input name=""start"" new { class=""datefield"" , type=""date"" } />
        Do: <input name=""stop"" new { class=""datefield"" , type=""date"" }"" />
        Sekcja: <input id=""sekcja"" name=""sekcja"" new { class=""button"" , type=""text"" }"" />
        <input type=""submit"" value=""Filter"" />
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayNameFor(model => model.Sekcja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayNameFor(model => model.Stacja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayNameFor(model => model.Opis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalMinutes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayNameFor(model => model.LiczbaWystapien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
         foreach (var item in Model.OrderByDescending(item => item.TotalMinutes))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sekcja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayFor(modelItem => item.Stacja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayFor(modelItem => item.Opis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalMinutes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
           Write(Html.DisplayFor(modelItem => item.LiczbaWystapien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            WriteLiteral("            </td>\r\n            <td>\r\n");
#nullable restore
#line 63 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
              
                string buf = "";
                foreach (var i in item.Ids)
                {
                    buf += i + "q";

                }
                var url = "/AwarieGM3/DetailsTops/" + buf;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 2166, "\"", 2177, 1);
#nullable restore
#line 71 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
WriteAttributeValue("", 2173, url, 2173, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a>\r\n");
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\2281209\source\repos\tutorial - nowa odsłona\tutorial\Views\AwarieGm3\DisplayTop.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<tutorial.Models.TopDowntimeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
