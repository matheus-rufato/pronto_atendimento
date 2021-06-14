#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "721f38b99d8e8b8caf07ba25798856a940cfe46e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_Atender), @"mvc.1.0.view", @"/Views/Consulta/Atender.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"721f38b99d8e8b8caf07ba25798856a940cfe46e", @"/Views/Consulta/Atender.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_Atender : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Consulta>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid mt-100"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h5>Procedimentos</h5>
                    </div>
                    <div class=""card-body cart"">
                        <div class=""col-sm-12 empty-cart-cls text-center"">
                            <h3><strong>Nenhuma Consulta aberta.</strong></h3>
                            <button class=""btn btn-primary"">
                                Escolher Procedimentos
                            </button>
                            <a href=""/home"" class=""btn btn-sm btn-danger m-3"" data-abc=""true"">Sair</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> ");
#nullable restore
#line 24 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
           }
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
            WriteLiteral("    <table class=\"table table-hover\">\n\n\n        <tr>\n            <th>Nr</th>\n            <th>Paciente</th>\n            <th>Médico(a)</th>\n            <th>Data</th>\n            <th>Situação</th>\n        </tr>\n\n\n");
#nullable restore
#line 45 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
         foreach (var cons in Model)

        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>");
#nullable restore
#line 49 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
       Write(cons.Nr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 50 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
       Write(cons.Paciente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 51 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
       Write(cons.Medico.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 52 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
       Write(cons.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 53 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
       Write(cons.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n        <td>\n\n            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1393, "\"", 1425, 2);
            WriteAttributeValue("", 1400, "/consulta/update/", 1400, 17, true);
#nullable restore
#line 57 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
WriteAttributeValue("", 1417, cons.Nr, 1417, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Atender</a>\n            \n            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1490, "\"", 1522, 2);
            WriteAttributeValue("", 1497, "/consulta/update/", 1497, 17, true);
#nullable restore
#line 59 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
WriteAttributeValue("", 1514, cons.Nr, 1514, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Finalizar Consulta</a>\n        </td>\n    </tr>\n");
#nullable restore
#line 62 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </table>\n<a href=\"/home\" class=\"btn btn-sm btn-danger m-3\" data-abc=\"true\">Sair</a>\n");
#nullable restore
#line 66 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Atender.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Consulta>> Html { get; private set; }
    }
}
#pragma warning restore 1591
