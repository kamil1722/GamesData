#pragma checksum "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fd36b042a9412e8e6f87473f4be5c6fcf00cd49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TablesJoin_Index), @"mvc.1.0.view", @"/Views/TablesJoin/Index.cshtml")]
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
#line 1 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
using GamesData;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fd36b042a9412e8e6f87473f4be5c6fcf00cd49", @"/Views/TablesJoin/Index.cshtml")]
    public class Views_TablesJoin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
  
    IEnumerable<GamesData.Models.JoinTables> displaydata = ViewData["Results"] as IEnumerable<GamesData.Models.JoinTables>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1> Games </h1>
<h3> Games and his genres</h3>
<hr />
    <table class=""table"">
        <thead>
            <tr>
                <th>Name Game</th>
                <th>Name Studio</th>
                <th>Name Genre</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
             foreach (var item in displaydata)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
                   Write(item.NameGame);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
                   Write(item.NameStudio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
                   Write(item.NameGenres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 28 "C:\Users\User_Kamil\source\repos\GamesData\GamesData\Views\TablesJoin\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n\r\n\r\n\r\n");
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
