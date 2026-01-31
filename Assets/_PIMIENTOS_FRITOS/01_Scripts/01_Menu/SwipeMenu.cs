using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] private GameObject scrollBar;
    [SerializeField] private float scrollSmoothness = 0.0075f;
    [SerializeField] private float zoomSmoothness = 0.005f;
    private float scrollPosition = 0f;
    private float[] positions;

    private void Update()
    {
        int menuItems = transform.childCount;
        positions = new float[menuItems];
        float distance = 1f / (positions.Length - 1f);

        for (int i = 0; i < positions.Length; i++) positions[i] = distance * i;

        if (Input.GetMouseButton(0))
        {
            scrollPosition = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (scrollPosition < positions[i] + (distance / 2) && scrollPosition > positions[i] - (distance / 2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, positions[i], scrollSmoothness);
                }
            }
        }

        for (int i = 0; i < positions.Length; i++)
        {
            if (scrollPosition < positions[i] + (distance / 2) && scrollPosition > positions[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), zoomSmoothness);
                for (int j = 0; j < positions.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), zoomSmoothness);
                    }
                }
            }
        }
    }
}