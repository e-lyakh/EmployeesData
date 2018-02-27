namespace HR.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            EmpPromotions = new HashSet<EmpPromotion>();
            Photos = new HashSet<Photo>();
        }

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [Column(TypeName = "Date")]
        [Display(Name = "Дата рождения")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateBirthday { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [StringLength(24)]
        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpPromotion> EmpPromotions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}