﻿using System;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class InstaProfileViewsInsight
    {
        public InstaProfileViewsInsight( DateTime time, int count )
        {
            Time = time;
            Count = count;
        }

        [ JsonPropertyName( "time" ) ] public DateTime Time { get; }

        [ JsonPropertyName( "count" ) ] public int Count { get; }
    }
}