/******************************************************************************
 * Classe:      GestionnaireTirages
 * 
 * Fichier:     gestionnaireTirages.cs
 * 
 * Auteur:      ?
 * 
 * But:         Générer un nombre alléatoire, en fonction de la limite
 *              fournis en paramètre.
 * 
 * Remarque:    commence a 1 donc faire -1 a la limite qu'on veut.
 *              
 * ***************************************************************************/
using System;

namespace Utilitaires
{
    public static class Aleatoire
    {
        public static Random g_rndGenerateur = new Random ();

        public static int GenererNombre (int iBorneSuperieure)
        {
            return g_rndGenerateur.Next (iBorneSuperieure + 1);
        }
    }
}