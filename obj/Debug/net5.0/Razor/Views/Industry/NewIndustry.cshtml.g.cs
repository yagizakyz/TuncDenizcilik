#pragma checksum "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189b7532e2689e36e7e10249f629f65c865cbdec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Industry_NewIndustry), @"mvc.1.0.view", @"/Views/Industry/NewIndustry.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"189b7532e2689e36e7e10249f629f65c865cbdec", @"/Views/Industry/NewIndustry.cshtml")]
    public class Views_Industry_NewIndustry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TuncDenizci.Models.IndustryClass>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
  
    ViewData["Title"] = "NewIndustry";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Yeni Fatura Ekleme Sayfası</h2>\r\n<br />\r\n");
#nullable restore
#line 9 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
 using (Html.BeginForm("NewIndustry", "Industry", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Irsaliye NO"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.TextBoxFor(x => x.IrsaliyeNo, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 14 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Plaka"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.TextBoxFor(x => x.Plate, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 17 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Tonaj"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.TextBoxFor(x => x.Tonaj, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 20 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Gemi Adı"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.TextBoxFor(x => x.ShipName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 23 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Firma"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 25 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.DropDownListFor(x => x.FactoriesID, (List<SelectListItem>)ViewBag.ind, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 27 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Tarih"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.TextBoxFor(x => x.DateT, new { @class = "form-control", @placeholder = "06.10.2021 12:52:05 (gün-ay-yıl saat:dakika:saniye) şeklinde giriş yapın." }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 30 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.Label("Ekleyen Kullanıcı"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 32 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
Write(Html.DropDownListFor(x => x.LogUser, (List<SelectListItem>)ViewBag.lu, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-info\" style=\"background-color:darkblue\">Faturayı Ekle</button>\r\n");
#nullable restore
#line 35 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Industry\NewIndustry.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TuncDenizci.Models.IndustryClass> Html { get; private set; }
    }
}
#pragma warning restore 1591
