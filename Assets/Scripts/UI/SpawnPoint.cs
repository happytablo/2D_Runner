using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool CheckWay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        if(!hit)
            return false;
        return hit.collider.TryGetComponent(out Player player);
    }
}
