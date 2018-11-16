﻿/**************************************************************************
 *                                                                        *
 *  Website:     https://github.com/florinleon/ActressMas                 *
 *  Description: Iterated Prisoner's Dilemma using ActressMas framework   *
 *  Copyright:   (c) 2018, Florin Leon                                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using ActressMas;
using System;

namespace IteratedPrisonersDilemma
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var env = new IPDEnvironment(Utils.NoTurns);

            //var prisonerAgent1 = new ConfessPrisonerAgent();
            //var prisonerAgent2 = new RandomPrisonerAgent();
            var prisonerAgent1 = new TitForTatPrisonerAgent();
            var prisonerAgent2 = new TitForTatPrisonerAgent();

            env.Add(prisonerAgent1, "p1-" + prisonerAgent1.GetType().Name);
            env.Add(prisonerAgent2, "p2-" + prisonerAgent2.GetType().Name);

            var policeAgent = new PoliceAgent();
            env.Add(policeAgent, "police");

            env.Start();
        }

        public class IPDEnvironment : TurnBasedEnvironment
        {
            private int _noTurns;

            public IPDEnvironment(int noTurns)
                : base(noTurns * 2 + 2, 0, false)
            {
                _noTurns = noTurns * 2;
            }

            public override void TurnFinished(int turn)
            {
                if (turn < _noTurns && turn % 2 == 0)
                    Console.WriteLine("Round {0}", turn / 2 + 1);
                else if (turn == _noTurns)
                    Console.WriteLine("Results");

                if (turn == _noTurns - 1)
                {
                    foreach (TurnBasedAgent a in this.Agents)
                    {
                        if (a.Name != "police")
                            Send(new Message("env", a.Name, "end"));
                    }
                }
            }
        }
    }
}