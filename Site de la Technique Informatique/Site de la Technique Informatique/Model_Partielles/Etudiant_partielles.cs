using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Site_de_la_Technique_Informatique.Model
{
    public partial class Etudiant
    {
    }
    [MetadataType(typeof(EtudiantValidation))]
    public partial class Etudiant : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            LeModelTIContainer leContext = new LeModelTIContainer();
            var listeRetour = new List<ValidationResult>();
            return listeRetour;
        }
    }
}
public partial class EtudiantValidation
{
    [DisplayName("Date de naissance"), Required(ErrorMessage = "La date de naissance du membre est requis.")]
    [dateNassianceValidation(ErrorMessage = "La date de naissance n'est pas valide.")]
    public System.DateTime dateNaissance { get; set; }

}
// Cette classe permet de comparer la date de naissance avec une date vide
// Écrit par Cédric Archambault, 16 février 2015
// Intrants: Date de naissance
// Extrants: vrai ou faux
public class dateNassianceValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime dtNaissance = Convert.ToDateTime(value);
        DateTime dtVide = new DateTime();

        if (dtNaissance == dtVide || dtNaissance>=DateTime.Now)
        {
            return false;
        }
        return true;
    }
}
