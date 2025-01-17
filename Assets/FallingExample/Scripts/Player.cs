using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Filling
{
    public class Player : MonoBehaviour
    {
        [Tooltip("��������� ������� ������")]
        [SerializeField] private Vector3 startPos;

        [Tooltip("��������� ���������� ��������")]
        [SerializeField] private float health = 5.0f;

        [Tooltip("�������� ������")]
        [SerializeField] private float speed = 0.1f;

        private void Start()
        {
            transform.position = startPos;
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -GameCamera.Border)
                transform.Translate(Vector3.left * speed);
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < GameCamera.Border)
                transform.Translate(Vector3.right * speed);
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            var obj = col.gameObject;
            if (EnemySpawner.Enemies.ContainsKey(obj))
            {
                health -= EnemySpawner.Enemies[obj].Attack;
                if (health <= 0)
                {
                    Destroy(gameObject);
                    Debug.Log("Game is over");
                }
                else Debug.Log("Player have hard damage, your health is " + health + " hp");
            }
        }
    }
}
