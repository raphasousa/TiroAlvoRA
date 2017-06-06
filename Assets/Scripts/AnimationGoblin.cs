using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGoblin : MonoBehaviour {

    [SerializeField]
    private Animation alvo;

    private float speed = 0.2f;
    private float speedF = 0.1f;
	
	// Update is called once per frame
	void Update () {
        //se atingir limite de pontos
        if (HitTarget.points >= HitTarget.lim_points)
        {
            //animação de morte
            alvo.CrossFade("death");
            //destroi o goblin ao fim da animação
            Destroy(gameObject, 2.8f);
        }
        else
        {
            //se chegar em uma posição limite, inverte
            if (transform.position.x > 0.3f || transform.position.x < -0.3f) speed = -speed;
            if (transform.position.z > 4.3f || transform.position.z < 3.7f) speedF = -speedF;

            //faz o Goblin andar para frente e para o lado
            transform.Translate((speed * Time.deltaTime), 0, (speedF * Time.deltaTime));
        }
    }
}
