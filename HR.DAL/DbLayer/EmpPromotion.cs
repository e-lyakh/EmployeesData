namespace HR.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpPromotion")]
    public partial class EmpPromotion
    {
        public int EmpPromotionId { get; set; }

        public int EmployeeId { get; set; }

        public int JobTitleId { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [Column(TypeName = "Date")]
        [Display(Name = "Дата продвижения")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [Column(TypeName = "money")]
        [Display(Name = "Зарплата")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:#}")] //{0:f0}
        public decimal Salary { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual JobTitle JobTitle { get; set; }
    }
}
