﻿/**************************************************************************
 *                                                                        *
 *  Website:     https://github.com/florinleon/ActressMas                 *
 *  Description: Vickrey auction using the ActressMas framework           *
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
using System.Collections.Generic;

namespace VickreyAuction
{
    public class BidderAgent : TurnBasedAgent
    {
        private int _valuation;

        public BidderAgent(int val)
        {
            _valuation = val;
        }

        public override void Setup()
        {
            Console.WriteLine("[{0}]: My valuation is {1}", this.Name, _valuation);
        }

        public override void Act(Queue<Message> messages)
        {
            try
            {
                while (messages.Count > 0)
                {
                    Message message = messages.Dequeue();
                    Console.WriteLine("\t[{1} -> {0}]: {2}", this.Name, message.Sender, message.Content);

                    string action; string parameters;
                    Utils.ParseMessage(message.Content, out action, out parameters);

                    switch (action)
                    {
                        case "start":
                            HandleStart();
                            break;

                        case "winner":
                            HandleWinner(parameters);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleStart()
        {
            Send("auctioneer", Utils.Str("bid", _valuation));
        }

        private void HandleWinner(string winner)
        {
            if (winner == this.Name)
                Console.WriteLine("[{0}]: I have won.", this.Name);

            Stop();
        }
    }
}