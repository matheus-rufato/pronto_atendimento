#pragma checksum "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65a7785140c144694643120d98179561d99dcd7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ItensUtilizados_Meus_pedidos), @"mvc.1.0.view", @"/Views/ItensUtilizados/Meus_pedidos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65a7785140c144694643120d98179561d99dcd7f", @"/Views/ItensUtilizados/Meus_pedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d313c4711937bce2a3a1d4ae06100f96a9639af", @"/Views/_ViewImports.cshtml")]
    public class Views_ItensUtilizados_Meus_pedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ItensUtilizados>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n<table class=\"table table-hover\">\n    <tr>\n        <th>Confirmar Procedimentos?</th>\n\n\n    </tr>\n\n    <tr>\n        <th>ID</th>\n        <th>Nome</th>\n        <th>Tipo</th>\n        <th>Valor</th>\n\n    </tr>\n\n\n");
#nullable restore
#line 20 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 23 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
   Write(item.Procedimento.IdProcedimento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 24 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
   Write(item.Procedimento.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 25 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
   Write(item.Procedimento.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 26 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
   Write(item.Procedimento.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n\n</tr>");
#nullable restore
#line 29 "C:\Users\Henri\Desktop\InterProjeto\pronto_atendimento\ProntoAtendimento\Views\ItensUtilizados\Meus_pedidos.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n\n</table>\n\n\n<a class=\"btn btn btn-primary\" href=\"/itensutilizados/criar/\">Confirmar</a>\n<a class=\"btn btn-sm btn-danger\" href=\"/listaprocedimentos/index/\">Voltar</a>\n");
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
