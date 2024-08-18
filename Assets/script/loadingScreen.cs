using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private float loadingTime;
    [SerializeField]
    private float rotationSpeed;
    public Image logo;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.instance.ChangeMusic(0);
        StartCoroutine(LoadingRoutine());
    }

    void Update()
    {
        logo.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }

    private IEnumerator LoadingRoutine()
    {
        while (loadingTime > 0)
        {
            loadingTime -= Time.deltaTime;
            yield return null;
        }

        // Ganti dengan nama atau indeks scene yang benar
        SceneManager.LoadScene(1);
    }
}
