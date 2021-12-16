namespace mvc.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class photo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPhoto { get; set; }

        public string namePhoto { get; set; }

        [Column(TypeName = "text")]
        public string textPhoto { get; set; }
    }
}
