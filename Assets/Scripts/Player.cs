using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGames
{
    public class Player : MonoBehaviour, ITakeDamage, ITakeHP
    {
       
        [SerializeField] private float _speed = 1f;
        private Vector3 _direction;
        private bool _isSprint;
        [SerializeField] public float speedRotate = 500f;

        public bool isGrounded;              

        [SerializeField] private GameObject _fire;
        [SerializeField] private Transform _fireSpawnPosition;
        private bool isStop = false;


        [SerializeField] private GameObject _gran;
        [SerializeField] private Transform _granSpawnPosition;
        private float _granPushForce = 40f;
        private float _granLifeTime = 5f;
        //private float _granFireDelay = 5f;

        [SerializeField] private Animator _anim;

        [SerializeField] public Slider mySlider;
        private float _durability = 100;
        private float _mdurability = 100;
        [SerializeField] public Image myImage;
        [SerializeField] private GameObject _gameOver;

        [SerializeField] public Slider mySlider2;        
        private float _mana = 100;
        [SerializeField] public Image myImage2;
        private float trata = 15;       

        private void Awake()
        {

            _anim = GetComponent<Animator>();

        }

        private void Start()
        {

            Time.timeScale = 1;

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


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isGrounded = false;                
                GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
                Pauza();
            }
           
            _anim.SetBool("isGo", _direction != Vector3.zero && !Input.GetButton("Sprint"));
            _anim.SetBool("isJump", isGrounded == false);
            _anim.SetBool("isFire", Input.GetButtonDown("Fire1") && isGrounded && !isStop && _mana >= trata);
            _anim.SetBool("isRun", _isSprint && _direction != Vector3.zero);
            _anim.SetBool("isStay", _direction == Vector3.zero);

                        
            mySlider.value = _durability;
            if (_durability <= 0)
            {
                myImage.enabled = false;
            }
            else
            {
                myImage.enabled = true;
            }

            
            mySlider2.value = _mana;
            if (_mana <= 0)
            {
                myImage2.enabled = false;
            }
            else
            {
                myImage2.enabled = true;
            }                        
           
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
                        
            if (Input.GetButtonDown("Fire1") && _mana >= trata)
            {
                if (isGrounded && !isStop)
                {
                    SpawnFire();
                }
                           
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SpawnGran();
            }

           
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? _speed * 2f : _speed) * delta;
        }

        private void SpawnFire()
        {
            StartCoroutine(Pauza());            
        }

        private void SpawnGran()
        {            
                          
                GameObject granObject = Instantiate(_gran, _granSpawnPosition.position + new Vector3(0, 1f, 0.51f), _granSpawnPosition.rotation);
                Gran gran = granObject.GetComponent<Gran>();
                gran.Init(_granPushForce, _granLifeTime);            

        }

        private IEnumerator Pauza()
        {
            _mana -= trata;
            yield return new WaitForSeconds(0.4f);
            var fireObj = Instantiate(_fire, _fireSpawnPosition.position, _fireSpawnPosition.rotation);
            var fireboom = fireObj.GetComponent<Fire>();
            fireboom.Init(durability: 10);
            isStop = true;
            yield return new WaitForSeconds(1f);
            isStop = false;
        }

        void OnCollisionEnter()
        {
            isGrounded = true;
        }

        public void Hit(float damage)
        {

            _durability -= damage;
            if (_durability <= 0)
            {
                _gameOver.SetActive(true);
            }

        }

        public void Medicine(float HP)
        {

            _durability += HP;
            if (_durability < _mdurability)
            {
                _durability += HP;

                if (_durability > _mdurability)
                {
                    _durability = _mdurability;
                }
            }

        }
        
}
          

}