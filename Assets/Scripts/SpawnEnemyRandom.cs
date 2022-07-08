using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class SpawnEnemyRandom : MonoBehaviour
    {
        [SerializeField] public GameObject enemy; // ��������� ������, ������� ����� �������
        float randomX; // ��������� ������� �� X
        float randomZ; // ��������� ������� �� Z
        private Vector3 whereToSpawn; // ����� �� X � Y � Z

        int vrag = 0;

        public Player _player; // ��������� ����� ������



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

            randomX = Random.Range(1f, 3f); // � �������� ����� ��������� X ����� ����� �������
            randomZ = Random.Range(4f, 6f); // � �������� ����� ��������� Z ����� ����� �������
            whereToSpawn = new Vector3(randomX, 0f, randomZ); // ����������� ��������� X � Z, � Y ����� ����. ��� ����� ��������� �����
            Instantiate(enemy, whereToSpawn, Quaternion.identity); // ����� ������ ������

        }
    }
}