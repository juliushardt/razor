﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.AspNetCore.Razor.LanguageServer.Protocol;
using Microsoft.Extensions.Internal;
using Microsoft.VisualStudio.LanguageServer.Protocol;

namespace Microsoft.VisualStudio.LanguageServerClient.Razor.HtmlCSharp
{
    // Note: This type should be kept in sync with the one in Razor.LanguageServer assembly.
    internal class RazorMapToDocumentEditsParams : IEquatable<RazorMapToDocumentEditsParams>
    {
        public RazorLanguageKind Kind { get; init; }

        public required Uri RazorDocumentUri { get; init; }

        public required TextEdit[] ProjectedTextEdits { get; init; }

        public TextEditKind TextEditKind { get; init; }

        public required FormattingOptions? FormattingOptions { get; init; }

        // Everything below this is for testing purposes only.
        public bool Equals(RazorMapToDocumentEditsParams? other)
        {
            return
                other is not null &&
                Kind == other.Kind &&
                RazorDocumentUri == other.RazorDocumentUri &&
                Enumerable.SequenceEqual(ProjectedTextEdits?.Select(p => p.NewText), other.ProjectedTextEdits?.Select(p => p.NewText)) &&
                Enumerable.SequenceEqual(ProjectedTextEdits?.Select(p => p.Range), other.ProjectedTextEdits?.Select(p => p.Range)) &&
                TextEditKind == other.TextEditKind &&
                IsEqual(other.FormattingOptions);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RazorMapToDocumentEditsParams);
        }

        public override int GetHashCode()
        {
            var hash = new HashCodeCombiner();
            hash.Add(Kind);
            hash.Add(RazorDocumentUri);
            hash.Add(ProjectedTextEdits);
            return hash;
        }

        private bool IsEqual(FormattingOptions? other)
        {
            if (FormattingOptions is null || other is null)
            {
                return FormattingOptions == other;
            }

            return
                FormattingOptions.InsertSpaces == other.InsertSpaces &&
                FormattingOptions.TabSize == other.TabSize &&
                (ReferenceEquals(FormattingOptions.OtherOptions, other.OtherOptions) ||
                (FormattingOptions.OtherOptions is not null && other.OtherOptions is not null &&
                FormattingOptions.OtherOptions.OrderBy(k => k.Key).SequenceEqual(other.OtherOptions.OrderBy(k => k.Key))));
        }
    }
}
