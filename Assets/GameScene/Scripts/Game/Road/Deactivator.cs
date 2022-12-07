using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public void Deactivate() => gameObject.SetActive(false);
}
