namespace mvc.Models.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class article
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idArticle { get; set; }

        [Column(TypeName = "text")]
        public string nameArticle { get; set; }

        public DateTime? dateArticle { get; set; }

        [Column(TypeName = "text")]
        public string textArticle { get; set; }

        [Column(TypeName = "text")]
        public string shortArticle { get; set; }

        [Column(TypeName = "text")]
        public string keyword { get; set; }
    }
}
