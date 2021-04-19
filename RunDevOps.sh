#!/bin/bash

dotnet publish Pinf.InstaService.Bootstrapping.DevOps -o DevOps;
dotnet exec DevOps/DevOps.dll $1;