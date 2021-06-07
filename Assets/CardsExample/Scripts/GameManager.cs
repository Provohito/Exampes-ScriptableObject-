using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardExample
{

    public class GameManager : MonoBehaviour
    {
        private Object[] cards;
        [SerializeField] Transform cardsPanel;
        [SerializeField] GameObject prefabCard;

        public void Start()
        {
            cards = Resources.LoadAll("", typeof(Card));
            foreach (var t in cards)
            {
                GameObject card = Instantiate(prefabCard);
                card.transform.SetParent(cardsPanel);
                card.GetComponent<CardDisplay>().Card = (Card)t;
                Debug.Log(t.name);
            }
        }
    }
}
