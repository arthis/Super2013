using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class CreateTipoInterventoRotBuilder : ICommandBuilder<CreateTipoInterventoRot>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;
        private bool _calcoloDetrazioni;
        private bool _aiTreni;
        private char _classe;

        public CreateTipoInterventoRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateTipoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateTipoInterventoRot(id, commitId, version, _mnemo, _idMeasuringUnit, _classe,_calcoloDetrazioni,_aiTreni ,_description);

            return cmd;
        }



        public CreateTipoInterventoRotBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public CreateTipoInterventoRotBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

        public CreateTipoInterventoRotBuilder ForCalcoloDetrazioni(bool calcoloDetrazioni)
        {
            _calcoloDetrazioni = calcoloDetrazioni;
            return this;
        }

        public CreateTipoInterventoRotBuilder ForAiTreni(bool aiTreni)
        {
            _aiTreni = aiTreni;
            return this;
        }

        public CreateTipoInterventoRotBuilder ForAiClasse(char classe)
        {
            _classe = classe;
            return this;
        }

        public CreateTipoInterventoRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
