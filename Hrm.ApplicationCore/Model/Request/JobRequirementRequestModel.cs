using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class JobRequirementRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Job Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalPositions { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int JobCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}

