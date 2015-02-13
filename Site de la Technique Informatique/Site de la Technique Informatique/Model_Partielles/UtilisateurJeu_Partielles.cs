using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Site_de_la_Technique_Informatique.Model
{
    public partial class UtilisateurJeu
    {
    }
    [MetadataType(typeof(UtilisateurJeuValidation))]
    public partial class UtilisateurJeu : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            ModelTIContainer leContext = new ModelTIContainer();
            var listeRetour = new List<ValidationResult>();
            return listeRetour;
        }
    }

}
public partial class UtilisateurJeuValidation
{
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
    public string hashMotDepasse { get; set; }
    public string pathPhotoProfil { get; set; }
    public string photoDescription { get; set; }
    public string temoignage { get; set; }
    public Nullable<System.DateTime> dateTemoignage { get; set; }
    public bool compteActif { get; set; }
}