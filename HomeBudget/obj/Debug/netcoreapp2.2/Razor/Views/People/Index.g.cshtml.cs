#pragma checksum "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\People\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1430bf587de27eb294c566a778329087eb790559"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_People_Index), @"mvc.1.0.view", @"/Views/People/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/People/Index.cshtml", typeof(AspNetCore.Views_People_Index))]
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
#line 1 "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\_ViewImports.cshtml"
using HomeBudget;

#line default
#line hidden
#line 2 "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\_ViewImports.cshtml"
using HomeBudget.Models;

#line default
#line hidden
#line 3 "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\_ViewImports.cshtml"
using HomeBudget.Models.Account;

#line default
#line hidden
#line 4 "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\_ViewImports.cshtml"
using HomeBudget.Models.Bills;

#line default
#line hidden
#line 6 "C:\Users\zbier\Desktop\homeBudgetv2-master\HomeBudget\Views\_ViewImports.cshtml"
using HomeBudget.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1430bf587de27eb294c566a778329087eb790559", @"/Views/People/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eac71874216d9859f8622f433421810f4e1126b", @"/Views/_ViewImports.cshtml")]
    public class Views_People_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeBudget.Models.People.PeopleListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 584, true);
            WriteLiteral(@"
<div id=""all-people-container""></div>

<div class=""container"">
    <h1>All family members</h1>
    <button class=""btn btn-success float-lg-right"">Add</button>

    <table class=""table table-striped table-hover"">
        <thead>
            <tr>
                <th hidden=""hidden"">Id</th>
                <th scope=""col"">#</th>
                <th scope=""col"">Name</th>
                <th scope=""col"">Relation</th>
                <th scope=""col"">Total Amount</th>
            </tr>
        </thead>
        <tbody id=""tbody""></tbody>
    </table>
</div>

//wywołanie jquery pkt 3.
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(653, 939, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(document).ready(function () {
            debugger;
            var url = ""/api/people/list""; // the url to the controller
            $.get(url, function (data) {
                debugger;
                var html = """";
                for (var i = 0; i < data.length; i++) {
                    debugger;
                    var person = data[i];
                    html = html + '<tr>';
                    html = html + '<th hidden=""hidden"">' + person.id + '</th>' +
                        '<th scope=""row"">' + (i + 1) + '</th>' +
                        '<td>' + person.name + '</td>' +
                        '<td>' + person.relationName + '</td>' +
                        '<td>' + person.totalAmount + '</td>';
                    html = html + ""</tr>""
                }
                debugger;
                $('tbody').html(html);

            });
        });

    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeBudget.Models.People.PeopleListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
