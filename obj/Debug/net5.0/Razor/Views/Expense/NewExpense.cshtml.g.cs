#pragma checksum "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73e210b0699181a6bc609de2eec1b8493f56457a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expense_NewExpense), @"mvc.1.0.view", @"/Views/Expense/NewExpense.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73e210b0699181a6bc609de2eec1b8493f56457a", @"/Views/Expense/NewExpense.cshtml")]
    public class Views_Expense_NewExpense : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TuncDenizci.Models.ExpenseClass>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
  
    ViewData["Title"] = "NewExpense";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Yeni Gider Ekleme Sayfası</h2>\r\n<br />\r\n");
#nullable restore
#line 9 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
 using (Html.BeginForm("NewExpense", "Expense", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Açıklama"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.TextAreaFor(x => x.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 14 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Tutar"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.TextBoxFor(x => x.Amount, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 17 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Gün"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.TextBoxFor(x => x.Day, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 20 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Ay"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 22 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.DropDownListFor(x => x.MonthID, (List<SelectListItem>)ViewBag.mon, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 24 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Yıl"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 26 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.DropDownListFor(x => x.Year, (List<SelectListItem>)ViewBag.y, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 28 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.Label("Kullanıcı"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 30 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
Write(Html.DropDownListFor(x => x.LogUser, (List<SelectListItem>)ViewBag.lu, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-info\" style=\"background-color:darkblue\">Gider Ekle</button>\r\n");
#nullable restore
#line 33 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Expense\NewExpense.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TuncDenizci.Models.ExpenseClass> Html { get; private set; }
    }
}
#pragma warning restore 1591
