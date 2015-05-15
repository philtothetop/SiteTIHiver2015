// Cette classe permet à un administrateur ET aux professeurs de pouvoir consulté les logs du site web.
// Écrit par Raphael Broard, Février 2015
// Intrants: Vide
// Extrants: Vide


//Valeur pour le type des logs
//0 = Normal
//1 = Erreur
//2 = Warning
//3 = Inscription
//4 = Banni


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Log : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(true, true, false, false, false);
        }

        //Méthode pour récupérer les logs de la BD
        public IQueryable<Model.Log> GetLesLogs()
        {
            //Créer une liste de base
            List<Model.Log> listeDesLogs = new List<Model.Log>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    int typeLogAChercher = 9000;

                    //Rechercher le hiddenfield pour savoir si veux chercher que un type de log
                    if (hfieldTrierType.Value != null && !hfieldTrierType.Value.Equals(""))
                    {
                        //Try catch de mesure de précaution mais devrais JAMAIS arriver, mais quand même afficher les logs si cela arrive
                        try
                        {
                            typeLogAChercher = Convert.ToInt16(hfieldTrierType.Value);
                        }
                        catch
                        {
                            typeLogAChercher = 9000;
                        }
                    }

                    //9000 c'est valeur de base, donc va tout rechercher
                    if (typeLogAChercher == 9000)
                    {
                        //Récupérer les logs dans la BD
                        listeDesLogs = (from cl in modelTI.LogSet
                                        select cl).ToList();
                    }
                    //Pour rechercher que un type de log
                    else
                    {
                        //Récupérer les logs dans la BD
                        listeDesLogs = (from cl in modelTI.LogSet
                                        where cl.typeLog == typeLogAChercher
                                        select cl).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //Si Erreur, retourner une liste avec un log qui indique erreur
                Model.Log logErreur = new Model.Log();
                logErreur.actionLog = "Erreur l'Hors du chargement des logs";
                logErreur.dateLog = DateTime.Now;
                logErreur.IDLog = 1;
                logErreur.typeLog = 1;
                logErreur.UtilisateurIDUtilisateur = 0;

                listeDesLogs.Add(logErreur);

                LogErreur("Log.aspx.cs dans la méthode GetLesLogs", ex);
            }

            //Mettre dataPager visible ou non si Plus que le minimum affiché
            if (listeDesLogs.Count <= dataPagerDesLogs.PageSize)
            {
                dataPagerDesLogs.Visible = false;
            }
            else
            {
                dataPagerDesLogs.Visible = true;
            }

            return listeDesLogs.AsQueryable().SortBy("dateLog").Reverse();
        }

        //Pour changer la valeur du hfield utiliser pour rechercher que un type de log
        protected void ChercherUnTypeDeLog(object sender, EventArgs e)
        {
            String argument = Convert.ToString(((Button)sender).CommandArgument);
            hfieldTrierType.Value = argument;
            lviewLogs.DataBind();
        }

        //Pour mettre le no compte a 0 si il est vide
        public int LeIdDuCompte(Model.Log leLog)
        {
            if (leLog.UtilisateurIDUtilisateur != null)
            {
                return Convert.ToInt16(leLog.UtilisateurIDUtilisateur);
            }
            else
            {
                return 0;
            }
        }

        //Mettre le lien au compte enable ou pas si c'est fait par le server ou pas
        public bool SavoirSiLienEnable(Model.Log leLog)
        {
            if (leLog.UtilisateurIDUtilisateur != null)
            {
                if (leLog.UtilisateurIDUtilisateur != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Pour donner le bon CSS au lien, sans de hover + noir, si pas actif 
        public string SavoirCSSPourLien(Model.Log leLog)
        {
            if (leLog.UtilisateurIDUtilisateur != null)
            {
                if (leLog.UtilisateurIDUtilisateur != 0)
                {
                    return "";
                }
                else
                {
                    return "lienNonEnable";
                }
            }
            else
            {
                return "lienNonEnable";
            }
        }

        //Fonction pour mettre le bon CSS pour chaque type de log
        public string GetCSSForTypeLog(int typeLog)
        {
            if (typeLog == 0)
            {
                return "ErreurTypeZero";
            }
            else if (typeLog == 1)
            {
                return "ErreurTypeUn";
            }
            else if (typeLog == 2)
            {
                return "ErreurTypeDeux";
            }
            else if (typeLog == 3)
            {
                return "ErreurTypeTrois";
            }
            else if (typeLog == 4)
            {
                return "ErreurTypeQuatre";
            }
            //Si numéro pas encore répertorier, mettre le normal
            else
            {
                return "ErreurTypeZero";
            }
        }

        protected void lnkNoCompte_Click(object sender, EventArgs e)
        {
            String argument = Convert.ToString(((LinkButton)sender).CommandArgument);

            //Si id pas null
            if (argument != null)
            {
                //Si id n'est pas administrateur
                if (!argument.Equals("0"))
                {
                    using (LeModelTIContainer modelTI = new LeModelTIContainer())
                    {
                        int id = Convert.ToInt32(argument);

                        Utilisateur trouverUtilisateur = new Utilisateur();
                        trouverUtilisateur = null;
                        trouverUtilisateur = (from cl in modelTI.UtilisateurSet
                                              where cl.IDUtilisateur == id
                                              select cl).FirstOrDefault();

                        //Si utilisateur est trouvé
                        if (trouverUtilisateur != null)
                        { 
                            //Si est un prof
                            if (trouverUtilisateur is Professeur)
                            {
                                if (isLocal())
                                {
                                    Response.Redirect("~/ProfilProfesseur.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                                else
                                {
                                    Response.Redirect("~/../ProfilProfesseur.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                            }
                            //Si étudian
                            else if (trouverUtilisateur is Etudiant)
                            {
                                if (isLocal())
                                {
                                    Response.Redirect("~/ProfilEtudiant.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                                else
                                {
                                    Response.Redirect("~/../ProfilEtudiant.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}