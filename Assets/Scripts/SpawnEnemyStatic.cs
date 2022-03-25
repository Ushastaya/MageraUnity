using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class SpawnEnemyStatic : MonoBehaviour
    {
        [SerializeField] public GameObject enemy1; // ќбъ€вл€ем объект, который будем спамить
        private Vector3 SpawnVragPoint1; // —паун по X и Y и Z

        public Player _player; // ќбъ€вл€ем поиск игрока

        int vrag1 = 0;

        void Start()
        {

            _player = FindObjectOfType<Player>();

        }


        void Update()
        {

            var point1 = new Vector3(-4.35f, 0f, 13f);
            if ((Vector3.Distance(point1, _player.transform.position) < 2.0f) && vrag1 < 1)
            {

                SpawnVragStatic();
                vrag1 += 1;
            }

        }
        void SpawnVragStatic()
        {
            SpawnVragPoint1 = new Vector3(-4.35f, 0f, 13f); // прописываем рандомное X и Z, а Y вегда одна. это место по€вление врага
            Instantiate(enemy1, SpawnVragPoint1, Quaternion.identity); // метод самого свавна
        }
    }
}