﻿using Amazon;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AwsCredentialsDto
    {
        public string Id { get; set; }
        
        public string Token { get; set; }

        public string Region { get; set; }
    }
}