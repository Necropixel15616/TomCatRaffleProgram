﻿using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    public class CreateRaffleInputPort : IInputPort<ICreateRaffleOutputPort>
    {

        public string RaffleName { get; set; }

    }
}
