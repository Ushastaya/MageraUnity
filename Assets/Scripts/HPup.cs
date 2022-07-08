using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class HPup : MonoBehaviour
    {
        public bool rotate; 
        public float rotationSpeed;

        private float HP = 50;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITakeHP takeHP))
            {

                if (other.CompareTag("Player"))
                {
                    takeHP.Medicine(HP);
                    Destroy(gameObject);
                }

            }
                
        }

        
    }
}