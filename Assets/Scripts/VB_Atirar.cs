using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]

public class VB_Atirar : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject BalaBase;

    [SerializeField]
    private GameObject flash;

    public Rigidbody bulletRigidbody;
    private float bulletVelocity = 1500f;

    private AudioSource som;
    public AudioClip audio_tiro;
    public AudioClip audio_headshot;

    public static int balas;
    public static bool headshot;
    
    void Start ()
    {
        balas = 0;
        headshot = false;
        //procura o componente de audio
        som = GetComponent<AudioSource>();
        //procura o botao virtual
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
        //pega o objeto bala para ter um ponto de saida para os tiros
        BalaBase = transform.FindChild("Bala Base").gameObject;
        BalaBase.SetActive(true);
    }

    void Update()
    {
        if (headshot == true) {
            headshot = false;
            TocaSom(audio_headshot);
        }
    }


    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        //se apertar o gatilho e tiver balas para atirar
        if (vb.VirtualButtonName == "VB Gatilho" && balas > 0)
        {
            //cria um clone da bala
            Rigidbody instance = (Rigidbody)Instantiate(bulletRigidbody, BalaBase.transform.position, BalaBase.transform.rotation);
                
            //transforma escala da bala para tamanho correto
            instance.transform.localScale = new Vector3 (transform.lossyScale.x * instance.transform.localScale.x, transform.lossyScale.y * instance.transform.localScale.y, transform.lossyScale.z * instance.transform.localScale.z);
            
            //define direcao do tiro
            Vector3 direction = transform.TransformDirection(0,-1,0);
            
            //aplica força na bala
            instance.AddForce(direction * bulletVelocity);

            //decrementa numero de balas
            balas--;

            //destroy a bala apos x segundos
            Destroy(instance.gameObject, 1.5f);

            //animacao do flash no tiro
            StartCoroutine(GunFlash());

            //toca som de um tiro
            TocaSom(audio_tiro);
        }
    }

    IEnumerator GunFlash ()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        flash.SetActive(false);
    }

    void TocaSom (AudioClip audio)
    {
        som.Stop();
        som.clip = audio;
        som.Play();
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        //Debug.Log("Botao solto");
    }

}
