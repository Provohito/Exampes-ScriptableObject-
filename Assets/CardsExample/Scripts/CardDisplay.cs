using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardExample
{
    public class CardDisplay : MonoBehaviour
    {

        [SerializeField]private Card card;
        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        [SerializeField] private Text nameText;
        [SerializeField] private Text descriptionText;

        [SerializeField] private Image artworkImage;

        [SerializeField] private Text manaText;
        [SerializeField] private Text attackText;
        [SerializeField] private Text healthText;
        void Start()
        {
            nameText.text = card.Name;
            descriptionText.text = card.Description;

            artworkImage.sprite = card.ArtWork;

            manaText.text = card.ManaCost.ToString();
            attackText.text = card.Attack.ToString();
            healthText.text = card.Health.ToString();


        }
    }
}
