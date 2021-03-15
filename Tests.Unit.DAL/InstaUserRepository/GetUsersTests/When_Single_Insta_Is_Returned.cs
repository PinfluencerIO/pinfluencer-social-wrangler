namespace Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    public class When_Single_Insta_Is_Returned : When_Get_Users_Is_Called
    {
        protected override void When()
        {
            SetSingleInsta("12321","user","Aidan Gan","this is my bio",121);
            
            base.When();

            Sut.GetUsers();
        }
    }
}