using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGames
{
    public class Player : MonoBehaviour
    {
        // ���������
        [SerializeField] private float _durability = 30;

        // �������� ������
        [SerializeField] private float _speed = 2f; // �������� ��������, � � ���������� ���������
        private Vector3 _direction; // ����������� ��������
        private bool _isSprint; // ���������
        [SerializeField] public float speedRotate = 500f;

        // ������
        public bool isGrounded;

        // ����� 1
        [SerializeField] private GameObject _fire;
        [SerializeField] private Transform _fireSpawnPosition;


        [SerializeField] private GameObject _gran;
        [SerializeField] private Transform _granSpawnPosition;
        private float _granPushForce = 40f;
        private float _granLifeTime = 5f;
        private float _granFireDelay = 5f;
        private float _granFireTime = -50f;


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
                UnityEditor.EditorApplication.isPlaying = false; // ������ ������
            }

            //if (Input.GetButton("Fire1"))
            //{
            //    SpawnFire();
            //}

            //if (Input.GetButton("G"))
            //{
            //    SpawnGran();
            //}

            if (Input.GetButton("Jump") && isGrounded)
            {
                isGrounded = false;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 210, 0));
            }

            //if (Input.GetKeyDown("G"))
            //{
            //    Transform magicgran = Instantiate(_gran, _fireSpawnPosition.position, _fireSpawnPosition.rotation, Quaternion.identity) as Transform;
            //    magicgran.GetComponent<Rigidbody>().AddForce(transform.forward * speedGran);
            //}
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                SpawnFire();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SpawnGran();
            }
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? _speed * 2 : _speed) * delta; // ����� �������� � �������� ������ �� ������ ���������?
        }

        private void SpawnFire()
        {
            var fireObj = Instantiate(_fire, _fireSpawnPosition.position, _fireSpawnPosition.rotation); // ������� ���� � ����� ������
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