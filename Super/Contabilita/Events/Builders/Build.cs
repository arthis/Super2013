using Super.Contabilita.Events.Builders.Appaltatore;
using Super.Contabilita.Events.Builders.CategoriaCommerciale;
using Super.Contabilita.Events.Builders.Committente;
using Super.Contabilita.Events.Builders.DirezioneRegionale;
using Super.Contabilita.Events.Builders.Impianto;
using Super.Contabilita.Events.Builders.Intervento;
using Super.Contabilita.Events.Builders.Lotto;
using Super.Contabilita.Events.Builders.MeasuringUnit;
using Super.Contabilita.Events.Builders.PeriodoProgrammazione;
using Super.Contabilita.Events.Builders.TipoIntervento;

namespace Super.Contabilita.Events.Builders
{
    public static class Build
    {
        public static ImpiantoCreatedBuilder ImpiantoCreated { get { return new ImpiantoCreatedBuilder(); } }

        public static ImpiantoUpdatedBuilder ImpiantoUpdated { get { return new ImpiantoUpdatedBuilder(); } }

        public static ImpiantoDeletedBuilder ImpiantoDeleted { get { return new ImpiantoDeletedBuilder(); } }

        public static LottoCreatedBuilder LottoCreated { get { return new LottoCreatedBuilder(); } }

        public static LottoUpdatedBuilder LottoUpdated { get { return new LottoUpdatedBuilder(); } }

        public static LottoDeletedBuilder LottoDeleted { get { return new LottoDeletedBuilder(); } }

        public static AppaltatoreCreatedBuilder AppaltatoreCreated { get { return new AppaltatoreCreatedBuilder(); } }

        public static AppaltatoreUpdatedBuilder AppaltatoreUpdated { get { return new AppaltatoreUpdatedBuilder(); } }

        public static AppaltatoreDeletedBuilder AppaltatoreDeleted { get { return new AppaltatoreDeletedBuilder(); } }

        public static CategoriaCommercialeCreatedBuilder CategoriaCommercialeCreated { get { return new CategoriaCommercialeCreatedBuilder(); } }

        public static CategoriaCommercialeUpdatedBuilder CategoriaCommercialeUpdated { get { return new CategoriaCommercialeUpdatedBuilder(); } }

        public static CategoriaCommercialeDeletedBuilder CategoriaCommercialeDeleted { get { return new CategoriaCommercialeDeletedBuilder(); } }

        public static CommittenteCreatedBuilder CommittenteCreated { get { return new CommittenteCreatedBuilder(); } }

        public static CommittenteUpdatedBuilder CommittenteUpdated { get { return new CommittenteUpdatedBuilder(); } }

        public static CommittenteDeletedBuilder CommittenteDeleted { get { return new CommittenteDeletedBuilder(); } }

        public static DirezioneRegionaleCreatedBuilder DirezioneRegionaleCreated { get { return new DirezioneRegionaleCreatedBuilder(); } }

        public static DirezioneRegionaleUpdatedBuilder DirezioneRegionaleUpdated { get { return new DirezioneRegionaleUpdatedBuilder(); } }

        public static DirezioneRegionaleDeletedBuilder DirezioneRegionaleDeleted { get { return new DirezioneRegionaleDeletedBuilder(); } }

        public static MeasuringUnitCreatedBuilder MeasuringUnitCreated { get { return new MeasuringUnitCreatedBuilder(); } }

        public static MeasuringUnitUpdatedBuilder MeasuringUnitUpdated { get { return new MeasuringUnitUpdatedBuilder(); } }

        public static MeasuringUnitDeletedBuilder MeasuringUnitDeleted { get { return new MeasuringUnitDeletedBuilder(); } }

        public static PeriodoProgrammazioneCreatedBuilder PeriodoProgrammazioneCreated { get { return new PeriodoProgrammazioneCreatedBuilder(); } }

        public static PeriodoProgrammazioneUpdatedBuilder PeriodoProgrammazioneUpdated { get { return new PeriodoProgrammazioneUpdatedBuilder(); } }

        public static PeriodoProgrammazioneDeletedBuilder PeriodoProgrammazioneDeleted { get { return new PeriodoProgrammazioneDeletedBuilder(); } }

        public static PeriodoProgrammazioneClosedBuilder PeriodoProgrammazioneClosed { get { return new PeriodoProgrammazioneClosedBuilder(); } }

        public static InterventoPriceOfPlanCalculatedBuilder InterventoPriceOfPlanCalculated { get { return new InterventoPriceOfPlanCalculatedBuilder(); } }

        public static InterventoPriceOfPlanCancelledBuilder InterventoPriceOfPlanCancelled { get { return new InterventoPriceOfPlanCancelledBuilder(); } }

        public static TipoInterventoAmbCreatedBuilder TipoInterventoAmbCreated { get { return new TipoInterventoAmbCreatedBuilder(); } }

        public static TipoInterventoAmbUpdatedBuilder TipoInterventoAmbUpdated { get { return new TipoInterventoAmbUpdatedBuilder(); } }

        public static TipoInterventoAmbDeletedBuilder TipoInterventoAmbDeleted { get { return new TipoInterventoAmbDeletedBuilder(); } }

        public static TipoInterventoRotCreatedBuilder TipoInterventoRotCreated { get { return new TipoInterventoRotCreatedBuilder(); } }

        public static TipoInterventoRotUpdatedBuilder TipoInterventoRotUpdated { get { return new TipoInterventoRotUpdatedBuilder(); } }

        public static TipoInterventoRotDeletedBuilder TipoInterventoRotDeleted { get { return new TipoInterventoRotDeletedBuilder(); } }

        public static TipoInterventoRotManCreatedBuilder TipoInterventoRotManCreated { get { return new TipoInterventoRotManCreatedBuilder(); } }

        public static TipoInterventoRotManUpdatedBuilder TipoInterventoRotManUpdated { get { return new TipoInterventoRotManUpdatedBuilder(); } }

        public static TipoInterventoRotManDeletedBuilder TipoInterventoRotManDeleted { get { return new TipoInterventoRotManDeletedBuilder(); } }
    }
}