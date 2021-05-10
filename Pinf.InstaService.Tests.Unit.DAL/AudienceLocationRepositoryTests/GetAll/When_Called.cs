﻿using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceLocationRepositoryTests.GetAll
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_AudienceLocationRepository
    {
        private readonly IEnumerable<AudiencePercentage<LocationProperty>> _audienceLocation;
        private readonly TypeResponse<BubbleCollection<AudienceLocation>> _audienceLocationRaw;
        private readonly OperationResultEnum _operationResult;
        private OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> _result;

        private static object [ ] data = {
            new object [ ]
            {
                new [ ]
                {
                    new AudiencePercentage<LocationProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "1", Value = new LocationProperty{ Country = "United Kingdom", CountryCode = CountryEnum.GB },
                        Percentage = 0.75
                    },
                    new AudiencePercentage<LocationProperty>
                    {
                        Audience = new AudienceModel { Id = "123" }, Id = "2", Value = new LocationProperty{ Country = "United States", CountryCode = CountryEnum.US },
                        Percentage = 0.25
                    }
                },
                new TypeResponse<BubbleCollection<AudienceLocation>>
                {
                    Type = new BubbleCollection<AudienceLocation>
                    {
                        Results = new []
                        {
                            new AudienceLocation
                            {
                                Audience = "123",
                                Id = "1",
                                Place = "United Kingdom",
                                Percentage = 0.75
                            },
                            new AudienceLocation
                            {
                                Audience = "123",
                                Id = "2",
                                Place = "United States",
                                Percentage = 0.25
                            }
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object[ ]
            {
                Enumerable.Empty<AudiencePercentage<LocationProperty>>( ),
                new TypeResponse<BubbleCollection<AudienceLocation>>{ Type = new BubbleCollection<AudienceLocation>{ Results = Enumerable.Empty<AudienceLocation>(  ) } },
                OperationResultEnum.Failed
            }
        };

        public When_Called( IEnumerable<AudiencePercentage<LocationProperty>> audienceLocation,
            TypeResponse<BubbleCollection<AudienceLocation>> audienceLocationRaw,
            OperationResultEnum operationResult )
        {
            _audienceLocation = audienceLocation;
            _audienceLocationRaw = audienceLocationRaw;
            _operationResult = operationResult;
        }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<TypeResponse<BubbleCollection<AudienceLocation>>, IEnumerable<AudiencePercentage<LocationProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<LocationProperty>>>( ) )
                .Returns( new OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>( _audienceLocation, _operationResult ) );
            _result = Sut.GetAll( "123" );
        }
        
        [ Test ]
        public void Then_Data_Is_Read_Once( )
        {
            MockBubbleDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ), Arg.Any<Func<TypeResponse<BubbleCollection<AudienceLocation>>, IEnumerable<AudiencePercentage<LocationProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<LocationProperty>>>( ) );
        }

        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var mapResult = Sut.DataMap( _audienceLocationRaw );
            Assert.True( mapResult.Select( x => x.Id ).SequenceEqual( _audienceLocation.Select( x => x.Id ) ) &&
                         mapResult.Select( x => x.Percentage ).SequenceEqual( _audienceLocation.Select( x => x.Percentage ) ) &&
                         mapResult.Select( x => x.Audience.Id ).SequenceEqual( _audienceLocation.Select( x => x.Audience.Id ) ) );
        }
        
        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Received( )
                .Read( Arg.Is( "audiencelocation" ), Arg.Any<Func<TypeResponse<BubbleCollection<AudienceLocation>>, IEnumerable<AudiencePercentage<LocationProperty>>>>( ),
                    Arg.Any<IEnumerable<AudiencePercentage<LocationProperty>>>( ) );
        }

        [ Test ]
        public void Then_Correct_Status_Is_Returned( )
        {
            Assert.AreEqual( _operationResult, _result.Status );
        }
        
        [ Test ]
        public void Then_Correct_Model_Is_Returned( )
        {
            Assert.AreSame( _audienceLocation, _result.Value );
        }
    }
}