using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramUserRepositoryTests.MapMany
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_A_InstagramUserRepository
    {
        private readonly IEnumerable<SocialInsightsUser> _socialInsightsUsers;
        private readonly DataArray<FacebookPage> _facebookPages;

        private static object [ ] data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new SocialInsightsUser
                    {
                        Bio = "example bio",
                        Followers = 123,
                        Id = "123",
                        Name = "Aidan Gannon",
                        Username = "aidangannon"
                    }
                },
                new DataArray<FacebookPage>
                {
                    Data = new [ ]
                    {
                        new FacebookPage
                        {
                            Id = "123",
                            Instagram = new InstagramUser
                            {
                                Bio = "example bio",
                                Followers = 123,
                                Id = "123",
                                Name = "Aidan Gannon",
                                Username = "aidangannon"
                            },
                            Name = "Aidan's Page"
                        }
                    }
                }
            },
            new object [ ]
            {
                new [ ]
                {
                    new SocialInsightsUser
                    {
                        Bio = "example bio",
                        Followers = 123,
                        Id = "123",
                        Name = "Aidan Gannon",
                        Username = "aidangannon"
                    }
                },
                new DataArray<FacebookPage>
                {
                    Data = new [ ]
                    {
                        new FacebookPage
                        {
                            Id = "123",
                            Instagram = new InstagramUser
                            {
                                Bio = "example bio",
                                Followers = 123,
                                Id = "123",
                                Name = "Aidan Gannon",
                                Username = "aidangannon"
                            },
                            Name = "Aidan's Page"
                        },
                        new FacebookPage
                        {
                            Id = "12345",
                            Name = "Aidan's Second Page"
                        }
                    }
                }
            },
            new object [ ]
            {
                new [ ]
                {
                    new SocialInsightsUser
                    {
                        Bio = "example bio",
                        Followers = 123,
                        Id = "123",
                        Name = "Aidan Gannon",
                        Username = "aidangannon"
                    },
                    new SocialInsightsUser
                    {
                        Bio = "example bio 2",
                        Followers = 200,
                        Id = "1234",
                        Name = "Aidan Jason Gannon",
                        Username = "aidangannon__"
                    }
                },
                new DataArray<FacebookPage>
                {
                    Data = new [ ]
                    {
                        new FacebookPage
                        {
                            Id = "123",
                            Instagram = new InstagramUser
                            {
                                Bio = "example bio",
                                Followers = 123,
                                Id = "123",
                                Name = "Aidan Gannon",
                                Username = "aidangannon"
                            },
                            Name = "Aidan's Page"
                        },
                        new FacebookPage
                        {
                            Id = "12345",
                            Name = "Aidan's Second Page",
                            Instagram = new InstagramUser
                            {
                                Bio = "example bio 2",
                                Followers = 200,
                                Id = "1234",
                                Name = "Aidan Jason Gannon",
                                Username = "aidangannon__"
                            }
                        }
                    }
                }
            },
            new object [ ]
            {
                Enumerable.Empty<SocialInsightsUser>( ),
                new DataArray<FacebookPage>
                {
                    Data = new [ ]
                    {
                        new FacebookPage
                        {
                            Id = "123",
                            Name = "Aidan's Page"
                        },
                        new FacebookPage
                        {
                            Id = "12345",
                            Name = "Aidan's Second Page"
                        }
                    }
                }
            },
            new object [ ]
            {
                Enumerable.Empty<SocialInsightsUser>( ),
                new DataArray<FacebookPage>
                {
                    Data = Enumerable.Empty<FacebookPage>( )
                }
            }
        };

        private IEnumerable<SocialInsightsUser> _result;

        public When_Called( IEnumerable<SocialInsightsUser> socialInsightsUsers, DataArray<FacebookPage> facebookPages )
        {
            _socialInsightsUsers = socialInsightsUsers;
            _facebookPages = facebookPages;
        }

        protected override void When( ) { _result = SUT.MapMany( _facebookPages ); }

        [ Test ]
        public void Then_Bios_Are_Correct( )
        {
            Assert.True( _result
                .Select( x => x.Bio )
                .SequenceEqual( _socialInsightsUsers.Select( x => x.Bio ) ) );
        }

        [ Test ]
        public void Then_Ids_Are_Correct( )
        {
            Assert.True( _result
                .Select( x => x.Id )
                .SequenceEqual( _socialInsightsUsers.Select( x => x.Id ) ) );
        }

        [ Test ]
        public void Then_Followers_Are_Correct( )
        {
            Assert.True( _result
                .Select( x => x.Followers )
                .SequenceEqual( _socialInsightsUsers.Select( x => x.Followers ) ) );
        }

        [ Test ]
        public void Then_Names_Are_Correct( )
        {
            Assert.True( _result
                .Select( x => x.Name )
                .SequenceEqual( _socialInsightsUsers.Select( x => x.Name ) ) );
        }

        [ Test ]
        public void Then_Usernames_Are_Correct( )
        {
            Assert.True( _result
                .Select( x => x.Username )
                .SequenceEqual( _socialInsightsUsers.Select( x => x.Username ) ) );
        }

        [ Test ]
        public void Then_Array_Length_Are_Correct( )
        {
            Assert.AreEqual( _socialInsightsUsers.Count( ), _result.Count( ) );
        }
    }
}