using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Enemy : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _durability = 50;
        [SerializeField] private float _speedRotate = 2;


        [SerializeField] private Player _player;
        

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _SpawnPosition;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            
        }

        void Update()
        {


            if ((Vector3.Distance(transform.position, _player.transform.position) < 3.5))
            {
                Fire();
            }

        }

        void FixedUpdate()
        {

            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(stepRotate);

        }

        private void Fire()
        {
            var bulletObj = Instantiate(_bullet, _SpawnPosition.position, _SpawnPosition.rotation); // Создаем мину в точке спавна
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 0.5f, 4f);
        }

        public void Hit(float damage)
        {
            
            _durability -= damage;
            if (_durability <= 0)
            {
                Destroy(gameObject);
            }

        }


    }
}