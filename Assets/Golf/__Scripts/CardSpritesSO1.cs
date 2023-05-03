using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolfGame
{
    [CreateAssetMenu(fileName = "CardSprites", menuName = "ScriptableObjects/CardSpriteSO1")]
    public class CardSpritesSO1 : ScriptableObject
    {
        [Header("Card Stock")]
        public Sprite cardBack;
        public Sprite cardBackSilver;
        public Sprite cardBackGold;
        public Sprite cardFront;
        public Sprite cardFrontSilver;
        public Sprite cardFrontGold;

        [Header("Suits")]
        public Sprite suitClub;
        public Sprite suitDiamond;
        public Sprite suitHeart;
        public Sprite suitSpade;

        [Header("Pip Sprites")]
        public Sprite[] faceSprites;
        public Sprite[] rankSprites;

        private static CardSpritesSO1 S;
        public static Dictionary<char, Sprite> SUITS { get; private set; }

        public void Init()
        {
            INIT_STATICS(this);
        }

        /// <summary>
        /// Initializes the static elements of CardSpriteSO.
        /// </summary>
        /// <param name="cSSO">CardSpriteSO to be assigned to the Singleton S</param>
        static void INIT_STATICS(CardSpritesSO1 cSSO)
        {
            if (S != null)
            {
                Debug.LogError("CardSpritesSO.S can�t be set a 2nd time!");
                return;
            }
            S = cSSO; // Initialize the Singleton each time the game starts

            // Initialize the _SUITS Dictionary
            SUITS = new Dictionary<char, Sprite>()
        {
            { 'C', S.suitClub },
            { 'D', S.suitDiamond },
            { 'H', S.suitHeart },
            { 'S', S.suitSpade }
        };

        }
        public static Sprite[] RANKS
        {
            get { return S.rankSprites; }
        }

        /// <summary>
        /// Searches S.faceSprites for the one with the right name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns>A face Sprite</returns>
        public static Sprite GET_FACE(string name)
        {
            foreach (Sprite spr in S.faceSprites)
            {
                if (spr.name == name) return spr;

            }
            return null;
        }

        /// <summary>
        /// This public static property makes S.cardBack accessible to other classes
        /// </summary>
        public static Sprite BACK
        {
            get { return S.cardBack; }
        }

        /// <summary>
        /// Call this to reset the Singleton S to null at the end of a game
        /// </summary>
        public static void RESET()
        {
            S = null;
        }
    }
}