﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

#nullable disable

using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.PooledObjects;
using Microsoft.AspNetCore.Razor.Test.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Razor.LanguageServer.Formatting;

public class HtmlFormattingTest(ITestOutputHelper testOutput)
    : FormattingTestBase(testOutput)
{
    [Fact]
    public async Task FormatsSimpleHtmlTag_OnType()
    {
        await RunOnTypeFormattingTestAsync(
            input: """
                    <html>
                    <head>
                        <title>Hello</title>
                            <script>
                                var x = 2;$$
                            </script>
                    </head>
                    </html>
                    """,
            expected: """
                    <html>
                    <head>
                        <title>Hello</title>
                        <script>
                            var x = 2;
                        </script>
                    </head>
                    </html>
                    """,
            triggerCharacter: ';',
            fileKind: FileKinds.Legacy);
    }

    [Fact]
    public async Task FormatsComponentTags()
    {
        var tagHelpers = GetComponents();
        await RunFormattingTestAsync(
            input: """
                       <Counter>
                        @if(true){
                            <p>@DateTime.Now</p>
                    }
                    </Counter>

                        <GridTable>
                        @foreach (var row in rows){
                            <GridRow @onclick="SelectRow(row)">
                            @foreach (var cell in row){
                        <GridCell>@cell</GridCell>}</GridRow>
                        }
                    </GridTable>
                    """,
            expected: """
                    <Counter>
                        @if (true)
                        {
                            <p>@DateTime.Now</p>
                        }
                    </Counter>

                    <GridTable>
                        @foreach (var row in rows)
                        {
                            <GridRow @onclick="SelectRow(row)">
                                @foreach (var cell in row)
                                {
                                    <GridCell>@cell</GridCell>
                                }
                            </GridRow>
                        }
                    </GridTable>
                    """,
            tagHelpers: tagHelpers,
            skipFlipLineEndingTest: true); // tracked by https://github.com/dotnet/razor/issues/10836
    }

    [Fact]
    public async Task FormatsComponentTag_WithImplicitExpression()
    {
        var tagHelpers = GetComponents();
        await RunFormattingTestAsync(
            input: """
                        <GridTable>
                            <GridRow >
                        <GridCell>@cell</GridCell>
                    <GridCell>cell</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                        <GridRow>
                            <GridCell>@cell</GridCell>
                            <GridCell>cell</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            tagHelpers: tagHelpers);
    }

    [Fact]
    public async Task FormatsComponentTag_WithExplicitExpression()
    {
        var tagHelpers = GetComponents();
        await RunFormattingTestAsync(
            input: """
                        <GridTable>
                            <GridRow >
                        <GridCell>@(cell)</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                        <GridRow>
                            <GridCell>@(cell)</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            tagHelpers: tagHelpers);
    }

    [Fact]
    public async Task FormatsComponentTag_WithExplicitExpression_FormatsInside()
    {
        var tagHelpers = GetComponents();
        await RunFormattingTestAsync(
            input: """
                        <GridTable>
                            <GridRow >
                        <GridCell>@(""  +    "")</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                        <GridRow>
                            <GridCell>@("" + "")</GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            tagHelpers: tagHelpers);
    }

    [Fact]
    public async Task FormatsComponentTag_WithExplicitExpression_MovesStart()
    {
        var tagHelpers = GetComponents();
        await RunFormattingTestAsync(
            input: """
                        <GridTable>
                            <GridRow >
                        <GridCell>
                        @(""  +    "")
                        </GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                        <GridRow>
                            <GridCell>
                                @("" + "")
                            </GridCell>
                        </GridRow>
                    </GridTable>
                    """,
            tagHelpers: tagHelpers);
    }

    [Fact]
    [WorkItem("https://github.com/dotnet/aspnetcore/issues/30382")]
    public async Task FormatNestedComponents2()
    {
        await RunFormattingTestAsync(
            input: """
                    <GridTable>
                    <ChildContent>
                    <GridRow>
                    <ChildContent>
                    <GridCell>
                    <ChildContent>
                    <strong></strong>
                    @if (true)
                    {
                    <strong></strong>
                    }
                    <strong></strong>
                    </ChildContent>
                    </GridCell>
                    </ChildContent>
                    </GridRow>
                    </ChildContent>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                        <ChildContent>
                            <GridRow>
                                <ChildContent>
                                    <GridCell>
                                        <ChildContent>
                                            <strong></strong>
                                            @if (true)
                                            {
                                                <strong></strong>
                                            }
                                            <strong></strong>
                                        </ChildContent>
                                    </GridCell>
                                </ChildContent>
                            </GridRow>
                        </ChildContent>
                    </GridTable>
                    """,
            tagHelpers: GetComponents());
    }

    [Fact]
    [WorkItem("https://github.com/dotnet/razor/issues/8227")]
    public async Task FormatNestedComponents3()
    {
        await RunFormattingTestAsync(
            input: """
                    @if (true)
                    {
                        <Component1 Id="comp1"
                                Caption="Title" />
                    <Component1 Id="comp2"
                                Caption="Title">
                                <Frag>
                    <Component1 Id="comp3"
                                Caption="Title" />
                                </Frag>
                                </Component1>
                    }

                    @if (true)
                    {
                        <a_really_long_tag_name Id="comp1"
                                Caption="Title" />
                    <a_really_long_tag_name Id="comp2"
                                Caption="Title">
                                <a_really_long_tag_name>
                    <a_really_long_tag_name Id="comp3"
                                Caption="Title" />
                                </a_really_long_tag_name>
                                </a_really_long_tag_name>
                    }
                    """,
            expected: """
                    @if (true)
                    {
                        <Component1 Id="comp1"
                                    Caption="Title" />
                        <Component1 Id="comp2"
                                    Caption="Title">
                            <Frag>
                                <Component1 Id="comp3"
                                            Caption="Title" />
                            </Frag>
                        </Component1>
                    }

                    @if (true)
                    {
                        <a_really_long_tag_name Id="comp1"
                                                Caption="Title" />
                        <a_really_long_tag_name Id="comp2"
                                                Caption="Title">
                            <a_really_long_tag_name>
                                <a_really_long_tag_name Id="comp3"
                                                        Caption="Title" />
                            </a_really_long_tag_name>
                        </a_really_long_tag_name>
                    }
                    """,
            tagHelpers: GetComponents());
    }

    [Fact(Skip = "Requires fix")]
    [WorkItem("https://github.com/dotnet/razor/issues/8228")]
    public async Task FormatNestedComponents4()
    {
        await RunFormattingTestAsync(
            input: """
                    @{
                        RenderFragment fragment =
                          @<Component1 Id="Comp1"
                                     Caption="Title">
                        </Component1>;
                    }
                    """,
            expected: """
                    @{
                        RenderFragment fragment =
                        @<Component1 Id="Comp1"
                                     Caption="Title">
                        </Component1>;
                    }
                    """,
            tagHelpers: GetComponents());
    }

    [Fact]
    [WorkItem("https://github.com/dotnet/razor/issues/8229")]
    public async Task FormatNestedComponents5()
    {
        await RunFormattingTestAsync(
            input: """
                    <Component1>
                        @{
                            RenderFragment fragment =
                            @<Component1 Id="Comp1"
                                     Caption="Title">
                            </Component1>;
                        }
                    </Component1>
                    """,
            expected: """
                    <Component1>
                        @{
                            RenderFragment fragment =
                            @<Component1 Id="Comp1"
                                         Caption="Title">
                            </Component1>;
                        }
                    </Component1>
                    """,
            tagHelpers: GetComponents());
    }

    [Fact]
    [WorkItem("https://github.com/dotnet/aspnetcore/issues/30382")]
    public async Task FormatNestedComponents2_Range()
    {
        await RunFormattingTestAsync(
            input: """
                    <GridTable>
                    <ChildContent>
                    <GridRow>
                    <ChildContent>
                    <GridCell>
                    <ChildContent>
                    <strong></strong>
                    @if (true)
                    {
                    [|<strong></strong>|]
                    }
                    <strong></strong>
                    </ChildContent>
                    </GridCell>
                    </ChildContent>
                    </GridRow>
                    </ChildContent>
                    </GridTable>
                    """,
            expected: """
                    <GridTable>
                    <ChildContent>
                    <GridRow>
                    <ChildContent>
                    <GridCell>
                    <ChildContent>
                    <strong></strong>
                    @if (true)
                    {
                                                <strong></strong>
                    }
                    <strong></strong>
                    </ChildContent>
                    </GridCell>
                    </ChildContent>
                    </GridRow>
                    </ChildContent>
                    </GridTable>
                    """,
            tagHelpers: GetComponents());
    }

    [Fact]
    [WorkItem("https://github.com/dotnet/razor/issues/6211")]
    public async Task FormatCascadingValueWithCascadingTypeParameter()
    {
        await RunFormattingTestAsync(
            input: """

                    <div>
                        @foreach ( var i in new int[] { 1, 23 } )
                        {
                            <div></div>
                        }
                    </div>
                    <Select TValue="string">
                        @foreach ( var i in new int[] { 1, 23 } )
                        {
                            <SelectItem Value="@i">@i</SelectItem>
                        }
                    </Select>
                    """,
            expected: """

                    <div>
                        @foreach (var i in new int[] { 1, 23 })
                        {
                            <div></div>
                        }
                    </div>
                    <Select TValue="string">
                        @foreach (var i in new int[] { 1, 23 })
                        {
                            <SelectItem Value="@i">@i</SelectItem>
                        }
                    </Select>
                    """,
            tagHelpers: CreateTagHelpers(),
            skipFlipLineEndingTest: true); // tracked by https://github.com/dotnet/razor/issues/10836

        ImmutableArray<TagHelperDescriptor> CreateTagHelpers()
        {
            var select = """
                    @typeparam TValue
                    @attribute [CascadingTypeParameter(nameof(TValue))]
                    <CascadingValue Value="@this" IsFixed>
                        <select>
                            @ChildContent
                        </select>
                    </CascadingValue>

                    @code
                    {
                        [Parameter] public TValue SelectedValue { get; set; }
                    }
                    """;
            var selectItem = """
                    @typeparam TValue
                    <option value="@StringValue">@ChildContent</option>

                    @code
                    {
                        [Parameter] public TValue Value { get; set; }
                        [Parameter] public RenderFragment ChildContent { get; set; }

                        protected string StringValue => Value?.ToString();
                    }
                    """;

            var selectComponent = CompileToCSharp("Select.razor", select, throwOnFailure: true, fileKind: FileKinds.Component);
            var selectItemComponent = CompileToCSharp("SelectItem.razor", selectItem, throwOnFailure: true, fileKind: FileKinds.Component);

            using var _ = ArrayBuilderPool<TagHelperDescriptor>.GetPooledObject(out var tagHelpers);
            tagHelpers.AddRange(selectComponent.CodeDocument.GetTagHelperContext().TagHelpers);
            tagHelpers.AddRange(selectItemComponent.CodeDocument.GetTagHelperContext().TagHelpers);

            return tagHelpers.ToImmutable();
        }
    }

    private ImmutableArray<TagHelperDescriptor> GetComponents()
    {
        AdditionalSyntaxTrees.Add(Parse("""
                using Microsoft.AspNetCore.Components;
                namespace Test
                {
                    public class GridTable : ComponentBase
                    {
                        [Parameter]
                        public RenderFragment ChildContent { get; set; }
                    }

                    public class GridRow : ComponentBase
                    {
                        [Parameter]
                        public RenderFragment ChildContent { get; set; }
                    }

                    public class GridCell : ComponentBase
                    {
                        [Parameter]
                        public RenderFragment ChildContent { get; set; }
                    }

                    public class Component1 : ComponentBase
                    {
                        [Parameter]
                        public string Id { get; set; }

                        [Parameter]
                        public string Caption { get; set; }

                        [Parameter]
                        public RenderFragment Frag {get;set;}
                    }
                }
                """));

        var generated = CompileToCSharp("Test.razor", string.Empty, throwOnFailure: false, fileKind: FileKinds.Component);

        return generated.CodeDocument.GetTagHelperContext().TagHelpers.ToImmutableArray();
    }
}
