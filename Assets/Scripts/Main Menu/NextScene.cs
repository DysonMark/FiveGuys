using UnityEngine;
using UnityEngine.SceneManagement;
namespace Leonardo.SceneChanger
{
    public class NextScene : MonoBehaviour
    {
        [SerializeField] private int sceneIndexToLoad;
        public void LoadNextScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }

        public void LoadSpecificScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        #region Debug purposes
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                LoadSpecificScene(sceneIndexToLoad);
            }
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                LoadNextScene();
            }
        }
        
        #endregion
    }
}