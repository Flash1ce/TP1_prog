/******************************************************************************
 * Classe:      GestionnaireTirages
 * 
 * Fichier:     gestionnaireTirages.cs
 * 
 * Auteur:      Antoine Bédard
 * 
 * But:         Représente un ensemble de tirages.
 * 
 * Remarque:    
 *              
 * ***************************************************************************/
using System;
using Utilitaires;

namespace SimulationLoterie
{
    /// <summary>
    /// Représente un ensemble de tirages.
    /// </summary>
    public class GestionnaireTirages
    {
        // Constante du nombre de tirages.
        const int NB_TIRAGES = 104;

        // Représente l'ensemble des tirages.
        private Tirage[] m_lesTirages;

        /// <summary>
        /// Constructeur, permet de créer l'ensemble de NB_TIRAGES 
        /// (2 tirages/semaine) selons les règles déterminer.
        /// </summary>
        public GestionnaireTirages()
        {
            const int MERCREDI = (int)DayOfWeek.Wednesday;
            const int SAMEDI = (int)DayOfWeek.Saturday;
            // Crée l'ensemble des tirages.
            m_lesTirages = new Tirage[NB_TIRAGES];

            // La date de la journé ou le gestionnaire est crée.
            DateTime dtmDateCourante = DateTime.Today;

            // Récupère le jours de la semaine et determine les dates des
            // prochains tirages.
            int iJourSemaineCourante = (int)dtmDateCourante.DayOfWeek;

            int iProchainJour;
            if (iJourSemaineCourante != MERCREDI && iJourSemaineCourante != SAMEDI)
            {
                if (iJourSemaineCourante < MERCREDI)
                {
                    iProchainJour = MERCREDI;
                }
                else
                {
                    iProchainJour = SAMEDI;
                }
                dtmDateCourante = dtmDateCourante.AddDays(iProchainJour - iJourSemaineCourante);
                m_lesTirages[0] = new Tirage(dtmDateCourante);
            }
            else
            {
                if (iJourSemaineCourante == MERCREDI)
                {
                    iProchainJour = MERCREDI;
                }
                else
                {
                    iProchainJour = SAMEDI;
                }
                dtmDateCourante = dtmDateCourante.AddDays(iProchainJour - iJourSemaineCourante);
                m_lesTirages[0] = new Tirage(dtmDateCourante);
            }

            for (int i = 1; i < NB_TIRAGES; i++)
            {
                iJourSemaineCourante = (int)dtmDateCourante.DayOfWeek;
                dtmDateCourante = dtmDateCourante.AddDays((iJourSemaineCourante / 3) + 2);
                m_lesTirages[i] = new Tirage(dtmDateCourante);
            }
        }

        /// <summary>
        /// Permet d'obtenir le tirage à l'indice reçu en paramètre si 
        /// celui-ci est valide.
        /// </summary>
        /// <param name="iIndice">Indice du tirage voulus.</param>
        /// <returns>Return null si invalide, si valide retun le tirage.
        /// </returns>
        public Tirage GetTirages(int iIndice)
        {
            if (m_lesTirages[iIndice] != null)
            {
                return m_lesTirages[iIndice];
            }
            else
            {
                return null;
            }
        }
    }
}