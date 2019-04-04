﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BoggleService.Models
{
    /// <summary>
    /// Class to store all of the game information needed for each individual game.
    /// </summary>
    [DataContract]
    public class GameInfo
    {
        /// <summary>
        /// Stores the state of the game.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string GameState { get; set; }

        /// <summary>
        /// Stores the Boggle Board object of this current game.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BoggleBoard MisterBoggle;

        /// <summary>
        /// Stores the string version of the Boggle Board.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Board;

        /// <summary>
        /// Stores the time limit of this game, which is the average time of both players.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int TimeLimit { get; set; }

        /// <summary>
        /// Stores the time remaining for this current game.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int TimeLeft { get; set; }

        /// <summary>
        /// Stores the player information for player 1.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public PlayerInfo Player1;

        /// <summary>
        /// Stores the player information for player 2.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public PlayerInfo Player2;


        [DataMember(EmitDefaultValue = false)]
        public int startTime;

       // public int currentTime;

        
        public void calculateTimeLeft()
        {
            TimeLeft = TimeLimit - (DateTime.Now.Second - startTime);

        }



        public GameInfo(BoggleBoard board)
        {
            MisterBoggle = board;
            Board = board.ToString();
            Player1 = new PlayerInfo();
            Player2 = new PlayerInfo();
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public GameInfo()
        {
            
        }
    }
}