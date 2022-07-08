using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class UdarGoblena : MonoBehaviour
    {
        private float _damage = 20;        

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