using UnityEngine;

public class MainMenuUIScene : MonoBehaviour
{
    [SerializeField] private string downloadGameLink;

    public void ShareToWhatsapp()
    {
        Application.OpenURL("https://api.whatsapp.com/send?text=" + downloadGameLink);
    }
}
