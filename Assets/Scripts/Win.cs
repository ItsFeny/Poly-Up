using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flag"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
