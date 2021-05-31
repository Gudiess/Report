//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Report.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            this.Courses = new HashSet<Course>();
        }
    
        public int ClassId { get; set; }
        public System.TimeSpan ClassTime { get; set; }
        public int ClassProfessorId { get; set; }
        public int SubjectId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> StudentClassId { get; set; }
    
        public virtual StudentClass StudentClass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
