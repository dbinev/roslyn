﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Roslyn.LanguageServer.Protocol;

using System.Text.Json.Serialization;

/// <summary>
/// Class which represents the parameter that's sent with 'textDocument/publishDiagnostics' messages.
///
/// See the <see href="https://microsoft.github.io/language-server-protocol/specifications/specification-current/#publishDiagnosticsParams">Language Server Protocol specification</see> for additional information.
/// </summary>
internal sealed class PublishDiagnosticParams
{
    /// <summary>
    /// Gets or sets the URI of the text document.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonConverter(typeof(DocumentUriConverter))]
    public DocumentUri Uri
    {
        get;
        set;
    }

    /// <summary>
    /// Optional version number of the document for which the diagnostics are published
    /// </summary>
    /// <remarks>Since LSP 3.15</remarks>
    [JsonPropertyName("version")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Version { get; init; }

    /// <summary>
    /// Gets or sets the collection of diagnostics.
    /// </summary>
    [JsonPropertyName("diagnostics")]
    public Diagnostic[] Diagnostics
    {
        get;
        set;
    }
}
