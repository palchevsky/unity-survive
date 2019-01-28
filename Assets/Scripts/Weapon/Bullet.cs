using UnityEngine;

namespace Survive
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _maxLifetime;
        [SerializeField]
        private Rigidbody _rigidbody;

        private Vector3 _direction;
        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            _rigidbody.velocity = _direction * _speed;

            Quaternion rotation = Quaternion.LookRotation(_direction, Vector3.up);
            _rigidbody.rotation = rotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }

        public void Init(Vector3 direction)
        {
            _direction = direction;
            Destroy(gameObject, _maxLifetime);
        }

    }
}