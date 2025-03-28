using UnityEngine;

public class TesTScript : MonoBehaviour
{

    [SerializeField] private ConfirmationWindow myConfirmationWindow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OpenConfirmationWindow("Are you sure?");
    }

   public void OpenConfirmationWindow(string message)
   {
        myConfirmationWindow.gameObject.SetActive(true);
        myConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        myConfirmationWindow.noButton.onClick.AddListener(NoClicked);
        myConfirmationWindow.messageText.text = message;
   }
   
    public void YesClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked.");
        Application.Quit();
    }

    public void NoClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked.");
    }

}
