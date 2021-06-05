/******************************************************************************
 * Classe:      Tirage
 * 
 * Fichier:     tirage.cs
 * 
 * Auteur:      Antoine Bédard
 * 
 * But:         Cette classe sert à représenter un tirage à une date donnée.
 * 
 * Remarque:    
 *              
 * ***************************************************************************/
using System;
using Utilitaires;

namespace SimulationLoterie
{
    /// <summary>
    /// Cette classe sert à représenter un tirage à une date donnée.
    /// </summary>
    public class Tirage
    {
        // Constante du nombre minimal de mise.
        private const int NB_MISES_MIN = 100000;
        // Constante du nombre maximal de mise.
        private const int NB_MISES_MAX = 300000;

        //représente date du tirage.
        private DateTime m_dtmTirage;
        //représente combinaison gagnante 6nb plus complémentare.
        private int[] m_iLesNombresGagnants;
        //représente ensemble des participations au tirage.
        private Mise[] m_lesMises;
        //représente la quantité de mises gagnantes pour chaque lot.
        private Resultats m_lesResultats;

        /// <summary>
        /// 
        /// </summary>
        public Tirage()
        {

        }
        /// <summary>
        /// Constructeur, permets d'initialiser la date en fonction du 
        /// paramètre reçu. L'heure est minuit.
        /// </summary>
        /// <param name="dtmDate">Date du tirage</param>
        public Tirage(DateTime dtmDate)
        {
            m_dtmTirage = dtmDate;
        }

        /// <summary>
        /// Permet d'obtenir la date du tirage.
        /// </summary>
        public DateTime Date
        {
            get { return m_dtmTirage; }
        }

        /// <summary>
        /// Permet d'obtenir le nombre de mises. 
        /// </summary>
        public int NbMises
        {
            get
            {
                if (m_lesMises == null)
                {
                    return 0;
                }
                return m_lesMises.Length;
            }
        }

        /// <summary>
        /// Permet d'obtenir les resultats.
        /// </summary>
        public Resultats Resultats
        {
            get { return m_lesResultats; }
        }

        /// <summary>
        /// Permet d'obtenir les résultats en string formater ou un messages 
        /// qui indique que les mises non pas encore été validé pour ce 
        /// tirage.
        /// </summary>
        /// <returns>Returns les resultats ou un messages si il n'y a pas de 
        /// résultats</returns>
        public override string ToString()
        {
            if (m_lesResultats != null)
            {
                //formatage pour la date
                return string.Format(
                    "Résultat du tirage du {0}" +
                    "\nNombre de mises:        {1}" +
                    "\nGagnants du 2 sur 6+:   {2}" +
                    "\nGagnants du 2 sur 6:    {3}" +
                    "\nGagnants du 4 sur 6:    {4}" +
                    "\nGagnants du 5 sur 6:    {5}" +
                    "\nGagnants du 5 sur 6+:   {6}" +
                    "\nGagnants du 6 sur 6:    {7}",
                    m_dtmTirage.ToString("yyyy-MM-dd"),
                    NbMises,
                    Resultats.GetQuantite(Indice.DeuxSurSixPlus),
                    Resultats.GetQuantite(Indice.TroisSurSix),
                    Resultats.GetQuantite(Indice.QuatreSurSix),
                    Resultats.GetQuantite(Indice.CinqSurSix),
                    Resultats.GetQuantite(Indice.CinqSurSixPlus),
                    Resultats.GetQuantite(Indice.SixSurSix));
            }
            else
            {
                // Message, les mises n'ont pas été validées.
                return "Les mises n'ont pas encore été validées " +
                    "pour ce tirage.";
            }
        }

        /// <summary>
        /// Permet de créer le tableau de mises en fonctions du nombre de mises
        /// reçu en paramètre. Si ce nombre n'est pas compris entre
        /// NB_MISES_MAX et NB_MISES_MIN la valeur seras le milieux etre c'est 
        /// deux valeur.
        /// </summary>
        /// <param name="iNbMises">Le nombre de mises pour ce tirages.</param>
        public void InscrireMises(int iNbMises)
        {
            // Vérification que la valeur respecte les contraintes.
            if (NB_MISES_MIN <= iNbMises && iNbMises <= NB_MISES_MAX)
            {
                // La valeur respecte les contraintes.
                m_lesMises = new Mise[iNbMises];

                for (int i = 0; i < iNbMises; i++)
                {
                    m_lesMises[i] = new Mise();
                }
            }
            else
            {
                // Millieu des valeur, car la valeur ne respecte pas les 
                // consignes.
                m_lesMises = new Mise[(NB_MISES_MIN + NB_MISES_MAX) / 2];

                m_lesMises = new Mise[iNbMises];
                for (int i = 0; i < iNbMises; i++)
                {
                    m_lesMises[i] = new Mise();
                }
            }
        }

        /// <summary>
        /// Pertmet d'effectuer le tirage (s'il y a des mises) en générant la
        /// combinaison gagnante (7 noombres entre 1 et 49) et retourne true
        /// ou false dépendent si le tirages c'est effectué avec succès
        /// (faux si il n'y a pas de mises).
        /// </summary>
        /// <returns></returns>
        public bool Effectuer()
        {
            // vérification si il y a des mises.
            if (m_lesMises != null)
            {
                //// Classement des six premier nombres en ordre.
                //Array.Sort(m_iLesNombresGagnants);
                m_iLesNombresGagnants = new int[7];
                int nb;
                //On génère le premier nombre
                nb = Aleatoire.GenererNombre(48);
                //+1, car on ne veut pas de 0 
                nb += 1;

                for (int i = 0; i < m_iLesNombresGagnants.Length - 1; i++)
                {
                    if (nb != m_iLesNombresGagnants[0] && nb != m_iLesNombresGagnants[1] && nb != m_iLesNombresGagnants[2] && nb != m_iLesNombresGagnants[3]
                        && nb != m_iLesNombresGagnants[4] && nb != m_iLesNombresGagnants[5])
                    {
                        m_iLesNombresGagnants[i] = nb;
                        nb = Aleatoire.GenererNombre(48);
                        nb += 1;
                    }
                    else
                    {
                        //Si le nombre n'est pas valide on en regénère un
                        nb = Aleatoire.GenererNombre(48);
                        //+1, car on veut que le nombre soit entre 1 et 49 
                        nb += 1;
                        i--;
                    }
                }
                Array.Sort(m_iLesNombresGagnants);
                bool trouver = false;
                //Septième nombre
                do
                {
                    nb = Aleatoire.GenererNombre(48);
                    nb += 1;
                    if (nb != m_iLesNombresGagnants[0] && nb != m_iLesNombresGagnants[1]
                    && nb != m_iLesNombresGagnants[2] && nb != m_iLesNombresGagnants[3]
                    && nb != m_iLesNombresGagnants[4] && nb != m_iLesNombresGagnants[5])
                    {
                        m_iLesNombresGagnants[6] = nb;
                        trouver = true;
                    }
                } while (!trouver);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permet de valider les mises en stockant les résultats dans 
        /// l'attribut si il y a une combinaison gagnante. return true 
        /// (Indique que les mises ont été validées avec
        /// succèes) sinon false.
        /// </summary>
        /// <returns>true ou false</returns>
        public bool ValiderMises()
        {
            if (m_iLesNombresGagnants != null)
            {
                m_lesResultats = new Resultats();

                bool bonus = false;
                for (int k = 0; k < m_lesMises.Length; k++)
                {
                    int nbMiseValidee = 0;
                    for (int i = 0; i < m_iLesNombresGagnants.Length; i++)
                    {
                        for (int j = 0; j < 6 - 1; j++)
                        {
                            if (m_lesMises[k].GetNombre(j) == m_iLesNombresGagnants[i])
                            {
                                nbMiseValidee++;
                            }
                        }
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        if (m_lesMises[k].GetNombre(i) == m_iLesNombresGagnants[6])
                        {
                            bonus = true;
                        }
                    }
                    switch (nbMiseValidee)
                    {
                        case 2:
                            if (bonus)
                            {
                                m_lesResultats.AugmenterQuantite(Indice.DeuxSurSixPlus);
                            }
                            break;
                        case 3:
                            m_lesResultats.AugmenterQuantite(Indice.TroisSurSix);
                            break;
                        case 4:
                            m_lesResultats.AugmenterQuantite(Indice.QuatreSurSix);
                            break;
                        case 5:
                            if (bonus)
                            {
                                m_lesResultats.AugmenterQuantite(Indice.CinqSurSix);
                            }
                            else
                            {
                                m_lesResultats.AugmenterQuantite(Indice.CinqSurSixPlus);
                            }
                            break;
                        case 6:
                            m_lesResultats.AugmenterQuantite(Indice.SixSurSix);
                            break;
                    }
                }

                m_lesResultats.ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}