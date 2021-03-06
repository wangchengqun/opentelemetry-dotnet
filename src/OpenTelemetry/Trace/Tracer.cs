﻿// <copyright file="Tracer.cs" company="OpenTelemetry Authors">
// Copyright 2018, OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Trace
{
    using OpenTelemetry.Trace.Config;
    using OpenTelemetry.Trace.Export;
    using System.Threading;

    /// <inheritdoc/>
    public sealed class Tracer : TracerBase
    {
        private readonly SpanBuilderOptions spanBuilderOptions;
        private readonly IExportComponent exportComponent;

        public Tracer(IRandomGenerator randomGenerator, IStartEndHandler startEndHandler, ITraceConfig traceConfig, IExportComponent exportComponent)
        {
            this.spanBuilderOptions = new SpanBuilderOptions(randomGenerator, startEndHandler, traceConfig);
        }

        /// <inheritdoc/>
        public override void RecordSpanData(ISpanData span)
        {
            this.exportComponent.SpanExporter.ExportAsync(span, CancellationToken.None);
        }

        /// <inheritdoc/>
        public override ISpanBuilder SpanBuilderWithExplicitParent(string spanName, SpanKind spanKind = SpanKind.Internal, ISpan parent = null)
        {
            return Trace.SpanBuilder.CreateWithParent(spanName, spanKind, parent, this.spanBuilderOptions);
        }

        /// <inheritdoc/>
        public override ISpanBuilder SpanBuilderWithRemoteParent(string spanName, SpanKind spanKind = SpanKind.Internal, ISpanContext remoteParentSpanContext = null)
        {
            return Trace.SpanBuilder.CreateWithRemoteParent(spanName, spanKind, remoteParentSpanContext, this.spanBuilderOptions);
        }
    }
}
