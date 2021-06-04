using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Filling
{
    [CreateAssetMenu(menuName = "FallingExample/Enemies/Standart Enemy", fileName = "New Enemy")]
    public class EnemyData : ScriptableObject
    {
        [Tooltip("�������� ������")]
        [SerializeField] private Sprite mainSprite;
        public Sprite MainSprite
        {
            get { return mainSprite;  }
            protected set { }
        }

        [Tooltip("�������� ����")]
        [SerializeField] private float speed;
        public float Speed
        {
            get { return speed; }
            protected set { }
        }

        [Tooltip("����� �����")]
        [SerializeField] private float attack;
        public float Attack
        {
            get { return attack; }
            protected set { }
        }
    }
}
