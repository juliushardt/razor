﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

#nullable disable

using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.Razor.ProjectSystem;

namespace Microsoft.AspNetCore.Razor.ExternalAccess.OmniSharp.Project;

internal sealed class OmniSharpHostProject
{
    internal OmniSharpHostProject(string projectFilePath, RazorConfiguration razorConfiguration, string rootNamespace)
    {
        if (projectFilePath is null)
        {
            throw new ArgumentNullException(nameof(projectFilePath));
        }

        if (razorConfiguration is null)
        {
            throw new ArgumentNullException(nameof(razorConfiguration));
        }

        InternalHostProject = new HostProject(projectFilePath, razorConfiguration, rootNamespace);
    }

    internal string FilePath => InternalHostProject.FilePath;

    internal RazorConfiguration Configuration => InternalHostProject.Configuration;

    internal string RootNamespace => InternalHostProject.RootNamespace;

    internal HostProject InternalHostProject { get; }
}
