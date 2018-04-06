using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    interface IDestruible
    {
        float Vidas { get; set; }

        float ReducirVidas(float dano);
    }
}
