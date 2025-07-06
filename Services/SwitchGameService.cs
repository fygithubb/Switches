using System.Text.Json.Serialization;

namespace Switches.Services
{
    public class SwitchGameService
    {
        [JsonInclude]
        public int[] toggleMasks = new int[]
        {
            0b110,   //Switch A affect A and B
            0b011,   // Switch B affects B and C
            0b001    // Switch C affects C
        };

        [JsonInclude]
        public int CurrentState { get; private set; } = 0b000;

        [JsonInclude]
        public int MoveCount { get; private set; } = 0;

        [JsonInclude]
        public int MaxMoves { get; private set; } = 4;


        //status properties
        public bool IsComplete => CurrentState == 0b111;
        public bool OutOfMoves => MoveCount >= MaxMoves;

        //current should be returned as binary string
        public string GetStateString()
        {
            return Convert.ToString(CurrentState, 2).PadLeft(3, '0');
        }


        public void PressSwitch(int index)
        {
            if (IsComplete || OutOfMoves) return;
            if (index < 0 || index >= toggleMasks.Length ) return;

            CurrentState ^= toggleMasks[index];
            MoveCount++;
        }


        public void Reset()
        {
            CurrentState = 0b000;
            MoveCount = 0;
        }



    }
}
