using Super.Contabilita.Commands.Builders.Appaltatore;
using Super.Contabilita.Commands.Builders.CategoriaCommerciale;
using Super.Contabilita.Commands.Builders.Committente;
using Super.Contabilita.Commands.Builders.DirezioneRegionale;
using Super.Contabilita.Commands.Builders.Impianto;
using Super.Contabilita.Commands.Builders.Intervento;
using Super.Contabilita.Commands.Builders.Lotto;
using Super.Contabilita.Commands.Builders.MeasuringUnit;
using Super.Contabilita.Commands.Builders.PeriodoProgrammazione;
using Super.Contabilita.Commands.Builders.TipoIntervento;

namespace Super.Contabilita.Commands.Builders
{
    public static class Build
    {
        public static CreateImpiantoBuilder CreateImpianto { get { return new CreateImpiantoBuilder(); } }

        public static UpdateImpiantoBuilder UpdateImpianto { get { return new UpdateImpiantoBuilder(); } }

        public static DeleteImpiantoBuilder DeleteImpianto { get { return new DeleteImpiantoBuilder(); } }

        public static CreateLottoBuilder CreateLotto { get { return new CreateLottoBuilder(); } }

        public static UpdateLottoBuilder UpdateLotto { get { return new UpdateLottoBuilder(); } }

        public static DeleteLottoBuilder DeleteLotto { get { return new DeleteLottoBuilder(); } }

        public static CreateAppaltatoreBuilder CreateAppaltatore { get { return new CreateAppaltatoreBuilder(); } }

        public static UpdateAppaltatoreBuilder UpdateAppaltatore { get { return new UpdateAppaltatoreBuilder(); } }

        public static DeleteAppaltatoreBuilder DeleteAppaltatore { get { return new DeleteAppaltatoreBuilder(); } }

        public static CreateCategoriaCommercialeBuilder CreateCategoriaCommerciale { get { return new CreateCategoriaCommercialeBuilder(); } }

        public static UpdateCategoriaCommercialeBuilder UpdateCategoriaCommerciale { get { return new UpdateCategoriaCommercialeBuilder(); } }

        public static DeleteCategoriaCommercialeBuilder DeleteCategoriaCommerciale { get { return new DeleteCategoriaCommercialeBuilder(); } }

        public static CreateCommittenteBuilder CreateCommittente { get { return new CreateCommittenteBuilder(); } }

        public static UpdateCommittenteBuilder UpdateCommittente { get { return new UpdateCommittenteBuilder(); } }

        public static DeleteCommittenteBuilder DeleteCommittente { get { return new DeleteCommittenteBuilder(); } }

        public static CreateDirezioneRegionaleBuilder CreateDirezioneRegionale { get { return new CreateDirezioneRegionaleBuilder(); } }

        public static UpdateDirezioneRegionaleBuilder UpdateDirezioneRegionale { get { return new UpdateDirezioneRegionaleBuilder(); } }

        public static DeleteDirezioneRegionaleBuilder DeleteDirezioneRegionale { get { return new DeleteDirezioneRegionaleBuilder(); } }

        public static CreateMeasuringUnitBuilder CreateMeasuringUnit { get { return new CreateMeasuringUnitBuilder(); } }

        public static UpdateMeasuringUnitBuilder UpdateMeasuringUnit { get { return new UpdateMeasuringUnitBuilder(); } }

        public static DeleteMeasuringUnitBuilder DeleteMeasuringUnit { get { return new DeleteMeasuringUnitBuilder(); } }

        public static CreatePeriodoProgrammazioneBuilder CreatePeriodoProgrammazione { get { return new CreatePeriodoProgrammazioneBuilder(); } }

        public static UpdatePeriodoProgrammazioneBuilder UpdatePeriodoProgrammazione { get { return new UpdatePeriodoProgrammazioneBuilder(); } }

        public static DeletePeriodoProgrammazioneBuilder DeletePeriodoProgrammazione { get { return new DeletePeriodoProgrammazioneBuilder(); } }

        public static ClosePeriodoProgrammazioneBuilder ClosePeriodoProgrammazione { get { return new ClosePeriodoProgrammazioneBuilder(); } }

        public static CalculateInterventoRotPriceOfPlanBuilder CalculateInterventoRotPriceOfPlan { get { return new CalculateInterventoRotPriceOfPlanBuilder(); } }

        public static CancelInterventoPriceOfPlanBuilder CancelInterventoPriceOfPlan { get { return new CancelInterventoPriceOfPlanBuilder(); } }

        public static CreateTipoInterventoAmbBuilder CreateTipoInterventoAmb { get { return new CreateTipoInterventoAmbBuilder(); } }

        public static UpdateTipoInterventoAmbBuilder UpdateTipoInterventoAmb { get { return new UpdateTipoInterventoAmbBuilder(); } }

        public static DeleteTipoInterventoAmbBuilder DeleteTipoInterventoAmb { get { return new DeleteTipoInterventoAmbBuilder(); } }

        public static CreateTipoInterventoRotBuilder CreateTipoInterventoRot { get { return new CreateTipoInterventoRotBuilder(); } }

        public static UpdateTipoInterventoRotBuilder UpdateTipoInterventoRot { get { return new UpdateTipoInterventoRotBuilder(); } }

        public static DeleteTipoInterventoRotBuilder DeleteTipoInterventoRot { get { return new DeleteTipoInterventoRotBuilder(); } }

        public static CreateTipoInterventoRotManBuilder CreateTipoInterventoRotMan { get { return new CreateTipoInterventoRotManBuilder(); } }

        public static UpdateTipoInterventoRotManBuilder UpdateTipoInterventoRotMan { get { return new UpdateTipoInterventoRotManBuilder(); } }

        public static DeleteTipoInterventoRotManBuilder DeleteTipoInterventoRotMan { get { return new DeleteTipoInterventoRotManBuilder(); } }
    }
}