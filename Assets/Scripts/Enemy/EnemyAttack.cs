using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerManager target;
    [SerializeField] int damage = 20;
    // [SerializeField] PlayerManager player;

    void Start()
    {
        target = FindObjectOfType<PlayerManager>();
    }
    public void NewEvent()
    {
        if(target == null) return;
        target.PlayerTakesDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageReceivedUI();
    }
}
