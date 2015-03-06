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

        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            LeModelTIContainer leContext = new LeModelTIContainer();
            var listeUtilisateurs = from cl in leContext.UtilisateurSet where cl.IDUtilisateur != this.IDUtilisateur select cl;
            var listeRetour = new List<ValidationResult>();



            foreach (Membre member in listeUtilisateurs)
            {
                if (member.courriel == this.courriel)
                {
                    listeRetour.Add(new ValidationResult("Cette adresse courriel a déjà un compte associé"));
                    break;
                }

            }
            return listeRetour;
        }
      
    }

    public partial class ProfesseurValidation 
    {
        [Key(),DisplayName("Id de professeur"), Required(ErrorMessage="Il y a eu un problème lors de l'inscription du Professeur")]
        public int IDProfesseur { get; set; }
        
        [DisplayName("Texte de présentation")]
        public string presentation { get; set; }
    }
}
