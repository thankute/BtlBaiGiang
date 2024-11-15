//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BtlBaiGiang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lecture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lecture()
        {
            this.LectureReviews = new HashSet<LectureReview>();
        }
    
        public int LectureID { get; set; }
        public string LectureName { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoURL { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public Nullable<int> Views { get; set; }
        public Nullable<int> ReviewCount { get; set; }
        public string CourseInfo { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual Cours Cours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LectureReview> LectureReviews { get; set; }
    }
}
