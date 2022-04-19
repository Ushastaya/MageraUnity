using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _durability = 30;

        [SerializeField] private float _speed = 2f;
        private Vector3 _direction;
        private bool _isSprint;
        [SerializeField] public float speedRotate = 500f;

        public bool isGrounded;

        [SerializeField] private GameObject _fire;
        [SerializeField] private Transform _fireSpawnPosition;
        private bool Fire;


        [SerializeField] private GameObject _gran;
        [SerializeField] private Transform _granSpawnPosition;
        private float _granPushForce = 40f;
        private float _granLifeTime = 5f;
        private float _granFireDelay = 5f;
        private float _granFireTime = -50f;

        [SerializeField] private Animator _anim;

        private void Awake()
        {

            _anim = GetComponent<Animator>();

        }

        void OnCollisionEnter()
        {
            isGrounded = true;
        }


        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));

            if (Input.GetKey(KeyCode.Escape))

            {
                UnityEditor.EditorApplication.isPlaying = false;
            }


            if (Input.GetButton("Jump") && isGrounded)
            {
                isGrounded = false;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 210, 0));
            }

            _anim.SetBool("isGo", _direction != Vector3.zero);
            _anim.SetBool("isJump", isGrounded == false);
            _anim.SetBool("isFire", Fire == true);
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                SpawnFire();
                Fire = true;
            }
            else
            {
                Fire = false;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SpawnGran();
            }
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? _speed * 2 : _speed) * delta;
        }

        private void SpawnFire()
        {
            var fireObj = Instantiate(_fire, _fireSpawnPosition.position, _fireSpawnPosition.rotation); 
            var fireboom = fireObj.GetComponent<Fire>();
            fireboom.Init(durability: 10);
        }

        private void SpawnGran()
        {
                        
            
                //_granFireTime = Time.time;
                GameObject granObject = Instantiate(_gran, _granSpawnPosition.position + new Vector3(0, 1f, 0.51f), _granSpawnPosition.rotation);
                Gran gran = granObject.GetComponent<Gran>();
                gran.Init(_granPushForce, _granLifeTime);
            

        }

    }

}