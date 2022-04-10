using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class Gran : MonoBehaviour
    {

        public float delay = 3f; // таймер задержки
        float countdown;

        bool hasExploded = false;

        public GameObject explosionEffect;

        public float radius = 5f;
        public float force = 700f;

        private Collider _granCollider;
        private Rigidbody _granRigidbody;

        private void Awake()
        {
            _granCollider = GetComponent<Collider>();
            _granRigidbody = GetComponent<Rigidbody>();
        }

        public void Init(float bombPushforce, float bombLifeTime)
        {
            _granRigidbody.AddForce(transform.forward * force);
            Invoke(nameof(Detonate), delay);
        }

        public void Detonate()
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Collider[] granVictims = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider victim in granVictims)
            {
                print(victim.name);
                if (victim.TryGetComponent(out Rigidbody targetObject))
                {
                    Vector3 vectorToTarget = targetObject.position - transform.position;
                    targetObject.AddForce(vectorToTarget.normalized * Mathf.Lerp(0, force, (radius - vectorToTarget.magnitude) / radius));
                }
            }
            Destroy(gameObject);
        }

    }
}