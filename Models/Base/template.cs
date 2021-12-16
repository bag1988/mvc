namespace mvc.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class template
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTemplate { get; set; }

        [StringLength(50)]
        public string nameTemplate { get; set; }
    }
}
