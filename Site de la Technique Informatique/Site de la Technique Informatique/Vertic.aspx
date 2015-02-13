<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vertic.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Classes.WebForm1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/scrolling-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Custom CSS -->

    <!-- Content Row -->
    <div class="row" style="margin-top: 50px;">
        <!-- Sidebar Column -->
        <div class="col-lg-3 scrolltarget">
            <div class="list-group" style="position: fixed; margin-left: 100px;">
                <ul class="nav nav-pills nav-stacked pills" role="tablist">

                    <li role="presentation" class="active"><a href="#projet" class="list-group-item page-scroll">Projet VerTIC</a></li>
                    <li role="presentation"><a href="#portable" class="list-group-item page-scroll">Le portable VerTIC</a></li>
                    <li role="presentation"><a href="#logiciel" class="list-group-item page-scroll">Les logiciels</a></li>

                </ul>
            </div>
        </div>
        <div class="col-lg-6">
            <!-- Content Column -->

            <!-- Projet Section -->
            <section id="projet" class="projet-section">
                <div class="row">
                    <div class="col-lg-12">
                        <h3>Des études en ligne avec VerTIC</h3>

                        <p>Un projet pédagogique et environnemental impliquant l'utilisation d'ordinateurs portatifs a été mis en place à l'automne 2007 en Techniques de l’informatique du Cégep de Granby. Les objectifs sont les suivants:</p>

                        <blockquote>Permettre à l'étudiant d'avoir constamment à portée de la main tous les outils pédagogiques nécessaires pour la réalisation des activités relatives à l'ensemble de ses cours;</blockquote>

                        <blockquote>Éliminer autant que possible l'utilisation du papier pour la réalisation des différentes activités pédagogiques.</blockquote>

                        <p><span class="greenText">"VerTIC"</span>, c’est à la fois la technologie et l'environnement. En fait, il s'agit d'une référence à l'utilisation des TIC (Technologie de l'information et des communications) intégrée à l'enseignement de l'ensemble des membres du département d'informatique. Cette pratique pédagogique amènera à éliminer presque à 100% l'utilisation du papier dans les cours, d'où le souci environnemental et l'appellation <span class="greenText">"VerTIC"</span>.</p>

                        <p>Pour arriver à nos fins, tous les enseignants s'engagent à mettre à la disposition des étudiants, via Internet, l'ensemble de la documentation nécessaire à la réalisation des cours c'est-à-dire plans de formation, notes de cours, exercices, travaux et possiblement les examens. Chaque enseignant possède son propre site Web et les étudiants auront accès aux pages Web contenant les documents de chacun de leurs cours. Pour atteindre nos objectifs, il sera essentiel que les étudiants soient munis d'un ordinateur portatif avec l'accès réseau sans fils. Les modèles proposés garantissent que toutes les activités pédagogiques reliées aux cours du programme seront réalisables.  Cette solution permettra aux étudiants d'avoir accès à leur environnement de travail autant au Cégep qu'à la maison. De notre département et de presque partout sur le cégep, vous pourrez vous brancher au réseau Internet par le biais d'un réseau sans fil et réseaux avec fils.</p>

                        <p>Département d’informatique du Cégep de Granby</p>
                    </div>
                </div>
            </section>

            <!-- About Section -->
            <section id="portable" class="portable-section">
                <div class="row">
                    <div class="col-lg-12">

                        <h3>Caractéristiques du portable VerTIC</h3>

                        <p>La sélection du portatif pour notre programme d'études s'effectue avec des critères concrets. Ce qui est le plus important pour nous demeure la performance du portatif et celui-ci saura bien tenir la route pendant le séjour de l'étudiant au département. Ces choix s'effectuent en fonction des applications qui sont utilisées dans le programme d'informatique.</p>

                        <p>Le département d'informatique du Cégep de Granby propose aux étudiants de faire partie d'un programme d'achats regroupés de portables de la compagnie DELL. La famille de portables proposée répond aux besoins et aux caractéristiques exigées par le département d’informatique du Cégep de Granby, les étudiants devront acheter un portable choisi parmi cette famille de portables.</p>

                        <p>Cette nouvelle façon de faire permettra de s’assurer de la qualité du portable et de la compatibilité avec les différents cours. Vous serez conviés à une rencontre d’information en avril prochain en soirée.</p>

                        <p><b>Pour les étudiants</b> qui ne désirent pas faire partie des achats regroupés, vous devrez avoir un portable performant ayant des caractéristiques similaires. De plus, nous suggérons l’achat d’une garantie de 3 ans, durée minimale de notre programme et l'achat du sac de transport. Il est également important d’acquérir quelques accessoires :</p>

                        <div class="row">

                            <b>Caractéristiques</b>

                          <asp:TextBox ID="txtCaractPortatif" runat="server" Text="  Processeur : Intel Core I7... 2,85GHz ou comparable
  Mémoire vive : 8Go (idéalement extensible 16Go)
  Disque dur : 500Go (min.)
  Carte graphique : permettant le multimédia
  Batterie : 6 ou 9 cellules

  Avec Windows 8 français, idéalement Win 8.1 PRO français"                
                             TextMode="MultiLine" Height="150px" Width="500px" Enabled="False">

                          </asp:TextBox>

                        </div>

                        <br />
                        <br />
                            <b>AUTRES:</b>
                        <br />


                        <asp:TextBox ID="txtAutres" runat="server" Text="" TextMode="MultiLine" Height="150px" Width="500px" Enabled="False">

                          </asp:TextBox>

                    </div>
                </div>
                </div>
            </section>

            <!-- Services Section -->
            <section id="echeancier" class="echeancier-section">
                <div class="row">
                    <div class="col-lg-12">

                        <h3>Les dates à retenir</h3>

                        <p>Il est important que vous portiez une attention spéciale à la présente section. Les dates qui y sont inscrites vous permettront de prendre les actions nécessaires pour faire l’acquisition de votre portatif VerTIC.</p>
                        <div class="col-lg-12">
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Évènement</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Mercredi 4 février 2015 de 18h à 20h</td>
                                        <td>Portes ouvertes du Cégep de Granby</td>
                                    </tr>
                                    <tr>
                                        <td>Avril 2015</td>
                                        <td>Envoi postal du dépliant d'information VerTIC aux étudiants admis pour la session d’automne 2015</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p><b>Avril 2015</b> de 18h30 à 20h (date à déterminer)</p>
                                            <p>Local A-307</p>
                                            <p>Rencontre d'informations avec les parents, les étudiants admis et le représentant de la compagnie Dell (pour les achats regroupés de portables)</p>
                                        </td>
                                        <td>
                                            <p>Information sur le programme, les cours, le marché de l'emploi.</p>

                                            <p>Rencontre avec le représentant Dell. Proposition d'achats regroupés de portables pour les étudiants</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p><b>Août 2015 19h</b> (un courriel sera envoyé à chaque étudiant)</p>
                                            <p>Livraison du portable... entente faite avec la compagnie Dell et son représentant Anthony Blais</p>
                                        </td>
                                        <td>
                                            <p>Pour les achats regroupés, livraison du portable par le représentant Dell</p>

                                            <p>Pour les autres étudiants, date limite à laquelle vous devez posséder votre portable VerTIC afin de s'assurer de l'avoir en main pour le VerTICamp et pour la première journée de cours</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p><b>21 Août 2015 de 9h à 12h au A307</b></p>
                                            <p>(vendredi précédant le début des cours)</p>
                                            <p>Le matériel nécessaire: votre portable, câble réseau, carte étudiante</p>
                                            <p><b>ACTIVITÉ OBLIGATOIRE POUR TOUS</b></p>
                                        </td>
                                        <td>VerTICamp
                                            Accueil, configuration, installation et activité de formation.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                </section>

            <!-- Logiciel Section -->
            <section id="logiciel" class="logiciel-section">
                <div class="row">
                    <div class="col-lg-12">
                        <h3>Configuration logicielle</h3>
                        <p>Nous vous suggérons de partitionner votre disque dur en deux parties au départ. Vous retrouverez une partition d'applications et une partition personnelle pour vos données. De plus, lors du cours «Gérer un poste de travail», vous allez créer une image de votre poste de travail sur votre disque externe, vous permettant de reconstruire votre environnement logiciel si un problème majeur survenait. Nous avons créé un DVD d'installation muni de logiciels libres (gratuits) et de certains logiciels avec licence, qui vous seront fournis gratuitement (via une entente entre le Cégep de Granby et Microsoft). Évidemment, votre portatif vous appartient et vous serez libre de le modifier comme vous l'entendez. De notre côté, nous nous engageons à vous fournir les DVD des images et des applications pour remettre votre portatif à son état initial en cas de pépins. Voici la liste des logiciels qui seront installés sur votre portatif lors du VerTICamp : </p>
                    <div class="col-lg-6">
                        <h4>LOGICIELS AVEC LICENCES</h4>
                        <asp:TextBox ID="txtLogicielLicenses" runat="server" Text="" TextMode="MultiLine" style="max-height:150px;min-height:150px;max-width:350px;min-width:350px;" Enabled="False">

                          </asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <h4>LOGICIELS LIBRES (gratuits)</h4>
                        <asp:TextBox ID="txtLogicielLibres" style="max-height:150px;min-height:150px;max-width:350px;min-width:350px;" runat="server" Text="" TextMode="MultiLine" Enabled="False">

                          </asp:TextBox>
                    </div>
                        <p>Les logiciels avec licences, sauf exception, vous appartiennent. Il se peut, en cours d'utilisation, que nous ayons besoin de nouveaux logiciels.  Le département d'informatique tentera toujours d'utiliser des outils logiciels qui pourront être offerts gratuitement à ses étudiants. Cependant, rien n'est garanti. Vous comprendrez que si un nouvel outil devient le standard demain et qu'il nous est impossible de négocier une entente, des frais d'utilisation pourraient être ajoutés.</p>

                    </div>
                </div>
            </section>
        </div>
    </div>

    <!-- jQuery -->

    <!-- Bootstrap Core JavaScript -->


</asp:Content>



