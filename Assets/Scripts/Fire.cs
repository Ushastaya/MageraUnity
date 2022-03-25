using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Fire : MonoBehaviour
    {
        //[SerializeField] private float _durability; // Прочность мины
        [SerializeField] private float _damage = 10;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                takeDamage.Hit(_damage);
            }
        }

        public void Init(float durability)
        {
            Destroy(gameObject, 0.35f);
        }
    }
}