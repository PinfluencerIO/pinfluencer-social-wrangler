﻿using System;

namespace BLL.Models
{
    public class InstaImpression
    {
        public DateTime Time { get; }

        public int Count { get; }

        public InstaImpression(DateTime time, int count)
        {
            Time = time;
            Count = count;
        }
    }
}