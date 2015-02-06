<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformationsStage.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Stages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >


    <script type="text/javascript"></script>



   <div class="container" >
        <div class="row"  >
            <div class="col-lg-3 scrolltarget" style="margin-top: 5px;" >
                <div  style="width:285px; position: fixed; overflow:hidden;  padding:3px;">
                    <asp:Image runat="server" ID="logoCegep" ImageUrl="~/Photos/logo/Logo_InformatiqueCouleur_FondTransparent.png" Width="370" Height="208" style="margin-right:51%; margin-left:-16% ;margin-bottom:-10%;" />
                   
                        <ul class="nav nav-pills nav-stacked pills" role="tablist">
                            <li role="presentation" class="active"><a class="page-scroll" href="#aideGouvernementale">L'aide gouvernementale</a></li>
                            <li role="presentation"><a class="page-scroll" href="#engagements">Les engagements</a></li>
                            <li role="presentation"><a class="page-scroll" href="#objectifs">Objectifs</a></li>
                            <li role="presentation"><a class="page-scroll" href="#caracteristiques">Caractéristiques du stage</a></li>
                            <li role="presentation"><a class="page-scroll" href="#types">Les différents types de stages</a></li>
                            <li role="presentation"><a class="page-scroll" href="#supervision">Mécanisme de supervision de l'étudiant</a></li>
                            <li role="presentation"><a class="page-scroll" href="#formation">Formation des étudiants</a></li>
                        </ul>
                    
                </div>
            </div>
            <div class="col-lg-7 col-lg-push-1">
                <h1 style="margin-top:32px; font-size:2.8em">Informations générales sur les stages</h1>
                <hr id="aideGouvernementale" />
                <div id="contenuInfoGenerales" >
                    
                    <div  >
                        <h2 style="padding-top:20px;">L’aide gouvernementale</h2>
                        <p>
                            Vous trouverez les formulaires sur le site <a href="http://inforoutefpt.org/creditimpot/docs/depliant_2010_fr.pdf" target="_blank">crédit d'impôts pour stage en milieu de travail </a>
                            et les informations pertinentes sur le site d'<a href="http://www.investquebec.com/fr/index.aspx" target="_blank">Investissement Québec</a>.
       
                        </p>
                        <h3>Stage en milieu de travail</h3>
                        <p>
                            « De nombreuses entreprises croient aux avantages d’une collaboration entre les milieux d’enseignement et d’affaires et offrent de compléter la formation théorique des étudiants par 
            un apprentissage pratique. Afin d’encourager de telles initiatives, le régime fiscal accorde un crédit d’impôt remboursable à l’égard des étudiants qui suivent un stage au sein de 
            ces entreprises.
       
                        </p>
                        <p>
                            Sommairement, une société peut demander un crédit d’impôt remboursable de 30 % des dépenses de salaire d’un étudiant. »
                            <br/>
                            (Page 24 du document <a href="http://www.investquebec.com/documents/fr/publications/fiscaliteQC2005.pdf" target="_blank">La fiscalité au Québec 2005</a>). 
       
                        </p>

                    </div>
                    <hr id="engagements" />
                    <div  >

                        <h2 class="padding40">Les engagements</h2>
                        <div>
                            <h3>Objectifs de l'entreprise</h3>
                            <ul>
                                <li>Soumettre une « Offre de stage » à la date prévue et selon le formulaire prévu à cet effet sur notre site.</li>
                                <li>Désigner un responsable pour planifier et coordonner le projet avec le cégep. </li>
                                <li>Permettre l'accès aux services, à l'équipement, au matériel, aux logiciels et à toute autre ressource nécessaire pour permettre l'atteinte des objectifs poursuivis par le projet. </li>
                                <li>S'engager à assurer la sécurité de l'étudiant au même titre que ses salariés. </li>
                                <li>S'engager à évaluer le travail de l'étudiant à l'aide du formulaire « Grille d’évaluation » prévu à cet effet sur notre site.</li>
                            </ul>
                        </div>
                        <div>
                            <h3>Objectifs du cégep</h3>
                            <ul>
                                <li>Désigner un responsable pour planifier et coordonner le projet avec l'entreprise.</li>
                                <li>S'engager à ce que l'étudiant respecte les politiques et les règles de l'entreprise.</li>
                                <li>S'engager à souscrire à une assurance protégeant l'entreprise contre tout dommage corporel, matériel ou professionnel.</li>
                                <li>N'assumer aucune responsabilité après la période de stage.</li>
                                <li>Assumer que le travail effectué par l'étudiant demeure la propriété et la responsabilité de l'entreprise.</li>
                            </ul>
                        </div>

                    </div>
                    <hr id="objectifs"/>
                    <div  >

                        <h2 class="padding40">Objectifs</h2>
                        <p>
                            Le programme Techniques de l’informatique du Cégep de Granby Haute-Yamaska offre l'opportunité aux entreprises de la région et de l'extérieur de participer à la formation 
            d'un technicien en informatique en l'insérant dans un milieu réel de travail. Non seulement vous pourrez participer à la formation, mais vous serez également en mesure 
            d'évaluer les capacités d'un étudiant finissant en informatique dans l'accomplissement de ses tâches professionnelles. Votre implication dans le processus de formation 
            de nos techniciens est essentielle si nous voulons répondre adéquatement aux besoins toujours grandissants du marché du travail. 
       
                        </p>
                        <h3>Objectif de l’étudiant</h3>
                        <ul>
                            <li>Participer activement à la réalisation des différentes tâches inhérentes à l'emploi de technicien en informatique.</li>
                            <li>Désigner un responsable pour planifier et coordonner le projet avec le cégep.</li>
                            <li>Expérimenter et améliorer les connaissances acquises au Collège.</li>
                            <li>S'initier aux relations humaines pour une intégration au marché du travail.</li>
                            <li>Développer chez l'étudiant un sens réel des responsabilités.</li>
                        </ul>
                        <div>
                            <h3>Objectifs de l'entreprise</h3>
                            <ul>
                                <li>Participer activement à la formation et porter un jugement sur les aptitudes professionnelles d'un futur diplômé.</li>
                                <li>Permettre aux professionnels en place de se dégager de certaines tâches et responsabilités en faveur d'un étudiant.</li>
                                <li>Permettre d'avoir une meilleure évaluation d'un employé éventuel.</li>
                            </ul>
                        </div>

                    </div>
                    <hr id="caracteristiques" />
                    <div >

                        <h2 class="padding40">Caractéristiques du stage</h2>
                        <ul>
                            <li>Les étudiants impliqués dans ce stage en sont à leur dernière session d'étude.</li>
                            <li>L'évaluation du cheminement de l'étudiant dans l'entreprise est un des critères d'obtention du diplôme d'études collégiales (DEC).</li>
                            <li>Une entreprise peut soumettre plusieurs projets et accueillir plusieurs étudiants.</li>
                        </ul>

                    </div>
                    <hr id="types" />
                    <div  >

                        <h2 class="padding40">Les différents types de stages</h2>
                        <h3>Analyse, conception et modification de système</h3>
                        <p>
                            Analyse informatique, programmation, documentations de système et d’utilisateur, création de site internet.
       
                        </p>
                        <h3>Installations, maintenance et administration</h3>
                        <p>
                            Configuration d’ordinateurs, réseaux locaux (serveur, station, pont, passerelle, WWW), logiciels d’application, système d’exploitation.
       
                        </p>
                        <h3>Soutien aux utilisateurs</h3>
                        <p>Dépannage réseau et logiciel, formation.</p>

                    </div>
                    <hr id="supervision"/>
                    <div  >

                        <h2 class="padding40">Mécanisme de supervision de l’étudiant</h2>
                        <div>
                            <h3>En entreprise</h3>
                            <p>
                                Le superviseur désigné par l'entreprise est responsable de fournir l'aide technique et les ressources nécessaires à 
                l'accomplissement des tâches inhérentes à la réalisation du projet demandé.<br/>
                                Il est également responsable de l'évaluation du stagiaire. Vers le milieu du stage, il doit compléter la grille d'évaluation 
                fournie par le collège de Granby et en discuter avec l'étudiant. Cette évaluation n'est pas comptabilisée dans sa note finale. 
                Il complète la même évaluation à la fin de la période de stage et doit à nouveau en discuter avec l'étudiant. Le résultat de 
                cette dernière évaluation est comptabilisé dans sa note finale. 
           
                            </p>
                        </div>
                        <div>
                            <h3>Au cégep</h3>
                            <p>
                                Un superviseur du cégep est affecté à chaque étudiant en milieu de formation. Ce superviseur est responsable d'établir 
                le contact avec son vis-à-vis de l'entreprise pour s'assurer du bon fonctionnement de l'étudiant dans son milieu de stage.<br/>
                                De plus, le superviseur du cégep est responsable d'encadrer, de diriger et d'évaluer l'étudiant dans l'accomplissement 
                de son projet de stage. Pour ce faire, il effectue trois visites : une visite en début de stage, une visite vers le 
                milieu du stage et une dernière visite vers la fin du stage. D’autres visites peuvent être faites selon le besoin.
           
                            </p>
                        </div>

                    </div>
                    <hr id="formation"/>
                    <div  >

                        <h2 class="padding40">Formation des étudiants</h2>
                        <table class="table">
                            <tbody>
                                <tr>
                                    <th>Langages de programmation</th>
                                    <td>Java, VB.NET, C, C#</td>
                                </tr>
                                <tr>
                                    <th>Bases de données</th>
                                    <td>Modèle relationnel, modèle entité, Access, SQL, LINQ</td>
                                </tr>
                                <tr>
                                    <th>Internet</th>
                                    <td>HTML, ASP.NET, PHP, Flash, Web Expressions</td>
                                </tr>
                                <tr>
                                    <th>Systèmes d'exploitation</th>
                                    <td>Windows XP, Windows Vista, Windows 7, Linux</td>
                                </tr>
                                <tr>
                                    <th>Analyse et modélisation</th>
                                    <td>SCRUM, UML, ergonomie des interfaces</td>
                                </tr>
                                <tr>
                                    <th>Réseaux</th>
                                    <td>Windows Server 2008</td>
                                </tr>
                                <tr>
                                    <th>Logiciels de bureautique</th>
                                    <td>Word, PowerPoint, Excel, Visio</td>
                                </tr>
                            </tbody>
                        </table>

                    </div>

                </div>
            </div>
        </div>
    </div>

    <footer></footer>


    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
   
</asp:Content>
