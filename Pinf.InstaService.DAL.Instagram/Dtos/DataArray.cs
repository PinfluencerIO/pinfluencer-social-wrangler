﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    [ DataContract ]
    public class DataArray<T>
    {
        [ DataMember( Name = "data" ) ] public IEnumerable<T> Data { get; set; }
    }
}