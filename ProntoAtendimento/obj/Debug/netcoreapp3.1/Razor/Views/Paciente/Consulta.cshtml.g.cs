#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2f65087ef02d73840d272591e52a5a57b5a0869"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Paciente_Consulta), @"mvc.1.0.view", @"/Views/Paciente/Consulta.cshtml")]
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
#line 1 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\_ViewImports.cshtml"
using ProntoAtendimento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\_ViewImports.cshtml"
using ProntoAtendimento.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2f65087ef02d73840d272591e52a5a57b5a0869", @"/Views/Paciente/Consulta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_Paciente_Consulta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Paciente>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<br />\n\n");
#nullable restore
#line 5 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
 if (@Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 7 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n");
#nullable restore
#line 8 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
}
else
{
    // <h3>@ViewBag.Mensagem @Model.Nome</h3>

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\n\n\n        <tr>\n            <th>ID</th>\n            <th>Nome</th>\n            <th>Endereço</th>\n            <th>Telefone</th>\n            <th>Convenio</th>\n            <th>Status</th>\n\n        </tr>\n\n\n");
#nullable restore
#line 26 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
         foreach (var pacie in Model)

        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 30 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 31 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 32 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Endereco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 33 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 34 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Convenio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 35 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
               Write(pacie.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>\n                    \n                    <a class=\"btn btn-sm btn-info\"");
            BeginWriteAttribute("href", " href=\"", 770, "\"", 804, 3);
            WriteAttributeValue("", 777, "/medico/consulta/", 777, 17, true);
#nullable restore
#line 38 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
WriteAttributeValue("", 794, pacie.Id, 794, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 803, "", 804, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Selecionar</a>\n                    \n\n                </td>\n            </tr>\n");
#nullable restore
#line 43 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n");
#nullable restore
#line 46 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Paciente\Consulta.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn btn-primary\" href=\"/home/escolherconsulta\">Voltar</a>\n\n<a class=\"btn btn-primary\" href=\"/medico/consulta\">Continuar</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Paciente>> Html { get; private set; }
    }
}
#pragma warning restore 1591
