namespace AspDemo.Models.Dto
{
  [Serializable]
  public class PageResult<T>(ICollection<T> rows, long total, long totalNotFiltered = 0)
  {
    public long Total { get; set; } = total;
    public long TotalNotFiltered { get; set; } =
        totalNotFiltered == 0 ? total : totalNotFiltered;
    public ICollection<T> Rows { get; set; } = rows;
  }
}
