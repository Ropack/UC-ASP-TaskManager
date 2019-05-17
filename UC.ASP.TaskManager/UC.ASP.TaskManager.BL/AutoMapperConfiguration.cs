using System;
using AutoMapper;

namespace UC.ASP.TaskManager.BL
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                

            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}