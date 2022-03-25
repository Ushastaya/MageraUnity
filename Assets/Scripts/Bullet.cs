using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        
        [SerializeField] private float _damage = 10;

        public void Init(Transform target, float lifeTime, float speed)
        {
            _target = target;
            _speed = speed;
            Destroy(gameObject, lifeTime);
        }

        void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }

        

        //private void OnTriggerEnter(Collider collision)
        //{
        //    if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
        //    {
        //        takeDamage.Hit(_damage);
        //    }
        //}
    }
}