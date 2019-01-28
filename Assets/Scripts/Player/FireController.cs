using System.Collections;
using UnityEngine;

namespace Survive
{
    public class FireController : MonoBehaviour
    {
        // Start is called before the first frame update
        #region Variables
        [SerializeField]
        private Bullet _bulletPrefab;
        [SerializeField]
        private Transform _bulletStartPosition;
        [SerializeField]
        private float _fireDelay;
        [SerializeField]
        private string _targetLayer;
        private Enemy _enemy;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer))
            {
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    _enemy = enemy;
                    StartCoroutine("CoFire", other.transform.position);
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer) && _enemy == null)
            {
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    _enemy = enemy;
                    StartCoroutine("CoFire", other.transform.position);
                }
            }
        }

        /// <summary>
        /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer))
            {
                var enemy = other.GetComponent<Enemy>();

                if (enemy != null && _enemy == enemy)
                {
                    _enemy = null;
                    StopCoroutine("CoFire");
                }
            }

        }

        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        private IEnumerator CoFire(Vector3 targetPosition)
        {
            while (true)
            {
                if (_enemy == null)
                {
                    break;
                }
                Vector3 direction = (targetPosition - _bulletStartPosition.position).normalized;
                var bullet = Instantiate(_bulletPrefab, _bulletStartPosition.position, Quaternion.identity);
                bullet.Init(direction);

                yield return new WaitForSeconds(_fireDelay);
            }
        }
    }
}