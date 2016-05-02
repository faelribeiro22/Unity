using UnityEngine;
using System.Collections;

public class Status {
    private int hp;
    private int hpMax;
    private int mp;
    private int mpMax;
    private int ataque;
    private int exp = 1;
    private int nivel = 1;

    public Status() { }

    public Status(int novoHp, int novoMP, int novoAtaque)
    {
        this.hpMax = this.hp = novoHp;
        this.mp = this.mpMax = novoMP;
        this.ataque = novoAtaque;
    }

    public int getHp()
    {
        return hp;
    }

    public int getMPMax()
    {
        return mpMax;
    }

    public int getMp()
    {
        return mp;
    }

    public int getHpMax()
    {
        return hpMax;
    }

    public int getAtaque()
    {
        return ataque;
    }

    public int getExp()
    {
        return exp;
    }

    public int getNivel()
    {
        return nivel;
    }

    public void setHP(int hp)
    {
        if (hp > this.hpMax)
            hp = this.hpMax;
        this.hp = hp;
    }

    public void setMP(int mp)
    {
        if (mp > this.mpMax)
            mp = this.mpMax;
        this.mp = mp;
    }

    public void setHpMax(int hpMax)
    {
        this.hpMax = hpMax; 
    }

    public void setMPMax(int mpMax)
    {
        this.mpMax = mpMax;
    }

    public void setAtaque(int ataque)
    {
        this.ataque = ataque;
    }

    public void setExp(int exp)
    {
        this.exp = exp;
        this.nivel = (int)System.Math.Ceiling(exp / 100.00);
    }

    public void sofrerDano(int dano)
    {
        this.hp -= dano;
        if (this.hp < 0)
            this.hp = 0;
    }

    public void recuperarHP(int valor)
    {
        this.hp += valor;
        if (this.hp > this.hpMax)
            this.hp = this.hpMax;
    }

    public bool usaMagia(int mp)
    {
        if (this.mp < mp)
            return false;
        this.mp -= mp;
        return true;
    }

    public void recuperarMagia(int valor)
    {
        this.mp += valor;
        if (this.mp > this.mpMax)
            this.mp = this.mpMax;
    }

    public void adicionaExp(int valor)
    {
        exp += valor;
        nivel = (int)System.Math.Ceiling(exp / 100.00);
    }

    public bool estarMorto()
    {
        return this.hp == 0;
    }
}
