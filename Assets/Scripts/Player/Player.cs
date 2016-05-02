using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour,ICharacter {

    protected Status status;
    public Animator animator;
    public float velocidade;
    public float forcaPulo;
    protected bool direita = true;
    public GameObject chaoVerificador;
    protected bool estaNoChao;
    public ISkill[] habilidades = new ISkill[3];

    public void recebeDano(int dano) {
        status.sofrerDano(dano);
    }

    void inverter() {
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    void mover() {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!direita)
                inverter();
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
            direita = true;
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            if (direita)
                inverter();
            transform.Translate(-Vector3.right * velocidade * Time.deltaTime);
            direita = false;
        }
    }

    public Status getStatus()
    {
        return status;
    }

    protected abstract void atacar();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mover();
        atacar();
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.transform.position, 1 << LayerMask.NameToLayer("Piso"));
        if(Input.GetButtonDown("Jump") && estaNoChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
	}
}
