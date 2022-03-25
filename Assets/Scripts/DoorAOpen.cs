using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{

    public class DoorAOpen : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;


         
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
                _rotatePoint.Rotate (Vector3.up, 90);
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                _rotatePoint.Rotate(Vector3.up, -90);

            }
        }
    }
}