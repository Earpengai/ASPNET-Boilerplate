using System.Net.Http.Headers;

namespace Application.Common.Models
{
    public class PagedList<T>
    {
        public List<T> Items { get; }
        public int TotalRecords { get; }
        public int Page { get; }
        public int Limit { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / Limit);
        public int Count => Items.Count;
        public bool HasNext => Page < TotalPages;
        public bool HasPrevious => Page > 1;

        public int[] Pages
        {
            get
            {
                var pages = new List<int>();
                if (TotalPages <= 10)
                {
                    for (int i = 1; i <= TotalPages; i++)
                    {
                        pages.Add(i);
                    }
                }
                else
                {
                    pages.Add(1);

                    int start = Math.Max(2, Page - 2);
                    int end = Math.Min(Page + 2, TotalPages);

                    for (int i = start; i <= end; i++)
                    {
                        pages.Add(i);
                    }
                    pages.Add(TotalPages);
                }
                return [.. pages.Distinct()];
            }
        }

        public PagedList(List<T> items, int totalRecords, int page = 1, int limit = 10)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), "Page number can't be less than 1");

            if (limit < 1)
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit can't be less than 1");

            Items = items;
            TotalRecords = totalRecords;
            Page = page;
            Limit = limit;
        }

        public static PagedList<T> FromList(List<T> source, int page = 1, int limit = 10)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), "Page number can't be less than 1");

            if (limit < 1)
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit can't be less than 1");

            var pagedItem = source
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return new PagedList<T>(pagedItem, source.Count, page, limit);
        }
    }
}
