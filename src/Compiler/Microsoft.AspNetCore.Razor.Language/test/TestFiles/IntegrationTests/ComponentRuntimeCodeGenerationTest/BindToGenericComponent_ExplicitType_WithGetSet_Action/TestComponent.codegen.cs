﻿// <auto-generated/>
#pragma warning disable 1591
namespace Test
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
    #line default
    #line hidden
    #nullable restore
    public partial class TestComponent : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Test.MyComponent<CustomValue>>(0);
            __builder.AddComponentParameter(1, nameof(global::Test.MyComponent<CustomValue>.
#nullable restore
#line (1,41)-(1,46) "x:\dir\subdir\Test\TestComponent.cshtml"
Value

#line default
#line hidden
#nullable disable
            ), global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<CustomValue>(
#nullable restore
#line (1,52)-(1,63) "x:\dir\subdir\Test\TestComponent.cshtml"
ParentValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentParameter(2, nameof(global::Test.MyComponent<CustomValue>.ValueChanged), global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<CustomValue>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<CustomValue>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, 
#nullable restore
#line (1,82)-(1,93) "x:\dir\subdir\Test\TestComponent.cshtml"
UpdateValue

#line default
#line hidden
#nullable disable
            , ParentValue))));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line (2,8)-(6,1) "x:\dir\subdir\Test\TestComponent.cshtml"

    public CustomValue ParentValue { get; set; } = new CustomValue();

    public void UpdateValue(CustomValue value) => ParentValue = value;

#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
