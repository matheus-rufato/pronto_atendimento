#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bef8b1ffd563f4d852e51ea48ec9050b2d5b2bdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListaProcedimentos_Index), @"mvc.1.0.view", @"/Views/ListaProcedimentos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bef8b1ffd563f4d852e51ea48ec9050b2d5b2bdc", @"/Views/ListaProcedimentos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_ListaProcedimentos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ItensUtilizados>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
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
                            <h3><strong>Nenhum Procedimento</strong></h3>
                            <button class=""btn btn-primary"">
                                Escolher Procedimentos</button>
                                    <a href=""/home""
                                                   class=""btn btn-sm btn-danger m-3"" data-abc=""true"">Sair</a>
</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 25 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid mt-100"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h5>Procedimentos Utilizados</h5>
                    </div>
                    <div>
                        <table class=""table table-hover"">
                            <tr>
                                <th>ID</th>
                                <th>Nome</th>
                                <th>Tipo</th>
                                <th>Valor</th>
                                
                            </tr>
");
#nullable restore
#line 44 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td>");
#nullable restore
#line 47 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                                   Write(item.Procedimento.IdProcedimento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 48 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                                   Write(item.Procedimento.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 49 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                                   Write(item.Procedimento.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 50 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                                   Write(item.Procedimento.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    \n                                    <td>\n                                        <a class=\"btn btn-sm btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 2106, "\"", 2174, 2);
            WriteAttributeValue("", 2113, "/listaprocedimentos/remover/", 2113, 28, true);
#nullable restore
#line 53 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
WriteAttributeValue("", 2141, item.Procedimento.IdProcedimento, 2141, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"removidoBox()\">Remover\n                                            Procedimento</a>\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 57 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </table>
                    </div>
                </div>
                <a href=""/procedimento/selection"" class=""btn btn-info cart-btn-transform mt-2 float-right m-2""
                data-abc=""true"">Continuar
                    </a>
                <a href=""/listaprocedimentos/remover"" class=""btn btn-primary cart-btn-transform mt-2 float-right""
                data-abc=""true"">Finalizar </a>
            </div>
        </div>
    </div>
");
            WriteLiteral("    <script>\n        function removidoBox() {\n            alert(\"Item Removido Com Sucesso!\");\n        }\n    </script>\n");
#nullable restore
#line 75 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ListaProcedimentos\Index.cshtml"
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