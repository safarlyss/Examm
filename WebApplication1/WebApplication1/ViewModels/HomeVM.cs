using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeVM
    {
        public List<Aboutus> Aboutus { get; set; }
        public List<FAQ> FAQs { get; set; }
        public List<Portfolio> Portfolio { get; set; }
        public List<OurServices> OurServices { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Team> Team { get; set; }
    }
}
