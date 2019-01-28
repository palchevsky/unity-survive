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
        #endregion

        #region Unity Lifecycle
        private void Update()
        {
            Vector3 direction = new Vector3(InputController.Instance.MoveDirection.x, 0, InputController.Instance.MoveDirection.y);

            _rigidbody.velocity = direction * _speed;

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _rigidbody.rotation = rotation;
        }
        #endregion
    }
}