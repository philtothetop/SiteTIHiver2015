using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Site_de_la_Technique_Informatique.Model
{/*
    public partial class UtilisateurJeu_Etudiant
    {
    }*/
    /*
    [MetadataType(typeof(UtilisateurJeu_EtudiantValidation))]
    public partial class UtilisateurJeu_Etudiant : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            ModelTIContainer leContext = new ModelTIContainer();
            var listeRetour = new List<ValidationResult>();
            return listeRetour;
        }
    }*/
}
public partial class UtilisateurJeu_EtudiantValidation
{
    [DisplayName("Date de naissance"), Required(ErrorMessage = "La date de naissance du membre est requis.")]
    [dateNassianceValidation(ErrorMessage = "La date n'est pas valide.")]
    public System.DateTime dateNaissance { get; set; }
    public System.DateTime dateInscription { get; set; }
    public bool valideTemoignage { get; set; }
    public bool valideCourriel { get; set; }
    public int IDUtilisateur { get; set; }
    public string pathCV { get; set; }
    
}
public class dateNassianceValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime dtNaissance = Convert.ToDateTime(value);
        DateTime dtVide = new DateTime();

        if (dtNaissance == dtVide)
        {
            return false;
        }
        return true;
    }
}