using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string mainScene;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(mainScene);
    }
}
