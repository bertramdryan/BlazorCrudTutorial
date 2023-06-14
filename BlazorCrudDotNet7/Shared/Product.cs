using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudDotNet7.Shared
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }
    }
}
