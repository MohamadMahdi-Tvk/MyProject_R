using Microsoft.EntityFrameworkCore;

namespace MyProject.SharedService.Utilities;

public class Paginated<T>
{
    public int pageIndex { get; set; }
    public int totalPages { get; set; }
    public int totalItems { get; set; }
    public List<T> data { get; set; }
}
