using UnityEngine;

namespace Survive
{
    public class Enemy : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private string _damageLayer;

        private EnemySpawner _spawner;
        private int _health = 100;
        [SerializeField]
        private Animator _animator;
        public EnemySpawner Spawner
        {
            set => _spawner = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_damageLayer))
            {
                _health -= 20;
                _animator.SetTrigger("RoundKick");
                Score.scoreValue += 10;
                if (_health <= 0)
                {
                    _health = 100;
                    Score.scoreValue += 10;
                    _spawner.RespawnEnemy(this);
                }
            }
        }

        public void SetDefaultParams()
        {
            _health = 100;
        }
    }
}