using UnityEngine;
using System.Collections;

public interface ICharacter {

    Status getStatus();
    void recebeDano(int dano);
}
