using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique.Model
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Professeur : Membre
    {
       


      
    }

    public partial class ProfesseurValidation 
    {
        [Key(),DisplayName("Id de professeur"), Required(ErrorMessage="Il y a eu un problème lors de l'inscription du Professeur")]
        public int IDProfesseur { get; set; }
        
        [DisplayName("Texte de présentation")]
        public string presentation { get; set; }
    }
}
