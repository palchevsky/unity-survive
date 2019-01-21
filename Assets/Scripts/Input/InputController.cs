using UnityEngine;

namespace Survive
{
    public class InputController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private readonly float _minThreshold;
        private bool _isTouchMoving;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        #endregion

        #region Properties
        public static InputController Instance { get; private set; }
        public Vector3 MoveDirection { get; private set; }
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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
                        MoveDirection = direction;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                MoveDirection = new Vector3(0, -1, 0);
            }

            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                MoveDirection = new Vector3(0, 1, 0);
            }

            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                MoveDirection = new Vector3(-1, 0, 0);
            }

            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                MoveDirection = new Vector3(1, 0, 0);
            }
            else
            {
                MoveDirection = Vector3.zero;
            }

        }
        #endregion    
    }
}