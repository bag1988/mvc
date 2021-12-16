namespace mvc.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public partial class photoImg
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPhotoImg { get; set; }

        public int? idPhoto { get; set; }

        public string urlImg { get; set; }

        public string urlSmall { get; set; }

        [Column(TypeName = "text")]
        public string textImg { get; set; }
    }
}
