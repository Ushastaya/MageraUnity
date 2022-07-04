using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Lever2 : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private bool isOpen;

        [SerializeField] private GameObject _door;
        private GameObject _destroy;

        void Start()
        {
            _destroy = GameObject.Find("DestroyWall");
        }

        private void Awake()
        {

            _anim = GetComponent<Animator>();

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetBool("isOpenLever", true);
                Instantiate(_door, _destroy.transform.position, _destroy.transform.rotation);                
                Destroy(_destroy);
                GetComponent<Lever>().enabled = false;
            }

        }

    }
}
