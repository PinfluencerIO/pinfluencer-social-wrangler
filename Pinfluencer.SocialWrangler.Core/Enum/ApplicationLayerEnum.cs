using System.ComponentModel;

namespace Pinfluencer.SocialWrangler.Core.Enum
{
    public enum ApplicationLayerEnum
    {
        [ Description( "Domain Layer" ) ] DL,
        [ Description( "Data Access Layer" ) ] DAL,
        [ Description( "Crosscutting Layer" ) ] Crosscutting,
        [ Description( "Rest Api Layer" ) ] API
    }
}