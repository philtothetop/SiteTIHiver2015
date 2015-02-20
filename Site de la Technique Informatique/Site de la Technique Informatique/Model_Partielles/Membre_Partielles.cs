using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Site_de_la_Technique_Informatique.Model
{
    public partial class Membre
    {
    }
    [MetadataType(typeof(MembreValidation))]
    public partial class Membre : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            LeModelTIContainer leContext = new LeModelTIContainer();
            var listeRetour = new List<ValidationResult>();
            return listeRetour;
        }
    }
}
public partial class MembreValidation
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
    [DisplayName("Mot de passe"),Required(ErrorMessage = "Un mot de passe est requis.")]
    [StringLengthRange(Minimum = 4, ErrorMessage = "Le mot de passe doit avoir au minimu 4 caractères.")]
    public string hashMotDePasse { get; set; }
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