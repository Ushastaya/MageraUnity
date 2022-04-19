using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class DoorAOpen : MonoBehaviour
    {
        //[SerializeField] private Transform _rotatePoint;

        [SerializeField] private Animator _anim;

        private void Awake()
        {

            _anim = GetComponent<Animator>();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _anim.SetBool("isOpen", true);
                //_rotatePoint.Rotate(Vector3.up, 90);
            }

        }
        private void OnTriggerExit(Collider other)
        {

            if (other.CompareTag("Player"))
            {
                _anim.SetBool("isOpen", false);
                //_rotatePoint.Rotate(Vector3.up, -90);
            }
        }
    }
}