using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class Lever : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private bool isOpen;

        [SerializeField] private GameObject _newLever;
        [SerializeField] private Transform _leverSpawnPosition;

        private void Awake()
        {

            _anim = GetComponent<Animator>();

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetBool("isOpenLever", true);
                var leverObj = Instantiate(_newLever, _leverSpawnPosition.position, _leverSpawnPosition.rotation);
                //var leverOpen = leverObj.GetComponent<Levers>();
                GetComponent<Lever>().enabled = false;
            }

        }

    }
}