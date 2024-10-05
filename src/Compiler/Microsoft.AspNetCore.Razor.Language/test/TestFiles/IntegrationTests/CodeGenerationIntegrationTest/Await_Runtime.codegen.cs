﻿#pragma checksum "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "347cf5b257c3885845256697175dd94c0ef0bef29e4fca7e4ec1a009ff29d9a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.TestFiles_IntegrationTests_CodeGenerationIntegrationTest_Await), @"mvc.1.0.view", @"/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"347cf5b257c3885845256697175dd94c0ef0bef29e4fca7e4ec1a009ff29d9a6", @"/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("Identifier", "/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml")]
    [global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdateAttribute]
    #nullable restore
    internal sealed class TestFiles_IntegrationTests_CodeGenerationIntegrationTest_Await : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section>\r\n    <h1>Basic Asynchronous Expression Test</h1>\r\n    <p>Basic Asynchronous Expression: ");
            Write(
#nullable restore
#line (10,40)-(10,51) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <p>Basic Asynchronous Template: ");
            Write(
#nullable restore
#line (11,39)-(11,50) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <p>Basic Asynchronous Statement: ");
#nullable restore
#line (12,40)-(12,54) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
 await Foo(); 

#line default
#line hidden
#nullable disable

            WriteLiteral("</p>\r\n    <p>Basic Asynchronous Statement Nested: ");
            WriteLiteral(" <b>");
            Write(
#nullable restore
#line (13,52)-(13,63) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b> ");
            WriteLiteral("</p>\r\n    <p>Basic Incomplete Asynchronous Statement: ");
            Write(
#nullable restore
#line (14,50)-(14,55) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n</section>\r\n\r\n<section>\r\n    <h1>Advanced Asynchronous Expression Test</h1>\r\n    <p>Advanced Asynchronous Expression: ");
            Write(
#nullable restore
#line (19,43)-(19,58) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo(1, 2)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <p>Advanced Asynchronous Expression Extended: ");
            Write(
#nullable restore
#line (20,52)-(20,71) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo.Bar(1, 2)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <p>Advanced Asynchronous Template: ");
            Write(
#nullable restore
#line (21,42)-(21,64) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo("bob", true)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <p>Advanced Asynchronous Statement: ");
#nullable restore
#line (22,43)-(22,82) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
 await Foo(something, hello: "world"); 

#line default
#line hidden
#nullable disable

            WriteLiteral("</p>\r\n    <p>Advanced Asynchronous Statement Extended: ");
#nullable restore
#line (23,52)-(23,73) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
 await Foo.Bar(1, 2) 

#line default
#line hidden
#nullable disable

            WriteLiteral("</p>\r\n    <p>Advanced Asynchronous Statement Nested: ");
            WriteLiteral(" <b>");
            Write(
#nullable restore
#line (24,55)-(24,82) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await Foo(boolValue: false)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</b> ");
            WriteLiteral("</p>\r\n    <p>Advanced Incomplete Asynchronous Statement: ");
            Write(
#nullable restore
#line (25,53)-(25,72) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"
await ("wrrronggg")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n</section>");
        }
        #pragma warning restore 1998
#nullable restore
#line (1,13)-(6,1) "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Await.cshtml"

    public async Task<string> Foo()
    {
        return "Bar";
    }

#line default
#line hidden
#nullable disable

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
