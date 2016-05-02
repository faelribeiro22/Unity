using UnityEngine;
using System.Collections;

public interface ISkill{

    void setPersonagem(GameObject personagem);
    int getCustoHabilidade();
    void executar();
}
