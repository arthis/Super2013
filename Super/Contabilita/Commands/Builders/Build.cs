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
        
    }
}