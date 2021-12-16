namespace mvc.Models.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
        
    public partial class optionsBlock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOptionsBlock { get; set; }

        public int? idproperty { get; set; }

        public int? idModule { get; set; }

        [StringLength(255)]
        public string nameOptions { get; set; }

        [DataType(DataType.MultilineText)]
        public string valueOptions { get; set; }

        [DataType(DataType.MultilineText)]
        public string dopOptions { get; set; }
    }
}
