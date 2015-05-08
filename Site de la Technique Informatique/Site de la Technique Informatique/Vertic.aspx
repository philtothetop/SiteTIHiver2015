<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vertic.aspx.cs" Inherits="Site_de_la_Technique_Informatique.Vertic" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="~­/Css/scrolling-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Custom CSS -->

    <!-- Content Row -->
    <div class="row" style="margin-top: 50px;">
        <!-- Sidebar Column -->
        <div class="col-lg-3 scrolltarget" style="margin-left: 150px;">
            <div style="width: 285px; position: fixed; overflow: hidden; padding: 3px;">
                <asp:Image runat="server" ID="logoCegep" ImageUrl="~/Photos/logo/Logo_InformatiqueCouleur_FondTransparent.png" Width="370" Height="208" Style="margin-right: 51%; margin-left: -16%; margin-bottom: -10%;" />

                <ul class="nav nav-pills nav-stacked pills" role="tablist">
                    <li role="presentation" class="active"><a href="#projet" class="list-group-item page-scroll">Projet VerTIC</a></li>
                    <li role="presentation"><a href="#portable" class="page-scroll">Le portable VerTIC</a></li>
                    <li role="presentation"><a href="#echeancier" class="page-scroll">Échéancier</a></li>
                    <li role="presentation"><a href="#logiciel" class="page-scroll">Les logiciels</a></li>
                    <li role="presentation"><a href="#garantie" class="page-scroll">Garantie et assurance</a></li>
                    <li role="presentation"><a href="#financement" class="page-scroll">Financement</a></li>
                    <li role="presentation"><a href="#accueil" class="page-scroll">Accueil et VerTICamp</a></li>
                </ul>

            </div>
        </div>
        <div class="col-lg-6">
            <!-- Content Column -->

            <!-- Projet Section -->
            <section id="projet" class="projet-section">
                <div class="row">
                 <h1 style="margin-top:32px; font-size:2.8em">Informations générales sur VERTIC</h1>
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


                        <b>Caractéristiques</b>
                        <br />
                        <div class="row">
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtCaractPortatif" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 599px; min-width: 500px;" Enabled="False">

                          </asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                            </div>

                        </div>

                        <br />
                        <br />
                        <b>AUTRES:</b>
                        <br />


                        <asp:TextBox ID="txtAutres" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 599px; min-width: 500px;" Enabled="False">

                          </asp:TextBox>
                    </div>
                </div>
            </section>



            <section id="echeancier" class="echeancier-section">
                <div>
                    <div>
                        <h3>Les dates à retenir</h3>

                        <p>Il est important que vous portiez une attention spéciale à la présente section. Les dates qui y sont inscrites vous permettront de prendre les actions nécessaires pour faire l’acquisition de votre portatif VerTIC.</p>

                    </div>
                    <asp:ListView ID="lviewEcheancier" runat="server" ItemType="Site_de_la_Technique_Informatique.Model.DateEvenementVerTIC" SelectMethod="lvEcheancier_GetData">
                        <LayoutTemplate>
                            <div style="background-color: #eee; border-bottom: 1px solid black; border-radius: 3px; min-height: 50px;">
                                <div class="col-lg-8">
                                    <h4>Événement</h4>
                                </div>
                                <div id="topDate" class="col-lg-4" style="">
                                    <h4>Date</h4>
                                </div>

                            </div>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div style="min-height: 50px; height: auto; position: relative;">

                                <div class="col-lg-4" style="min-height: 50px; height: 100%; padding-top: 10px; padding-bottom: 10px; float: right; position: inherit">
                                    <asp:Label ID="lblDateEvent" runat="server" Text='<%#BindItem.dateDescription %>' />
                                </div>
                                <div style="float: right; border-right: 1px solid black; margin: auto; padding-top: 10px; min-height: 50px; width: 63%;">
                                    <asp:Label ID="lblDescEvent" runat="server" Text='<%#BindItem.evenement %>' Style="word-wrap: break-word; height: auto" />
                                </div>

                            </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div style="background-color: #eee; height: 50px; border-radius: 3px;">

                                <div class="col-lg-4" style="padding-top: 10px; min-height: 50px; height: auto; padding-bottom: 10px; float: right;">
                                    <asp:Label ID="lblDateEvent" runat="server" Text='<%#BindItem.dateDescription %>' />
                                </div>
                                <div style="border-right: 1px solid black; margin: auto; padding-top: 10px; float: right; width: 63%; min-height: 50px;">

                                    <asp:Label ID="lblDescEvent" runat="server" Text='<%#BindItem.evenement %>' />
                                </div>


                            </div>
                        </AlternatingItemTemplate>

                    </asp:ListView>
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
                            <asp:TextBox ID="txtLogicielLicenses" runat="server" Text="" TextMode="MultiLine" Style="max-height: 150px; min-height: 150px; max-width: 350px; min-width: 350px;" Enabled="False">

                          </asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <h4>LOGICIELS LIBRES (gratuits)</h4>
                            <asp:TextBox ID="txtLogicielLibres" Style="max-height: 150px; min-height: 150px; max-width: 350px; min-width: 350px;" runat="server" Text="" TextMode="MultiLine" Enabled="False">

                          </asp:TextBox>
                        </div>
                        <p>Les logiciels avec licences, sauf exception, vous appartiennent. Il se peut, en cours d'utilisation, que nous ayons besoin de nouveaux logiciels.  Le département d'informatique tentera toujours d'utiliser des outils logiciels qui pourront être offerts gratuitement à ses étudiants. Cependant, rien n'est garanti. Vous comprendrez que si un nouvel outil devient le standard demain et qu'il nous est impossible de négocier une entente, des frais d'utilisation pourraient être ajoutés.</p>

                    </div>
                </div>
            </section>

            <section id="garantie" class="garantie-section">
                <div class="row">
                    <div class="col-lg-12">
                        <h3>Garantie et assurance</h3>

                        <p>À la base, votre portatif VerTIC est couvert par une garantie d'un an sur les pièces et la main-d'œuvre. La garantie couvre les bris associés à une mauvaise conception ou à un défaut de fabrication de l'appareil. Elle ne couvre pas les bris causés par un usage abusif. Tel que mentionné, le service s'effectue chez votre fournisseur. La période de réparation devrait se compter entre une à deux semaines. Advenant un pépin, vous aurez accès à un ordinateur portable de remplacement offert par le Cégep de Granby.</p>

                        <p>Au niveau des assurances, il est très important de vérifier les modalités de votre police, ou celle de vos parents le cas échéant, pour savoir si votre futur portatif VerTIC sera couvert contre le vol et les accidents. Bien souvent, un ordinateur portatif sera considéré comme un ordinateur de maison, mais il se peut que le contraire se produise également. Un simple coup de téléphone à votre courtier vous donnera l'heure juste à ce sujet. Une bonne police d'assurances pourrait vous sauver d'une lourde dépense si, par exemple, vous échappiez votre portatif sur le sol fissurant ainsi l'écran, ou encore, si votre voisin échappait son café sur votre clavier causant des courts-circuits dans votre portatif.</p>
                    </div>
                </div>
            </section>

            <section id="financement" class="financement-section">
                <div class="row">
                    <div class="col-lg-12">
                        <h3>Financement</h3>
                        <p>Il y a plusieurs façons de financer un portatif VerTIC</p>
                        <ul>
                            <li>
                                <b>Programme de Prêt pour l'achat de matériel informatique du  ministère de l'Éducation (MEQ)</b>
                            </li>
                            <li>
                                <b>Marge de crédit Avantage étudiant du Mouvement Desjardins</b>
                            </li>
                            <li>
                                <b>Financement Accord D du Mouvement Desjardins et de Visa Desjardins</b>
                            </li>
                        </ul>
                        <br />
                        <br />
                        <p>Évidemment, vous avez le choix de payer la totalité de la facture sur livraison de l'ordinateur par vos propres moyens ou par le biais d'un prêt négocié ailleurs. Vous avez le choix de rembourser les intérêts ou, le capital plus les intérêts, pendant vos études. Nous vous suggérons cette dernière solution si vous en avez la capacité.</p>
                        <br />
                        <p>Voici un tableau qui résume ces offres.</p>
                        <div class="col-lg-offset-1 col-lg-10 col-lg-offset-1">
                            <table id="tableFinancement" style="border: solid 1px;">
                                <tr style="text-align: center">
                                    <td></td>
                                    <td style="width: 30%">Programme Achat informatique du MEQ
                                </td>
                                    <td style="width: 30%">Marge de crédit Avantage étudiant Desjardins
                                </td>
                                    <td style="width: 30%">Financement Accord D Desjardins
                                </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">Éligibilité</td>
                                    <td style="width: 30%">Être éligible aux prêts et bourses selon les critères du MEQ pour l'année d'attribution concernée.

                                    Vous n'avez jamais bénéficié d'une aide accordée par l'Aide financière aux études pour l'achat d'un micro-ordinateur ou de matériel informatique.</td>
                                    <td style="width: 30%">Selon le dossier financier de l'étudiant ou à l'aide d'un cosignataire, être citoyen canadien et être inscrit au programme d'informatique</td>
                                    <td style="width: 30%">Selon le dossier financier de l'étudiant ou à l'aide d'un cosignataire, être citoyen canadien et être inscrit au programme d'informatique</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">Plafond de prêt</td>
                                    <td style="width: 30%">3 000 $</td>
                                    <td style="width: 30%">6 000 $</td>
                                    <td style="width: 30%">5 000 $</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">Temps de traitement</td>
                                    <td style="width: 30%">Entre 4 et 6 semaines</td>
                                    <td style="width: 30%">1-2 jours</td>
                                    <td style="width: 30%">1-2 jours</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">Modalités</td>
                                    <td style="width: 30%">Taux variable : 1% de plus que le taux préférentiel
                                    Taux révisé annuellement</td>
                                    <td style="width: 30%">Taux variable = taux de base personnel + 0,5%
                                    Taux révisé aux trois mois</td>
                                    <td style="width: 30%">Taux fixe de 8,9% sur un terme de 36 mois</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">Remboursement</td>
                                    <td style="width: 30%">Vous n'avez pas à payer d'intérêts sur le montant du prêt supplémentaire pendant toute la durée de vos études à temps plein.

                                Remboursement du prêt 6 mois après avoir quitté les études et les intérêts seront à votre charge le mois suivant la fin de vos études.</td>
                                    <td style="width: 30%">Intérêts ou capital+intérêts payés mensuellement

                                Capital 6 mois après avoir quitté les études ou sur une base mensuelle pendant les études</td>
                                    <td style="width: 30%">Intérêts et capital remboursés sur une base mensuelle</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">Demande</td>
                                    <td style="width: 30%">Impression du formulaire 2017 sur le site AFE du MEQ

                                    Retourner le formulaire au MEQ

                                    Dans l'affirmatif, le prêt est déposé directement dans votre compte bancaire.</td>
                                    <td style="width: 30%">Doit remplir le formulaire électronique du site Web Desjardins (adresse plus bas) OU

                                    Faire une demande par le 1-800-CAISSES OU

                                    Se présenter à une caisse populaire locale</td>
                                    <td style="width: 30%">Se présenter à une caisse populaire locale</td>
                                </tr>
                            </table>
                            <br />
                            <ul>
                                <li>
                                    <b>Aide financière aux études du MEQ</b>
                                    <br />
                                    <a href="http://www.afe.gouv.qc.ca/">www.afe.gouv.qc.ca</a>
                                    <br />
                                    <a href="http://www.afe.gouv.qc.ca/renseigner/autresProgrammes/pretAchatMaterielInformatique.asp">www.afe.gouv.qc.ca/renseigner/autresProgrammes/pretAchatMaterielInformatique</a>
                                </li>
                                <li>
                                    <b>Portail Génération 18-24 du Mouvement Desjardins (Avantage D)</b>
                                    <br />
                                    <a href="http://www.desjardins.com/fr/particuliers/clienteles/generation_1824">www.desjardins.com/fr/particuliers/clienteles/generation_1824</a>

                                </li>
                            </ul>
                            <br />
                        </div>
                    </div>
                </div>

            </section>

            <section id="accueil" class="accueil-section">
                <div id="row">
                    <h3>Accueil et VerTICamp</h3>

                    <p>La journée d'accueil et le VerTICamp sont jumelés pour ne faire qu'une seule activité. Lors de l'accueil, tous les membres du département seront présents et une brève explication de votre programme d'études vous sera également faite.</p>

                    <p>En un deuxième temps, la portion VerTICamp se mettra en marche. Ce camp vous permettra de comprendre votre portatif, l'environnement réseau ainsi que les principales applications pour débuter votre programme. À cette occasion, vous procéderez à l'installation et à la configuration de la partie logicielle de votre portatif à l'aide des procéduriers, un DVD vous sera fourni.</p>

                    <p>Finalement, un léger goûter sera servi, vous pourrez donc prendre quelques pauses entre les installations et faire connaissance avec vos collègues.</p>

                    <h4>Le VerTICamp (Activité obligatoire)</h4>

                    <p><b>21 AOÛT 2015, soit le vendredi précédant le début des cours</b></p>

                    <p><b>Local : A-307 de 9H à 12H</b></p>

                    <ul>
                        <li>Accueil</li>
                        <li>Présentation des professeurs et des techniciens</li>
                        <li>Installation et configuration du portable</li>
                        <li>Pause : léger goûter accessible tout au long du camp</li>
                    </ul>

                    <p>Notez que les informations offertes lors du VerTICamp sont difficilement remplaçables par de la documentation papier. Il y va de votre meilleur intérêt d'y assister. Des renseignements supplémentaires sur cette journée, incluant l'horaire et le programme complet des activités, seront publiés sur le site Web vers le début du mois d'août. Nous vous demandons de faire l'impossible pour vous présenter au «VerTICamp». L'information qui y est véhiculée vous évitera de nombreux tracas. Nous vous demandons de nous prévenir si vous prévoyez être absent pour des raisons jugées exceptionnelles. Vous pouvez nous rejoindre par téléphone ou par courriel : </p>

                    <p>
                        Courriel: MDesAulniers
               
                        <br />
                        Téléphone: (450) 372-6614 poste 1164
                    </p>
                </div>
            </section>

        </div>
    </div>


    <!-- jQuery -->

    <!-- Bootstrap Core JavaScript -->
</asp:Content>



