﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.LanguageServer.EndpointContracts;
using Microsoft.AspNetCore.Razor.LanguageServer.Serialization;
using Microsoft.AspNetCore.Razor.ProjectSystem;
using Microsoft.CodeAnalysis.Razor.ProjectSystem;
using Microsoft.CodeAnalysis.Razor.Workspaces.Protocol.ProjectSystem;

namespace Microsoft.AspNetCore.Razor.LanguageServer.ProjectSystem;

/// <summary>
/// Used to receive project system info updates from the client that were discovered OOB.
/// </summary>
[RazorLanguageServerEndpoint(LanguageServerConstants.RazorProjectInfoEndpoint)]
internal class ProjectInfoEndpoint(ProjectConfigurationStateManager stateManager) : IRazorNotificationHandler<ProjectInfoParams>
{
    private readonly ProjectConfigurationStateManager _stateManager = stateManager;

    public bool MutatesSolutionState => false;

    public Task HandleNotificationAsync(ProjectInfoParams request, RazorRequestContext requestContext, CancellationToken cancellationToken)
    {
        var projectKey = ProjectKey.FromString(request.ProjectKeyId);

        RazorProjectInfo? projectInfo = null;

        if (request.FilePath is string filePath)
        {
            projectInfo = RazorProjectInfoDeserializer.Instance.DeserializeFromFile(filePath);
            File.Delete(filePath);
        }

        return _stateManager.ProjectInfoUpdatedAsync(projectKey, projectInfo, cancellationToken);
    }
}
