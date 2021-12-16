namespace mvc.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class savingModule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? idModule { get; set; }

        [StringLength(255)]
        public string nameMarker { get; set; }
    }
}
