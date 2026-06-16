using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
   [SerializeField] private PlayableDirector playableDirector;

   public void ReloadLevel()
   {
      StartCoroutine(HandleSceneChange());
   }

   private IEnumerator HandleSceneChange()
   {
      playableDirector.Pause();

      yield return new WaitForSeconds(2f);

      var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
   }
}
