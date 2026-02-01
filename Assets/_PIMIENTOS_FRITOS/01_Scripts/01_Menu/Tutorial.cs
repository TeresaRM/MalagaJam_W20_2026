using UnityEngine;

public class PanelUI : MonoBehaviour
{
    public GameObject panel;

    public void AbrirPanel()
    {
        panel.SetActive(true);
    }

    public void CerrarPanel()
    {
        panel.SetActive(false);
    }
}
