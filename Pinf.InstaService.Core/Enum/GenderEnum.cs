using System.Runtime.Serialization;

namespace Pinf.InstaService.Core.Enum
{
    //TODO => MAKE DYNAMIC ( REFLECTION )
    public enum GenderEnum
    {
        [ EnumMember( Value = "male" ) ] Male,
        [ EnumMember( Value = "female" ) ] Female
    }
}