#pragma checksum "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d54d5a8137b3018bc5ff24e97a52928dad005412"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Atendente_Index), @"mvc.1.0.view", @"/Views/Atendente/Index.cshtml")]
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
#line 1 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\_ViewImports.cshtml"
using ProntoAtendimento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\_ViewImports.cshtml"
using ProntoAtendimento.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d54d5a8137b3018bc5ff24e97a52928dad005412", @"/Views/Atendente/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5b816a6553ad8cee42897d92f61050fdb7ecbce", @"/Views/_ViewImports.cshtml")]
    public class Views_Atendente_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Atendente>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 5 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
 if (@Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 7 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 8 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 11 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
                     Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <table class=\"table table-hover\">\r\n        <tr>\r\n            <td>");
#nullable restore
#line 14 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
           Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
           Write(Model.Endereco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 16 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
           Write(Model.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
           Write(Model.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a class=\"btn btn-sm btn-warning\"");
            BeginWriteAttribute("href", "\r\n                   href=\"", 408, "\"", 461, 2);
            WriteAttributeValue("", 435, "atendente/update/", 435, 17, true);
#nullable restore
#line 20 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
WriteAttributeValue("", 452, Model.Id, 452, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a>\r\n            </td>\r\n            <td>\r\n                <a class=\"btn btn-primary\"\r\n                   href=\"atendente/create\">Novo</a>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n");
#nullable restore
#line 28 "C:\Users\mrs55\source\repos\ProntoAtendimento\ProntoAtendimento\Views\Atendente\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn btn-primary\" href=\"atendente/create\">Adicionar</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Atendente> Html { get; private set; }
    }
}
#pragma warning restore 1591
