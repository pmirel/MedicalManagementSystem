using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel.Collections
{
    public class PaginatedList<T>
    {
        public PaginatedList(long currentPage, long totalItems, long itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            TotalPages = (totalItems + itemsPerPage - 1) / itemsPerPage;
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
        public long CurrentPage { get; private set; }
        public long TotalItems { get; private set; }
        public long ItemsPerPage { get; private set; }
        public long TotalPages { get; private set; }

    }
}

