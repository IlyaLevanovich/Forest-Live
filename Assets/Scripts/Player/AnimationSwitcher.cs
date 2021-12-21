using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class AnimationSwitcher : MonoBehaviour
    {
        private Animator _animator;


        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        public void Move() => _animator.SetBool("IsMoving", true);

        public void Idle() => _animator.SetBool("IsMoving", false);

        public void Attack() => _animator.SetTrigger("Attack");


    }
}