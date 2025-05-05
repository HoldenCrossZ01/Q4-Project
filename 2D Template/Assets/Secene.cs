using UnityEngine;
using UnityEngine.SceneManagement;

public class Secene : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CreditLoader()
    {
        SceneManager.LoadScene("Laina");
    }
    public void CreditLoader2()
    {
        SceneManager.LoadScene("Coda");
    }
    public void CreditLoader3()
    {
        SceneManager.LoadScene("Thomas");
    }
    public void CreditLoader4()
    {
        SceneManager.LoadScene("Joshua");
    }
    public void CreditLoader5()
    {
        SceneManager.LoadScene("Meadow");
    }

}
