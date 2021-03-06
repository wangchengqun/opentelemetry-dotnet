﻿// <copyright file="NoopStats.cs" company="OpenTelemetry Authors">
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

namespace OpenTelemetry.Stats
{
    internal sealed class NoopStats
    {
        private NoopStats()
        {
        }

        internal static IStatsRecorder NoopStatsRecorder
        {
            get
            {
                return OpenTelemetry.Stats.NoopStatsRecorder.Instance;
            }
        }

        internal static IMeasureMap NoopMeasureMap
        {
            get
            {
                return OpenTelemetry.Stats.NoopMeasureMap.Instance;
            }
        }

        internal static IStatsComponent NewNoopStatsComponent()
        {
            return new NoopStatsComponent();
        }

        internal static IViewManager NewNoopViewManager()
        {
            return new NoopViewManager();
        }
    }
}
