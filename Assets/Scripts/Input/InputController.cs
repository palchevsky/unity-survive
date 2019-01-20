using UnityEngine;

namespace Survive
{
    public class InputController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private readonly float _minThreshold;

        private static InputController instance;

        private bool _isTouchMoving;
        private Vector3 _moveDirection;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        #endregion

        #region Properties
        public static InputController Instance => instance;

        public Vector3 MoveDirection => _moveDirection;

        public float turnSpeed = 50f;
        public float moveSpeed = 10f;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        private void Update()
        {
            if (Input.touchSupported)
            {
                if (Input.touches.Length > 0)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        _isTouchMoving = true;
                        _startPosition = Input.touches[0].position;
                    }
                    else if (Input.touches[0].phase == TouchPhase.Ended)
                    {
                        _isTouchMoving = false;
                    }

                    _currentPosition = Input.touches[0].position;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _isTouchMoving = true;
                    _startPosition = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _isTouchMoving = false;
                }

                _currentPosition = Input.mousePosition;
            }

            if (_isTouchMoving)
            {
                if (Vector3.Distance(_currentPosition, _startPosition) > _minThreshold)
                {
                    Vector3 direction = (_currentPosition - _startPosition).normalized;

                    if (direction != Vector3.zero)
                    {
                        _startPosition = _currentPosition;
                        _moveDirection = direction;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 direction = (Vector3.forward + _startPosition).normalized;

                if (direction != Vector3.zero)
                {
                    _startPosition += Vector3.forward;
                    _moveDirection = direction;
                }


                //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 direction = (-_startPosition).normalized;

                if (direction != Vector3.zero)
                {
                    _startPosition -= Vector3.forward;
                    _moveDirection = direction;
                }


                //transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 direction = (Vector3.up - _startPosition).normalized;

                if (direction != Vector3.zero)
                {
                    _startPosition -= Vector3.up;
                    _moveDirection = direction;
                }


//                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 direction = (Vector3.up + _startPosition).normalized;

                if (direction != Vector3.zero)
                {
                    _startPosition += Vector3.up;
                    _moveDirection = direction;
                }

                //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
            else
            {
                _moveDirection = Vector3.zero;
            }

        }
        #endregion    
    }
}