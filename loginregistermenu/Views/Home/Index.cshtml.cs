using Microsoft.AspNetCore.Mvc;


namespace loginregistermenu.Pages.Home
{
    public class IndexModel 
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
