using System.Collections;
using System.Linq;
using UnityEngine;

namespace Survive
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private Enemy _enemyPrefab;
        [SerializeField]
        private float _respawnTime;
        [SerializeField]
        private int _enemiesOnMap;
        private Enemy[] _enemies;
        private Bounds _bounds;
        #endregion

        private void Start()
        {
            _bounds = Level.Instance.Floor.bounds;
            _enemies = new Enemy[_enemiesOnMap];

            for (int e = 0; e < _enemiesOnMap; e++)
            {
                float x = Random.Range(_bounds.min.x, _bounds.max.x);
                float z = Random.Range(_bounds.min.z, _bounds.max.z);

                _enemies[e] = Instantiate(_enemyPrefab, new Vector3(x, 0f, z), Quaternion.identity);
                _enemies[e].transform.parent = transform;
                _enemies[e].Spawner = this;
            }
        }

        public void RespawnEnemy(Enemy enemy)
        {
            if (_enemies.Contains(enemy))
            {
                enemy.gameObject.SetActive(false);

                StartCoroutine("CoRespawnEnemy", enemy);
            }
        }

        private IEnumerator CoRespawnEnemy(Enemy enemy)
        {
            yield return new WaitForSeconds(_respawnTime);

            float x = Random.Range(_bounds.min.x, _bounds.max.x);
            float z = Random.Range(_bounds.min.z, _bounds.max.z);

            Vector3 position = enemy.transform.position;
            position.x = x;
            position.z = z;
            enemy.transform.position = position;
            enemy.gameObject.SetActive(true);
            enemy.SetDefaultParams();
        }
    }
}