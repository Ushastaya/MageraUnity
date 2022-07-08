using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Enemy : MonoBehaviour, ITakeDamage
    {
        private float _durability = 50;
        private float _speedRotate = 2;


        [SerializeField] private Player _player;
        

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _SpawnPosition;
        [SerializeField] private Transform _SpawnPosition1;

        [SerializeField] private Animator _anim;
        private bool fire1;        
        private bool isPaus1 = false;        

        private void Awake()
        {

            _anim = GetComponent<Animator>();
            _player = FindObjectOfType<Player>();

        }

        void Update()
        {

            Ray ray = new Ray(_SpawnPosition1.position, transform.forward);

            

            if (Physics.Raycast(ray, out RaycastHit hit, 3))
            {
                if (hit.collider.CompareTag("Player") && !isPaus1)
                {
                    fire1 = true;                    
                    Fire();
                }
                else
                {
                    fire1 = false;                    
                }
            }

            _anim.SetBool("isFire", fire1 == true);

        }

        void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 3.0f)
            {
                var direction = _player.transform.position - transform.position;
                var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(stepRotate);
            }           

        }

        private void Fire()
        {
            var bulletObj = Instantiate(_bullet, _SpawnPosition.position, _SpawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 2f, 3f);
            StartCoroutine(Pauza());
        }


        private IEnumerator Pauza()
        {
            isPaus1 = true;
            yield return new WaitForSeconds(3f);
            isPaus1 = false;
        }
                
        public void Hit(float damage)
        {
            
            _durability -= damage;
            if (_durability <= 0)
            {
                Destroy(gameObject);
            }

        }


    }
}