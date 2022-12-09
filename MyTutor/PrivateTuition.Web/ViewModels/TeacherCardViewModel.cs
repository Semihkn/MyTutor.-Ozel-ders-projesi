using PrivateTuition.Entity;

namespace PrivateTuition.Web.ViewModels
{
    public class TeacherCardViewModel
    {
        public PageInfo PageInfo { get; set; } = null!;
        public List<Teacher> Teachers { get; set; } = null!;

    }
   
}
