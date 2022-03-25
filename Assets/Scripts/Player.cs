using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _durability = 30;

        [SerializeField] private float _speed = 2f; // Скорость движения, а в дальнейшем ускорение
        private Vector3 _direction; // Направление движения
        private bool _isSprint; // Ускорение

        [SerializeField] private GameObject _fire;
        [SerializeField] private Transform _fireSpawnPosition;

        [SerializeField] public float speedRotate = 500f;

        [SerializeField] private GameObject _key;
        [SerializeField] private Transform _target;

        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");


            if (Input.GetKey(KeyCode.Escape))

            {
                UnityEditor.EditorApplication.isPlaying = false; // Кнопка выхода
            }

            if (Input.GetButton("Fire1"))
            {
                SpawnFire();
            }

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                SpawnFire();
            }
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? _speed * 2 : _speed) * delta; // метод движения с условием нажата ли кнопка ускорения?
        }

        private void SpawnFire()
        {
            var fireObj = Instantiate(_fire, _fireSpawnPosition.position, _fireSpawnPosition.rotation); // Создаем мину в точке спавна
            var fireboom = fireObj.GetComponent<Fire>();
            fireboom.Init(durability: 10);
        }

        //public void Hit(float damage)
        //{

        //    _durability -= damage;
        //    if (_durability <= 0)
        //    {
        //        Destroy(gameObject);
        //    }

        //}
    }

}