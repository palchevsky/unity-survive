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
        #endregion

        #region Unity Lifecycle
        private void Update()
        {
            Vector3 direction = new Vector3(InputController.Instance.MoveDirection.x, 0, InputController.Instance.MoveDirection.y);

            transform.position += direction * _speed;

            //transform.Translate(direction * _speed * Time.deltaTime);

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
        }
        #endregion
    }
}