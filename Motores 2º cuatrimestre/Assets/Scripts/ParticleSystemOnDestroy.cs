using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemOnDestroy : MonoBehaviour
{
    public ParticleSystem particleSystemOnDestroy;//sistema de particulas del objeto que es destruido
    //variable publica del sonido del objeto

    private void OnDestroy()
    {
        Instantiate(particleSystemOnDestroy, transform.position, Quaternion.identity);//crea el sistema de particulas en el centro del objeto
        //llamar al sonido del objeto destruido
       // Destroy(particleSystemOnDestroy, 3f);
    }
}
