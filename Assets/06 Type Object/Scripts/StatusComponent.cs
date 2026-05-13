using System.Collections.Generic;
using UnityEngine;

namespace TypeObject
{
    public class StatusComponent : MonoBehaviour
    {
        // Lo ideal seria usar clases para los status
        // Clase abstracta Status y clases concretas para cada una
        // Asi podemos decirle a cada status que aplique su effecto al chequearla
        Dictionary<Status, int> statusStacks;

        void Awake() { InitializeStatus(); }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        void InitializeStatus()
        {
            statusStacks = new Dictionary<Status, int>();
            statusStacks.Add(Status.Burn, 0);
            statusStacks.Add(Status.Poison, 0);
            statusStacks.Add(Status.Break, 0);
            statusStacks.Add(Status.Doom, 0);
        }

        public void InflictStatus(Status inflicted, int stacks) { statusStacks[inflicted] += stacks; }

        public void HealStatus(Status toHeal) { statusStacks[toHeal] = 0; }
    }

    public enum Status { Burn, Poison, Break, Doom }
}