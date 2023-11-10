using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
using UnityEngine.Windows;
#endif

namespace GladiatorSurvival
{
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif  

    public class PlayerAttack : MonoBehaviour
    {
        PlayerInputs _input;




#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerInput;
#endif


        void Start()
        {
            _input = GetComponent<PlayerInputs>();

#if ENABLE_INPUT_SYSTEM
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Input System을 찾을 수 없음");
#endif
        }

        void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if(_input.attack)
            {
                Debug.Log("공격");
                _input.attack = false;
            }

        }


    }
}