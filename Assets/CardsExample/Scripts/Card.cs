using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardExample
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        [SerializeField] private new string name;
        public string Name
        {
            get { return name; }
            protected set { }
        }
        [SerializeField] private string description;
        public string Description
        {
            get { return description; }
            protected set { }
        }

        [SerializeField] private Sprite artwork;
        public Sprite ArtWork
        {
            get { return artwork; }
            protected set { }
        }

        [SerializeField] private int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
            protected set { }
        }
        [SerializeField] private int attack;
        public int Attack
        {
            get { return attack; }
            protected set { }
        }
        [SerializeField] private int health;
        public int Health
        {
            get { return health; }
            protected set { }
        }
    }
}
