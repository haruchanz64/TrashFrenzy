using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace TrashFrenzy.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadNextScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
