#pragma checksum "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e003d4678a08307570bdb064e34db949c044ad79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ShoppingAssignment_SE151263.Pages.Products.Pages_Products_Delete), @"mvc.1.0.razor-page", @"/Pages/Products/Delete.cshtml")]
namespace ShoppingAssignment_SE151263.Pages.Products
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
#line 1 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\_ViewImports.cshtml"
using ShoppingAssignment_SE151263;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e003d4678a08307570bdb064e34db949c044ad79", @"/Pages/Products/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c4e28bbd42271e2d6db677cdf58a6e836dfad71", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Products_Delete : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
  
    ViewData["Title"] = "Delete product";
    Console.WriteLine("Toi la nguoi phan quyen!");
    if (HttpContext.Session.GetString("EmailAdmin") == null)
    {
        Console.WriteLine("User chua login!");

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e003d4678a08307570bdb064e34db949c044ad796100", async() => {
                WriteLiteral("Back to login");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 14 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1 class=\"text-info text-center\">DELETE PRODUCT</h1>\r\n");
#nullable restore
#line 18 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
         if (ViewData["Message"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"text-center text-danger\">");
#nullable restore
#line 20 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
                                          Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr/>\r\n        <h3>Are you sure you want to delete this?</h3>\r\n        <div>\r\n            <hr />\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 28 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 31 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 34 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 37 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 40 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 43 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 46 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.ProductImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 49 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.ProductImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 52 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 55 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 58 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 61 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 64 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayNameFor(model => model.Product.Supplier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 67 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
               Write(Html.DisplayFor(model => model.Product.Supplier.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e003d4678a08307570bdb064e34db949c044ad7914659", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e003d4678a08307570bdb064e34db949c044ad7914934", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 72 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Product.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e003d4678a08307570bdb064e34db949c044ad7916794", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 77 "E:\Chuyen_nganh_7\PRN221\Assignments\ShoppingAssignment_SE151263\ShoppingAssignment_SE151263\Pages\Products\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingAssignment_SE151263.Pages.Products.DeleteModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShoppingAssignment_SE151263.Pages.Products.DeleteModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShoppingAssignment_SE151263.Pages.Products.DeleteModel>)PageContext?.ViewData;
        public ShoppingAssignment_SE151263.Pages.Products.DeleteModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591