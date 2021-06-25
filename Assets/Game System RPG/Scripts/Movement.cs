using UnityEngine;
using UnityEngine.UI;

namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Player Details")]
        public int playerLevel;
        public Text playerLevelText;
        public int playerMoney;
        public Text playerMoneyText;
        public int playerRocks;
        public Text playerRocksText;

        [Header("Speed Vars")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 10.0f;
        private Vector3 _moveDir;
        private CharacterController _charC;

        private Animator myAnimator;
        private void Start()
        {
            playerLevel = 1;
            playerMoney = 0;
            playerRocks = 0;
            _charC = GetComponent<CharacterController>();
            myAnimator = GetComponentInChildren<Animator>();
        }
        
        private void Update()
        {
            Move();
            playerLevelText.text = ("Player level = " + playerLevel);
            playerMoneyText.text = ("Player money = " + playerMoney);
            playerRocksText.text = ("Player rock count = " + playerRocks);
            OtherFunctions();
        }
        private void 
            OtherFunctions()
        {
            if (Input.GetKeyDown("q"))
            {
                Time.timeScale = 1;
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            if (Input.GetKeyDown("l"))
            {
                playerLevel++;
            }
        }
            private void Move()
        {
            Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_charC.isGrounded)
            {
                if (Input.GetButton("Crouch"))
                {
                    moveSpeed = runSpeed;
                    myAnimator.SetFloat("speed", 0.25f);
                }
                else
                {
                    if (Input.GetButton("Sprint"))
                    {
                        moveSpeed = crouchSpeed;
                        myAnimator.SetFloat("speed", 3f);
                    }
                    else if (!Input.GetButton("Sprint"))
                    {
                        moveSpeed = walkSpeed;

                        myAnimator.SetFloat("speed", 1f);
                    }
                }
                myAnimator.SetBool("walking", movementInput.magnitude > 0.05f);

                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
    }
}