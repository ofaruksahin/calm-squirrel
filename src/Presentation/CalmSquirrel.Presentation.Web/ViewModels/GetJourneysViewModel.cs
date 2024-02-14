namespace CalmSquirrel.Presentation.Web.ViewModels
{
    public class GetJourneysViewModel
    {
        public string SearchText { get; set; }
        public DateTime Date { get; set; }

        public bool Validate()
        {
            var now = DateTime.Now;
            if (Date < new DateTime(now.Year,now.Month,now.Day,0,0,0))
                return false;

            return true;
        }
    }
}
