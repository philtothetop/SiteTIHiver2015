//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Site_de_la_Technique_Informatique.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FAQ
    {
        public int IDFAQ { get; set; }
        public string texteQuestion { get; set; }
        public string texteReponse { get; set; }
        public int ProfesseurIDUtilisateur { get; set; }
    
        public virtual Professeur Professeur { get; set; }
    }
}