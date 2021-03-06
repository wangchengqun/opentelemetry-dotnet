﻿// <copyright file="NoopTraceComponent.cs" company="OpenTelemetry Authors">
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
    using OpenTelemetry.Trace.Propagation;

    internal sealed class NoopTraceComponent : ITraceComponent
    {
        private readonly IExportComponent noopExportComponent = Export.ExportComponentBase.NewNoopExportComponent;

        public ITracer Tracer
        {
            get
            {
                return Trace.Tracer.NoopTracer;
            }
        }

        public IPropagationComponent PropagationComponent
        {
            get
            {
                return Propagation.PropagationComponentBase.NoopPropagationComponent;
            }
        }

        public IExportComponent ExportComponent
        {
            get
            {
                return this.noopExportComponent;
            }
        }

        public ITraceConfig TraceConfig
        {
            get
            {
                return Config.TraceConfigBase.NoopTraceConfig;
            }
        }
    }
}
