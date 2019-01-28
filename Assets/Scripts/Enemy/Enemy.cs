using System.Collections;
using UnityEngine;
namespace Survive
{
    public class Enemy : MonoBehaviour
    {
        // Start is called before the first frame update
        #region Fields 
        [SerializeField]
        private string _damageLayer;
        private int _health = 100;
        #endregion

        /// <summary>
        /// OnCollisionEnter is called when this collider/rigidbody has begun
        /// touching another rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_damageLayer))
            {
                _health -= 20;
                Debug.Log($"Health: {_health}");
                if (_health <= 0)
                {
                    var prefab = gameObject.GetComponent<EnemyPrefab>()._prefab;
                    Destroy(gameObject);
                    StartCoroutine(SpawnObject(prefab));
                    _health = 100;
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

        private IEnumerator SpawnObject(GameObject prefab)
        {
            float x = Random.Range(-2.0f, 2.0f);
            float z = Random.Range(-2.0f, 2.0f);
            Instantiate(prefab, new Vector3(x, 2, z), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}