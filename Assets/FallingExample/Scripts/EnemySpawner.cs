using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Filling
{
    public class EnemySpawner : MonoBehaviour
    {
        [Tooltip("������ �������� ��� ������")]
        [SerializeField] private List<EnemyData> enemySettings;

        [Tooltip("���������� �������� � ����")]
        [SerializeField] private int poolCount;

        [Tooltip("������ �� ������� ������ ��� ������")]
        [SerializeField] private GameObject enemyprefab;

        [Tooltip("����� ����� ������� ������")]
        [SerializeField] private float spawnTime;

        /// <summary>
        /// ������� ��� �������� ������ �� �����
        /// </summary>
        public static Dictionary<GameObject, Enemy> Enemies;

        private Queue<GameObject> currentEnemies;

        private void Start()
        {
            Enemies = new Dictionary<GameObject, Enemy>();
            currentEnemies = new Queue<GameObject>();

            for (int i = 0; i < poolCount; i++)
            {
                var prefab = Instantiate(enemyprefab);
                var script = prefab.GetComponent<Enemy>();
                prefab.SetActive(false);
                Enemies.Add(prefab, script);
                currentEnemies.Enqueue(prefab);
            }
            Enemy.OnEnemyOverFly += ReturnEnemy;

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            if (spawnTime == 0)
            {
                Debug.LogError("�� ���������� ����� ������, ������ ����������� �������� - 1 ���.");
                spawnTime = 1;
            }
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                if (currentEnemies.Count > 0)
                {
                    // ��������� ����������� � ��������� �����
                    var enemy = currentEnemies.Dequeue();
                    var script = Enemies[enemy];
                    enemy.SetActive(true);

                    // ��������� ���������� EnemyData � �������������
                    int rand = Random.Range(0, enemySettings.Count);
                    script.Init(enemySettings[rand]);

                    // ��������� ���������� ����� ��� �������
                    float xPos = Random.Range(-GameCamera.Border, GameCamera.Border);
                    enemy.transform.position = new Vector2(xPos, transform.position.y);

                }
            }
        }

        /// <summary>
        /// ������� ����� � ��� � ���������� � ���������� �������������
        /// </summary>
        /// <param name="_enemy"></param>
        private void ReturnEnemy(GameObject _enemy)
        {
            _enemy.transform.position = transform.position;
            _enemy.SetActive(false);
            currentEnemies.Enqueue(_enemy);
        }
    }
}
