#pragma checksum "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae4b94267a8c08f4d197f03e963ae4ae9320d444"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PastExpense_Index), @"mvc.1.0.view", @"/Views/PastExpense/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae4b94267a8c08f4d197f03e963ae4ae9320d444", @"/Views/PastExpense/Index.cshtml")]
    public class Views_PastExpense_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TuncDenizci.Models.Expense21Class>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>2021 Gider Listesi</h2>
<br />
<a href=""/PastExpense/NewPE/"" class=""btn btn-primary"" style=""background-color:darkblue"">2021 Gider Ekleme</a>
<a href=""/PastExpense/ExportToExcel"" class=""btn btn-success"">Excel Olarak İndir</a>
<br />
<table class=""table table-bordered"">
    <tr>
        <th>ID</th>
        <th>Açıklama</th>
        <th>Tutar</th>
        <th>Gün</th>
        <th>Ay</th>
        <th>Yıl</th>
        <th>Güncelle</th>
        <th>Ekleyen Kullanıcı</th>
    </tr>
");
#nullable restore
#line 23 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 923, "\"", 965, 2);
            WriteAttributeValue("", 930, "/PastExpense/DeleteExpense/", 930, 27, true);
#nullable restore
#line 32 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
WriteAttributeValue("", 957, item.Id, 957, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
           Write(item.LogUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<h2>Toplam Tutar: ");
#nullable restore
#line 37 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\PastExpense\Index.cshtml"
             Write(ViewBag.e);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TuncDenizci.Models.Expense21Class>> Html { get; private set; }
    }
}
#pragma warning restore 1591
