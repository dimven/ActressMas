﻿/**************************************************************************
 *                                                                        *
 *  Website:     https://github.com/florinleon/ActressMas                 *
 *  Description: Mechanism design using the ActressMas framework          *
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
using System.Threading;

namespace MechanismDesign
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var env = new TurnBasedEnvironment(100, 0, false);

            Utils.AisLying = false;
            var agentA = new BeneficiaryAgent(); env.Add(agentA, "a");
            var agentB = new BeneficiaryAgent(); env.Add(agentB, "b");
            var agentC = new BeneficiaryAgent(); env.Add(agentC, "c");
            var dmAgent = new DecisionMakerAgent(); env.Add(dmAgent, "dm");

            env.Start();

            Thread.Sleep(1000);
            Console.WriteLine("\r\n");

            Utils.AisLying = true;
            env.Add(agentA, "a");
            env.Add(agentB, "b");
            env.Add(agentC, "c");
            env.Add(dmAgent, "dm");

            env.Continue();
        }
    }
}