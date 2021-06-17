#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c202ba6167050b73e4ef1b257399fcf7fa4c50e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_RelatorioProcedimento), @"mvc.1.0.view", @"/Views/Consulta/RelatorioProcedimento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c202ba6167050b73e4ef1b257399fcf7fa4c50e", @"/Views/Consulta/RelatorioProcedimento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_RelatorioProcedimento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ItensUtilizados>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
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
                    <h5>Procedimentos</h5>
                </div>
                <div class=""card-body cart"">
                    <div class=""col-sm-12 empty-cart-cls text-center"">
                        <h3><strong>Nenhum Procedimento</strong></h3>

                        <a href=""/procedimento/selection"" class=""btn btn-primary"" data-abc=""true"">Escolher Procedimento</a>
                        <a href=""/home"" class=""btn btn-sm btn-danger m-3"" data-abc=""true"">Sair</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div> ");
#nullable restore
#line 23 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
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
                    <h5>Procedimentos Utilizados</h5>
                </div>
                <div>
                    <table class=""table table-hover rounded-top rounded-bottom shadow"">
                        <tr>
                            
                            <th>Nome</th>
                            <th>Tipo</th>
                            <th>Valor</th>

                        </tr>
");
#nullable restore
#line 42 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n            \n                                <td>");
#nullable restore
#line 46 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
                               Write(item.Procedimento.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 47 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
                               Write(item.Procedimento.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 48 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
                               Write(item.Procedimento.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n            \n                            </tr>");
#nullable restore
#line 51 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>
            </div>
            <a href=""/home/inicial"" class=""btn btn-info cart-btn-transform mt-2 float-right m-2""
               data-abc=""true"">
                Continuar
            </a>
            
        </div>
    </div>
</div>
");
            WriteLiteral("                <script>\n                    function removidoBox() {\n                        alert(\"Item Removido Com Sucesso!\");\n                    }\n                </script>");
#nullable restore
#line 68 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\Consulta\RelatorioProcedimento.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ItensUtilizados>> Html { get; private set; }
    }
}
#pragma warning restore 1591
