using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class SpawnEnemyRandom : MonoBehaviour
    {
        [SerializeField] public GameObject enemy; // ќбъ€вл€ем объект, который будем спамить
        float randomX; // рандомна€ позици€ по X
        float randomZ; // рандомна€ позици€ по Z
        private Vector3 whereToSpawn; // —паун по X и Y и Z

        int vrag = 0;

        public Player _player; // ќбъ€вл€ем поиск игрока



        void Start()
        {

            _player = FindObjectOfType<Player>();

        }


        void Update()
        {

            var point = new Vector3(2f, 0f, 5f);
            if ((Vector3.Distance(point, _player.transform.position) < 2.0f) && vrag < 1)
            {

                SpawnVrag();
                vrag += 1;
            }

        }





        void SpawnVrag()
        {

            randomX = Random.Range(1f, 3f); // в пределах каких координат X будет спавн объекта
            randomZ = Random.Range(4f, 6f); // в пределах каких координат Z будет спавн объекта
            whereToSpawn = new Vector3(randomX, 0f, randomZ); // прописываем рандомное X и Z, а Y вегда одна. это место по€вление врага
            Instantiate(enemy, whereToSpawn, Quaternion.identity); // метод самого свавна

        }
    }
}