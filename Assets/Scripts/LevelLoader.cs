using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 10f)] float fadeDelay = 1f;
    CameraFade cameraFade;
    void Awake() 
    {
        cameraFade = GetComponent<CameraFade>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadLevel(0));
        }
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        cameraFade.FadeIn();

        yield return new WaitForSeconds(fadeDelay);
        
        SceneManager.LoadScene(sceneIndex);

        cameraFade.FadeOut();
    }


}
