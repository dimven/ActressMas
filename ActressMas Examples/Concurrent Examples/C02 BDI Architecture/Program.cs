﻿/**************************************************************************
 *                                                                        *
 *  Website:     https://github.com/florinleon/ActressMas                 *
 *  Description: The BDI architecture using the ActressMas framework      *
 *  Copyright:   (c) 2018, Florin Leon                                    *
 *                                                                        *
 *  Acknowledgement:                                                      *
 *  The idea of this example is inspired by this project:                 *
 *  https://github.com/gama-platform/gama/wiki/UsingBDI                   *
 *  The actual implementation is completely original.                     *
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
using System.Threading;

namespace Bdi
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var env = new ConcurrentEnvironment();

            var terrainAgent = new TerrainAgent();
            env.Add(terrainAgent, "terrain");
            terrainAgent.Start();

            Thread.Sleep(100);

            var patrolAgent = new PatrolAgent();
            env.Add(patrolAgent, "patrol");
            patrolAgent.Start();

            env.WaitAll();
        }
    }
}