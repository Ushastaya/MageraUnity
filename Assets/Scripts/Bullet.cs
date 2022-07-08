using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Bullet : MonoBehaviour
    {

        private Transform _target;
        private float _speed;

        private float _damage = 15;
       

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


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {                
                if (other.gameObject.TryGetComponent(out ITakeDamage takeDamage))
                {
                    takeDamage.Hit(_damage);                    
                }
            }
            
        }
        
    }
}