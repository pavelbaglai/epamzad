using System.Collections.Generic;
using System;
using System.Linq;

namespace homeWork_11
{
    public static class Query
    {
        public static IEnumerable<Student> QueryFilter(List<Student> list, Filter filter)
        {
            IEnumerable<Student> result = list;
            if (filter!=null&&result!=null)
            { 
                if (!string.IsNullOrEmpty(filter.StudentName)) result = result.Where(x => x.Name == filter.StudentName);
                if (!string.IsNullOrEmpty(filter.Discipline)) result = result.Where(x => x.Discipline == filter.Discipline);
                if (filter.MinMark != null&& filter.MaxMark != null) result = result.Where(x => x.Mark >= filter.MinMark && x.Mark <= filter.MaxMark);
                if (filter.StartDate!=null&&filter.EndDate!=null) result = result.Where(x => x.Date>= filter.StartDate && x.Date <= filter.EndDate);
                if (filter.Number>0 && list.Count > filter.Number) result = result.Take(filter.Number);
            }
            else
            {
                throw new ArgumentNullException();
            }
            return result.ToList();
        }

    }
}