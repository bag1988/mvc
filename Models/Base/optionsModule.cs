namespace mvc.Models.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class optionsModule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOption { get; set; }

        public int? idModule { get; set; }

        [StringLength(50)]
        public string nameMenu { get; set; }

        [StringLength(50)]
        public string functionMenu { get; set; }
    }
}
