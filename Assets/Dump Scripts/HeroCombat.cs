//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HeroCombat : MonoBehaviour
//{
//    public enum HeroAttackType { Melee, Ranged};
//    public HeroAttackType heroAttackType;

//    public GameObject targetedEnemy;
//    public float attackRange;
//    public float rotateSpeedForAttack;

//    private Player moveScript;

//    public bool basicAttackIdle = false;
//    public bool isHeroAlive;
//    public bool performMeleeAttack = true;

//    // Start is called before the first frame update
//    void Start()
//    {
//        moveScript = GetComponent<Player>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (targetedEnemy != null) {
//            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange) {
//                moveScript.SetDestination(targetedEnemy.transform.position);
//                moveScript.StoppingDistance = attackRange;
//            }
//        }
//    }
//}
