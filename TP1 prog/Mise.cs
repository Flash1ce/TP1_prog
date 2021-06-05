/******************************************************************************
 * Classe:      Mise
 * 
 * Fichier:     mise.cs
 * 
 * Auteur:      Antoine Bédard
 * 
 * But:         Cette classe sert à représenter une participation à un tirage.
 * 
 * Remarque:    
 *              
 * ***************************************************************************/
using Utilitaires;
using System;

namespace SimulationLoterie
{
    /// <summary>
    /// Cette classe sert à représenter une participation à un tirage.
    /// </summary>
    public class Mise
    {
        // Représente les six nombres différents de 1 à 49 de la mise.
        private int[] m_iLesNombres;
        // Représente le nombre de nombre pour la mise.
        private const int NbNombres = 6;

        /// <summary>
        /// Constructeur qui permet de créer le tableau de nombre, 
        /// initialiser chacun de ceux-ci (compris entre 1 et 49 et tous 
        /// différents).
        /// </summary>
        public Mise()
        {
            // Création du tableau m_iLesNombres de taille NbNombres.
            m_iLesNombres = new int[NbNombres];

            // Génération des nombres et vérification 
            // qu'ils sont tous différents.
            int nb = Aleatoire.GenererNombre(48);

            for (int i = 0; i < m_iLesNombres.Length; i++)
            {
                if (nb != m_iLesNombres[0] && nb != m_iLesNombres[1]
                    && nb != m_iLesNombres[2] && nb != m_iLesNombres[3]
                    && nb != m_iLesNombres[4] && nb != m_iLesNombres[5])
                {
                    m_iLesNombres[i] = nb;
                }
                else
                {
                    nb = Aleatoire.GenererNombre(48);
                    i--;
                }
            }

            // Classement des nombres en ordre.
            Array.Sort(m_iLesNombres);
        }

        /// <summary>
        /// Obtenir le nombre grace a l'indice fournis en paramètre si l'indice
        /// est valide.
        /// </summary>
        /// <param name="indice">int, indice du nombre voulus.</param>
        /// <returns>Le nombre dans la case de l'indice ou -1 si l'indice est 
        /// invalide.</returns>
        public int GetNombre(int indice)
        {
            if (indice < 0 || indice > NbNombres)
            {
                // return -1, car indice est pas valide.
                return -1;
            }

            // return la valeur.
            return m_iLesNombres[indice];
        }
    }
}