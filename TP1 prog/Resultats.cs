/******************************************************************************
 * Classe:      Resultats
 * 
 * Fichier:     resultats.cs
 * 
 * Auteur:      Antoine Bédard
 * 
 * But:         Représente les résultats d'un tirage.
 * 
 * Remarque:    
 *              
 * ***************************************************************************/
using System;

namespace SimulationLoterie
{
    /// <summary>
    /// Énumération des type de résultats.
    /// </summary>
    public enum Indice
    {
        DeuxSurSixPlus,
        TroisSurSix,
        QuatreSurSix,
        CinqSurSix,
        CinqSurSixPlus,
        SixSurSix
    }

    /// <summary>
    ///  Cette class sert a représenter les résultats d'un tirage.
    /// </summary>
    public class Resultats
    {
        // Indique les nombres de mises obtenus pour chaque catégories.
        private int[] m_iLesQuantites;

        /// <summary>
        /// Constructeur, crée le tableau m_iLesQuantites.
        /// </summary>
        public Resultats()
        {
            m_iLesQuantites = new int[6];
        }

        /// <summary>
        /// Permet de récupérer la quantité è l'indice reçu en paramètre. 
        /// </summary>
        /// <param name="indice">Indice de la catégorie voulus.</param>
        /// <returns>La quantité de la catégorie voulus.</returns>
        public int GetQuantite(Indice indice)
        {
            return m_iLesQuantites[(int)indice];
        }

        /// <summary>
        /// Permet d'augmenter la quantité (+1), en fonction de l'indice reçu 
        /// en paramètre.
        /// </summary>
        /// <param name="indice">Indice de la catégorie.</param>
        public void AugmenterQuantite(Indice indice)
        {
            // Augmentation de la catégorie sélectioner.
            m_iLesQuantites[(int)indice]++;
        }
    }
}