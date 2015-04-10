using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Site_de_la_Technique_Informatique.Model
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

 

    [MetadataType(typeof(ProfesseurValidation))]
    public partial class Professeur : IValidatableObject
    {

        
 public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            LeModelTIContainer leContext = new LeModelTIContainer();
            var listeRetour = new List<ValidationResult>();

            List<Utilisateur> listeUtilisateurs = (from cl in leContext.UtilisateurSet where cl.IDUtilisateur != this.IDUtilisateur select cl).ToList();
            



            foreach (Utilisateur member in listeUtilisateurs)
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

        [DisplayName("Texte de présentation"), StringLengthRange(Maximum = 2000, ErrorMessage = "Le texte de présentation ne doit pas dépasser 2000 caractères.")]
        public string presentation { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Un nom est requis.")]
        [StringLength(64, ErrorMessage = "Le nom doit avoir moins de 64 caractères.")]
        public string nom { get; set; }
        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Un prénom est requis.")]
        [StringLength(64, ErrorMessage = "Le prénom doit avoir moins de 64 caractères.")]
        public string prenom { get; set; }
        [DisplayName("Courriel"), Required(ErrorMessage = "Le courriel est requis.")]
        [RegularExpression("^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\\.[a-zA-Z]{2,4}", ErrorMessage = "Le courriel doit être valide.")]
        [StringLength(64, ErrorMessage = "Le courriel doit avoir moins de 64 caractères.")]
        public string courriel { get; set; }
        [DisplayName("Mot de passe"), Required(ErrorMessage = "Un mot de passe est requis.")]
        [StringLengthRange(Minimum = 4, ErrorMessage = "Le mot de passe doit avoir au minimu 4 caractères.")]
        public string hashMotDePasse { get; set; }

        [DisplayName("Description de la photo")]
        [StringLengthRange(Maximum = 500, ErrorMessage = "La description de la photo ne peut pas avoir plus de 500 caractères.")]
        public string photoDescription { get; set; }
    }

    public class StringLengthRangeAttribute : ValidationAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public StringLengthRangeAttribute()
        {
            this.Minimum = 0;
            this.Maximum = int.MaxValue;
        }
        public override bool IsValid(object value)
        {

            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                int len = strValue.Length;
                return len >= this.Minimum && len <= this.Maximum;
            }
            return true;
        }
    }
}
