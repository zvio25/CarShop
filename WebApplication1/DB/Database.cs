namespace WebApplication1.DB
{
    public class Database
    {
        public static TUTORIALDataContext Get()
        {
            var addressConection = "Data Source=DESKTOP-1AJ32P2;Initial Catalog=TUTORIAL;Integrated Security=True;";
            var tutorialDataContext = new TUTORIALDataContext(addressConection);

            return tutorialDataContext;
        }
    }
}