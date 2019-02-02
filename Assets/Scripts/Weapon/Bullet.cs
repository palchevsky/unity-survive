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

        private void Update()
        {
            _rigidbody.velocity = _direction * _speed;
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