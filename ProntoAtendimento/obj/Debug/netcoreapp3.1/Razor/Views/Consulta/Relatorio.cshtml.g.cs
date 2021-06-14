#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4050a3a84d6fe3b46bc2d6722dc655cc936c91aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_Relatorio), @"mvc.1.0.view", @"/Views/Consulta/Relatorio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4050a3a84d6fe3b46bc2d6722dc655cc936c91aa", @"/Views/Consulta/Relatorio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_Relatorio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Consulta>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid mt-100"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5>Relatórios</h5>
                </div>
                <div class=""card-body cart"">
                    <div class=""col-sm-12 empty-cart-cls text-center"">
                        <h3><strong>Nenhum Relatório encontrado</strong></h3>

                        <a href=""/home/inicial"" class=""btn btn-primary"" data-abc=""true"">Voltar</a>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div> ");
#nullable restore
#line 23 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
       }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid mt-100"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5>Relatório da Consulta</h5>
                </div>
                <div>
                    <table class=""table table-hover"">
                        <tr>
                            <th>ID</th>
                            <th>Nome Medico</th>
                            <th>Nome Paciente</th>
                            <th>Data</th>
                            <th>Valor</th>
                            <th>Diagnostico</th>

                        </tr>
");
#nullable restore
#line 44 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>");
#nullable restore
#line 47 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Nr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 48 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Medico.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 49 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Paciente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 50 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \n                        <td>");
#nullable restore
#line 51 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 52 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                       Write(item.Diagnostico);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                        \n                    </tr>");
#nullable restore
#line 55 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
                         }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>
            </div>
            <a href=""/home/inicial"" class=""btn btn-info cart-btn-transform mt-2 float-right m-2""
               data-abc=""true"">
                Voltar
            </a>
            
        </div>
    </div>
</div>
");
            WriteLiteral("                <script>function removidoBox() {\n            alert(\"Item Removido Com Sucesso!\");\n        }</script>");
#nullable restore
#line 70 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\Relatorio.cshtml"
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
