using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class HPup : MonoBehaviour
    {
        public bool rotate; // Нужен поворот?

        public float rotationSpeed;

        void Update()
        {

            if (rotate)
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                Destroy(gameObject);

            }
        }
    }
}