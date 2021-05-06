﻿using System.Runtime.Serialization;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    [ DataContract ]
    public class Insight<T>
    {
        [ DataMember( Name = "value" ) ] public T Value { get; set; }

        [ DataMember( Name = "end_time" ) ] public string Time { get; set; }
    }
}