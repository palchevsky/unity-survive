using UnityEngine;

namespace Survive
{
    public class MoveController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _turnSpeed;
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Animator _animator;
        #endregion

        #region Unity Lifecycle
        private void Update()
        {
            Vector3 direction = new Vector3(InputController.Instance.MoveDirection.x, 0, InputController.Instance.MoveDirection.y);

            _rigidbody.velocity = direction * _speed;

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                _rigidbody.rotation = rotation;
                _animator.SetBool("isRunning", true);
                _animator.SetFloat("speed", rotation.y);
                if (rotation.y > 0.8f)
                {
                    _animator.SetTrigger("trigger");
                }
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }


        }
        #endregion
    }
}