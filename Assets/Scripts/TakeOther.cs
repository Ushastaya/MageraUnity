using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class TakeOther : MonoBehaviour
    {

        private float _durability = 10;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {

                Destroy(gameObject);

            }
        }


    }
}