﻿using System;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.Insights
{
    public class ProfileViewsInsight
    {
        public ProfileViewsInsight( DateTime time, int count )
        {
            Time = time;
            Count = count;
        }

        public DateTime Time { get; }

        public int Count { get; }
    }
}