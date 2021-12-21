using System.Collections;
using UnityEngine;


namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private FixedJoystick _joystick;
        private Rigidbody _rigidbody;
        private AnimationSwitcher _animationSwitcher;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animationSwitcher = GetComponent<AnimationSwitcher>();
        }
        private void FixedUpdate()
        {
            float rotationAngle = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
            Vector3 joystickOffset = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

            if (rotationAngle != 0)
                Move(rotationAngle, joystickOffset);
            else
                _animationSwitcher.Idle();

        }
        private void Move(float rotationAngle, Vector3 offset)
        {
            _rigidbody.rotation = Quaternion.Euler(0, rotationAngle, 0);
            _rigidbody.MovePosition(transform.position + offset * _speed * Time.fixedDeltaTime);
            _animationSwitcher.Move();
        }
    }
}