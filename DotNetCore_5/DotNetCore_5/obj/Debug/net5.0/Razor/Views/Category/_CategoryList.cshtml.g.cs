#pragma checksum "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7de336f9443ecf7d09799e58645ae876d2bc47b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category__CategoryList), @"mvc.1.0.view", @"/Views/Category/_CategoryList.cshtml")]
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
#line 1 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using DotNetCore_5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using DotNetCore_5.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using DotNetCore_5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using DotNetCore_5.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7de336f9443ecf7d09799e58645ae876d2bc47b8", @"/Views/Category/_CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1b30d4bc122c4320bbfa4d3217edd978bb658e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Category__CategoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CategoryViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h2>Category List</h2>\r\n<div>\r\n    <table class=\"table table-bordered table-striped text-center\">\r\n\r\n        <tr>\r\n            <th>Category Id</th>\r\n            <th>Category Name</th>\r\n            <th>Operation</th>\r\n        </tr>\r\n");
#nullable restore
#line 11 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 14 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
               Write(item.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 15 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
               Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a href=\"#\" class=\"btn btn-warning\" name=\"btnEditModal\"");
            BeginWriteAttribute("onclick", " onclick=\'", 523, "\'", 561, 3);
            WriteAttributeValue("", 533, "Update(\"+", 533, 9, true);
#nullable restore
#line 17 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
WriteAttributeValue("", 542, item.CategoryId, 542, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 558, "+\")", 558, 3, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#EditModal\">Edit</a>\r\n                    <a href=\"#\" class=\"btn  btn-danger\" name=\"btnDeleteModal\"");
            BeginWriteAttribute("onclick", " onclick=\'", 701, "\'", 739, 3);
            WriteAttributeValue("", 711, "Delete(\"+", 711, 9, true);
#nullable restore
#line 18 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
WriteAttributeValue("", 720, item.CategoryId, 720, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 736, "+\")", 736, 3, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#DeleteModal\">Delete</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 21 "G:\CSHARP\MVC CORE\Practice\DotNetCore_5\DotNetCore_5\Views\Category\_CategoryList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
