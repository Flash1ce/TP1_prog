using System;
using SimulationLoterie;
using Utilitaires;

namespace TP1_prog
{
    class Program
    {
        // Nombre de tirages.
        const int NB_TIRAGES = 104;

        static void Main(string[] args)
        {
            // Si le gestionnaire de Tirage est crée = True sinon = False.
            bool gestionnaireTirageExiste = false;
            // Si les mises sont valider = True sinon = False.
            bool miseValider = false;
            // Choix saisie par l'utilisateur.
            string strChoix;
            // Déclaration du gestionnaire de tirages.
            GestionnaireTirages gestionnaireTirages;
            // 
            Tirage[] vectTirage = new Tirage[NB_TIRAGES];

            do
            {
                // Affichage du menu.
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("");
                Console.WriteLine("[1] Génération de donnees");
                Console.WriteLine("[2] Résultats des tirages");
                Console.WriteLine("[3] Sommaire des résultats");
                Console.WriteLine("[4] Auteur");
                Console.WriteLine("[5] Quitter");
                Console.WriteLine("");
                Console.Write("Votre choix: ");

                // Récupération du choix de l'utilisateur.
                strChoix = Console.ReadLine();

                switch (strChoix)
                {
                    case "1":
                        Console.Clear();

                        //Création du gestionnaire de tirages
                        gestionnaireTirages = new GestionnaireTirages();

                        // Assigne la valeur true, car le gestionnaire 
                        // est maintenent crée.
                        gestionnaireTirageExiste = true;

                        for (int i = 0; i < NB_TIRAGES; i++)
                        {
                            vectTirage[i] = gestionnaireTirages.GetTirages(i);
                            // 
                            vectTirage[i].InscrireMises(
                                Aleatoire.GenererNombre(299999));

                            // Effectuer le tirage
                            vectTirage[i].Effectuer();
                            Console.WriteLine(
                                "Génération du tirage du {0}...",
                                vectTirage[i].Date.ToString("yyyy/MM/dd"));
                        }

                        Console.Write(
                            "\nAppuyez sur <Entrée> pour continuer...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();

                        // Validation si le gestionnaire est existent.
                        if (gestionnaireTirageExiste)
                        {
                            for (int i = 0; i < NB_TIRAGES; i++)
                            {
                                vectTirage[i].ValiderMises();
                                miseValider = true;
                                Console.WriteLine(vectTirage[i].ToString());
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                                "Vous devez avoir généré des données pour" +
                                " voir les résultats des tirages.");
                            Console.WriteLine();
                        }

                        Console.Write(
                            "Appuyez sur <Entrée> pour continuer...");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();

                        if (miseValider && gestionnaireTirageExiste)
                        {
                            int iNbMises = 0;
                            int iDeuxSurSixPlus = 0;
                            int iTroisSurSix = 0;
                            int iQuatreSurSix = 0;
                            int iCinqSurSix = 0;
                            int iCinqSurSixPlus = 0;
                            int iSixSurSix = 0;
                            for (int i = 0; i < NB_TIRAGES; i++)
                            {
                                iNbMises += vectTirage[i].NbMises;
                                iDeuxSurSixPlus += vectTirage[i].Resultats.GetQuantite(Indice.DeuxSurSixPlus);
                                iTroisSurSix += vectTirage[i].Resultats.GetQuantite(Indice.TroisSurSix);
                                iQuatreSurSix += vectTirage[i].Resultats.GetQuantite(Indice.QuatreSurSix);
                                iCinqSurSix += vectTirage[i].Resultats.GetQuantite(Indice.CinqSurSix);
                                iCinqSurSixPlus += vectTirage[i].Resultats.GetQuantite(Indice.CinqSurSixPlus);
                                iSixSurSix += vectTirage[i].Resultats.GetQuantite(Indice.SixSurSix);
                            }
                            Console.WriteLine("Sommaire des résultats");
                            Console.WriteLine();
                            Console.WriteLine("Nombre de mises:         {0}", iNbMises);
                            Console.WriteLine("Gagnants du 2 sur 6+:    {0}", iDeuxSurSixPlus);
                            Console.WriteLine("Gagnants du 3 sur 6:     {0}", iTroisSurSix);
                            Console.WriteLine("Gagnants du 4 sur 6:     {0}", iQuatreSurSix);
                            Console.WriteLine("Gagnants du 5 sur 6:     {0}", iCinqSurSix);
                            Console.WriteLine("Gagnants du 5 sur 6+:    {0}", iCinqSurSixPlus);
                            Console.WriteLine("Gagnants du 6 sur 6:     {0}", iSixSurSix);
                        }
                        else
                        {
                            Console.WriteLine("Vous devez avoir généré des données et validé les mises pour voir le sommaire des résultats.");
                        }

                        Console.WriteLine();
                        Console.Write(
                            "Appuyez sur <Entrée> pour retourner au menu principal...");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(
                            "Travail 1 réalisé par Antoine Bédard " +
                            "(DA: 1939379)");
                        Console.WriteLine();
                        Console.Write("Appuyez sur <Entrée> " +
                            "pour continuer...");
                        Console.ReadLine();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine();
                        Console.Write(
                            "Choix invalide. Appuyez sur <Entrée> " +
                            "pour continuer...");
                        Console.ReadLine();
                        break;
                }
            } while (strChoix != "5");
        }
    }
}
