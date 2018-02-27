using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.DbLayer
{

    [MetadataType(typeof(JobTitleMetedata))]
    public partial class JobTitle
    {
    }

    public class JobTitleMetedata
    {
        [Required(ErrorMessage = "Поле должно должно быть заполнено")]
        [Display(Name = "Наименование должности")]
        public string NameJobTitle { get; set; }
    }
}
