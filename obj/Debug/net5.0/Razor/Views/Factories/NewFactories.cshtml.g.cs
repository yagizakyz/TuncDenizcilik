#pragma checksum "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a7e01cd19f9d20c40414a27efd7695e0f5066ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Factories_NewFactories), @"mvc.1.0.view", @"/Views/Factories/NewFactories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a7e01cd19f9d20c40414a27efd7695e0f5066ca", @"/Views/Factories/NewFactories.cshtml")]
    public class Views_Factories_NewFactories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TuncDenizci.Models.FactoriesClass>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
  
    ViewData["Title"] = "NewFactories";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Yeni Firma Ekleme Sayfası</h2>\r\n<br />\r\n");
#nullable restore
#line 9 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
 using (Html.BeginForm("NewFactories", "Factories", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
Write(Html.Label("Firma Adı"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
Write(Html.TextBoxFor(x => x.IndustryName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 14 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
Write(Html.Label("Ekleyen Kullanıcı"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 16 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
Write(Html.DropDownListFor(x => x.LogUser, (List<SelectListItem>)ViewBag.lu, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-info\" style=\"background-color:darkblue\">Firma Ekle</button>\r\n");
#nullable restore
#line 19 "C:\Users\akyz6\OneDrive\Masaüstü\DOSYALAR\Kodlamalar\Mvc\TuncDenizci\TuncDenizci\Views\Factories\NewFactories.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TuncDenizci.Models.FactoriesClass> Html { get; private set; }
    }
}
#pragma warning restore 1591