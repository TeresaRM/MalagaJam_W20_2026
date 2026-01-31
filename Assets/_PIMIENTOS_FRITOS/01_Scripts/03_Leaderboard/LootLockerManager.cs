using UnityEngine;
using LootLocker.Requests;

public class LootLockerManager : MonoBehaviour
{
    public static LootLockerManager lootLockerManagerInstance;

    private void Awake()
    {
        if (lootLockerManagerInstance == null)
        {
            lootLockerManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start() => StartGuestSession();

    private void StartGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success) Debug.LogError("Failed to start LootLocker session. Error: " + response.errorData.ToString());
        });
    }
}