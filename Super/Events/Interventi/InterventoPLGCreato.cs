﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    public abstract class InterventoPLGCreato
    {
        public Guid Id { get; set; }
        public int InterventoIdSuper { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public DateTime DataCreazione { get; set; }
    }

    public class InterventoPLGRotCreato : InterventoPLGCreato
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }
    }

    public class InterventoPLGAmbCreato : InterventoPLGCreato
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }
    }

    public class InterventoPLGRotManCreato : InterventoPLGCreato
    {
        public IEnumerable<OggettoRotMan> Oggetti { get; set; }
    }
}
