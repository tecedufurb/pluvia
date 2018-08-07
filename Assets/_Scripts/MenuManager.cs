using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	/// <summary>
    /// Closes the game.
    /// </summary>
    public void QuitGame () {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
	/// <summary>
	/// Loads any scene from the project.
	/// </summary>
	/// <param name="scene">The name of the scene to be loaded.</param>
    public void LoadScene (string scene) {
        SceneManager.LoadScene(scene);
    }
}
