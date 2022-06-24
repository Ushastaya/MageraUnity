﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGames
{
    public class EnemyPatrul : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _durability = 50;
        [SerializeField] private float _speedRotate = 2;


        [SerializeField] private Player _player;


        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _SpawnPosition;


        [SerializeField] private Animator _anim;
        private bool fire1;

        private NavMeshAgent _agent;
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private Transform _SpawnPosition1;
        int m_CurrentWayPointIndex;
        private bool isPaus = false;
        private bool isPaus1 = false;

        private void Awake()
        {

            _anim = GetComponent<Animator>();
            _player = FindObjectOfType<Player>();
            _agent = GetComponent<NavMeshAgent>();

        }

        void Start()
        {
            _agent.SetDestination(waypoints[0].position);
        }

        void Update()
        {

            Ray ray = new Ray(_SpawnPosition1.position, transform.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 4))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    _agent.SetDestination(_player.transform.position);
                    Run();

                    if (Physics.Raycast(ray, out hit, 2f))
                    {

                        if (hit.collider.CompareTag("Player") && !isPaus1)
                        {
                            Attack();
                            fire1 = true;
                        }
                        else
                        {
                            fire1 = false;
                        }
                    }
                }
                               
            }                        

            if ((Vector3.Distance(transform.position, _player.transform.position) >= 1.5f) && (Vector3.Distance(transform.position, _player.transform.position) < 1.7f))
            {
                StartCoroutine(Pauza());
            }
                        
            if (_agent.remainingDistance <= _agent.stoppingDistance && !isPaus)
            {                
                StartCoroutine(PatrulPauza());
            }
        }


        void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 4f)
            {
                var direction = _player.transform.position - transform.position;
                var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(stepRotate);
            }

        }

        //private void Fire()
        //{
        //    var bulletObj = Instantiate(_bullet, _SpawnPosition.position, _SpawnPosition.rotation);
        //    var bullet = bulletObj.GetComponent<Bullet>();
        //    bullet.Init(_player.transform, 0.5f, 4f);
        //    StartCoroutine(Pauza());
        //    _anim.SetBool("isAttack", true);
        //}

        private void Attack()
        {
            
            _anim.SetBool("isStay", false);
            _anim.SetBool("isAttack", true);
            _anim.SetBool("isRun", false);
            _anim.SetBool("isWalk", false);
        }

        private void Run()
        {
            
            _agent.speed = 3.0f;
            _anim.SetBool("isStay", false);
            _anim.SetBool("isAttack", false);
            _anim.SetBool("isRun", true);
            _anim.SetBool("isWalk", false);
        }

        private void Walk()
        {
            
            _agent.speed = 1.2f;
            _anim.SetBool("isStay", false);
            _anim.SetBool("isAttack", false);
            _anim.SetBool("isRun", false);
            _anim.SetBool("isWalk", true);
        }

        private void Stay()
        {

            _anim.SetBool("isStay", true);
            _anim.SetBool("isAttack", false);
            _anim.SetBool("isRun", false);
            _anim.SetBool("isWalk", false);
        }

        public void Hit(float damage)
        {

            _durability -= damage;
            if (_durability <= 0)
            {
                Destroy(gameObject);
            }

        }

        private IEnumerator PatrulPauza()
        {
            isPaus = true;
            Stay();
            yield return new WaitForSeconds(5f);
            Walk();
            m_CurrentWayPointIndex = (m_CurrentWayPointIndex + 1) % waypoints.Length;
            _agent.SetDestination(waypoints[m_CurrentWayPointIndex].position);

            isPaus = false;
            
        }

        private IEnumerator Pauza()
        {
            isPaus1 = true;
            Stay();           
            yield return new WaitForSeconds(3f);
            Walk();
            isPaus1 = false;
        } 
        
       

    }
}