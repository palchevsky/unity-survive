using UnityEngine;
using UnityEngine.UI;
namespace Survive
{
    public class Score : MonoBehaviour
    {
        public static int scoreValue = 0;
        private Text scoreText;

        private void Start()
        {
            scoreText = GetComponent<Text>();
        }

        private void Update()
        {
            scoreText.text = $"Score: {scoreValue.ToString()}";
        }
    }
}